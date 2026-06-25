Public Class Start
	Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Hide()
		Menu__1_.Show()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Hide()
		Admin_SignIn.Show()
	End Sub
End Class
