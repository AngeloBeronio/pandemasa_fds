Imports MySql.Data.MySqlClient

Public Class Start

    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            OpenConnection()
            CloseConnection()
        Catch ex As Exception
            MessageBox.Show("Connection failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoginUser()
    End Sub

    Private Sub LoginUser()
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("Please enter your Employee ID.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()

            Dim query As String = "SELECT employee_id, first_name, last_name, role_id, passcode FROM employees WHERE employee_id = @id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim dbPasscode As String = If(reader.IsDBNull(reader.GetOrdinal("passcode")), Nothing, reader("passcode").ToString())

                If dbPasscode Is Nothing OrElse dbPasscode = TextBox2.Text.Trim Then
                    [Global].EmployeeID = reader("employee_id").ToString()
                    [Global].EmployeeName = reader("first_name").ToString() & " " & reader("last_name").ToString()
                    [Global].RoleID = reader("role_id").ToString()

                    reader.Close()

                    LogAttendance([Global].EmployeeID)

                    CloseConnection()

                    MessageBox.Show("Welcome, " & [Global].EmployeeName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Hide()
                    Menu__1_.Show()
                Else
                    reader.Close()
                    CloseConnection()
                    MessageBox.Show("Invalid passcode.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox2.Clear()
                    TextBox2.Focus()
                End If
            Else
                reader.Close()
                CloseConnection()
                MessageBox.Show("Employee ID not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Login error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogAttendance(empID As String)
        Try
            Dim query As String = "INSERT INTO attendance (employee_id, work_date) VALUES (@id, CURDATE())"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", empID)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Attendance logging failed: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Select_Device.Show()
    End Sub

End Class