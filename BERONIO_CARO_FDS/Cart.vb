Imports MySql.Data.MySqlClient

Public Class Cart
    Private Sub Cart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupCartGrid()
        LoadCartItems()
        NumericUpDown1.Value = CInt(cartMenu.Rows(0).Cells("colQty").Value)
    End Sub

	Private Sub Cart_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		LoadCartItems()
	End Sub

    ' DGV
    Private Sub SetupCartGrid()
        cartMenu.Columns.Clear()

        cartMenu.Columns.Add("colProductId", "ID")
        cartMenu.Columns.Add("colName", "Product")
        cartMenu.Columns.Add("colQty", "Qty")
        cartMenu.Columns.Add("colPrice", "Unit Price")
        cartMenu.Columns.Add("colTotal", "Total")
        cartMenu.Columns("colProductId").Visible = False
        cartMenu.Columns("colName").Width = 685
        cartMenu.Columns("colQty").Width = 150
        cartMenu.Columns("colPrice").Width = 200
        cartMenu.Columns("colTotal").Width = 200
    End Sub
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
        UpdateSummary()
    End Sub
    Private Sub cartMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles cartMenu.CellClick
        If e.RowIndex < 0 Then Return
        NumericUpDown1.Value = CInt(cartMenu.Rows(e.RowIndex).Cells("colQty").Value)
    End Sub

    ' QUANTITY
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If cartMenu.SelectedRows.Count = 0 Then Return

        Dim selectedRow As DataGridViewRow = cartMenu.SelectedRows(0)
        Dim pid As Integer = CInt(selectedRow.Cells("colProductId").Value)
        Dim itemName As String = selectedRow.Cells("colName").Value.ToString()

        If NumericUpDown1.Value = 0 Then
            Dim confirm As DialogResult = MessageBox.Show(
                "Remove " & itemName & " from cart?", "Remove Item",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm = DialogResult.Yes Then
                Dim toRemove As CartItem = CartItems.FirstOrDefault(Function(c) c.ProductId = pid)
                If toRemove IsNot Nothing Then CartItems.Remove(toRemove)
                LoadCartItems()
            Else
                Dim existing As CartItem = CartItems.FirstOrDefault(Function(c) c.ProductId = pid)
                If existing IsNot Nothing Then
                    NumericUpDown1.Value = existing.Quantity
                End If
            End If
            Return
        End If

        Dim item As CartItem = CartItems.FirstOrDefault(Function(c) c.ProductId = pid)
        If item IsNot Nothing Then
            item.Quantity = NumericUpDown1.Value
            item.Total = item.UnitPrice * item.Quantity

            selectedRow.Cells("colQty").Value = item.Quantity
            selectedRow.Cells("colTotal").Value = "₱" & item.Total.ToString("0.00")
        End If

        UpdateSummary()
    End Sub

    ' UPDATE SUBTOTAL
    Private Sub UpdateSummary()
        Dim subtotal As Decimal = CartItems.Sum(Function(c) c.Total)
        Dim vat As Decimal = subtotal * 0.12
        Dim total As Decimal = subtotal + vat
        lblSubtotal.Text = "₱" & subtotal.ToString("0.00")
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
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnAddtoCart.Click
        If CartItems.Count = 0 Then
            MessageBox.Show("Your cart is empty. Please add items first.",
                            "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Me.Hide()
        Payment.Show()
    End Sub
End Class