Public Class PaymentMethod
    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Payment.ApplyPaymentMethod("Cash")
        Payment.Show()
    End Sub
    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Payment.ApplyPaymentMethod("Card")
        Payment.Show()
    End Sub
    Private Sub btnGCash_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Payment.ApplyPaymentMethod("GCash")
        Payment.Show()
    End Sub
    Private Sub btnMaya_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Payment.ApplyPaymentMethod("Maya")
        Payment.Show()
    End Sub
End Class