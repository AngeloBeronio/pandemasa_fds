Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Admin_Homevb
	Private Sub Admin_Homevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		MonthCalendar1.MaxSelectionCount = 1
		MonthCalendar1.SetDate(DateTime.Today)
		LoadDashboard(DateTime.Today)
	End Sub

	Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
		Dim chosenDate As Date = MonthCalendar1.SelectionStart.Date
		LoadDashboard(chosenDate)
	End Sub

	Private Sub LoadDashboard(selectedDate As Date)
		LoadStatusCounts()
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
				"SELECT COALESCE(SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity), 0) " &
				"FROM order_items oi " &
				"INNER JOIN orders o ON oi.order_id = o.order_id " &
				"INNER JOIN products p ON oi.product_id = p.product_id " &
				"WHERE DATE(o.order_date) = @d"
			Dim profitCommand As New MySqlCommand(profitQuery, conn)
			profitCommand.Parameters.AddWithValue("@d", dateAsText)
			Dim totalProfit As Decimal = Convert.ToDecimal(profitCommand.ExecuteScalar())

			Label4.Text = "₱" & totalRevenue.ToString("N2")
			Label5.Text = "₱" & totalProfit.ToString("N2")
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
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim userInput As String = InputBox("Enter new low stock threshold:", "Set Threshold", "10")
		Dim newThreshold As Integer
		Dim inputIsValidNumber As Boolean = Integer.TryParse(userInput, newThreshold)
		If inputIsValidNumber AndAlso newThreshold >= 0 Then
			SaveNewThreshold(newThreshold)
		ElseIf userInput <> "" Then
			MessageBox.Show("Please enter a valid positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
	End Sub

	Private Sub SaveNewThreshold(newThreshold As Integer)
		Try
			OpenConnection()
			Dim updateThresholdQuery As String = "UPDATE products SET low_stock_threshold = @threshold"
			Dim updateThresholdCommand As New MySqlCommand(updateThresholdQuery, conn)
			updateThresholdCommand.Parameters.AddWithValue("@threshold", newThreshold)
			updateThresholdCommand.ExecuteNonQuery()

			Dim updateStatusQuery As String =
				"UPDATE products SET status = CASE " &
				"WHEN stock_quantity <= 0 THEN 'Unavailable' " &
				"WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock' " &
				"ELSE 'Available' " &
				"END"
			Dim updateStatusCommand As New MySqlCommand(updateStatusQuery, conn)
			updateStatusCommand.ExecuteNonQuery()

			MessageBox.Show("Threshold updated and stock states recalculated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			LoadDashboard(MonthCalendar1.SelectionStart.Date)
		Catch ex As Exception
			MessageBox.Show("Error saving threshold: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	' CREATE REPORT
	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Dim selectedDate As Date = MonthCalendar1.SelectionStart.Date
		Dim saveDialog As New SaveFileDialog()
		saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
		saveDialog.FileName = "Sales_Report_" & selectedDate.ToString("yyyy-MM-dd") & ".pdf"
		Dim userClickedSave As Boolean = (saveDialog.ShowDialog() = DialogResult.OK)
		If userClickedSave Then
			ExportSalesReportToPdf(selectedDate, saveDialog.FileName)
		End If
	End Sub

	Private Sub ExportSalesReportToPdf(selectedDate As Date, filePath As String)
		Try
			OpenConnection()
			Dim salesQuery As String =
				"SELECT p.product_name, SUM(oi.quantity) AS total_qty, " &
				"SUM(oi.quantity * oi.price_at_sale) AS total_revenue, " &
				"SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity) AS total_profit " &
				"FROM order_items oi " &
				"INNER JOIN orders o ON oi.order_id = o.order_id " &
				"INNER JOIN products p ON oi.product_id = p.product_id " &
				"WHERE o.order_date >= @start AND o.order_date < @end " &
				"GROUP BY p.product_id, p.product_name"
			Dim cmdSales As New MySqlCommand(salesQuery, conn)
			cmdSales.Parameters.AddWithValue("@start", selectedDate.Date)
			cmdSales.Parameters.AddWithValue("@end", selectedDate.Date.AddDays(1))
			Dim reader As MySqlDataReader = cmdSales.ExecuteReader()

			Dim doc As New Document(PageSize.A4, 36, 36, 54, 36)
			Using fs As New System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write)
				Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
				doc.Open()

				Dim normalFont As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10)
				Dim boldFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)
				Dim titleFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)
				Dim netFont As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13)

				Dim title As New Paragraph("Sales & Payroll Report", titleFont)
				title.SpacingAfter = 4
				doc.Add(title)

				Dim datePara As New Paragraph("Date: " & selectedDate.ToString("MMMM d, yyyy"), normalFont)
				datePara.SpacingAfter = 12
				doc.Add(datePara)

				Dim table As New PdfPTable(4)
				table.WidthPercentage = 100
				table.SpacingAfter = 12

				For Each header As String In {"Product", "Qty", "Revenue", "Gross Profit"}
					Dim cell As New PdfPCell(New Phrase(header, boldFont))
					cell.BackgroundColor = BaseColor.LIGHT_GRAY
					cell.Padding = 5
					table.AddCell(cell)
				Next

				Dim totalRev As Decimal = 0
				Dim grossProfit As Decimal = 0

				While reader.Read()
					Dim pName As String = reader("product_name").ToString()
					Dim qty As String = reader("total_qty").ToString()
					Dim rev As Decimal = Convert.ToDecimal(reader("total_revenue"))
					Dim prof As Decimal = Convert.ToDecimal(reader("total_profit"))

					table.AddCell(New PdfPCell(New Phrase(pName, normalFont)) With {.Padding = 5})
					table.AddCell(New PdfPCell(New Phrase(qty, normalFont)) With {.Padding = 5})
					table.AddCell(New PdfPCell(New Phrase("PHP " & rev.ToString("N2"), normalFont)) With {.Padding = 5})
					table.AddCell(New PdfPCell(New Phrase("PHP " & prof.ToString("N2"), normalFont)) With {.Padding = 5})

					totalRev += rev
					grossProfit += prof
				End While
				reader.Close()

				doc.Add(table)

				Dim salaryQuery As String =
					"SELECT COALESCE(SUM(e.salary_per_day), 0) FROM attendance a " &
					"INNER JOIN employees e ON a.employee_id = e.employee_id WHERE a.work_date = @d"
				Dim cmdSalary As New MySqlCommand(salaryQuery, conn)
				cmdSalary.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
				Dim totalSalary As Decimal = Convert.ToDecimal(cmdSalary.ExecuteScalar())

				Dim netProfit As Decimal = grossProfit - totalSalary

				doc.Add(New Paragraph("Total Revenue: PHP " & totalRev.ToString("N2"), boldFont))
				doc.Add(New Paragraph("Gross Profit: PHP " & grossProfit.ToString("N2"), boldFont))
				doc.Add(New Paragraph("Employee Salaries: PHP " & totalSalary.ToString("N2"), boldFont))
				doc.Add(New Paragraph("-----------------------------------------------------------------", normalFont))

				Dim netPara As New Paragraph("True Net Profit: PHP " & netProfit.ToString("N2"), netFont)
				netPara.SpacingBefore = 4
				doc.Add(netPara)

				doc.Close()
			End Using

			MessageBox.Show("Report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("Error: " & ex.Message)
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
		Me.Hide()
		Admin_InvLogs.Show()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Hide()
		Admin_GrossProfit.Show()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

	End Sub
End Class