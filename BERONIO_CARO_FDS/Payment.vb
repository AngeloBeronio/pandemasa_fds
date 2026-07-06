Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Payment

	Private isDiscounted As Boolean = False
	Private discountType As String = "None"
	Private isOnlinePayment As Boolean = False
	Public selectedPaymentMethod As String = "Cash"
	Private FEE_RATE As Decimal = 0.0

	Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupOrderGrid()
		LoadCartSummary()
		hchangelbl.Text = "Change"
	End Sub

	Private Sub Payment_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		LoadCartSummary()
	End Sub

	' NAVIGATION
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Hide()
		Menu_2_.Show()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Hide()
		Menu_3_.Show()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Menu_4_.Show()
	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Me.Hide()
		Menu__1_.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Menu_5_.Show()
	End Sub

	' sub-nav
	Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
		PaymentMethod.Show()
	End Sub

	Private Sub SetupOrderGrid()
		dgvOrder.Columns.Clear()
		dgvOrder.RowTemplate.Height = 35

		dgvOrder.Columns.Add("colProductId", "ID")
		dgvOrder.Columns.Add("colName", "Product")
		dgvOrder.Columns.Add("colQty", "Qty")
		dgvOrder.Columns.Add("colPrice", "Unit Price")
		dgvOrder.Columns.Add("colTotal", "Total")

		dgvOrder.Columns("colName").Width = 180
		dgvOrder.Columns("colProductId").Visible = False
	End Sub

	Private Sub LoadCartSummary()
		dgvOrder.Rows.Clear()

		For Each item As CartItem In CartItems
			dgvOrder.Rows.Add(
				item.ProductId,
				item.ProductName,
				item.Quantity,
				"₱" & item.UnitPrice.ToString("0.00"),
				"₱" & item.Total.ToString("0.00")
			)
		Next

		UpdateTotals()
	End Sub

	' UPDATE SUBTOTAL, DISCOUNT, FEE, TOTAL
	Private Sub UpdateTotals()
		Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
		Dim discount As Decimal = 0

		If isDiscounted Then
			discount = subtotal * 0.2
		End If

		Dim afterDiscount As Decimal = subtotal - discount
		Dim fee As Decimal = Math.Round(afterDiscount * FEE_RATE, 2)
		Dim total As Decimal = afterDiscount + fee

		lblSubtotal.Text = "₱" & subtotal.ToString("0.00")
		lblDiscount.Text = "₱" & discount.ToString("0.00")
		lblTotal.Text = "₱" & total.ToString("0.00")

		If isOnlinePayment Then
			lblchange.Text = "₱" & fee.ToString("0.00")
		ElseIf selectedPaymentMethod = "Card" Then
			lblchange.Text = "₱" & fee.ToString("0.00")
		Else
			Dim cash As Decimal = 0
			Decimal.TryParse(amoTendered.Text, cash)
			lblchange.Text = If(cash > 0, "₱" & (cash - total).ToString("0.00"), "₱0.00")
		End If
	End Sub

	Public Sub ApplyPaymentMethod(method As String)
		selectedPaymentMethod = method
		amoTendered.Text = "0"

		Select Case method
			Case "Cash"
				FEE_RATE = 0.0
				isOnlinePayment = False
				Button18.Text = "CASH"
				Button18.BackColor = Color.Orange
				Label2.Text = "Tendered Amount"
				hchangelbl.Text = "Change"
			Case "Card"
				FEE_RATE = 0.015
				isOnlinePayment = False
				Button18.Text = "CARD"
				Button18.BackColor = Color.Gray
				Label2.Text = "Card Payment"
				hchangelbl.Text = "Fee"
			Case "GCash"
				FEE_RATE = 0
				isOnlinePayment = True
				Button18.Text = "GCASH"
				Button18.BackColor = Color.Blue
				Label2.Text = "GCash Reference No."
				hchangelbl.Text = "Fee"
			Case "Maya"
				FEE_RATE = 0.01
				isOnlinePayment = True
				Button18.Text = "MAYA"
				Button18.BackColor = Color.Green
				Label2.Text = "Maya Reference No."
				hchangelbl.Text = "Fee"
		End Select

		UpdateTotals()
	End Sub

	' NUMPAD
	Private Sub AppendInput(value As String)
		If amoTendered.Text = "0" Then
			amoTendered.Text = value
		Else
			amoTendered.Text &= value
		End If
		If Not isOnlinePayment Then UpdateTotals()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		AppendInput("7")
	End Sub
	Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
		AppendInput("8")
	End Sub
	Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
		AppendInput("9")
	End Sub
	Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
		AppendInput("4")
	End Sub
	Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
		AppendInput("5")
	End Sub
	Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
		AppendInput("6")
	End Sub
	Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
		AppendInput("3")
	End Sub
	Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
		AppendInput("2")
	End Sub
	Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
		AppendInput("1")
	End Sub
	Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
		If Not isOnlinePayment Then AppendInput(".")
	End Sub
	Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
		AppendInput("0")
	End Sub
	Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
		If Not isOnlinePayment Then AppendInput("00")
	End Sub

	' BACKSPACE
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		If amoTendered.Text.Length > 1 Then
			amoTendered.Text = amoTendered.Text.Substring(0, amoTendered.Text.Length - 1)
		Else
			amoTendered.Text = "0"
		End If
		If Not isOnlinePayment Then UpdateTotals()
	End Sub

	' CLEAR
	Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
		amoTendered.Text = "0"
		If Not isOnlinePayment Then UpdateTotals()
	End Sub

	' DISCOUNT
	Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
		If Not isDiscounted Then
			isDiscounted = True
			discountType = "PWD/Senior"
			Button21.Text = "REMOVE DISCOUNT"
			Panel2.BackColor = Color.Green
		Else
			isDiscounted = False
			discountType = "None"
			Button21.Text = "PWD / SENIOR"
			Panel2.BackColor = Color.Red
		End If
		UpdateTotals()
	End Sub

	Private Sub amoTendered_TextChanged(sender As Object, e As EventArgs) Handles amoTendered.TextChanged
		If Not isOnlinePayment Then UpdateTotals()
	End Sub

	Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
		If CartItems.Count = 0 Then
			MessageBox.Show("Cart is empty.", "Nothing to Pay")
			Return
		End If

		Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
		Dim discount As Decimal = If(isDiscounted, subtotal * 0.2, 0)
		Dim afterDiscount As Decimal = subtotal - discount
		Dim fee As Decimal = Math.Round(afterDiscount * FEE_RATE, 2)
		Dim total As Decimal = afterDiscount + fee
		Dim cash As Decimal = 0
		Dim refNumber As String = ""

		Select Case selectedPaymentMethod
			Case "Cash"
				If Not Decimal.TryParse(amoTendered.Text, cash) OrElse cash < total Then
					MessageBox.Show("Insufficient cash amount.", "Payment Error",
								MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Return
				End If

			Case "GCash", "Maya"
				refNumber = amoTendered.Text.Trim()
				If refNumber = "" OrElse refNumber = "0" Then
					MessageBox.Show("Please enter the reference number.", "Missing Reference",
								MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Return
				End If

			Case "Card"
				Dim cardResult As DialogResult = MessageBox.Show(
					"Was the card payment approved on the terminal?",
					"Confirm Card Payment",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question)
				If cardResult = DialogResult.No Then
					MessageBox.Show("Card declined. Please try another payment method.",
									"Payment Declined",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning)
					Return
				End If
		End Select

		' PUT TO ORDER_LOGS
		Try
			OpenConnection()
			Dim transaction As MySqlTransaction = conn.BeginTransaction()

			Try
				Dim orderCmd As New MySqlCommand(
				"INSERT INTO orders (user_id, subtotal, discount_amount, total_amount, payment_method, reference_number, transaction_fee)
                 VALUES (@uid, @sub, @disc, @total, @method, @ref, @fee)", conn, transaction)

				orderCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
				orderCmd.Parameters.AddWithValue("@sub", subtotal)
				orderCmd.Parameters.AddWithValue("@disc", discount)
				orderCmd.Parameters.AddWithValue("@total", total)
				orderCmd.Parameters.AddWithValue("@method", selectedPaymentMethod)
				orderCmd.Parameters.AddWithValue("@ref", If(refNumber = "", DBNull.Value, refNumber))
				orderCmd.Parameters.AddWithValue("@fee", fee)
				orderCmd.ExecuteNonQuery()

				Dim newOrderId As Integer = orderCmd.LastInsertedId

				For Each item As CartItem In CartItems
					Dim itemCmd As New MySqlCommand(
					"INSERT INTO order_items (order_id, product_id, quantity, price_at_sale, net_price_sale)
                     VALUES (@oid, @pid, @qty, @price, @netprice)", conn, transaction)

					itemCmd.Parameters.AddWithValue("@oid", newOrderId)
					itemCmd.Parameters.AddWithValue("@pid", item.ProductId)
					itemCmd.Parameters.AddWithValue("@qty", item.Quantity)
					itemCmd.Parameters.AddWithValue("@price", item.UnitPrice)
					itemCmd.Parameters.AddWithValue("@netprice", item.UnitPrice - (item.UnitPrice * 0.12))
					itemCmd.ExecuteNonQuery()

					Dim stockCmd As New MySqlCommand(
					"UPDATE products SET stock_quantity = stock_quantity - @qty
                     WHERE product_id = @pid", conn, transaction)
					stockCmd.Parameters.AddWithValue("@qty", item.Quantity)
					stockCmd.Parameters.AddWithValue("@pid", item.ProductId)
					stockCmd.ExecuteNonQuery()
				Next

				transaction.Commit()

				CartItems.Clear()
				Me.Hide()
				Start.Show()

			Catch ex As Exception
				transaction.Rollback()
				MessageBox.Show("Transaction failed: " & ex.Message, "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try

		Finally
			CloseConnection()
		End Try
	End Sub

	' WALA PA RECEIPTS WIT LANG GAGAWING REPORT

End Class