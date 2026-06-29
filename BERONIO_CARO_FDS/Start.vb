Public Class Start
	Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			OpenConnection()
			CloseConnection()
		Catch ex As Exception
			MessageBox.Show("Connection failed: " & ex.Message, "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Hide()
		Menu__1_.Show()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Hide()
		Select_Device.Show()
	End Sub
End Class
