Public Class Admin_SignIn
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Hide()
		Select_Device.Show()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Hide()
		Admin_Homevb.Show()
	End Sub
End Class