Imports MySql.Data.MySqlClient

Public Class Payment

    Private isDiscounted As Boolean = False
    Private discountType As String = "None"

    ' FORM LOAD
    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupOrderGrid()
        LoadCartSummary()
    End Sub

    ' NAVIGATION BUTTONS
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

    ' SETUP DATAGRIDVIEW
    Private Sub SetupOrderGrid()
        dgvOrder.Columns.Clear()
        dgvOrder.RowTemplate.Height = 35

        dgvOrder.Columns.Add("colProductId", "ID")
        dgvOrder.Columns.Add("colName", "Product")
        dgvOrder.Columns.Add("colQty", "Qty")
        dgvOrder.Columns.Add("colPrice", "Unit Price")
        dgvOrder.Columns.Add("colTotal", "Total")

        dgvOrder.Columns("colProductId").Visible = False
    End Sub

    ' LOAD CART INTO GRID + CALCULATE TOTALS
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

    ' UPDATE SUBTOTAL & VAT & DISCOUNT & TOTAL
    Private Sub UpdateTotals()
        Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
        Dim discount As Decimal = 0

        If isDiscounted Then
            discount = subtotal * 0.2
        End If

        Dim total As Decimal = subtotal - discount
        Dim cash As Decimal = 0
        Decimal.TryParse(amoTendered.Text, cash)
        Dim change As Decimal = cash - total

        lblSubtotal.Text = "₱" & subtotal.ToString("0.00")
        lblDiscount.Text = "₱" & discount.ToString("0.00")
        lblTotal.Text = "₱" & total.ToString("0.00")
        lblChange.Text = If(cash > 0, "₱" & change.ToString("0.00"), "₱0.00")
    End Sub

    ' CASH INPUT BUTTONS
    Private Sub AppendCash(value As String)
        If amoTendered.Text = "0" Then
            amoTendered.Text = value
        Else
            amoTendered.Text &= value
        End If
        UpdateTotals()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        AppendCash("7")
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        AppendCash("8")
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AppendCash("9")
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        AppendCash("4")
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        AppendCash("5")
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AppendCash("6")
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        AppendCash("3")
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        AppendCash("2")
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        AppendCash("1")
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        AppendCash(".")
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        AppendCash("0")
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        AppendCash("00")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If amoTendered.Text.Length > 1 Then
            amoTendered.Text = amoTendered.Text.Substring(0, amoTendered.Text.Length - 1)
        Else
            amoTendered.Text = "0"
        End If
        UpdateTotals()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        amoTendered.Text = "0"
        UpdateTotals()
    End Sub

    Private Sub amoTendered_TextChanged(sender As Object, e As EventArgs) Handles amoTendered.TextChanged
        UpdateTotals()
    End Sub

    ' DISCOUNT TOGGLE
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If Not isDiscounted Then
            isDiscounted = True
            discountType = "PWD/Senior"
            Button18.Text = "REMOVE DISCOUNT"
            Panel1.BackColor = Color.Green
        Else
            isDiscounted = False
            discountType = "None"
            Button18.Text = "PWD / SENIOR"
            Button18.BackColor = Color.Orange
            Panel1.BackColor = Color.Red
        End If

        UpdateTotals()
    End Sub

    ' CONFIRM PAYMENT
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If CartItems.Count = 0 Then
            MessageBox.Show("Cart is empty.", "Nothing to Pay")
            Return
        End If

        Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
        Dim discount As Decimal = If(isDiscounted, subtotal * 0.2, 0)
        Dim total As Decimal = subtotal + discount
        Dim cash As Decimal = 0

        If Not Decimal.TryParse(amoTendered.Text, cash) OrElse cash < total Then
            MessageBox.Show("Insufficient cash amount.", "Payment Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Try
                Dim orderCmd As New MySqlCommand(
                "INSERT INTO orders (user_id, subtotal, discount_amount, total_amount)
                 VALUES (@uid, @sub, @disc, @total)", conn, transaction)

                orderCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
                orderCmd.Parameters.AddWithValue("@sub", subtotal)
                orderCmd.Parameters.AddWithValue("@disc", discount)
                orderCmd.Parameters.AddWithValue("@total", total)
                orderCmd.ExecuteNonQuery()

                Dim newOrderId As Integer = orderCmd.LastInsertedId

                For Each item As CartItem In CartItems
                    Dim itemCmd As New MySqlCommand(
                    "INSERT INTO order_items (order_id, product_id, quantity, price_at_sale)
                     VALUES (@oid, @pid, @qty, @price)", conn, transaction)

                    itemCmd.Parameters.AddWithValue("@oid", newOrderId)
                    itemCmd.Parameters.AddWithValue("@pid", item.ProductId)
                    itemCmd.Parameters.AddWithValue("@qty", item.Quantity)
                    itemCmd.Parameters.AddWithValue("@price", item.UnitPrice)
                    itemCmd.ExecuteNonQuery()

                    Dim stockCmd As New MySqlCommand(
                    "UPDATE products SET stock_quantity = stock_quantity - @qty
                     WHERE product_id = @pid", conn, transaction)
                    stockCmd.Parameters.AddWithValue("@qty", item.Quantity)
                    stockCmd.Parameters.AddWithValue("@pid", item.ProductId)
                    stockCmd.ExecuteNonQuery()
                Next

                transaction.Commit()

                receipt.OrderId = newOrderId
                receipt.CashAmount = cash
                receipt.ChangeAmount = cash - total

                CartItems.Clear()

                Me.Hide()
                receipt.Show()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Transaction failed: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Finally
            CloseConnection()
        End Try
    End Sub

    ' REFRESH
    Private Sub Payment_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            LoadCartSummary()
            amoTendered.Text = "0"
            isDiscounted = False
            discountType = "None"
            Button18.Text = "PWD / SENIOR"
            Button18.BackColor = Color.Orange
        End If
    End Sub

End Class