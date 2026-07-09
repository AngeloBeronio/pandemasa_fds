Imports MySql.Data.MySqlClient

Public Class Admin_ManageIngredients

	Private selectedIngredientId As Integer = -1
	Private selectedIngredientOldStock As Decimal = 0

	Private Sub Admin_Ingredients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupIngredientGrid()
		LoadIngredients()
	End Sub

	Private Sub SetupIngredientGrid()
		DataGridView1.Columns.Clear()
		DataGridView1.AutoGenerateColumns = False
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		DataGridView1.MultiSelect = False
		DataGridView1.ReadOnly = True
		DataGridView1.AllowUserToAddRows = False
		DataGridView1.RowHeadersVisible = False

		DataGridView1.Columns.Add("colId", "ID")
		DataGridView1.Columns.Add("colName", "INGREDIENT NAME")
		DataGridView1.Columns.Add("colPrice", "PRICE PER GRAM")
		DataGridView1.Columns.Add("colStock", "GRAMS IN STOCK")

		DataGridView1.Columns("colId").Visible = False
		DataGridView1.Columns("colName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
	End Sub

	Private Sub LoadIngredients()
		Try
			OpenConnection()
			DataGridView1.Rows.Clear()

			Dim cmd As New MySqlCommand("SELECT ingredient_id, ingredient_name, price_per_gram, stock_grams FROM ingredients ORDER BY ingredient_name", conn)
			Dim reader As MySqlDataReader = cmd.ExecuteReader()

			While reader.Read()
				Dim index As Integer = DataGridView1.Rows.Add()
				Dim row As DataGridViewRow = DataGridView1.Rows(index)

				row.Cells("colId").Value = reader("ingredient_id")
				row.Cells("colName").Value = reader("ingredient_name").ToString()

				Dim priceDec As Decimal = Convert.ToDecimal(reader("price_per_gram"))
				row.Cells("colPrice").Value = priceDec.ToString("N4")

				Dim stockDec As Decimal = Convert.ToDecimal(reader("stock_grams"))
				row.Cells("colStock").Value = stockDec.ToString("N2")
			End While

			reader.Close()
		Catch ex As Exception
			MessageBox.Show("Error loading ingredients: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
		If DataGridView1.SelectedRows.Count = 0 Then
			Exit Sub
		End If

		Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
		If row.Cells("colName").Value Is Nothing Then
			Exit Sub
		End If

		selectedIngredientId = Convert.ToInt32(row.Cells("colId").Value)
		TextBox1.Text = row.Cells("colName").Value.ToString()
		TextBox2.Text = row.Cells("colPrice").Value.ToString()
		TextBox3.Text = row.Cells("colStock").Value.ToString()

		' Remember the stock level as of selection so we can log the delta on Save
		Decimal.TryParse(row.Cells("colStock").Value.ToString(), selectedIngredientOldStock)
	End Sub

	' SET: saves name / price per gram / stock in grams for the selected ingredient
	' Also logs any stock change to ingredientinv_logs, mirroring productinv_logs
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If selectedIngredientId = -1 Then
			MessageBox.Show("Please select an ingredient first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Dim ingName As String = TextBox1.Text.Trim()
		Dim pricePerGram As Decimal
		Dim gramsInStock As Decimal

		If ingName = "" Then
			MessageBox.Show("Please enter an ingredient name.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		If Not Decimal.TryParse(TextBox2.Text, pricePerGram) Then
			MessageBox.Show("Please enter a valid price per gram.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		If Not Decimal.TryParse(TextBox3.Text, gramsInStock) Then
			MessageBox.Show("Please enter a valid stock amount in grams.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Dim trans As MySqlTransaction = Nothing

		Try
			OpenConnection()
			trans = conn.BeginTransaction()

			Dim cmd As New MySqlCommand("UPDATE ingredients SET ingredient_name = @name, price_per_gram = @price, stock_grams = @stock WHERE ingredient_id = @id", conn, trans)
			cmd.Parameters.AddWithValue("@name", ingName)
			cmd.Parameters.AddWithValue("@price", pricePerGram)
			cmd.Parameters.AddWithValue("@stock", gramsInStock)
			cmd.Parameters.AddWithValue("@id", selectedIngredientId)
			cmd.ExecuteNonQuery()

			Dim stockDelta As Decimal = gramsInStock - selectedIngredientOldStock

			' Only write a log entry if the stock quantity actually changed
			If stockDelta <> 0 Then
				Dim logCmd As New MySqlCommand("INSERT INTO ingredientinv_logs (ingredient_id, user_id, adjustment_quantity, adjustment_unit) VALUES (@iid, @uid, @qty, @unit)", conn, trans)
				logCmd.Parameters.AddWithValue("@iid", selectedIngredientId)
				logCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
				logCmd.Parameters.AddWithValue("@qty", stockDelta)
				logCmd.Parameters.AddWithValue("@unit", "grams")
				logCmd.ExecuteNonQuery()
			End If

			trans.Commit()

			MessageBox.Show("Ingredient updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			LoadIngredients()
		Catch ex As Exception
			If trans IsNot Nothing Then
				trans.Rollback()
			End If
			MessageBox.Show("Error updating ingredient: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' ADD: creates a brand-new ingredient with 0 stock; stock is set afterward via the Update panel
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim ingName As String = TextBox4.Text.Trim()
		Dim pricePerGram As Decimal

		If ingName = "" Then
			MessageBox.Show("Please enter an ingredient name.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		If Not Decimal.TryParse(TextBox5.Text, pricePerGram) Then
			MessageBox.Show("Please enter a valid price per gram.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Try
			OpenConnection()

			Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM ingredients WHERE ingredient_name = @name", conn)
			checkCmd.Parameters.AddWithValue("@name", ingName)
			Dim existingCount As Long = Convert.ToInt64(checkCmd.ExecuteScalar())

			If existingCount > 0 Then
				MessageBox.Show("An ingredient with this name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Exit Sub
			End If

			Dim insertCmd As New MySqlCommand("INSERT INTO ingredients (ingredient_name, price_per_gram, stock_grams) VALUES (@name, @price, 0)", conn)
			insertCmd.Parameters.AddWithValue("@name", ingName)
			insertCmd.Parameters.AddWithValue("@price", pricePerGram)
			insertCmd.ExecuteNonQuery()

			MessageBox.Show("Ingredient added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			TextBox4.Clear()
			TextBox5.Clear()
			LoadIngredients()
		Catch ex As Exception
			MessageBox.Show("Error adding ingredient: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' REMOVE: deletes the ingredient currently selected in the grid
	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		If selectedIngredientId = -1 Then
			MessageBox.Show("Please select an ingredient first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Dim result = MessageBox.Show("Remove this ingredient permanently?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		If result <> DialogResult.Yes Then
			Exit Sub
		End If

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("DELETE FROM ingredients WHERE ingredient_id = @id", conn)
			cmd.Parameters.AddWithValue("@id", selectedIngredientId)
			cmd.ExecuteNonQuery()

			MessageBox.Show("Ingredient removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			ClearUpdateForm()
			LoadIngredients()
		Catch ex As MySqlException
			If ex.Number = 1451 Then
				MessageBox.Show("Cannot remove an ingredient that is used in one or more product recipes.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Else
				MessageBox.Show("Error removing ingredient: " & ex.Message)
			End If
		Catch ex As Exception
			MessageBox.Show("Error removing ingredient: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub ClearUpdateForm()
		selectedIngredientId = -1
		selectedIngredientOldStock = 0
		TextBox1.Clear()
		TextBox2.Clear()
		TextBox3.Clear()
	End Sub

	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Me.Hide()
		Admin_Homevb.Show()
	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Me.Hide()
		Admin_ManageProducts.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Admin_ManageEmp.Show()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Hide()
		Admin_OrdLogs.Show()
	End Sub

	Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
		Me.Hide()
		Admin_InvLogs.Show()
	End Sub
End Class