Imports MySql.Data.MySqlClient

Public Class setwarningtime
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userInput As String = TextBox1.Text.Trim()

        If userInput = "" Then
            MessageBox.Show("Please enter a time.", "Empty Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim parsedTime As TimeSpan
        If TimeSpan.TryParse(userInput, parsedTime) Then
            SaveSetting("warning_time", parsedTime.ToString("hh\:mm"))
            MessageBox.Show("Warning time set to " & parsedTime.ToString("hh\:mm") & ".",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Invalid time format. Please use HH:mm (e.g. 08:00).", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub SaveSetting(key As String, value As String)
        Try
            OpenConnection()
            Dim query As String =
                "INSERT INTO set_ls_time (setting_key, setting_value) VALUES (@k, @v) " &
                "ON DUPLICATE KEY UPDATE setting_value = @v"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@k", key)
            cmd.Parameters.AddWithValue("@v", value)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error saving setting: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub
End Class