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

        If TextBox2.Text.Trim = "" Then
            MessageBox.Show("Please enter your passcode.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Focus()
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
                Dim empID As String = reader("employee_id").ToString()
                Dim empName As String = reader("first_name").ToString() & " " & reader("last_name").ToString()
                Dim roleID As String = reader("role_id").ToString()
                reader.Close()
                CloseConnection()

                If dbPasscode IsNot Nothing AndAlso dbPasscode = TextBox2.Text.Trim Then
                    [Global].EmployeeID = empID
                    [Global].LoggedInUserId = CInt(empID)
                    [Global].EmployeeName = empName
                    [Global].RoleID = roleID
                    LogAttendance(empID)
                    MessageBox.Show("Welcome, " & empName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    Select Case roleID
                        Case "1"
                            Admin_Homevb.Show()
                        Case "2"
                            Menu__1_.Show()
                        Case "3"
                            MessageBox.Show("Successfully logged in for the day ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Show()
                        Case Else
                            MessageBox.Show("Unknown role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Show()
                    End Select
                Else
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
            OpenConnection()
            Dim query As String = "INSERT IGNORE INTO attendance (employee_id, work_date) VALUES (@empId, CURDATE())"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@empId", empID)
            cmd.ExecuteNonQuery()
            CloseConnection()
        Catch ex As Exception
            MessageBox.Show("Attendance logging failed: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class