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

    ' ---------- GRID SETUP ----------
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

    ' ---------- LOAD INVENTORY (with category filter) ----------
    ' NOTE: checkbox labels don't exactly match the DB's category_name values
    ' ("Cakes & Sweets" vs "Cakes & Sweet Baked Goods", "Beverages" vs "Drinks").
    ' Mapped manually below so the filter still works correctly.
    Private Sub LoadInventory()
        Try
            OpenConnection()
            DataGridView1.Rows.Clear()

            Dim checkedCategories As New List(Of String)
            If CheckBox1.Checked Then checkedCategories.Add("House Special")
            If CheckBox2.Checked Then checkedCategories.Add("Soft Bread")
            If CheckBox3.Checked Then checkedCategories.Add("Pastries")
            If CheckBox4.Checked Then checkedCategories.Add("Cakes & Sweet Baked Goods")
            If CheckBox5.Checked Then checkedCategories.Add("Drinks")

            Dim query As String = "
                SELECT p.product_id, p.product_name, c.category_name, p.stock_quantity,
                       p.estimated_cost, p.selling_price, p.status, p.image_path, p.category_id
                FROM products p
                LEFT JOIN categories c ON p.category_id = c.category_id"

            If checkedCategories.Count > 0 Then
                Dim placeholders As New List(Of String)
                For i As Integer = 0 To checkedCategories.Count - 1
                    placeholders.Add("@cat" & i)
                Next
                query &= " WHERE c.category_name IN (" & String.Join(",", placeholders) & ")"
            End If

            query &= " ORDER BY p.product_id"

            Dim cmd As New MySqlCommand(query, conn)
            For i As Integer = 0 To checkedCategories.Count - 1
                cmd.Parameters.AddWithValue("@cat" & i, checkedCategories(i))
            Next

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim rowIndex As Integer = DataGridView1.Rows.Add()
                Dim row As DataGridViewRow = DataGridView1.Rows(rowIndex)

                row.Cells("colId").Value = reader("product_id")
                row.Cells("colName").Value = reader("product_name").ToString()
                row.Cells("colCategory").Value = If(IsDBNull(reader("category_name")), "Uncategorized", reader("category_name").ToString())
                row.Cells("colQuantity").Value = reader("stock_quantity")
                row.Cells("colCost").Value = "₱" & Convert.ToDecimal(reader("estimated_cost")).ToString("N2")
                row.Cells("colPrice").Value = "₱" & Convert.ToDecimal(reader("selling_price")).ToString("N2")
                row.Cells("colStatus").Value = reader("status").ToString()
                row.Cells("colCategoryId").Value = If(IsDBNull(reader("category_id")), -1, reader("category_id"))

                Dim imgPath As String = If(IsDBNull(reader("image_path")), "", reader("image_path").ToString())
                row.Cells("colImagePath").Value = imgPath

                Dim fullPath As String = Path.Combine(Application.StartupPath, imgPath)
                If imgPath <> "" AndAlso File.Exists(fullPath) Then
                    Try
                        row.Cells("colImg").Value = Image.FromFile(fullPath)
                    Catch
                        row.Cells("colImg").Value = Nothing
                    End Try
                End If
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- FILTER CHECKBOXES ----------
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        LoadInventory()
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        LoadInventory()
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        LoadInventory()
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        LoadInventory()
    End Sub
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        LoadInventory()
    End Sub

    ' ---------- ROW SELECTION -> POPULATE EDIT FIELDS ----------
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        ' 1. Guard Clause: If no rows are selected, get out immediately
        If DataGridView1.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)

        ' 2. Guard Clause: If the cell value is Nothing (grid is clearing/loading), get out
        If row.Cells("colName").Value Is Nothing Then Return

        ' 3. Safely populate everything using your actual grid column names
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

    ' Strips "₱" and thousands separators so a displayed price can go back into a TextBox
    Private Function CleanCurrency(displayValue As String) As String
        Return displayValue.Replace("₱", "").Replace(",", "").Trim()
    End Function

    ' ---------- CATEGORY DROPDOWN ----------
    Private Sub PopulateCategoryComboBox()
        Try
            OpenConnection()
            Dim query As String = "SELECT category_id, category_name FROM categories ORDER BY category_name"
            Dim da As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()
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

    ' ---------- BUTTON1: ATTACH IMAGE ----------
    ' Copies the chosen image into /assets so it matches LoadProductImage's
    ' expected relative-path format, and stores the path for use by ADD.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim assetsFolder As String = Path.Combine(Application.StartupPath, "assets")
                    Directory.CreateDirectory(assetsFolder)

                    Dim destFileName As String = Path.GetFileName(ofd.FileName)
                    Dim destPath As String = Path.Combine(assetsFolder, destFileName)
                    File.Copy(ofd.FileName, destPath, True)

                    selectedImagePath = "assets/" & destFileName
                    MessageBox.Show("Image attached: " & destFileName, "Image Ready", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error attaching image: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    ' ---------- BUTTON2: ADD PRODUCT ----------
    ' Bare-bones insert (name, image, category). Cost/Price/Quantity default to
    ' 0 and get filled in afterward via Update Quantity / Update Price.
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim productName As String = TextBox3.Text.Trim()

        If productName = "" Then
            MessageBox.Show("Enter a product name first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If ComboBox1.SelectedValue Is Nothing Then
            MessageBox.Show("Select a category first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Dim query As String = "INSERT INTO products (category_id, product_name, image_path) VALUES (@cat, @name, @img)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@cat", ComboBox1.SelectedValue)
            cmd.Parameters.AddWithValue("@name", productName)
            cmd.Parameters.AddWithValue("@img", selectedImagePath)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product added. Don't forget to set its cost/price/quantity.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearEditForm()
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- BUTTON4: REMOVE PRODUCT ----------
    ' Note: products.product_id has no ON DELETE CASCADE for order_items, so
    ' removing a product that's already been sold before will throw a foreign
    ' key error. That's expected DB behavior, not a bug — catch handles it.
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedProductId = -1 Then
            MessageBox.Show("Select a product to remove first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to remove this product? This cannot be undone.",
            "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm <> DialogResult.Yes Then Return

        Try
            OpenConnection()
            Dim query As String = "DELETE FROM products WHERE product_id = @id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", selectedProductId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Product removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearEditForm()
            LoadInventory()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Can't remove this product — it already has order history tied to it.", "Cannot Remove", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error removing product: " & ex.Message)
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
            Case 1 ' Pandesal
                Return 24
            Case 2, 3, 5, 6 ' Pan de Coco, Pan de Leche, Putok, Monay
                Return 15
            Case 7, 8, 9, 10, 11, 12 ' Spanish Breads
                Return 18
            Case 13 ' Empanada
                Return 12
            Case 14, 15 ' Otap, Biscocho
                Return 24
            Case 16 ' Pianono
                Return 6
            Case 17, 18, 19, 20 ' Premium Cakes & Polvoron pack
                Return 12
            Case Else ' Drinks
                Return 1
        End Select
    End Function

    ' ---------- BUTTON7: UPDATE QUANTITY ----------
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If selectedProductId = -1 Then
            MessageBox.Show("Select a product first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim inputValue As Integer = CInt(NumericUpDown1.Value)
        If inputValue <= 0 Then
            MessageBox.Show("Enter a quantity greater than 0.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Determine final quantity calculation based on the unit choice
        Dim finalQtyToAdd As Integer = inputValue
        Dim unit As String = "piece"

        If RadioButton1.Checked Then ' "By Tray" is selected
            unit = "tray"
            Dim piecesPerTray As Integer = GetPiecesPerTray(selectedProductId)
            finalQtyToAdd = inputValue * piecesPerTray
        End If

        Try
            OpenConnection()

            ' Update the stock with our calculated piece value
            Dim updateQuery As String = "UPDATE products SET stock_quantity = stock_quantity + @qty WHERE product_id = @id"
            Dim cmd As New MySqlCommand(updateQuery, conn)
            cmd.Parameters.AddWithValue("@qty", finalQtyToAdd)
            cmd.Parameters.AddWithValue("@id", selectedProductId)
            cmd.ExecuteNonQuery()

            ' Recalculate status values against the threshold
            Dim statusQuery As String = "
            UPDATE products
            SET status = CASE
                WHEN stock_quantity <= 0 THEN 'Unavailable'
                WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock'
                ELSE 'Available'
            END
            WHERE product_id = @id"
            Dim statusCmd As New MySqlCommand(statusQuery, conn)
            statusCmd.Parameters.AddWithValue("@id", selectedProductId)
            statusCmd.ExecuteNonQuery()

            ' Insert log record with what the user originally typed and selected
            Dim logQuery As String = "
            INSERT INTO inventory_logs (product_id, user_id, adjustment_quantity, adjustment_unit)
            VALUES (@pid, @uid, @qty, @unit)"
            Dim logCmd As New MySqlCommand(logQuery, conn)
            logCmd.Parameters.AddWithValue("@pid", selectedProductId)
            logCmd.Parameters.AddWithValue("@uid", DBNull.Value)
            logCmd.Parameters.AddWithValue("@qty", inputValue) ' Keeps user input raw for logs
            logCmd.Parameters.AddWithValue("@unit", unit)
            logCmd.ExecuteNonQuery()

            MessageBox.Show($"Quantity updated successfully! Added {finalQtyToAdd} pieces.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NumericUpDown1.Value = 0
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error updating quantity: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- BUTTON8: UPDATE PRICE ----------
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If selectedProductId = -1 Then
            MessageBox.Show("Select a product first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sellingPrice As Decimal
        Dim costPrice As Decimal

        If Not Decimal.TryParse(TextBox1.Text, sellingPrice) OrElse Not Decimal.TryParse(TextBox2.Text, costPrice) Then
            MessageBox.Show("Enter valid numbers for both selling and cost price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Dim query As String = "UPDATE products SET selling_price = @sp, estimated_cost = @cp WHERE product_id = @id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@sp", sellingPrice)
            cmd.Parameters.AddWithValue("@cp", costPrice)
            cmd.Parameters.AddWithValue("@id", selectedProductId)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Price updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadInventory()
        Catch ex As Exception
            MessageBox.Show("Error updating price: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- NAVIGATION ----------
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class