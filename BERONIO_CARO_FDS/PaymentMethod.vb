Public Class PaymentMethod
    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Payment.selectedPaymentMethod = "Cash"
        Me.Hide()
        Payment.Show()
    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Payment.selectedPaymentMethod = "Card"
        Me.Hide()
        Payment.Show()
    End Sub

    Private Sub btnGCash_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Payment.selectedPaymentMethod = "GCash"
        Me.Hide()
        Payment.Show()
    End Sub

    Private Sub btnMaya_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Payment.selectedPaymentMethod = "Maya"
        Me.Hide()
        Payment.Show()
    End Sub
End Class