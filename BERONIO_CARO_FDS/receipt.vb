Imports MySql.Data.MySqlClient

Public Class receipt
	<System.ComponentModel.DefaultValue(0)>
	Public Property OrderId As Integer

	<System.ComponentModel.DefaultValue(0D)>
	Public Property CashAmount As Decimal

	<System.ComponentModel.DefaultValue(0D)>
	Public Property ChangeAmount As Decimal

	' FORM LOAD
	Private Sub Receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupReceiptGrid()
		LoadReceiptData()
	End Sub

	' SETUP DATAGRIDVIEW
	Private Sub SetupReceiptGrid()
		dgvReceipt.Columns.Clear()
		dgvReceipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
		dgvReceipt.AllowUserToAddRows = False
		dgvReceipt.ReadOnly = True
		dgvReceipt.RowHeadersVisible = False
		dgvReceipt.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvReceipt.RowTemplate.Height = 30

		dgvReceipt.Columns.Add("colName", "Product")
		dgvReceipt.Columns.Add("colQty", "Qty")
		dgvReceipt.Columns.Add("colPrice", "Unit Price")
		dgvReceipt.Columns.Add("colTotal", "Total")

		dgvReceipt.Columns("colName").Width = 300
		dgvReceipt.Columns("colQty").Width = 80
		dgvReceipt.Columns("colPrice").Width = 80
		dgvReceipt.Columns("colTotal").Width = 80
	End Sub

	' LOAD ORDER
	Private Sub LoadReceiptData()
		Try
			OpenConnection()
			Dim orderCmd As New MySqlCommand(
				"SELECT subtotal, discount_amount, total_amount,
                        order_date
                 FROM orders WHERE order_id = @oid", conn)
			orderCmd.Parameters.AddWithValue("@oid", OrderId)

			Dim reader As MySqlDataReader = orderCmd.ExecuteReader()

			Dim subtotal As Decimal = 0
			Dim discount As Decimal = 0
			Dim total As Decimal = 0
			Dim orderDate As String = ""

			If reader.Read() Then
				subtotal = reader.GetDecimal("subtotal")
				discount = reader.GetDecimal("discount_amount")
				total = reader.GetDecimal("total_amount")
				orderDate = reader.GetDateTime("order_date").ToString("MM/dd/yyyy hh:mm tt")
			End If
			reader.Close()

			Dim itemCmd As New MySqlCommand(
				"SELECT p.product_name, oi.quantity, oi.price_at_sale,
                        (oi.quantity * oi.price_at_sale) AS line_total
                 FROM order_items oi
                 INNER JOIN products p ON oi.product_id = p.product_id
                 WHERE oi.order_id = @oid", conn)
			itemCmd.Parameters.AddWithValue("@oid", OrderId)

			Dim itemReader As MySqlDataReader = itemCmd.ExecuteReader()
			dgvReceipt.Rows.Clear()

			While itemReader.Read()
				dgvReceipt.Rows.Add(
					itemReader.GetString("product_name"),
					itemReader.GetInt32("quantity"),
					"₱" & itemReader.GetDecimal("price_at_sale").ToString("0.00"),
					"₱" & itemReader.GetDecimal("line_total").ToString("0.00")
				)
			End While
			itemReader.Close()

			lblOrderId.Text = "Order #: " & OrderId.ToString()
			lblDate.Text = "Date: " & orderDate
			lblSubtotal.Text = "₱" & subtotal.ToString("0.00")
			lblDiscount.Text = "₱" & discount.ToString("0.00")
			lblTotal.Text = "₱" & total.ToString("0.00")
			lblChange.Text = "₱" & ChangeAmount.ToString("0.00")

		Catch ex As Exception
			MessageBox.Show("Error loading receipt: " & ex.Message, "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			CloseConnection()
		End Try
	End Sub

	' CLOSE
	Private Sub btnNewTransaction_Click(sender As Object, e As EventArgs)
		Hide()
		Menu__1_.Show()
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Hide()
		Start.Show()
	End Sub
End Class