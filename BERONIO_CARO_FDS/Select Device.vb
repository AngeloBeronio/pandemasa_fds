Public Class Select_Device

    '==================================================
    ' ADMIN BUTTONS (1, 2, 3)
    '==================================================
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

    Private Sub btnAdmin3_Click(sender As Object, e As EventArgs) Handles btnAdmin3.Click
        LoggedInUserId = 3
        Me.Hide()
        Admin_SignIn.Show()
    End Sub

    '==================================================
    ' CASHIER BUTTONS (1, 2, 3, 4, 5)
    '==================================================
    Private Sub btnCashier1_Click(sender As Object, e As EventArgs) Handles btnCashier1.Click
        LoggedInUserId = 1
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub btnCashier2_Click(sender As Object, e As EventArgs) Handles btnCashier2.Click
        LoggedInUserId = 2
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub btnCashier3_Click(sender As Object, e As EventArgs) Handles btnCashier3.Click
        LoggedInUserId = 3
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub btnCashier4_Click(sender As Object, e As EventArgs) Handles btnCashier4.Click
        LoggedInUserId = 4
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub btnCashier5_Click(sender As Object, e As EventArgs) Handles btnCashier5.Click
        LoggedInUserId = 5
        Me.Hide()
        Start.Show()
    End Sub

End Class