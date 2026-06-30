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
        With DataGridView1
            .Columns.Clear()
            .AutoGenerateColumns = False
            .RowTemplate.Height = 60
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .RowHeadersVisible = False

            .Columns.Add("colId", "ID")

            Dim imgCol As New DataGridViewImageColumn With {
                .Name = "colImg", .HeaderText = "IMG", .ImageLayout = DataGridViewImageCellLayout.Zoom
            }
            .Columns.Add(imgCol)

            .Columns.Add("colName", "NAME")
            .Columns.Add("colCategory", "CATEGORY")
            .Columns.Add("colQuantity", "QUANTITY")
            .Columns.Add("colCost", "COST PRICE")
            .Columns.Add("colPrice", "SELLING PRICE")
            .Columns.Add("colStatus", "STATUS")
            .Columns.Add("colCategoryId", "CategoryId")
            .Columns.Add("colImagePath", "ImagePath")

            .Columns("colId").Visible = False
            .Columns("colCategoryId").Visible = False
            .Columns("colImagePath").Visible = False
            .Columns("colName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    Private Sub LoadInventory()
        Try
            OpenConnection()
            DataGridView1.Rows.Clear()

            Dim checkedCategories As New List(Of String)
            Dim maps As New Dictionary(Of CheckBox, String) From {
                {CheckBox1, "House Special"}, {CheckBox2, "Soft Bread"},
                {CheckBox3, "Pastries"}, {CheckBox4, "Cakes & Sweet Baked Goods"}, {CheckBox5, "Drinks"}
            }

            For Each kvp In maps
                If kvp.Key.Checked Then checkedCategories.Add(kvp.Value)
            Next

            Dim query As String = "
                SELECT p.product_id, p.product_name, c.category_name, p.stock_quantity,
                       p.estimated_cost, p.selling_price, p.status, p.image_path, p.category_id
                FROM products p
                LEFT JOIN categories c ON p.category_id = c.category_id"

            If checkedCategories.Count > 0 Then
                Dim placeholders = Enumerable.Range(0, checkedCategories.Count).Select(Function(i) $"@cat{i}").ToList()
                query &= $" WHERE c.category_name IN ({String.Join(",", placeholders)})"
            End If
            query &= " ORDER BY p.product_id"

            Dim cmd As New MySqlCommand(query, conn)
            For i As Integer = 0 To checkedCategories.Count - 1
                cmd.Parameters.AddWithValue($"@cat{i}", checkedCategories(i))
            Next

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim index As Integer = DataGridView1.Rows.Add()
                    Dim row As DataGridViewRow = DataGridView1.Rows(index)

                    row.Cells("colId").Value = reader("product_id")
                    row.Cells("colName").Value = reader("product_name").ToString()
                    row.Cells("colCategory").Value = If(IsDBNull(reader("category_name")), "Uncategorized", reader("category_name").ToString())
                    row.Cells("colQuantity").Value = reader("stock_quantity")
                    row.Cells("colCost").Value = $"₱{Convert.ToDecimal(reader("estimated_cost")):N2}"
                    row.Cells("colPrice").Value = $"₱{Convert.ToDecimal(reader("selling_price")):N2}"
                    row.Cells("colStatus").Value = reader("status").ToString()
                    row.Cells("colCategoryId").Value = If(IsDBNull(reader("category_id")), -1, reader("category_id"))

                    Dim imgPath As String = If(IsDBNull(reader("image_path")), "", reader("image_path").ToString())
                    row.Cells("colImagePath").Value = imgPath

                    Dim fullPath As String = Path.Combine(Application.StartupPath, imgPath)
                    If imgPath <> "" AndAlso File.Exists(fullPath) Then
                        Try : row.Cells("colImg").Value = Image.FromFile(fullPath) : Catch : End Try
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading inventory: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged,
        CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged
        LoadInventory()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count = 0 Then Return
        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        If row.Cells("colName").Value Is Nothing Then Return

        selectedProductId = Convert.ToInt32(row.Cells("colId").Value)
        TextBox3.Text = row.Cells("colName").Value.ToString()
        TextBox1.Text = CleanCurrency(row.Cells("colPrice").Value.ToString())
        TextBox2.Text = CleanCurrency(row.Cells("colCost").Value.ToString())
        selectedImagePath = row.Cells("colImagePath").Value.ToString()

        Dim catId As Object = row.Cells("colCategoryId").Value
        If catId IsNot Nothing AndAlso IsNumeric(catId) AndAlso Convert.ToInt32(catId) > 0 Then
            ComboBox1.SelectedValue = Convert.ToInt32(catId)
        End If
    End Sub

    Private Function CleanCurrency(displayValue As String) As String
        Return displayValue.Replace("₱", "").Replace(",", "").Trim()
    End Function

    Private Sub PopulateCategoryComboBox()
        Try
            OpenConnection()
            Dim dt As New DataTable()
            Using da As New MySqlDataAdapter("SELECT category_id, category_name FROM categories ORDER BY category_name", conn)
                da.Fill(dt)
            End Using
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "category_name"
            ComboBox1.ValueMember = "category_id"
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using ofd As New OpenFileDialog With {.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"}
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim assetsFolder As String = Path.Combine(Application.StartupPath, "assets")
                    Directory.CreateDirectory(assetsFolder)

                    Dim destFileName As String = Path.GetFileName(ofd.FileName)
                    File.Copy(ofd.FileName, Path.Combine(assetsFolder, destFileName), True)

                    selectedImagePath = $"assets/{destFileName}"
                    MessageBox.Show($"Image attached: {destFileName}", "Ready", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error attaching image: {ex.Message}")
                End Try
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim productName As String = TextBox3.Text.Trim()
        If productName = "" OrElse ComboBox1.SelectedValue Is Nothing Then
            MessageBox.Show("Please fill out Name and Category options.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
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
            MessageBox.Show($"Error adding product: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedProductId = -1 Then Return

        If MessageBox.Show("Remove this item permanently?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            OpenConnection()
            Dim cmd As New MySqlCommand("DELETE FROM products WHERE product_id = @id", conn)
            cmd.Parameters.AddWithValue("@id", selectedProductId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearEditForm()
            LoadInventory()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Cannot remove product with associated transactional sales history.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error tracking query: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If selectedProductId = -1 Then Return
        Dim inputValue As Integer = CInt(NumericUpDown1.Value)
        If inputValue <= 0 Then Return

        Dim finalQtyToAdd As Integer = inputValue
        Dim unit As String = "piece"

        If RadioButton1.Checked Then
            unit = "tray"
            finalQtyToAdd = inputValue * GetPiecesPerTray(selectedProductId)
        End If

        Try
            OpenConnection()

            Dim upStock As New MySqlCommand("UPDATE products SET stock_quantity = stock_quantity + @qty WHERE product_id = @id", conn)
            upStock.Parameters.AddWithValue("@qty", finalQtyToAdd)
            upStock.Parameters.AddWithValue("@id", selectedProductId)
            upStock.ExecuteNonQuery()

            Dim upStatus As New MySqlCommand("
                UPDATE products SET status = CASE
                    WHEN stock_quantity <= 0 THEN 'Unavailable'
                    WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock'
                    ELSE 'Available'
                END WHERE product_id = @id", conn)
            upStatus.Parameters.AddWithValue("@id", selectedProductId)
            upStatus.ExecuteNonQuery()

            Dim logCmd As New MySqlCommand("
                INSERT INTO inventory_logs (product_id, user_id, adjustment_quantity, adjustment_unit)
                VALUES (@pid, @uid, @qty, @unit)", conn)
            logCmd.Parameters.AddWithValue("@pid", selectedProductId)
            logCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
            logCmd.Parameters.AddWithValue("@qty", inputValue)
            logCmd.Parameters.AddWithValue("@unit", unit)
            logCmd.ExecuteNonQuery()

            MessageBox.Show($"Stock adjusted! Added {finalQtyToAdd} individual units.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NumericUpDown1.Value = 0
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show($"Execution failed: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim sellingPrice, costPrice As Decimal
        If selectedProductId = -1 OrElse Not Decimal.TryParse(TextBox1.Text, sellingPrice) OrElse Not Decimal.TryParse(TextBox2.Text, costPrice) Then Return

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
            MessageBox.Show($"Pricing failure: {ex.Message}")
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
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = -1
    End Sub

    Private Function GetPiecesPerTray(productId As Integer) As Integer
        Select Case productId
            Case 1 : Return 24
            Case 2, 3, 5, 6 : Return 15
            Case 7 To 12 : Return 18
            Case 13 : Return 12
            Case 14, 15 : Return 24
            Case 16 : Return 6
            Case 17 To 20 : Return 12
            Case Else : Return 1
        End Select
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide() : Admin_Homevb.Show()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide() : Admin_OrdLogs.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide() : Admin_InvLogs.Show()
    End Sub
End Class