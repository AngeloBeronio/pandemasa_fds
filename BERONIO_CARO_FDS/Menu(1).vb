Public Class Menu__1_
    Private selectedProductId As Integer = -1
    Private selectedProductName As String = ""
    Private selectedPrice As Decimal = 0

    Private Sub Menu__1__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupMenuGrid(itemMenu)
        LoadMenu(itemMenu, "House Special", PictureBox1, NumericUpDown1, selectedProductId, selectedProductName, selectedPrice)
        Label1.Text = GetGreeting()
        Label2.Text = DateTime.Now.ToString("hh:mm tt")
        Timer1.Interval = 1000
        Timer1.Start()
    End Sub
    Private Sub Menu__1__Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadLowStockWarning(ListBox1)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = GetGreeting()
        Label2.Text = DateTime.Now.ToString("hh:mm tt")
    End Sub

    ' SELECT PRODUCT
    Private Sub itemMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles itemMenu.CellClick
        Dim row As DataGridViewRow = itemMenu.Rows(e.RowIndex)

        If row.DefaultCellStyle.BackColor = Color.LightGray Then
            MessageBox.Show("This product is currently unavailable.", "Unavailable",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            selectedProductId = -1
            Return
        End If
        selectedProductId = CInt(row.Cells("colProductId").Value)
        selectedProductName = row.Cells("colName").Value.ToString()
        selectedPrice = CDec(row.Cells("colPrice").Value.ToString().Replace("₱", ""))
        LoadProductImage(PictureBox1, row.Cells("colImagePath").Value.ToString())
        NumericUpDown1.Value = 1
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If selectedProductId = -1 Then
            MessageBox.Show("Please select a product from the menu first.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        AddToCart(selectedProductId, selectedProductName, selectedPrice, NumericUpDown1.Value)
        NumericUpDown1.Value = 1
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
        Menu_5_.Show()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If CartItems.Count = 0 Then
            MessageBox.Show("Your cart is empty. Please add items first.",
                        "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Me.Hide()
        Cart.Show()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub Menu__1__FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        End If
    End Sub
End Class