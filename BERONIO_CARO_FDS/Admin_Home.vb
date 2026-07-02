Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Admin_Homevb

	Private Sub Admin_Homevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		MonthCalendar1.MaxSelectionCount = 1
		MonthCalendar1.SetDate(DateTime.Today)
		LoadDashboard(DateTime.Today)
	End Sub

	Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
		LoadDashboard(MonthCalendar1.SelectionStart.Date)
	End Sub

	' MASTER LOAD 
	Private Sub LoadDashboard(selectedDate As Date)
		LoadStatusCounts()
		LoadRevenueAndProfit(selectedDate)
		LoadOrderCount(selectedDate)
		LoadTopSelling(selectedDate)
	End Sub

	' STOCK STATUS COUNTS 
	Private Sub LoadStatusCounts()
		Try
			OpenConnection()
			Dim query As String = "SELECT status, COUNT(*) AS cnt FROM products GROUP BY status"
			Dim cmd As New MySqlCommand(query, conn)
			Dim reader As MySqlDataReader = cmd.ExecuteReader()

			Dim unavailable As Integer = 0
			Dim lowStock As Integer = 0
			Dim available As Integer = 0

			While reader.Read()
				Select Case reader("status").ToString()
					Case "Unavailable"
						unavailable = Convert.ToInt32(reader("cnt"))
					Case "Low in Stock"
						lowStock = Convert.ToInt32(reader("cnt"))
					Case "Available"
						available = Convert.ToInt32(reader("cnt"))
				End Select
			End While
			reader.Close()

			Label1.Text = unavailable.ToString()
			Label2.Text = lowStock.ToString()
			Label3.Text = available.ToString()
		Catch ex As Exception
			MessageBox.Show("Error loading status counts: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' GROSS REVENUE + PROFIT FOR THE DAY 
	Private Sub LoadRevenueAndProfit(selectedDate As Date)
		Try
			OpenConnection()

			Dim revQuery As String = "SELECT COALESCE(SUM(total_amount), 0) AS gross FROM orders WHERE DATE(created_at) = @selDate"
			Dim revCmd As New MySqlCommand(revQuery, conn)
			revCmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
			Dim gross As Decimal = Convert.ToDecimal(revCmd.ExecuteScalar())
			Label4.Text = "₱" & gross.ToString("N2")

			Dim profitQuery As String = "
                SELECT COALESCE(SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity), 0) AS profit
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id
                WHERE DATE(o.created_at) = @selDate"
			Dim profitCmd As New MySqlCommand(profitQuery, conn)
			profitCmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
			Dim profit As Decimal = Convert.ToDecimal(profitCmd.ExecuteScalar())
			Label5.Text = "₱" & profit.ToString("N2")

		Catch ex As Exception
			MessageBox.Show("Error loading revenue/profit: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' NUMBER OF ORDERS 
	Private Sub LoadOrderCount(selectedDate As Date)
		Try
			OpenConnection()
			Dim query As String = "SELECT COUNT(*) FROM orders WHERE DATE(created_at) = @selDate"
			Dim cmd As New MySqlCommand(query, conn)
			cmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
			Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
			Label6.Text = count.ToString()
		Catch ex As Exception
			MessageBox.Show("Error loading order count: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' DATAGRIDVIEW1: TOP-SELLING PRODUCTS + REVENUE
	Private Sub LoadTopSelling(selectedDate As Date)
		Try
			OpenConnection()

			DataGridView1.Columns.Clear()
			DataGridView1.RowHeadersVisible = False
			DataGridView1.AllowUserToAddRows = False
			DataGridView1.ReadOnly = True
			DataGridView1.Columns.Add("colProduct", "Top-selling")
			DataGridView1.Columns.Add("colRevenue", "Revenue")
			DataGridView1.Columns("colProduct").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

			Dim query As String = "
                SELECT p.product_name,
                       SUM(oi.quantity) AS total_qty,
                       SUM(oi.quantity * oi.price_at_sale) AS total_revenue
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id
                WHERE DATE(o.created_at) = @selDate
                GROUP BY p.product_id, p.product_name
                ORDER BY total_qty DESC
                LIMIT 9"

			Dim cmd As New MySqlCommand(query, conn)
			cmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
			Dim reader As MySqlDataReader = cmd.ExecuteReader()

			While reader.Read()
				Dim pname As String = reader("product_name").ToString()
				Dim revenue As Decimal = Convert.ToDecimal(reader("total_revenue"))
				DataGridView1.Rows.Add(pname, "₱" & revenue.ToString("N2"))
			End While
			reader.Close()

		Catch ex As Exception
			MessageBox.Show("Error loading top-selling products: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' NAVIGATION 
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Me.Hide()
		Admin_Inv.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Admin_OrdLogs.Show()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Hide
		Admin_InvLogs.Show
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim input As String = InputBox("Enter new low stock threshold (applies to all products):", "Set Low Stock Threshold", "10")

		Dim newThreshold As Integer
		If Integer.TryParse(input, newThreshold) AndAlso newThreshold >= 0 Then
			Try
				OpenConnection()

				Dim updateThresholdQuery As String = "UPDATE products SET low_stock_threshold = @threshold"
				Dim cmd As New MySqlCommand(updateThresholdQuery, conn)
				cmd.Parameters.AddWithValue("@threshold", newThreshold)
				cmd.ExecuteNonQuery()

				Dim updateStatusQuery As String = "
                    UPDATE products
                    SET status = CASE
                        WHEN stock_quantity <= 0 THEN 'Unavailable'
                        WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock'
                        ELSE 'Available'
                    END"
				Dim statusCmd As New MySqlCommand(updateStatusQuery, conn)
				statusCmd.ExecuteNonQuery()

				MessageBox.Show("Low stock threshold updated and product statuses refreshed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
				LoadDashboard(MonthCalendar1.SelectionStart.Date)
			Catch ex As Exception
				MessageBox.Show("Error updating threshold: " & ex.Message)
			Finally
				CloseConnection()
			End Try
		ElseIf input <> "" Then
			MessageBox.Show("Please enter a valid non-negative number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Hide()
		EmpManage.Show()
	End Sub
End Class