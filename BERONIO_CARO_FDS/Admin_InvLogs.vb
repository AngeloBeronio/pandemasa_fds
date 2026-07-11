Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Admin_InvLogs
	Private currentPage As Integer = 1
	Private Const pageSize As Integer = 10

	Private Sub Admin_InvLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupLogsGrid()
		TextBox1.Text = currentPage.ToString()
	End Sub

	Private Sub Admin_InvLogs_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		LoadLogs()
	End Sub

	Private Sub SetupLogsGrid()
		With DataGridView1
			.Columns.Clear()
			.AutoGenerateColumns = False
			.Columns.Add("colLogId", "LOGS ID")
			.Columns.Add("colType", "TYPE")
			.Columns.Add("colItemId", "ITEM ID")
			.Columns.Add("colUserId", "USER ID")
			.Columns.Add("colQty", "ADJ QUANTITY")
			.Columns.Add("colUnit", "ADJ UNIT")
			.Columns.Add("colDate", "DATE")
			.Columns("colDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
		End With
	End Sub

	Private Sub LoadLogs()
		Try
			OpenConnection()
			DataGridView1.Rows.Clear()
			Dim offset As Integer = (currentPage - 1) * pageSize
			Dim searchKeyword As String = TextBox2.Text.Trim()

			Dim query As String = "
                SELECT log_id, item_type, item_id, user_id, adjustment_quantity, adjustment_unit, timestamp
                FROM (
                    SELECT log_id, 'Product' AS item_type, product_id AS item_id, user_id, adjustment_quantity, adjustment_unit, timestamp
                    FROM productinv_logs
                    UNION ALL
                    SELECT log_id, 'Ingredient' AS item_type, ingredient_id AS item_id, user_id, adjustment_quantity, adjustment_unit, timestamp
                    FROM ingredientinv_logs
                ) AS combined_logs"

			If Not String.IsNullOrEmpty(searchKeyword) Then
				query &= " WHERE item_id LIKE @search OR log_id LIKE @search OR item_type LIKE @search"
			End If

			query &= " ORDER BY timestamp DESC LIMIT @limit OFFSET @offset"

			Dim cmd As New MySqlCommand(query, conn)
			cmd.Parameters.AddWithValue("@limit", pageSize)
			cmd.Parameters.AddWithValue("@offset", offset)
			If Not String.IsNullOrEmpty(searchKeyword) Then
				cmd.Parameters.AddWithValue("@search", $"%{searchKeyword}%")
			End If

			Using reader As MySqlDataReader = cmd.ExecuteReader()
				While reader.Read()
					Dim index As Integer = DataGridView1.Rows.Add()
					Dim row As DataGridViewRow = DataGridView1.Rows(index)
					Dim logType As String = reader("item_type").ToString()
					Dim logId As String = reader("log_id").ToString()
					row.Cells("colLogId").Value = logType.Substring(0, 1) & "-" & logId  ' e.g. "P-1" or "I-1"
					row.Cells("colType").Value = logType
					row.Cells("colItemId").Value = reader("item_id")
					row.Cells("colUserId").Value = If(IsDBNull(reader("user_id")), "N/A", reader("user_id"))
					row.Cells("colQty").Value = reader("adjustment_quantity")
					row.Cells("colUnit").Value = reader("adjustment_unit").ToString()
					row.Cells("colDate").Value = $"{Convert.ToDateTime(reader("timestamp")):yyyy-MM-dd HH:mm:ss}"
				End While
			End Using
		Catch ex As Exception
			MessageBox.Show($"Error loading logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If currentPage > 1 Then
			currentPage -= 1
			TextBox1.Text = currentPage.ToString()
		End If
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		currentPage += 1
		TextBox1.Text = currentPage.ToString()
	End Sub

	Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
		Dim targetedPage As Integer
		If Integer.TryParse(TextBox1.Text, targetedPage) AndAlso targetedPage > 0 Then
			currentPage = targetedPage
			LoadLogs()
		End If
	End Sub

	Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
		currentPage = 1
		TextBox1.Text = "1"
		LoadLogs()
	End Sub

	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Me.Hide()
		Admin_ManageProducts.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Admin_Homevb.Show()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Admin_OrdLogs.Show()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Hide()
		Admin_ManageIngredients.Show()
	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Me.Hide()
		Admin_ManageEmp.Show()
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Me.Hide()
		Start.Show()
	End Sub
End Class