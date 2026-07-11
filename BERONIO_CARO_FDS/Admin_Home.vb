Imports MySql.Data.MySqlClient

Public Class Admin_Homevb
	Private Sub Admin_Homevb_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		LoadDashboard(DateTime.Today)
	End Sub

	Private Sub LoadDashboard(selectedDate As Date)
		LoadStatusCounts()
		LoadTargetQuotaAndRevenue(selectedDate)
		LoadRevenueAndProfit(selectedDate)
		LoadOrderCount(selectedDate)
		LoadTopSelling(selectedDate)
	End Sub

	Private Sub LoadStatusCounts()
		Dim unavailableCount As Integer = 0
		Dim lowStockCount As Integer = 0
		Dim availableCount As Integer = 0

		Try
			OpenConnection()
			Dim statusQuery As String = "SELECT status, COUNT(*) AS cnt FROM products GROUP BY status"
			Dim cmd As New MySqlCommand(statusQuery, conn)
			Dim reader As MySqlDataReader = cmd.ExecuteReader()

			While reader.Read()
				Dim currentStatus As String = reader("status").ToString()
				Dim currentCount As Integer = Convert.ToInt32(reader("cnt"))

				If currentStatus = "Unavailable" Then
					unavailableCount = currentCount
				ElseIf currentStatus = "Low in Stock" Then
					lowStockCount = currentCount
				ElseIf currentStatus = "Available" Then
					availableCount = currentCount
				End If
			End While

			reader.Close()

			Label1.Text = unavailableCount.ToString()
			Label2.Text = lowStockCount.ToString()
			Label3.Text = availableCount.ToString()
		Catch ex As Exception
			MessageBox.Show("Error loading status counts: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub LoadRevenueAndProfit(selectedDate As Date)
		Try
			OpenConnection()
			Dim dateAsText As String = selectedDate.ToString("yyyy-MM-dd")

			Dim revenueQuery As String = "SELECT COALESCE(SUM(total_amount), 0) FROM orders WHERE DATE(order_date) = @d"
			Dim revenueCommand As New MySqlCommand(revenueQuery, conn)
			revenueCommand.Parameters.AddWithValue("@d", dateAsText)
			Dim totalRevenue As Decimal = Convert.ToDecimal(revenueCommand.ExecuteScalar())

			Dim profitQuery As String =
				"SELECT COALESCE(SUM((oi.price_at_sale - pec.cost_per_piece) * oi.quantity), 0) " &
				"FROM order_items oi " &
				"INNER JOIN orders o ON oi.order_id = o.order_id " &
				"INNER JOIN product_estimated_costs pec ON oi.product_id = pec.product_id " &
				"WHERE DATE(o.order_date) = @d"
			Dim profitCommand As New MySqlCommand(profitQuery, conn)
			profitCommand.Parameters.AddWithValue("@d", dateAsText)
			Dim totalProfit As Decimal = Convert.ToDecimal(profitCommand.ExecuteScalar())

			Label4.Text = "₱" & totalRevenue.ToString("N2")
		Catch ex As Exception
			MessageBox.Show("Error loading financial stats: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub LoadOrderCount(selectedDate As Date)
		Try
			OpenConnection()
			Dim orderCountQuery As String = "SELECT COUNT(*) FROM orders WHERE DATE(order_date) = @d"
			Dim cmd As New MySqlCommand(orderCountQuery, conn)
			cmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
			Label6.Text = cmd.ExecuteScalar().ToString()
		Catch ex As Exception
			MessageBox.Show("Error loading order count: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub LoadTopSelling(selectedDate As Date)
		Try
			OpenConnection()
			SetUpTopSellingGrid()

			Dim topSellingQuery As String =
				"SELECT p.product_name, SUM(oi.quantity * oi.price_at_sale) AS total_revenue " &
				"FROM order_items oi " &
				"INNER JOIN orders o ON oi.order_id = o.order_id " &
				"INNER JOIN products p ON oi.product_id = p.product_id " &
				"WHERE DATE(o.order_date) = @d " &
				"GROUP BY p.product_id, p.product_name " &
				"ORDER BY SUM(oi.quantity) DESC LIMIT 9"
			Dim cmd As New MySqlCommand(topSellingQuery, conn)
			cmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
			Dim reader As MySqlDataReader = cmd.ExecuteReader()

			While reader.Read()
				Dim productName As String = reader("product_name").ToString()
				Dim revenueForProduct As Decimal = Convert.ToDecimal(reader("total_revenue"))
				Dim revenueAsText As String = "₱" & revenueForProduct.ToString("N2")
				DataGridView1.Rows.Add(productName, revenueAsText)
			End While

			reader.Close()
		Catch ex As Exception
			MessageBox.Show("Error loading top sellers: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub LoadTargetQuotaAndRevenue(selectedDate As Date)
		Try
			OpenConnection()

			' Total Revenue for the day
			Dim revenueQuery As String =
			"SELECT COALESCE(SUM(oi.quantity * oi.price_at_sale), 0) " &
			"FROM order_items oi " &
			"INNER JOIN orders o ON oi.order_id = o.order_id " &
			"WHERE DATE(o.order_date) = @d"
			Dim revenueCmd As New MySqlCommand(revenueQuery, conn)
			revenueCmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
			Dim totalRevenue As Decimal = Convert.ToDecimal(revenueCmd.ExecuteScalar())

			' Total COGS for the day (cost of products sold)
			Dim cogsQuery As String =
			"SELECT COALESCE(SUM(COALESCE(pec.cost_per_piece, 0) * oi.quantity), 0) " &
			"FROM order_items oi " &
			"INNER JOIN orders o ON oi.order_id = o.order_id " &
			"LEFT JOIN product_estimated_costs pec ON oi.product_id = pec.product_id " &
			"WHERE DATE(o.order_date) = @d"
			Dim cogsCmd As New MySqlCommand(cogsQuery, conn)
			cogsCmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
			Dim totalCogs As Decimal = Convert.ToDecimal(cogsCmd.ExecuteScalar())

			' Total Salaries for the day (employees who attended)
			Dim salaryQuery As String =
			"SELECT COALESCE(SUM(e.salary_per_day), 0) " &
			"FROM attendance a " &
			"INNER JOIN employees e ON a.employee_id = e.employee_id " &
			"WHERE a.work_date = @d"
			Dim salaryCmd As New MySqlCommand(salaryQuery, conn)
			salaryCmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
			Dim totalSalaries As Decimal = Convert.ToDecimal(salaryCmd.ExecuteScalar())

			Dim targetQuota As Decimal = totalCogs + totalSalaries

			Label5.Text = "₱" & targetQuota.ToString("N2")
			Label7.Text = "₱" & totalRevenue.ToString("N2")

		Catch ex As Exception
			MessageBox.Show("Error loading quota and revenue: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub SetUpTopSellingGrid()
		DataGridView1.Columns.Clear()
		DataGridView1.RowHeadersVisible = False
		DataGridView1.AllowUserToAddRows = False
		DataGridView1.ReadOnly = True
		DataGridView1.Columns.Add("colProduct", "Top-selling")
		DataGridView1.Columns.Add("colRevenue", "Revenue")
		DataGridView1.Columns("colProduct").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
	End Sub

	' SET THRESHOLD AND UPDATE STATUS
	' BUTTON 1 — Set Low Stock Threshold
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim userInput As String = InputBox("Enter new low stock threshold:", "Set Threshold", "10")
		Dim newThreshold As Integer

		If userInput = "" Then Exit Sub

		If Integer.TryParse(userInput, newThreshold) AndAlso newThreshold >= 0 Then
			SaveSetting("low_stock_threshold", newThreshold.ToString())
			UpdateProductStatuses(newThreshold)
			MessageBox.Show("Threshold saved and stock statuses updated!", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			MessageBox.Show("Please enter a valid positive number.", "Invalid Input",
						MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
	End Sub

	' BUTTON 2 — Set Warning Time
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim userInput As String = InputBox(
		"Enter the time to show low stock warning on cashier screen (24hr format, e.g. 08:00):",
		"Set Warning Time", "08:00")

		If userInput = "" Then Exit Sub

		Dim parsedTime As TimeSpan
		If TimeSpan.TryParse(userInput, parsedTime) Then
			SaveSetting("warning_time", parsedTime.ToString("hh\:mm"))
			MessageBox.Show("Warning time set to " & parsedTime.ToString("hh\:mm") & ".",
						"Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			MessageBox.Show("Invalid time format. Please use HH:mm (e.g. 08:00).", "Invalid Input",
						MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
	End Sub

	' Save any key-value setting to the database
	Private Sub SaveSetting(key As String, value As String)
		Try
			OpenConnection()
			Dim query As String =
			"INSERT INTO set_ls_time (setting_key, setting_value) VALUES (@k, @v) " &
			"ON DUPLICATE KEY UPDATE setting_value = @v"
			Dim cmd As New MySqlCommand(query, conn)
			cmd.Parameters.AddWithValue("@k", key)
			cmd.Parameters.AddWithValue("@v", value)
			cmd.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("Error saving setting: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' Update product statuses based on new threshold
	Private Sub UpdateProductStatuses(newThreshold As Integer)
		Try
			OpenConnection()

			Dim updateThresholdQuery As String = "UPDATE products SET low_stock_threshold = @threshold"
			Dim cmd1 As New MySqlCommand(updateThresholdQuery, conn)
			cmd1.Parameters.AddWithValue("@threshold", newThreshold)
			cmd1.ExecuteNonQuery()

			Dim updateStatusQuery As String =
			"UPDATE products SET status = CASE " &
			"WHEN stock_quantity <= 0 THEN 'Unavailable' " &
			"WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock' " &
			"ELSE 'Available' " &
			"END"
			Dim cmd2 As New MySqlCommand(updateStatusQuery, conn)
			cmd2.ExecuteNonQuery()
		Catch ex As Exception
			MessageBox.Show("Error updating product statuses: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' OPEN REPORT OPTIONS
	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Me.Hide()
		ReportOptions.Show()
	End Sub

	' NAVIGATION
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Me.Hide()
		Admin_ManageProducts.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Hide()
		Admin_OrdLogs.Show()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Admin_ManageIngredients.Show()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Hide()
		Admin_ManageEmp.Show()
	End Sub

	Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
		Admin_InvLogs.Show()
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Me.Hide()
		Start.Show()
	End Sub
End Class