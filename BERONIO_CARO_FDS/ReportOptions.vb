Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class ReportOptions

	Private Sub ReportOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		MonthCalendar1.MaxSelectionCount = 1
		MonthCalendar1.SetDate(DateTime.Today)

		PopulateMonthDropdown()

		RadioButton1.Checked = True
		ToggleModeControls()
	End Sub

	Private Sub PopulateMonthDropdown()
		ComboBox1.Items.Clear()
		Dim cursor As Date = New Date(DateTime.Today.Year, DateTime.Today.Month, 1)

		For i As Integer = 0 To 11
			ComboBox1.Items.Add(cursor.ToString("MMMM yyyy"))
			cursor = cursor.AddMonths(-1)
		Next

		ComboBox1.SelectedIndex = 0
	End Sub

	Private Sub Radiobutton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
		ToggleModeControls()
	End Sub

	Private Sub Radiobutton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
		ToggleModeControls()
	End Sub

	Private Sub ToggleModeControls()
		ComboBox1.Enabled = RadioButton1.Checked
		MonthCalendar1.Enabled = RadioButton2.Checked
	End Sub

	' GENERATE REPORT
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim rangeStart As Date
		Dim rangeEnd As Date
		Dim fileLabel As String

		If RadioButton2.Checked Then
			If ComboBox1.SelectedItem Is Nothing Then
				MessageBox.Show("Please select a month.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return
			End If

			Dim monthText As String = ComboBox1.SelectedItem.ToString()
			rangeStart = Date.ParseExact(monthText, "MMMM yyyy", Globalization.CultureInfo.InvariantCulture)
			rangeEnd = rangeStart.AddMonths(1)
			fileLabel = rangeStart.ToString("yyyy-MM")
		Else
			rangeStart = MonthCalendar1.SelectionStart.Date
			rangeEnd = rangeStart.AddDays(1)
			fileLabel = rangeStart.ToString("yyyy-MM-dd")
		End If

		Dim saveDialog As New SaveFileDialog()
		saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
		saveDialog.FileName = "Sales_and_Payroll_Report_" & fileLabel & ".pdf"

		Dim userClickedSave As Boolean = (saveDialog.ShowDialog() = DialogResult.OK)
		If userClickedSave Then
			ExportSalesReportToPdf(rangeStart, rangeEnd, saveDialog.FileName)
		End If
	End Sub

	Private Sub ExportSalesReportToPdf(rangeStart As Date, rangeEnd As Date, filePath As String)
		Try
			OpenConnection()

			Dim salesQuery As String =
			"SELECT p.product_id, p.product_name, SUM(oi.quantity) AS total_qty, " &
			"SUM(oi.quantity * oi.price_at_sale) AS total_revenue, " &
			"SUM(oi.quantity * COALESCE(oi.net_price_sale, oi.price_at_sale * 0.88)) AS total_net_revenue, " &
			"SUM(COALESCE(pec.cost_per_piece, 0) * oi.quantity) AS total_cogs, " &
			"SUM((COALESCE(oi.net_price_sale, oi.price_at_sale * 0.88) - COALESCE(pec.cost_per_piece, 0)) * oi.quantity) AS gross_profit " &
			"FROM order_items oi " &
			"INNER JOIN orders o ON oi.order_id = o.order_id " &
			"INNER JOIN products p ON oi.product_id = p.product_id " &
			"LEFT JOIN product_estimated_costs pec ON oi.product_id = pec.product_id " &
			"WHERE o.order_date >= @start AND o.order_date < @end " &
			"GROUP BY p.product_id, p.product_name"
			Dim cmdSales As New MySqlCommand(salesQuery, conn)
			cmdSales.Parameters.AddWithValue("@start", rangeStart)
			cmdSales.Parameters.AddWithValue("@end", rangeEnd)

			Dim salesTable As New DataTable()
			Using reader As MySqlDataReader = cmdSales.ExecuteReader()
				salesTable.Load(reader)
			End Using

			Dim salaryQuery As String =
			"SELECT e.employee_id, e.last_name, e.first_name, r.role_name, e.salary_per_day, " &
			"COUNT(a.schedule_id) AS days_attended, SUM(e.salary_per_day) AS total_salary " &
			"FROM attendance a " &
			"INNER JOIN employees e ON a.employee_id = e.employee_id " &
			"INNER JOIN roles r ON e.role_id = r.role_id " &
			"WHERE a.work_date >= @start AND a.work_date < @end " &
			"GROUP BY e.employee_id, e.last_name, e.first_name, r.role_name, e.salary_per_day"
			Dim cmdSalary As New MySqlCommand(salaryQuery, conn)
			cmdSalary.Parameters.AddWithValue("@start", rangeStart.ToString("yyyy-MM-dd"))
			cmdSalary.Parameters.AddWithValue("@end", rangeEnd.ToString("yyyy-MM-dd"))

			Dim payrollTable As New DataTable()
			Using reader As MySqlDataReader = cmdSalary.ExecuteReader()
				payrollTable.Load(reader)
			End Using

			Dim aggregateRevenue As Decimal = 0
			Dim aggregateNetRevenue As Decimal = 0
			Dim aggregateCogs As Decimal = 0
			Dim aggregateGrossProfit As Decimal = 0

			For Each row As DataRow In salesTable.Rows
				aggregateRevenue += Convert.ToDecimal(row("total_revenue"))
				aggregateNetRevenue += Convert.ToDecimal(row("total_net_revenue"))
				aggregateCogs += Convert.ToDecimal(row("total_cogs"))
				aggregateGrossProfit += Convert.ToDecimal(row("gross_profit"))
			Next

			Dim aggregateVatAmount As Decimal = aggregateNetRevenue - aggregateRevenue

			Dim aggregateSalaries As Decimal = 0
			For Each row As DataRow In payrollTable.Rows
				aggregateSalaries += Convert.ToDecimal(row("total_salary"))
			Next

			Dim ultimateNetProfit As Decimal = aggregateGrossProfit - aggregateSalaries

			Dim doc As New Document(PageSize.A4, 36, 36, 54, 36)
			Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
				Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
				doc.Open()

				Dim titleFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, BaseColor.DARK_GRAY)
				Dim subtitleFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.GRAY)
				Dim sectionFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK)
				Dim boldFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK)
				Dim normalFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK)
				Dim captionFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.GRAY)
				Dim totalProfitValFont As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 26, New BaseColor(34, 139, 34))

				Dim rangeLabel As String
				If rangeEnd = rangeStart.AddDays(1) Then
					rangeLabel = "as of " & rangeStart.ToString("MMMM d, yyyy")
				Else
					rangeLabel = "for " & rangeStart.ToString("MMMM yyyy")
				End If

				Dim pTitle As New Paragraph("Sales & Payroll Report", titleFont)
				pTitle.Alignment = Element.ALIGN_CENTER
				doc.Add(pTitle)

				' TOTAL PROFIT BOX
				Dim summaryBoxTable As New PdfPTable(1)
				summaryBoxTable.WidthPercentage = 60
				summaryBoxTable.HorizontalAlignment = Element.ALIGN_CENTER
				summaryBoxTable.SpacingBefore = 15
				summaryBoxTable.SpacingAfter = 20

				Dim containerCell As New PdfPCell()
				containerCell.BackgroundColor = New BaseColor(245, 245, 245)
				containerCell.Padding = 12
				containerCell.BorderWidth = 1
				containerCell.BorderColor = BaseColor.LIGHT_GRAY
				containerCell.HorizontalAlignment = Element.ALIGN_CENTER

				Dim pBoxTitle As New Paragraph("Total Profit", subtitleFont)
				pBoxTitle.Alignment = Element.ALIGN_CENTER
				containerCell.AddElement(pBoxTitle)

				Dim pBoxSub As New Paragraph(rangeLabel, subtitleFont)
				pBoxSub.Alignment = Element.ALIGN_CENTER
				containerCell.AddElement(pBoxSub)

				Dim pBoxValue As New Paragraph("PHP " & ultimateNetProfit.ToString("N2"), totalProfitValFont)
				pBoxValue.Alignment = Element.ALIGN_CENTER
				pBoxValue.SpacingBefore = 4
				containerCell.AddElement(pBoxValue)

				Dim pBoxCaption As New Paragraph("Gross Profit - Total Salary Deduction", captionFont)
				pBoxCaption.Alignment = Element.ALIGN_CENTER
				containerCell.AddElement(pBoxCaption)

				summaryBoxTable.AddCell(containerCell)
				doc.Add(summaryBoxTable)

				' SUMMARY ROWS WITH CAPTIONS
				Dim financialTable As New PdfPTable(3)
				financialTable.WidthPercentage = 100
				financialTable.SetWidths({45.0F, 20.0F, 35.0F})
				financialTable.SpacingAfter = 25

				AddFinancialRow(financialTable, "Total Revenue", "PHP " & aggregateRevenue.ToString("N2"), "sum of price at sale from order_item", normalFont, captionFont)
				AddFinancialRow(financialTable, "Total VAT Amount", "PHP " & aggregateVatAmount.ToString("N2"), "total net revenue - total revenue", normalFont, captionFont)
				AddFinancialRow(financialTable, "Total Net Revenue", "PHP " & aggregateNetRevenue.ToString("N2"), "sum of net_price_sale from order_item", boldFont, captionFont)
				AddFinancialRow(financialTable, "Total Cost of Goods Sold", "PHP " & (-aggregateCogs).ToString("N2"), "sum of cost price", normalFont, captionFont)
				AddFinancialRow(financialTable, "Total Salary Deduction", "PHP " & (-aggregateSalaries).ToString("N2"), "sum of all employee salaries", normalFont, captionFont)
				AddFinancialRow(financialTable, "Total Gross Profit", "PHP " & aggregateGrossProfit.ToString("N2"), "Net Revenue - Total Cost of Goods Sold", boldFont, captionFont)
				doc.Add(financialTable)

				' PRODUCTS SOLD TABLE - 7 columns
				doc.Add(New Paragraph("Products Sold", sectionFont) With {.SpacingAfter = 8})

				Dim prodTable As New PdfPTable(7)
				prodTable.WidthPercentage = 100
				prodTable.SetWidths({10.0F, 22.0F, 10.0F, 15.0F, 15.0F, 15.0F, 13.0F})
				prodTable.SpacingAfter = 25

				For Each header As String In {"ProductID", "Product Name", "Qty", "Revenue", "Net Revenue", "Cost of Goods Sold", "Gross Profit"}
					Dim cell As New PdfPCell(New Phrase(header, boldFont)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .Padding = 6}
					prodTable.AddCell(cell)
				Next

				For Each row As DataRow In salesTable.Rows
					prodTable.AddCell(New PdfPCell(New Phrase(row("product_id").ToString(), normalFont)) With {.Padding = 5})
					prodTable.AddCell(New PdfPCell(New Phrase(row("product_name").ToString(), normalFont)) With {.Padding = 5})
					prodTable.AddCell(New PdfPCell(New Phrase(row("total_qty").ToString(), normalFont)) With {.Padding = 5})
					prodTable.AddCell(New PdfPCell(New Phrase("PHP " & Convert.ToDecimal(row("total_revenue")).ToString("N2"), normalFont)) With {.Padding = 5})
					prodTable.AddCell(New PdfPCell(New Phrase("PHP " & Convert.ToDecimal(row("total_net_revenue")).ToString("N2"), normalFont)) With {.Padding = 5})
					prodTable.AddCell(New PdfPCell(New Phrase("PHP " & Convert.ToDecimal(row("total_cogs")).ToString("N2"), normalFont)) With {.Padding = 5})
					prodTable.AddCell(New PdfPCell(New Phrase("PHP " & Convert.ToDecimal(row("gross_profit")).ToString("N2"), normalFont)) With {.Padding = 5})
				Next

				doc.Add(prodTable)
				doc.NewPage()

				doc.Add(New Paragraph("Employee Salary", sectionFont) With {.SpacingAfter = 4})
				doc.Add(New Paragraph(rangeLabel, subtitleFont) With {.SpacingAfter = 12})

				Dim payGrid As New PdfPTable(7)
				payGrid.WidthPercentage = 100
				payGrid.SetWidths({12.0F, 16.0F, 16.0F, 16.0F, 14.0F, 12.0F, 14.0F})

				For Each header As String In {"Employee ID", "Last Name", "First Name", "Role", "Salary", "Days Attended", "Total Salary"}
					Dim cell As New PdfPCell(New Phrase(header, boldFont)) With {.BackgroundColor = BaseColor.LIGHT_GRAY, .Padding = 6}
					payGrid.AddCell(cell)
				Next

				For Each row As DataRow In payrollTable.Rows
					payGrid.AddCell(New PdfPCell(New Phrase(row("employee_id").ToString(), normalFont)) With {.Padding = 5})
					payGrid.AddCell(New PdfPCell(New Phrase(row("last_name").ToString(), normalFont)) With {.Padding = 5})
					payGrid.AddCell(New PdfPCell(New Phrase(row("first_name").ToString(), normalFont)) With {.Padding = 5})
					payGrid.AddCell(New PdfPCell(New Phrase(row("role_name").ToString(), normalFont)) With {.Padding = 5})
					payGrid.AddCell(New PdfPCell(New Phrase("PHP " & Convert.ToDecimal(row("salary_per_day")).ToString("N2"), normalFont)) With {.Padding = 5})
					payGrid.AddCell(New PdfPCell(New Phrase(row("days_attended").ToString(), normalFont)) With {.Padding = 5})
					payGrid.AddCell(New PdfPCell(New Phrase("PHP " & Convert.ToDecimal(row("total_salary")).ToString("N2"), normalFont)) With {.Padding = 5})
				Next

				doc.Add(payGrid)
				doc.Close()
			End Using

			MessageBox.Show("Comprehensive report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("Error building report: " & ex.Message)
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub AddFinancialRow(ByRef table As PdfPTable, metricLabel As String, metricValue As String, caption As String, itemFont As iTextSharp.text.Font, captionFont As iTextSharp.text.Font)
		Dim lblCell As New PdfPCell(New Phrase(metricLabel, itemFont))
		lblCell.Padding = 6
		lblCell.BorderColor = BaseColor.LIGHT_GRAY

		Dim valCell As New PdfPCell(New Phrase(metricValue, itemFont))
		valCell.Padding = 6
		valCell.HorizontalAlignment = Element.ALIGN_RIGHT
		valCell.BorderColor = BaseColor.LIGHT_GRAY

		Dim captionCell As New PdfPCell(New Phrase(caption, captionFont))
		captionCell.Padding = 6
		captionCell.HorizontalAlignment = Element.ALIGN_LEFT
		captionCell.BorderColor = BaseColor.LIGHT_GRAY

		table.AddCell(lblCell)
		table.AddCell(valCell)
		table.AddCell(captionCell)
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

	End Sub
End Class