Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Admin_OrdLogs
	Private currentPage As Integer = 1
	Private Const pageSize As Integer = 10

	Private Sub Admin_OrdLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupLogsGrid()
		TextBox1.Text = currentPage.ToString()
	End Sub

	Private Sub Admin_OrdLogs_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		LoadLogs()
	End Sub

	Private Sub SetupLogsGrid()
		DataGridView1.Columns.Clear()
		DataGridView1.AutoGenerateColumns = False

		DataGridView1.Columns.Add("colOrderId", "ORDER ID")
		DataGridView1.Columns.Add("colUserId", "USER ID")
		DataGridView1.Columns.Add("colSubtotal", "SUBTOTAL")
		DataGridView1.Columns.Add("colDiscount", "DISCOUNT")
		DataGridView1.Columns.Add("colTotal", "TOTAL")
		DataGridView1.Columns.Add("colCreatedAt", "CREATED AT")
		DataGridView1.Columns.Add("colOrderDate", "ORDER DATE")
	End Sub

	'LOAD DGV
	Private Sub LoadLogs()
		Try
			OpenConnection()
			DataGridView1.Rows.Clear()

			Dim offset As Integer = (currentPage - 1) * pageSize
			Dim searchKeyword As String = TextBox2.Text.Trim()

			Dim query As String = "
                SELECT order_id, user_id, subtotal, discount_amount, total_amount, created_at, order_date
                FROM orders"

			If Not String.IsNullOrEmpty(searchKeyword) Then
				query &= " WHERE order_id LIKE @search OR user_id LIKE @search"
			End If

			query &= " ORDER BY created_at DESC LIMIT @limit OFFSET @offset"

			Dim cmd As New MySqlCommand(query, conn)
			cmd.Parameters.AddWithValue("@limit", pageSize)
			cmd.Parameters.AddWithValue("@offset", offset)

			If Not String.IsNullOrEmpty(searchKeyword) Then
				cmd.Parameters.AddWithValue("@search", "%" & searchKeyword & "%")
			End If

			Dim reader As MySqlDataReader = cmd.ExecuteReader()
			While reader.Read()
				Dim rowIndex As Integer = DataGridView1.Rows.Add()
				Dim row As DataGridViewRow = DataGridView1.Rows(rowIndex)

				row.Cells("colOrderId").Value = reader("order_id")
				row.Cells("colUserId").Value = If(IsDBNull(reader("user_id")), "N/A", reader("user_id"))
				row.Cells("colSubtotal").Value = Convert.ToDecimal(reader("subtotal")).ToString("F2")
				row.Cells("colDiscount").Value = Convert.ToDecimal(reader("discount_amount")).ToString("F2")
				row.Cells("colTotal").Value = Convert.ToDecimal(reader("total_amount")).ToString("F2")
				row.Cells("colCreatedAt").Value = Convert.ToDateTime(reader("created_at")).ToString("yyyy-MM-dd HH:mm:ss")
				row.Cells("colOrderDate").Value = Convert.ToDateTime(reader("order_date")).ToString("yyyy-MM-dd HH:mm:ss")
			End While
			reader.Close()

		Catch ex As Exception
			MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			CloseConnection()
		End Try
	End Sub

	' PAGINATION
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

	' NAVIGATION
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Hide()
		Admin_ManageProducts.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Admin_Homevb.Show()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Admin_ManageEmp.Show()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Hide()
		Admin_InvLogs.Show()
	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Me.Hide()
		Admin_ManageIngredients.Show()
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Me.Hide()
		Start.Show()
	End Sub
End Class