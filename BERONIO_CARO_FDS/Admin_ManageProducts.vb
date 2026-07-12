Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data

Public Class Admin_ManageProducts

	Private selectedProductId As Integer = -1
	Private selectedImagePath As String = ""
	Private selectedIsBaked As Boolean = True

	Private Sub Admin_Inv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupInventoryGrid()
		PopulateCategoryComboBox()
		RadioButton3.Checked = True
		ApplyBakedFieldState()
		LoadInventory()
	End Sub

	Private Sub ApplyBakedFieldState()
		Dim isBaked As Boolean = RadioButton3.Checked

		TextBox5.Enabled = Not isBaked
		TextBox5.BackColor = If(TextBox5.Enabled, SystemColors.Window, SystemColors.Control)

		TextBox2.Enabled = isBaked
		TextBox4.Enabled = isBaked
		Button8.Enabled = isBaked
		ComboBox2.Enabled = isBaked
		Button10.Enabled = isBaked
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
		DataGridView1.Columns.Add("colIsBaked", "IsBaked")

		DataGridView1.Columns("colId").Visible = False
		DataGridView1.Columns("colCategoryId").Visible = False
		DataGridView1.Columns("colImagePath").Visible = False
		DataGridView1.Columns("colIsBaked").Visible = False
		DataGridView1.Columns("colName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
	End Sub

	Private Sub LoadInventory()
		Try
			OpenConnection()
			DataGridView1.Rows.Clear()

			Dim query As String = "SELECT p.product_id, p.product_name, c.category_name, p.stock_quantity, " &
				"p.is_baked, " &
				"CASE WHEN p.is_baked = 1 THEN IFNULL(rc.recipe_cost, 0) ELSE p.estimated_cost_price END AS cost_per_piece, " &
				"p.selling_price, p.status, p.image_path, p.category_id " &
				"FROM products p " &
				"LEFT JOIN categories c ON p.category_id = c.category_id " &
				"LEFT JOIN (" &
				"    SELECT pi.product_id, SUM(pi.qty_gram_per_piece * i.price_per_gram) AS recipe_cost " &
				"    FROM product_ingredients pi " &
				"    JOIN ingredients i ON pi.ingredient_id = i.ingredient_id " &
				"    GROUP BY pi.product_id" &
				") rc ON p.product_id = rc.product_id"

			If CheckBox1.Checked Or CheckBox2.Checked Or CheckBox3.Checked Or CheckBox4.Checked Or CheckBox5.Checked Then
				query &= " WHERE c.category_name IN ("

				If CheckBox1.Checked Then query &= "@cat1,"
				If CheckBox2.Checked Then query &= "@cat2,"
				If CheckBox3.Checked Then query &= "@cat3,"
				If CheckBox4.Checked Then query &= "@cat4,"
				If CheckBox5.Checked Then query &= "@cat5,"

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

				Dim costDec As Decimal = 0D
				If Not IsDBNull(reader("cost_per_piece")) Then
					costDec = Convert.ToDecimal(reader("cost_per_piece"))
				End If
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
				row.Cells("colIsBaked").Value = Convert.ToBoolean(reader("is_baked"))

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
		TextBox1.Text = CleanCurrency(row.Cells("colPrice").Value.ToString())
		TextBox5.Text = CleanCurrency(row.Cells("colCost").Value.ToString())
		selectedImagePath = row.Cells("colImagePath").Value.ToString()
		selectedIsBaked = Convert.ToBoolean(row.Cells("colIsBaked").Value)

		RadioButton3.Checked = selectedIsBaked
		RadioButton4.Checked = Not selectedIsBaked
		ApplyBakedFieldState()

		TextBox2.Clear()
		TextBox4.Clear()
		PopulateProductIngredientComboBox(selectedProductId)
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
		Dim productName = TextBox3.Text.Trim
		If productName = "" Or ComboBox1.SelectedValue Is Nothing Then
			MessageBox.Show("Please fill out Name and Category options.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Dim isBakedValue As Integer = If(RadioButton3.Checked, 1, 0)

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("INSERT INTO products (category_id, product_name, image_path, selling_price, estimated_cost_price, is_baked) VALUES (@cat, @name, @img, 0.00, 0.00, @baked)", conn)
			cmd.Parameters.AddWithValue("@cat", ComboBox1.SelectedValue)
			cmd.Parameters.AddWithValue("@name", productName)
			cmd.Parameters.AddWithValue("@img", selectedImagePath)
			cmd.Parameters.AddWithValue("@baked", isBakedValue)
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

		Dim result = MessageBox.Show("Remove this item permanently?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

		Dim trans As MySqlTransaction = Nothing

		Try
			OpenConnection()
			trans = conn.BeginTransaction()

			If selectedIsBaked Then
				Dim recipe As List(Of Tuple(Of Integer, String, Decimal)) = GetProductIngredients(selectedProductId, conn, trans)

				If recipe.Count = 0 Then
					trans.Rollback()
					MessageBox.Show("This product is marked as Baked but has no recipe set up yet. Please add ingredients first.", "Missing Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				End If

				Dim shortages As New List(Of String)
				For Each ing In recipe
					Dim neededGrams As Decimal = ing.Item3 * finalQtyToAdd
					Dim currentStock As Decimal = GetIngredientStock(ing.Item1, conn, trans)
					If currentStock < neededGrams Then
						shortages.Add(ing.Item2 & " (need " & neededGrams.ToString("N1") & "g, have " & currentStock.ToString("N1") & "g)")
					End If
				Next

				If shortages.Count > 0 Then
					trans.Rollback()
					MessageBox.Show("Cannot add stock — not enough ingredient stock:" & Environment.NewLine &
						String.Join(Environment.NewLine, shortages), "Insufficient Ingredients", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				End If

				For Each ing In recipe
					Dim neededGrams As Decimal = ing.Item3 * finalQtyToAdd
					Dim deductCmd As New MySqlCommand("UPDATE ingredients SET stock_grams = stock_grams - @amt WHERE ingredient_id = @iid", conn, trans)
					deductCmd.Parameters.AddWithValue("@amt", neededGrams)
					deductCmd.Parameters.AddWithValue("@iid", ing.Item1)
					deductCmd.ExecuteNonQuery()
				Next
			End If

			Dim upStock As New MySqlCommand("UPDATE products SET stock_quantity = stock_quantity + @qty WHERE product_id = @id", conn, trans)
			upStock.Parameters.AddWithValue("@qty", finalQtyToAdd)
			upStock.Parameters.AddWithValue("@id", selectedProductId)
			upStock.ExecuteNonQuery()

			Dim upStatus As New MySqlCommand("UPDATE products SET status = CASE WHEN stock_quantity <= 0 THEN 'Unavailable' WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock' ELSE 'Available' END WHERE product_id = @id", conn, trans)
			upStatus.Parameters.AddWithValue("@id", selectedProductId)
			upStatus.ExecuteNonQuery()

			Dim logCmd As New MySqlCommand("INSERT INTO productinv_logs (product_id, user_id, adjustment_quantity, adjustment_unit) VALUES (@pid, @uid, @qty, @unit)", conn, trans)
			logCmd.Parameters.AddWithValue("@pid", selectedProductId)
			logCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
			logCmd.Parameters.AddWithValue("@qty", inputValue)
			logCmd.Parameters.AddWithValue("@unit", unit)
			logCmd.ExecuteNonQuery()

			trans.Commit()

			MessageBox.Show("Stock adjusted! Added " & finalQtyToAdd & " individual units.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
			NumericUpDown1.Value = 0
			LoadInventory()
		Catch ex As Exception
			Try
				If trans IsNot Nothing Then trans.Rollback()
			Catch
			End Try
			MessageBox.Show("Execution failed: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
		Dim sellingPrice As Decimal
		Dim costPrice As Decimal

		If selectedProductId = -1 Then
			Exit Sub
		End If

		If Not Decimal.TryParse(TextBox1.Text, sellingPrice) Then
			Exit Sub
		End If

		Dim isBakedValue = RadioButton3.Checked

		If Not isBakedValue Then
			If Not Decimal.TryParse(TextBox5.Text, costPrice) Then
				Exit Sub
			End If
		End If

		Try
			OpenConnection()

			Dim cmd As MySqlCommand
			If isBakedValue Then
				cmd = New MySqlCommand("UPDATE products SET selling_price = @sp, is_baked = @baked WHERE product_id = @id", conn)
			Else
				cmd = New MySqlCommand("UPDATE products SET selling_price = @sp, estimated_cost_price = @cp, is_baked = @baked WHERE product_id = @id", conn)
				cmd.Parameters.AddWithValue("@cp", costPrice)
			End If
			cmd.Parameters.AddWithValue("@sp", sellingPrice)
			cmd.Parameters.AddWithValue("@baked", If(isBakedValue, 1, 0))
			cmd.Parameters.AddWithValue("@id", selectedProductId)
			cmd.ExecuteNonQuery()

			selectedIsBaked = isBakedValue
			ApplyBakedFieldState()

			MessageBox.Show("Price adjustments recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			LoadInventory()
		Catch ex As Exception
			MessageBox.Show("Pricing failure: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub BakedStatusChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
		ApplyBakedFieldState()
	End Sub

	Private Sub ClearEditForm()
		selectedProductId = -1
		selectedImagePath = ""
		selectedIsBaked = True
		TextBox3.Clear()
		TextBox1.Clear()
		TextBox5.Clear()
		TextBox2.Clear()
		TextBox4.Clear()
		RadioButton3.Checked = True
		ApplyBakedFieldState()
		ComboBox2.DataSource = Nothing
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

	Private Function GetProductIngredients(productId As Integer, conn As MySqlConnection, trans As MySqlTransaction) As List(Of Tuple(Of Integer, String, Decimal))
		Dim result As New List(Of Tuple(Of Integer, String, Decimal))

		Dim cmd As New MySqlCommand("SELECT pi.ingredient_id, i.ingredient_name, pi.qty_gram_per_piece " &
			"FROM product_ingredients pi " &
			"JOIN ingredients i ON pi.ingredient_id = i.ingredient_id " &
			"WHERE pi.product_id = @pid", conn, trans)
		cmd.Parameters.AddWithValue("@pid", productId)

		Dim reader As MySqlDataReader = cmd.ExecuteReader()
		While reader.Read()
			result.Add(New Tuple(Of Integer, String, Decimal)(
				Convert.ToInt32(reader("ingredient_id")),
				reader("ingredient_name").ToString(),
				Convert.ToDecimal(reader("qty_gram_per_piece"))
			))
		End While
		reader.Close()

		Return result
	End Function

	Private Function GetIngredientStock(ingredientId As Integer, conn As MySqlConnection, trans As MySqlTransaction) As Decimal
		Dim cmd As New MySqlCommand("SELECT stock_grams FROM ingredients WHERE ingredient_id = @iid", conn, trans)
		cmd.Parameters.AddWithValue("@iid", ingredientId)
		Dim result As Object = cmd.ExecuteScalar()
		If result Is Nothing OrElse IsDBNull(result) Then
			Return 0D
		End If
		Return Convert.ToDecimal(result)
	End Function

	Private Sub PopulateProductIngredientComboBox(productId As Integer)
		Try
			OpenConnection()
			Dim dt As New DataTable()
			Dim da As New MySqlDataAdapter("SELECT i.ingredient_id, i.ingredient_name " &
				"FROM product_ingredients pi " &
				"JOIN ingredients i ON pi.ingredient_id = i.ingredient_id " &
				"WHERE pi.product_id = @pid ORDER BY i.ingredient_name", conn)
			da.SelectCommand.Parameters.AddWithValue("@pid", productId)
			da.Fill(dt)

			ComboBox2.DataSource = dt
			ComboBox2.DisplayMember = "ingredient_name"
			ComboBox2.ValueMember = "ingredient_id"
		Catch ex As Exception
			MessageBox.Show("Error loading recipe ingredients: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Function GetIngredientIdByName(ingredientName As String, conn As MySqlConnection) As Object
		Dim cmd As New MySqlCommand("SELECT ingredient_id FROM ingredients WHERE ingredient_name = @name LIMIT 1", conn)
		cmd.Parameters.AddWithValue("@name", ingredientName)
		Dim result As Object = cmd.ExecuteScalar()
		If result Is Nothing OrElse IsDBNull(result) Then
			Return Nothing
		End If
		Return result
	End Function

	Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
		If selectedProductId = -1 Then
			MessageBox.Show("Please select a product first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Dim ingName = TextBox2.Text.Trim
		Dim gramsPerPiece As Decimal

		If ingName = "" Then
			MessageBox.Show("Please enter an ingredient name.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		If Not Decimal.TryParse(TextBox4.Text, gramsPerPiece) Then
			MessageBox.Show("Please enter a valid amount in grams.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Try
			OpenConnection()

			Dim ingredientId = GetIngredientIdByName(ingName, conn)
			If ingredientId Is Nothing Then
				MessageBox.Show("Ingredient '" & ingName & "' was not found in the ingredients list.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Exit Sub
			End If

			Dim existsCmd As New MySqlCommand("SELECT COUNT(*) FROM product_ingredients WHERE product_id = @pid AND ingredient_id = @iid", conn)
			existsCmd.Parameters.AddWithValue("@pid", selectedProductId)
			existsCmd.Parameters.AddWithValue("@iid", ingredientId)
			Dim alreadyExists = Convert.ToInt64(existsCmd.ExecuteScalar)

			If alreadyExists > 0 Then
				Dim updateCmd As New MySqlCommand("UPDATE product_ingredients SET qty_gram_per_piece = @qty WHERE product_id = @pid AND ingredient_id = @iid", conn)
				updateCmd.Parameters.AddWithValue("@qty", gramsPerPiece)
				updateCmd.Parameters.AddWithValue("@pid", selectedProductId)
				updateCmd.Parameters.AddWithValue("@iid", ingredientId)
				updateCmd.ExecuteNonQuery()
			Else
				Dim insertCmd As New MySqlCommand("INSERT INTO product_ingredients (product_id, ingredient_id, qty_gram_per_piece) VALUES (@pid, @iid, @qty)", conn)
				insertCmd.Parameters.AddWithValue("@pid", selectedProductId)
				insertCmd.Parameters.AddWithValue("@iid", ingredientId)
				insertCmd.Parameters.AddWithValue("@qty", gramsPerPiece)
				insertCmd.ExecuteNonQuery()
			End If

			MessageBox.Show("Recipe ingredient saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			TextBox2.Clear()
			TextBox4.Clear()
			PopulateProductIngredientComboBox(selectedProductId)
		Catch ex As Exception
			MessageBox.Show("Error saving recipe ingredient: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
		If selectedProductId = -1 Then
			MessageBox.Show("Please select a product first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		If ComboBox2.SelectedValue Is Nothing Then
			Exit Sub
		End If

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("DELETE FROM product_ingredients WHERE product_id = @pid AND ingredient_id = @iid", conn)
			cmd.Parameters.AddWithValue("@pid", selectedProductId)
			cmd.Parameters.AddWithValue("@iid", ComboBox2.SelectedValue)
			cmd.ExecuteNonQuery()

			MessageBox.Show("Ingredient removed from recipe.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			PopulateProductIngredientComboBox(selectedProductId)
		Catch ex As Exception
			MessageBox.Show("Error removing recipe ingredient: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub


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
		Admin_ManageEmp.Show()
	End Sub

	Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
		Me.Hide()
		Admin_InvLogs.Show()
	End Sub

	Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
		Me.Hide()
		Admin_ManageIngredients.Show()
	End Sub

End Class