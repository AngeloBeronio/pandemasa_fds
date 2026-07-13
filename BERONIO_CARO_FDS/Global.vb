Imports MySql.Data.MySqlClient
Imports System.IO

Module [Global]
    Public conn As MySqlConnection
    Public connStr As String = "Server=localhost;Database=pan_de_masa_db;Uid=root;Pwd=;"
    Public LoggedInUserId As Integer
    Public CartItems As New List(Of CartItem)
    Public EmployeeID As Integer
    Public EmployeeName As String
    Public RoleID As Integer

    Public Sub OpenConnection()
        conn = New MySqlConnection(connStr)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Public Sub CloseConnection()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    ' MENU HEADER
    Public Function GetGreeting() As String
        Dim hour As Integer = DateTime.Now.Hour
        Dim greeting As String

        If hour >= 5 AndAlso hour < 12 Then
            greeting = "Good Morning"
        ElseIf hour >= 12 AndAlso hour < 18 Then
            greeting = "Good Afternoon"
        Else
            greeting = "Good Evening"
        End If

        Return greeting
    End Function

    ' DEFAULT MENU GRID SETUP
    Public Sub SetupMenuGrid(dgv As DataGridView)
        dgv.Columns.Clear()
        dgv.RowTemplate.Height = 110
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.RowHeadersVisible = False

        dgv.Columns.Add("colProductId", "ID")
        dgv.Columns.Add("colName", "Product")
        dgv.Columns.Add("colPrice", "Price")
        dgv.Columns.Add("colImagePath", "ImagePath")

        dgv.Columns("colProductId").Visible = False
        dgv.Columns("colImagePath").Visible = False
        dgv.Columns("colName").Width = 300
        dgv.Columns("colPrice").Width = 120
        dgv.Columns("colName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    ' LOAD PRODUCT IMAGE
    Public Sub LoadProductImage(pictureBox As PictureBox, imgPath As String)
        If pictureBox.Image IsNot Nothing Then
            Dim oldImage As Image = pictureBox.Image
            pictureBox.Image = Nothing
            oldImage.Dispose()
        End If

        Dim fullPath As String = Path.Combine(Application.StartupPath, imgPath)

        If imgPath <> "" AndAlso File.Exists(fullPath) Then
            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read)
                pictureBox.Image = Image.FromStream(fs)
            End Using
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom
        Else
            pictureBox.Image = Nothing
        End If
    End Sub

    ' SEPARATE MENU BY CATEGORY
    Public Sub LoadMenu(dgv As DataGridView, categoryName As String, pictureBox As PictureBox,
                        numericUpDown As NumericUpDown, ByRef selectedProductId As Integer,
                        ByRef selectedProductName As String, ByRef selectedPrice As Decimal)
        dgv.Rows.Clear()
        Try
            OpenConnection()

            Dim query As String =
                "SELECT p.product_id, p.product_name, p.selling_price, p.status, p.image_path
                 FROM products p
                 INNER JOIN categories c ON p.category_id = c.category_id
                 WHERE c.category_name = @category
                 ORDER BY p.selling_price ASC"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@category", categoryName)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim imgPath As String = If(IsDBNull(reader("image_path")), "", reader("image_path"))
                Dim status As String = reader("status").ToString()

                dgv.Rows.Add(
                    reader("product_id"),
                    reader("product_name"),
                    "₱" & CDec(reader("selling_price")).ToString("0.00"),
                    imgPath
                )

                Dim lastRow As DataGridViewRow = dgv.Rows(dgv.Rows.Count - 1)

                If status = "Unavailable" Then
                    lastRow.DefaultCellStyle.ForeColor = Color.Gray
                    lastRow.DefaultCellStyle.BackColor = Color.LightGray
                ElseIf status = "Low in Stock" Then
                    lastRow.DefaultCellStyle.ForeColor = Color.Orange
                End If
            End While

            reader.Close()

            If dgv.Rows.Count > 0 Then
                Dim firstRow As DataGridViewRow = dgv.Rows(0)
                firstRow.Selected = True
                dgv.CurrentCell = firstRow.Cells("colName")

                selectedProductId = CInt(firstRow.Cells("colProductId").Value)
                selectedProductName = firstRow.Cells("colName").Value.ToString()
                selectedPrice = CDec(firstRow.Cells("colPrice").Value.ToString().Replace("₱", ""))
                LoadProductImage(pictureBox, firstRow.Cells("colImagePath").Value.ToString())
                numericUpDown.Value = 1
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading menu: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub AddToCart(productId As Integer, productName As String,
                         price As Decimal, qty As Integer)
        Try
            OpenConnection()

            Dim stockQuery As String = "SELECT stock_quantity FROM products WHERE product_id = @id"
            Dim stockCmd As New MySqlCommand(stockQuery, conn)
            stockCmd.Parameters.AddWithValue("@id", productId)
            Dim currentStock As Integer = Convert.ToInt32(stockCmd.ExecuteScalar())

            Dim existing As CartItem = CartItems.FirstOrDefault(
                Function(c) c.ProductId = productId)
            Dim alreadyInCart As Integer = If(existing IsNot Nothing, existing.Quantity, 0)

            If alreadyInCart + qty > currentStock Then
                Dim remaining As Integer = currentStock - alreadyInCart
                If remaining <= 0 Then
                    MessageBox.Show("No more stock available for " & productName & ".",
                                    "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Only " & remaining & " left in stock for " & productName & ".",
                                    "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Exit Sub
            End If

            If existing IsNot Nothing Then
                existing.Quantity += qty
                existing.Total = existing.Quantity * existing.UnitPrice
            Else
                CartItems.Add(New CartItem With {
                    .ProductId = productId,
                    .ProductName = productName,
                    .Quantity = qty,
                    .UnitPrice = price,
                    .Total = price * qty
                })
            End If

            MessageBox.Show(qty & "x " & productName & " added to cart.",
                            "Added to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error checking stock: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub LoadLowStockWarning(targetListBox As ListBox)
        targetListBox.Items.Clear()

        If Not IsWarningTimeReached() Then
            targetListBox.Items.Add("(Low stock warning not active yet)")
            Exit Sub
        End If

        Try
            OpenConnection()
            Dim query As String =
                "SELECT product_name, stock_quantity " &
                "FROM products " &
                "WHERE status = 'Low in Stock' OR status = 'Unavailable' " &
                "ORDER BY stock_quantity ASC"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            Dim hasItems As Boolean = False
            While reader.Read()
                Dim productName As String = reader("product_name").ToString()
                Dim qty As Integer = Convert.ToInt32(reader("stock_quantity"))
                Dim statusLabel As String = If(qty <= 0, "[OUT]", "[LOW]")
                targetListBox.Items.Add(statusLabel & " " & productName & " — " & qty & " left")
                hasItems = True
            End While

            reader.Close()

            If Not hasItems Then
                targetListBox.Items.Add("All products are sufficiently stocked.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading low stock list: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Function IsWarningTimeReached() As Boolean
		Try
			OpenConnection()
			Dim query As String =
				"SELECT setting_value FROM set_ls_time WHERE setting_key = 'warning_time'"
			Dim cmd As New MySqlCommand(query, conn)
			Dim result As Object = cmd.ExecuteScalar()

			If result Is Nothing OrElse result Is DBNull.Value Then Return True

			Dim warningTime As TimeSpan
			If TimeSpan.TryParse(result.ToString(), warningTime) Then
				Return DateTime.Now.TimeOfDay < warningTime
			End If

			Return True
		Catch ex As Exception
			Return True
		Finally
			CloseConnection()
		End Try
	End Function

	' CART ITEM CLASS
	Public Class CartItem
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property Quantity As Integer
        Public Property UnitPrice As Decimal
        Public Property Total As Decimal
    End Class

End Module