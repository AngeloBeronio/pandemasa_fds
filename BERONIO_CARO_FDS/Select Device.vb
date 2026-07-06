Public Class Select_Device

    ' ADMIN BUTTONS
    Private Sub btnAdmin1_Click(sender As Object, e As EventArgs) Handles btnAdmin1.Click
        LoggedInUserId = 1
        Me.Hide()
        Admin_SignIn.Show()
    End Sub

    Private Sub btnAdmin2_Click(sender As Object, e As EventArgs) Handles btnAdmin2.Click
        LoggedInUserId = 2
        Me.Hide()
        Admin_SignIn.Show()
    End Sub


    ' CASHIER BUTTONS
    Private Sub btnCashier1_Click(sender As Object, e As EventArgs) Handles btnCashier1.Click
        LoggedInUserId = 3
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub btnCashier2_Click(sender As Object, e As EventArgs) Handles btnCashier2.Click
        LoggedInUserId = 4
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub btnCashier3_Click(sender As Object, e As EventArgs) Handles btnCashier3.Click
        LoggedInUserId = 5
        Me.Hide()
        Start.Show()
    End Sub
End Class