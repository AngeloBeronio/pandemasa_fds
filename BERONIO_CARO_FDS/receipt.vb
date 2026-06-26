Imports MySql.Data.MySqlClient

Public Class receipt

    ' Properties set by Payment form
    <System.ComponentModel.DefaultValue(0)>
    Public Property OrderId As Integer

    <System.ComponentModel.DefaultValue(0D)>
    Public Property CashAmount As Decimal

    <System.ComponentModel.DefaultValue(0D)>
    Public Property ChangeAmount As Decimal

    '==================================================
    ' FORM LOAD
    '==================================================
    Private Sub Receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupReceiptGrid()
        LoadReceiptData()
    End Sub

    '==================================================
    ' SETUP DATAGRIDVIEW
    '==================================================
    Private Sub SetupReceiptGrid()
        dgvReceipt.Columns.Clear()
        dgvReceipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReceipt.AllowUserToAddRows = False
        dgvReceipt.ReadOnly = True
        dgvReceipt.RowHeadersVisible = False
        dgvReceipt.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReceipt.RowTemplate.Height = 30
        dgvReceipt.DefaultCellStyle.Font = New Font("Courier New", 10)
        dgvReceipt.ColumnHeadersDefaultCellStyle.Font = New Font("Courier New", 10, FontStyle.Bold)

        dgvReceipt.Columns.Add("colName", "Product")
        dgvReceipt.Columns.Add("colQty", "Qty")
        dgvReceipt.Columns.Add("colPrice", "Unit Price")
        dgvReceipt.Columns.Add("colTotal", "Total")
    End Sub

    '==================================================
    ' LOAD ORDER DATA FROM DATABASE
    '==================================================
    Private Sub LoadReceiptData()
        Try
            OpenConnection()

            ' Load order header info
            Dim orderCmd As New MySqlCommand(
                "SELECT subtotal, vat_amount, discount_type, discount_amount, total_amount,
                        order_date
                 FROM orders WHERE order_id = @oid", conn)
            orderCmd.Parameters.AddWithValue("@oid", OrderId)

            Dim reader As MySqlDataReader = orderCmd.ExecuteReader()

            Dim subtotal As Decimal = 0
            Dim vat As Decimal = 0
            Dim discountType As String = "None"
            Dim discount As Decimal = 0
            Dim total As Decimal = 0
            Dim orderDate As String = ""

            If reader.Read() Then
                subtotal = reader.GetDecimal("subtotal")
                vat = reader.GetDecimal("vat_amount")
                discountType = reader.GetString("discount_type")
                discount = reader.GetDecimal("discount_amount")
                total = reader.GetDecimal("total_amount")
                orderDate = reader.GetDateTime("order_date").ToString("MM/dd/yyyy hh:mm tt")
            End If
            reader.Close()

            ' Load order items
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

            ' Populate labels
            lblOrderId.Text = "Order #: " & OrderId.ToString()
            lblDate.Text = "Date: " & orderDate
            lblSubtotal.Text = "₱" & subtotal.ToString("0.00")
            lblVat.Text = "₱" & vat.ToString("0.00")
            lblDiscountType.Text = discountType
            lblDiscount.Text = "₱" & discount.ToString("0.00")
            lblTotal.Text = "₱" & total.ToString("0.00")
            lblCash.Text = "₱" & CashAmount.ToString("0.00")
            lblChange.Text = "₱" & ChangeAmount.ToString("0.00")

        Catch ex As Exception
            MessageBox.Show("Error loading receipt: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    '==================================================
    ' PRINT RECEIPT BUTTON
    '==================================================
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim pd As New Printing.PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintReceiptPage
        Dim preview As New PrintPreviewDialog()
        preview.Document = pd
        preview.ShowDialog()
    End Sub

    Private Sub PrintReceiptPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim fontTitle As New Font("Courier New", 13, FontStyle.Bold)
        Dim fontBold As New Font("Courier New", 10, FontStyle.Bold)
        Dim fontNormal As New Font("Courier New", 10)
        Dim x As Integer = 40
        Dim y As Integer = 20
        Dim lineH As Integer = 22

        ' Header
        g.DrawString("===== OFFICIAL RECEIPT =====", fontTitle, Brushes.Black, x, y) : y += lineH + 5
        g.DrawString("Order #: " & OrderId.ToString(), fontNormal, Brushes.Black, x, y) : y += lineH
        g.DrawString(lblDate.Text, fontNormal, Brushes.Black, x, y) : y += lineH
        g.DrawString(New String("-"c, 38), fontNormal, Brushes.Black, x, y) : y += lineH

        ' Column headers
        g.DrawString("Product", fontBold, Brushes.Black, x, y)
        g.DrawString("Qty", fontBold, Brushes.Black, x + 160, y)
        g.DrawString("Price", fontBold, Brushes.Black, x + 210, y)
        g.DrawString("Total", fontBold, Brushes.Black, x + 290, y)
        y += lineH

        g.DrawString(New String("-"c, 38), fontNormal, Brushes.Black, x, y) : y += lineH

        ' Items
        For Each row As DataGridViewRow In dgvReceipt.Rows
            g.DrawString(row.Cells(0).Value?.ToString(), fontNormal, Brushes.Black, x, y)
            g.DrawString(row.Cells(1).Value?.ToString(), fontNormal, Brushes.Black, x + 160, y)
            g.DrawString(row.Cells(2).Value?.ToString(), fontNormal, Brushes.Black, x + 210, y)
            g.DrawString(row.Cells(3).Value?.ToString(), fontNormal, Brushes.Black, x + 290, y)
            y += lineH
        Next

        g.DrawString(New String("-"c, 38), fontNormal, Brushes.Black, x, y) : y += lineH

        ' Totals
        g.DrawString("Subtotal:", fontNormal, Brushes.Black, x, y)
        g.DrawString(lblSubtotal.Text, fontNormal, Brushes.Black, x + 200, y) : y += lineH

        g.DrawString("VAT (12%):", fontNormal, Brushes.Black, x, y)
        g.DrawString(lblVat.Text, fontNormal, Brushes.Black, x + 200, y) : y += lineH

        If lblDiscountType.Text <> "None" Then
            g.DrawString("Discount (" & lblDiscountType.Text & "):", fontNormal, Brushes.Black, x, y)
            g.DrawString("-" & lblDiscount.Text, fontNormal, Brushes.Black, x + 200, y) : y += lineH
        End If

        g.DrawString("TOTAL:", fontBold, Brushes.Black, x, y)
        g.DrawString(lblTotal.Text, fontBold, Brushes.Black, x + 200, y) : y += lineH

        g.DrawString(New String("-"c, 38), fontNormal, Brushes.Black, x, y) : y += lineH

        g.DrawString("Cash:", fontNormal, Brushes.Black, x, y)
        g.DrawString(lblCash.Text, fontNormal, Brushes.Black, x + 200, y) : y += lineH

        g.DrawString("Change:", fontNormal, Brushes.Black, x, y)
        g.DrawString(lblChange.Text, fontNormal, Brushes.Black, x + 200, y) : y += lineH + 10

        g.DrawString("===========================", fontNormal, Brushes.Black, x, y) : y += lineH
        g.DrawString("  Thank you for your purchase! ", fontBold, Brushes.Black, x, y) : y += lineH
        g.DrawString("===========================", fontNormal, Brushes.Black, x, y)
    End Sub

    '==================================================
    ' NEW TRANSACTION / CLOSE BUTTON
    '==================================================
    Private Sub btnNewTransaction_Click(sender As Object, e As EventArgs) Handles btnNewTransaction.Click
        Me.Hide()
        Menu__1_.Show()  ' Go back to main menu
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class