Imports MySql.Data.MySqlClient

Public Class Payment

    Private isDiscounted As Boolean = False
    Private discountType As String = "None"

    '==================================================
    ' FORM LOAD
    '==================================================
    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupOrderGrid()
        LoadCartSummary()
    End Sub

    '==================================================
    ' NAVIGATION BUTTONS
    '==================================================
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

    '==================================================
    ' SETUP ORDER SUMMARY DATAGRIDVIEW
    '==================================================
    Private Sub SetupOrderGrid()
        dgvOrder.Columns.Clear()
        dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvOrder.AllowUserToAddRows = False
        dgvOrder.ReadOnly = True
        dgvOrder.RowHeadersVisible = False
        dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrder.RowTemplate.Height = 35
        dgvOrder.DefaultCellStyle.Font = New Font("Arial", 11)
        dgvOrder.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

        dgvOrder.Columns.Add("colProductId", "ID")
        dgvOrder.Columns.Add("colName", "Product")
        dgvOrder.Columns.Add("colQty", "Qty")
        dgvOrder.Columns.Add("colPrice", "Unit Price")
        dgvOrder.Columns.Add("colTotal", "Total")
        dgvOrder.Columns("colName").Width = 150

        dgvOrder.Columns("colProductId").Visible = False
    End Sub

    '==================================================
    ' LOAD CART INTO GRID + CALCULATE TOTALS
    '==================================================
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

    '==================================================
    ' UPDATE SUBTOTAL / VAT / DISCOUNT / TOTAL LABELS
    '==================================================
    Private Sub UpdateTotals()
        Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
        Dim vat As Decimal = subtotal * 0.12
        Dim discount As Decimal = 0

        If isDiscounted Then
            discount = subtotal * 0.2  ' 20% discount for PWD/Senior
        End If

        Dim total As Decimal = subtotal + vat - discount
        Dim cash As Decimal = 0
        Decimal.TryParse(amoTendered.Text, cash)
        Dim change As Decimal = cash - total

        lblSubtotal.Text = "₱" & subtotal.ToString("0.00")
        lblDiscount.Text = "₱" & discount.ToString("0.00")
        lblTotal.Text = "₱" & total.ToString("0.00")
        lblChange.Text = If(cash > 0, "₱" & change.ToString("0.00"), "₱0.00")
    End Sub

    '==================================================
    ' CASH INPUT BUTTONS (7 8 9 / 4 5 6 / 1 2 3 / 0 00)
    '==================================================
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

    ' Backspace button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If amoTendered.Text.Length > 1 Then
            amoTendered.Text = amoTendered.Text.Substring(0, amoTendered.Text.Length - 1)
        Else
            amoTendered.Text = "0"
        End If
        UpdateTotals()
    End Sub

    ' Clear cash button
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        amoTendered.Text = "0"
        UpdateTotals()
    End Sub

    '==================================================
    ' CASH TEXTBOX — update totals when typed manually
    '==================================================
    Private Sub amoTendered_TextChanged(sender As Object, e As EventArgs) Handles amoTendered.TextChanged
        UpdateTotals()
    End Sub

    '==================================================
    ' PWD / SENIOR DISCOUNT TOGGLE (Button18)
    '==================================================
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If Not isDiscounted Then
            ' Ask which type
            Dim result = MessageBox.Show(
                "Select discount type:" & vbNewLine &
                "Yes = Senior Citizen" & vbNewLine &
                "No = PWD",
                "Discount Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            isDiscounted = True
            discountType = If(result = DialogResult.Yes, "Senior Citizen", "PWD")
            Button18.Text = "REMOVE DISCOUNT"
            Panel1.BackColor = Color.Green
        Else
            Panel1.BackColor = Color.Red
            isDiscounted = False
            discountType = "None"
            Button18.Text = "PWD / SENIOR"
            Button18.BackColor = Color.Orange
        End If

        UpdateTotals()
    End Sub

    '==================================================
    ' CONFIRM PAYMENT + SAVE ORDER
    '==================================================
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If CartItems.Count = 0 Then
            MessageBox.Show("Cart is empty.", "Nothing to Pay")
            Return
        End If

        Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
        Dim vat As Decimal = subtotal * 0.12
        Dim discount As Decimal = If(isDiscounted, subtotal * 0.2, 0)
        Dim total As Decimal = subtotal + vat - discount
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
                ' Save to orders table
                Dim orderCmd As New MySqlCommand(
                    "INSERT INTO orders (user_id, subtotal, vat_amount, discount_type, discount_amount, total_amount)
                     VALUES (@uid, @sub, @vat, @dtype, @disc, @total)", conn, transaction)

                orderCmd.Parameters.AddWithValue("@uid", LoggedInUserId)
                orderCmd.Parameters.AddWithValue("@sub", subtotal)
                orderCmd.Parameters.AddWithValue("@vat", vat)
                orderCmd.Parameters.AddWithValue("@dtype", discountType)
                orderCmd.Parameters.AddWithValue("@disc", discount)
                orderCmd.Parameters.AddWithValue("@total", total)
                orderCmd.ExecuteNonQuery()

                Dim newOrderId As Integer = orderCmd.LastInsertedId

                ' Save each item to order_items + deduct stock
                For Each item As CartItem In CartItems
                    Dim itemCmd As New MySqlCommand(
                        "INSERT INTO order_items (order_id, product_id, quantity, price_at_sale)
                         VALUES (@oid, @pid, @qty, @price)", conn, transaction)

                    itemCmd.Parameters.AddWithValue("@oid", newOrderId)
                    itemCmd.Parameters.AddWithValue("@pid", item.ProductId)
                    itemCmd.Parameters.AddWithValue("@qty", item.Quantity)
                    itemCmd.Parameters.AddWithValue("@price", item.UnitPrice)
                    itemCmd.ExecuteNonQuery()

                    ' Deduct stock
                    Dim stockCmd As New MySqlCommand(
                        "UPDATE products SET stock_quantity = stock_quantity - @qty
                         WHERE product_id = @pid", conn, transaction)
                    stockCmd.Parameters.AddWithValue("@qty", item.Quantity)
                    stockCmd.Parameters.AddWithValue("@pid", item.ProductId)
                    stockCmd.ExecuteNonQuery()
                Next

                transaction.Commit()

                ' Pass order info to receipt form
                Receipt.OrderId = newOrderId
                Receipt.CashAmount = cash
                Receipt.ChangeAmount = cash - total

                ' Clear cart
                CartItems.Clear()

                ' Show receipt
                Me.Hide()
                Receipt.Show()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Transaction failed: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Finally
            CloseConnection()
        End Try
    End Sub

    '==================================================
    ' REFRESH WHEN FORM SHOWN
    '==================================================
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