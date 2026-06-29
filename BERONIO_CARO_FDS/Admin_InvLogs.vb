Public Class Admin_InvLogs
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Me.Hide()
		Admin_Inv.Show()
	End Sub
	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Admin_Homevb.Show()
	End Sub
	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Admin_OrdLogs.Show()
	End Sub
End Class