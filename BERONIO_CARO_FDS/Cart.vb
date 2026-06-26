Imports MySql.Data.MySqlClient

Public Class Cart

    '==================================================
    ' FORM LOAD
    '==================================================
    Private Sub Cart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupCartGrid()
        LoadCartItems()
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnAddtoCart.Click
        If CartItems.Count = 0 Then
            MessageBox.Show("Your cart is empty. Please add items first.",
                            "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Me.Hide()
        Payment.Show()
    End Sub

    '==================================================
    ' SETUP DATAGRIDVIEW
    '==================================================
    Private Sub SetupCartGrid()
        cartMenu.Columns.Clear()
        cartMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cartMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        cartMenu.MultiSelect = False
        cartMenu.ReadOnly = True
        cartMenu.AllowUserToAddRows = False
        cartMenu.RowHeadersVisible = False

        cartMenu.Columns.Add("colProductId", "ID")
        cartMenu.Columns.Add("colName", "Product")
        cartMenu.Columns.Add("colQty", "Qty")
        cartMenu.Columns.Add("colPrice", "Unit Price")
        cartMenu.Columns.Add("colTotal", "Total")

        cartMenu.Columns("colProductId").Visible = False
    End Sub

    '==================================================
    ' LOAD FROM SHARED CARTITEMS LIST
    '==================================================
    Private Sub LoadCartItems()
        cartMenu.Rows.Clear()

        For Each item As CartItem In CartItems
            cartMenu.Rows.Add(
                item.ProductId,
                item.ProductName,
                item.Quantity,
                "₱" & item.UnitPrice.ToString("0.00"),
                "₱" & item.Total.ToString("0.00")
            )
        Next

        NumericUpDown1.Value = 0
        UpdateSummary()
    End Sub

    '==================================================
    ' ROW CLICK — LOAD QTY INTO NUMERICUPDOWN
    '==================================================
    Private Sub cartMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles cartMenu.CellClick
        If e.RowIndex < 0 Then Return
        NumericUpDown1.Value = CInt(cartMenu.Rows(e.RowIndex).Cells("colQty").Value)
    End Sub

    '==================================================
    ' NUMERICUPDOWN — UPDATE QTY OR REMOVE IF SET TO 0
    '==================================================
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If cartMenu.SelectedRows.Count = 0 Then Return

        Dim selectedRow As DataGridViewRow = cartMenu.SelectedRows(0)
        Dim pid As Integer = CInt(selectedRow.Cells("colProductId").Value)
        Dim itemName As String = selectedRow.Cells("colName").Value.ToString()

        ' If set to 0 — ask to remove
        If NumericUpDown1.Value = 0 Then
            Dim confirm As DialogResult = MessageBox.Show(
                "Remove " & itemName & " from cart?", "Remove Item",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm = DialogResult.Yes Then
                Dim toRemove As CartItem = CartItems.FirstOrDefault(Function(c) c.ProductId = pid)
                If toRemove IsNot Nothing Then CartItems.Remove(toRemove)
                LoadCartItems()
            Else
                ' Restore previous quantity if they say No
                Dim existing As CartItem = CartItems.FirstOrDefault(Function(c) c.ProductId = pid)
                If existing IsNot Nothing Then
                    NumericUpDown1.Value = existing.Quantity
                End If
            End If
            Return
        End If

        ' Otherwise update quantity normally
        Dim item As CartItem = CartItems.FirstOrDefault(Function(c) c.ProductId = pid)
        If item IsNot Nothing Then
            item.Quantity = NumericUpDown1.Value
            item.Total = item.UnitPrice * item.Quantity

            selectedRow.Cells("colQty").Value = item.Quantity
            selectedRow.Cells("colTotal").Value = "₱" & item.Total.ToString("0.00")
        End If

        UpdateSummary()
    End Sub

    '==================================================
    ' UPDATE SUBTOTAL LABEL
    '==================================================
    Private Sub UpdateSummary()
        Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
        Dim vat As Decimal = subtotal * 0.12
        Dim total As Decimal = subtotal + vat

        lblSubtotal.Text = "Subtotal: ₱" & subtotal.ToString("0.00")
    End Sub

    '==================================================
    ' REFRESH CART WHEN FORM IS SHOWN
    '==================================================
    Private Sub Cart_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            LoadCartItems()
        End If
    End Sub

End Class