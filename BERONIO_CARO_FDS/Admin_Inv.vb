Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data

Public Class Admin_Inv

    Private selectedProductId As Integer = -1
    Private selectedImagePath As String = ""

    Private Sub Admin_Inv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInventoryGrid()
        PopulateCategoryComboBox()
        LoadInventory()
    End Sub

    Private Sub SetupInventoryGrid()
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.RowTemplate.Height = 60
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowHeadersVisible = False

        DataGridView1.Columns.Add("colId", "ID")

        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "colImg"
        imgCol.HeaderText = "IMG"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        DataGridView1.Columns.Add(imgCol)

        DataGridView1.Columns.Add("colName", "NAME")
        DataGridView1.Columns.Add("colCategory", "CATEGORY")
        DataGridView1.Columns.Add("colQuantity", "QUANTITY")
        DataGridView1.Columns.Add("colCost", "COST PRICE")
        DataGridView1.Columns.Add("colPrice", "SELLING PRICE")
        DataGridView1.Columns.Add("colStatus", "STATUS")
        DataGridView1.Columns.Add("colCategoryId", "CategoryId")
        DataGridView1.Columns.Add("colImagePath", "ImagePath")

        DataGridView1.Columns("colId").Visible = False
        DataGridView1.Columns("colCategoryId").Visible = False
        DataGridView1.Columns("colImagePath").Visible = False
        DataGridView1.Columns("colName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub LoadInventory()
        Try
            OpenConnection()
            DataGridView1.Rows.Clear()

            Dim query As String = "SELECT p.product_id, p.product_name, c.category_name, p.stock_quantity, p.estimated_cost, p.selling_price, p.status, p.image_path, p.category_id FROM products p LEFT JOIN categories c ON p.category_id = c.category_id"

            Dim hasFilter As Boolean = False

            If CheckBox1.Checked Or CheckBox2.Checked Or CheckBox3.Checked Or CheckBox4.Checked Or CheckBox5.Checked Then
                query &= " WHERE c.category_name IN ("

                If CheckBox1.Checked Then
                    query &= "@cat1,"
                    hasFilter = True
                End If
                If CheckBox2.Checked Then
                    query &= "@cat2,"
                    hasFilter = True
                End If
                If CheckBox3.Checked Then
                    query &= "@cat3,"
                    hasFilter = True
                End If
                If CheckBox4.Checked Then
                    query &= "@cat4,"
                    hasFilter = True
                End If
                If CheckBox5.Checked Then
                    query &= "@cat5,"
                    hasFilter = True
                End If

                If query.EndsWith(",") Then
                    query = query.Substring(0, query.Length - 1)
                End If

                query &= ")"
            End If

            query &= " ORDER BY p.product_id"

            Dim cmd As New MySqlCommand(query, conn)

            If CheckBox1.Checked Then cmd.Parameters.AddWithValue("@cat1", "House Special")
            If CheckBox2.Checked Then cmd.Parameters.AddWithValue("@cat2", "Soft Bread")
            If CheckBox3.Checked Then cmd.Parameters.AddWithValue("@cat3", "Pastries")
            If CheckBox4.Checked Then cmd.Parameters.AddWithValue("@cat4", "Cakes & Sweet Baked Goods")
            If CheckBox5.Checked Then cmd.Parameters.AddWithValue("@cat5", "Drinks")

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim index As Integer = DataGridView1.Rows.Add()
                Dim row As DataGridViewRow = DataGridView1.Rows(index)

                row.Cells("colId").Value = reader("product_id")
                row.Cells("colName").Value = reader("product_name").ToString()

                If IsDBNull(reader("category_name")) Then
                    row.Cells("colCategory").Value = "Uncategorized"
                Else
                    row.Cells("colCategory").Value = reader("category_name").ToString()
                End If

                row.Cells("colQuantity").Value = reader("stock_quantity")

                Dim costDec As Decimal = Convert.ToDecimal(reader("estimated_cost"))
                row.Cells("colCost").Value = "₱" & costDec.ToString("N2")

                Dim priceDec As Decimal = Convert.ToDecimal(reader("selling_price"))
                row.Cells("colPrice").Value = "₱" & priceDec.ToString("N2")

                row.Cells("colStatus").Value = reader("status").ToString()

                If IsDBNull(reader("category_id")) Then
                    row.Cells("colCategoryId").Value = -1
                Else
                    row.Cells("colCategoryId").Value = reader("category_id")
                End If

                Dim imgPath As String = ""
                If Not IsDBNull(reader("image_path")) Then
                    imgPath = reader("image_path").ToString()
                End If
                row.Cells("colImagePath").Value = imgPath

                If imgPath <> "" Then
                    Dim fullPath As String = Path.Combine(Application.StartupPath, imgPath)
                    If File.Exists(fullPath) Then
                        Try
                            row.Cells("colImg").Value = Image.FromFile(fullPath)
                        Catch
                        End Try
                    End If
                End If
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged
        LoadInventory()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        If row.Cells("colName").Value Is Nothing Then
            Exit Sub
        End If

        selectedProductId = Convert.ToInt32(row.Cells("colId").Value)
        TextBox3.Text = row.Cells("colName").Value.ToString()
        TextBox1.Text = CleanCurrency(row.Cells("colPrice").Value.ToString())
        TextBox2.Text = CleanCurrency(row.Cells("colCost").Value.ToString())
        selectedImagePath = row.Cells("colImagePath").Value.ToString()

        Dim catId As Object = row.Cells("colCategoryId").Value
        If catId IsNot Nothing Then
            If IsNumeric(catId) Then
                If Convert.ToInt32(catId) > 0 Then
                    ComboBox1.SelectedValue = Convert.ToInt32(catId)
                End If
            End If
        End If
    End Sub

    Private Function CleanCurrency(displayValue As String) As String
        Dim clean As String = displayValue
        clean = clean.Replace("₱", "")
        clean = clean.Replace(",", "")
        Return clean.Trim()
    End Function

    Private Sub PopulateCategoryComboBox()
        Try
            OpenConnection()
            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter("SELECT category_id, category_name FROM categories ORDER BY category_name", conn)
            da.Fill(dt)

            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "category_name"
            ComboBox1.ValueMember = "category_id"
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"

        If ofd.ShowDialog() = DialogResult.OK Then
            Try
                Dim assetsFolder As String = Path.Combine(Application.StartupPath, "assets")
                If Not Directory.Exists(assetsFolder) Then
                    Directory.CreateDirectory(assetsFolder)
                End If

                Dim destFileName As String = Path.GetFileName(ofd.FileName)
                Dim destinationPath As String = Path.Combine(assetsFolder, destFileName)
                File.Copy(ofd.FileName, destinationPath, True)

                selectedImagePath = "assets/" & destFileName
                MessageBox.Show("Image attached: " & destFileName, "Ready", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error attaching image: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim productName As String = TextBox3.Text.Trim()
        If productName = "" Or ComboBox1.SelectedValue Is Nothing Then
            MessageBox.Show("Please fill out Name and Category options.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            OpenConnection()
            Dim cmd As New MySqlCommand("INSERT INTO products (category_id, product_name, image_path) VALUES (@cat, @name, @img)", conn)
            cmd.Parameters.AddWithValue("@cat", ComboBox1.SelectedValue)
            cmd.Parameters.AddWithValue("@name", productName)
            cmd.Parameters.AddWithValue("@img", selectedImagePath)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product added! Set prices and quantities next.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearEditForm()
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedProductId = -1 Then
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show("Remove this item permanently?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            OpenConnection()
            Dim cmd As New MySqlCommand("DELETE FROM products WHERE product_id = @id", conn)
            cmd.Parameters.AddWithValue("@id", selectedProductId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearEditForm()
            LoadInventory()
        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show("Cannot remove product with associated transactional sales history.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error tracking query: " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Error tracking query: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If selectedProductId = -1 Then
            Exit Sub
        End If

        Dim inputValue As Integer = Convert.ToInt32(NumericUpDown1.Value)
        If inputValue <= 0 Then
            Exit Sub
        End If

        Dim finalQtyToAdd As Integer = inputValue
        Dim unit As String = "piece"

        If RadioButton1.Checked Then
            unit = "tray"
            Dim piecesPerTray As Integer = GetPiecesPerTray(selectedProductId)
            finalQtyToAdd = inputValue * piecesPerTray
        End If

        Try
            OpenConnection()

            Dim upStock As New MySqlCommand("UPDATE products SET stock_quantity = stock_quantity + @qty WHERE product_id = @id", conn)
            upStock.Parameters.AddWithValue("@qty", finalQtyToAdd)
            upStock.Parameters.AddWithValue("@id", selectedProductId)
            upStock.ExecuteNonQuery()

            Dim upStatus As New MySqlCommand("UPDATE products SET status = CASE WHEN stock_quantity <= 0 THEN 'Unavailable' WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock' ELSE 'Available' END WHERE product_id = @id", conn)
            upStatus.Parameters.AddWithValue("@id", selectedProductId)
            upStatus.ExecuteNonQuery()

            Dim logCmd As New MySqlCommand("INSERT INTO inventory_logs (product_id, user_id, adjustment_quantity, adjustment_unit) VALUES (@pid, @uid, @qty, @unit)", conn)
            logCmd.Parameters.AddWithValue("@pid", selectedProductId)
            logCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
            logCmd.Parameters.AddWithValue("@qty", inputValue)
            logCmd.Parameters.AddWithValue("@unit", unit)
            logCmd.ExecuteNonQuery()

            MessageBox.Show("Stock adjusted! Added " & finalQtyToAdd & " individual units.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NumericUpDown1.Value = 0
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Execution failed: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim sellingPrice As Decimal
        Dim costPrice As Decimal

        If selectedProductId = -1 Then
            Exit Sub
        End If

        If Not Decimal.TryParse(TextBox1.Text, sellingPrice) Then
            Exit Sub
        End If

        If Not Decimal.TryParse(TextBox2.Text, costPrice) Then
            Exit Sub
        End If

        Try
            OpenConnection()
            Dim cmd As New MySqlCommand("UPDATE products SET selling_price = @sp, estimated_cost = @cp WHERE product_id = @id", conn)
            cmd.Parameters.AddWithValue("@sp", sellingPrice)
            cmd.Parameters.AddWithValue("@cp", costPrice)
            cmd.Parameters.AddWithValue("@id", selectedProductId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Price adjustments recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Pricing failure: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub ClearEditForm()
        selectedProductId = -1
        selectedImagePath = ""
        TextBox3.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = -1
        End If
    End Sub

    Private Function GetPiecesPerTray(productId As Integer) As Integer
        Select Case productId
            Case 1
                Return 24
            Case 2, 3, 5, 6
                Return 15
            Case 7 To 12
                Return 18
            Case 13
                Return 12
            Case 14, 15
                Return 24
            Case 16
                Return 6
            Case 17 To 20
                Return 12
            Case Else
                Return 1
        End Select
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Admin_Homevb.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Admin_OrdLogs.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Admin_InvLogs.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()
        Admin_GrossProfit.Show()
    End Sub
End Class