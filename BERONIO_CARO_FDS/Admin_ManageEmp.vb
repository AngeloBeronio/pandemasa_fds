Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Admin_ManageEmp

	Private selectedEmployeeId As Integer = -1

	Private Sub Admin_Emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupGrid()
		LoadRoles()
		LoadEmployees()
	End Sub

	Private Sub SetupGrid()
		With DataGridView1
			.Columns.Clear()
			.AutoGenerateColumns = False
			.RowTemplate.Height = 40

			.Columns.Add("colEmpId", "EmpID")
			.Columns.Add("colLastName", "Last Name")
			.Columns.Add("colFirstName", "First Name")
			.Columns.Add("colMI", "M.I.")
			.Columns.Add("colRole", "Role")
			.Columns.Add("colSalary", "Salary / Day")
			.Columns.Add("colRoleId", "RoleId")

			.Columns("colRoleId").Visible = False
			.Columns("colLastName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			.Columns("colFirstName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
		End With
	End Sub

	Private Sub LoadRoles()
		Try
			OpenConnection()
			Dim dt As New DataTable()
			Using da As New MySqlDataAdapter("SELECT role_id, role_name FROM roles ORDER BY role_name", conn)
				da.Fill(dt)
			End Using

			cmb_FilterRole.DisplayMember = "role_name"
			cmb_FilterRole.ValueMember = "role_id"
			cmb_FilterRole.DataSource = dt
			cmb_FilterRole.SelectedIndex = -1

			cmb_EditRole.DisplayMember = "role_name"
			cmb_EditRole.ValueMember = "role_id"
			cmb_EditRole.DataSource = dt.Copy()
			cmb_EditRole.SelectedIndex = -1
		Catch ex As Exception
			MessageBox.Show($"Error loading roles: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Function GetSelectedRoleId(cmb As ComboBox) As Integer
		Dim sv As Object = cmb.SelectedValue
		If sv Is Nothing Then Return -1
		If TypeOf sv Is DataRowView Then Return Convert.ToInt32(CType(sv, DataRowView)("role_id"))
		If IsNumeric(sv) Then Return Convert.ToInt32(sv)
		Return -1
	End Function

	Private Sub btn_AddRole_Click(sender As Object, e As EventArgs) Handles btn_AddRole.Click
		Dim name As String = txt_RoleName.Text.Trim()
		If name = "" Then MsgWarn("Enter a role name first.") : Return

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("INSERT INTO roles (role_name) VALUES (@name)", conn)
			cmd.Parameters.AddWithValue("@name", name)
			cmd.ExecuteNonQuery()
			MsgOK("Role added.")
			txt_RoleName.Clear()
			LoadRoles()
		Catch ex As MySqlException When ex.Number = 1062
			MsgWarn("That role already exists.")
		Catch ex As Exception
			MessageBox.Show($"Error: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub btn_RemoveRole_Click(sender As Object, e As EventArgs) Handles btn_RemoveRole.Click
		Dim roleId As Integer = GetSelectedRoleId(cmb_EditRole)
		If roleId <= 0 Then MsgWarn("Select a role to remove.") : Return
		If Not Confirm("Remove this role permanently?") Then Return

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("DELETE FROM roles WHERE role_id = @id", conn)
			cmd.Parameters.AddWithValue("@id", roleId)
			cmd.ExecuteNonQuery()
			MsgOK("Role removed.")
			LoadRoles()
			LoadEmployees()
		Catch ex As MySqlException When ex.Number = 1451
			MsgWarn("Cannot remove a role still assigned to employees.")
		Catch ex As Exception
			MessageBox.Show($"Error: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub LoadEmployees(Optional filterId As String = "", Optional filterRoleId As Integer = -1)
		Try
			OpenConnection()
			DataGridView1.Rows.Clear()

			Dim query As String = "
                SELECT e.employee_id, e.last_name, e.first_name, e.middle_initial,
                       r.role_name, e.salary_per_day, e.role_id
                FROM employees e
                LEFT JOIN roles r ON e.role_id = r.role_id
                WHERE 1=1"

			If filterId.Trim() <> "" Then query &= " AND e.employee_id = @empId"
			If filterRoleId > 0 Then query &= " AND e.role_id = @roleId"
			query &= " ORDER BY e.employee_id"

			Dim cmd As New MySqlCommand(query, conn)

			If filterId.Trim() <> "" Then
				Dim idVal As Integer
				If Not Integer.TryParse(filterId.Trim(), idVal) Then MsgWarn("ID must be a number.") : Return
				cmd.Parameters.AddWithValue("@empId", idVal)
			End If
			If filterRoleId > 0 Then cmd.Parameters.AddWithValue("@roleId", filterRoleId)

			Using reader As MySqlDataReader = cmd.ExecuteReader()
				While reader.Read()
					Dim i As Integer = DataGridView1.Rows.Add()
					Dim row As DataGridViewRow = DataGridView1.Rows(i)
					row.Cells("colEmpId").Value = reader("employee_id")
					row.Cells("colLastName").Value = NullStr(reader("last_name"))
					row.Cells("colFirstName").Value = NullStr(reader("first_name"))
					row.Cells("colMI").Value = NullStr(reader("middle_initial"))
					row.Cells("colRole").Value = If(IsDBNull(reader("role_name")), "Unassigned", reader("role_name").ToString())
					row.Cells("colSalary").Value = $"₱{Convert.ToDecimal(reader("salary_per_day")):N2}"
					row.Cells("colRoleId").Value = If(IsDBNull(reader("role_id")), -1, reader("role_id"))
				End While
			End Using
		Catch ex As Exception
			MessageBox.Show($"Error loading employees: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub btn_Find_Click(sender As Object, e As EventArgs) Handles btn_Find.Click
		LoadEmployees(txt_FilterId.Text, GetSelectedRoleId(cmb_FilterRole))
	End Sub

	Private Sub cmb_FilterRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_FilterRole.SelectedIndexChanged
		LoadEmployees(txt_FilterId.Text, GetSelectedRoleId(cmb_FilterRole))
	End Sub

	Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
		If DataGridView1.SelectedRows.Count = 0 Then Return
		Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
		If row.Cells("colLastName").Value Is Nothing Then Return

		selectedEmployeeId = Convert.ToInt32(row.Cells("colEmpId").Value)
		txt_EditSalary.Text = row.Cells("colSalary").Value.ToString().Replace("₱", "").Replace(",", "").Trim()

		Dim roleId As Object = row.Cells("colRoleId").Value
		If roleId IsNot Nothing AndAlso IsNumeric(roleId) AndAlso Convert.ToInt32(roleId) > 0 Then
			cmb_EditRole.SelectedValue = Convert.ToInt32(roleId)
		Else
			cmb_EditRole.SelectedIndex = -1
		End If
	End Sub

	Private Sub btn_AddEmployee_Click(sender As Object, e As EventArgs) Handles btn_AddEmployee.Click
		Dim passcode As String = txt_Passcode.Text.Trim()
		Dim lastName As String = txt_LastName.Text.Trim()
		Dim firstName As String = txt_FirstName.Text.Trim()
		Dim mi As String = txt_MI.Text.Trim()

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("
                INSERT INTO employees (passcode, last_name, first_name, middle_initial, role_id, salary_per_day)
                VALUES (@pass, @last, @first, @mi, NULL, 0)", conn)
			cmd.Parameters.AddWithValue("@pass", passcode)
			cmd.Parameters.AddWithValue("@last", lastName)
			cmd.Parameters.AddWithValue("@first", firstName)
			cmd.Parameters.AddWithValue("@mi", If(mi = "", DBNull.Value, mi))
			cmd.ExecuteNonQuery()
			MsgOK("Employee added! Set role and salary next.")
			ClearAddForm()
			LoadEmployees()
		Catch ex As Exception
			MessageBox.Show($"Error: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub btn_RemoveEmployee_Click(sender As Object, e As EventArgs) Handles btn_RemoveEmployee.Click
		If selectedEmployeeId = -1 Then MsgWarn("Select an employee first.") : Return
		If Not Confirm("Remove this employee permanently?") Then Return

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("DELETE FROM employees WHERE employee_id = @id", conn)
			cmd.Parameters.AddWithValue("@id", selectedEmployeeId)
			cmd.ExecuteNonQuery()
			MsgOK("Employee removed.")
			ClearAddForm()
			ClearEditForm()
			LoadEmployees()
		Catch ex As MySqlException When ex.Number = 1451
			MsgWarn("Cannot remove employee with existing order/payroll history.")
		Catch ex As Exception
			MessageBox.Show($"Error: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Sub btn_Set_Click(sender As Object, e As EventArgs) Handles btn_Set.Click
		If selectedEmployeeId = -1 Then MsgWarn("Select an employee first.") : Return

		Dim roleId As Integer = GetSelectedRoleId(cmb_EditRole)
		If roleId <= 0 Then MsgWarn("Please select a role.") : Return

		Dim salary As Decimal
		If Not Decimal.TryParse(txt_EditSalary.Text, salary) Then MsgWarn("Salary must be a valid number.") : Return

		Try
			OpenConnection()
			Dim cmd As New MySqlCommand("UPDATE employees SET role_id = @role, salary_per_day = @sal WHERE employee_id = @id", conn)
			cmd.Parameters.AddWithValue("@role", roleId)
			cmd.Parameters.AddWithValue("@sal", salary)
			cmd.Parameters.AddWithValue("@id", selectedEmployeeId)
			cmd.ExecuteNonQuery()
			MsgOK("Employee info updated.")
			LoadEmployees()
		Catch ex As Exception
			MessageBox.Show($"Error: {ex.Message}")
		Finally
			CloseConnection()
		End Try
	End Sub

	Private Function NullStr(val As Object) As String
		Return If(IsDBNull(val), "", val.ToString())
	End Function

	Private Sub MsgOK(msg As String)
		MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

	Private Sub MsgWarn(msg As String)
		MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub

	Private Function Confirm(msg As String) As Boolean
		Return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
	End Function

	Private Sub ClearAddForm()
		txt_LastName.Clear() : txt_FirstName.Clear() : txt_MI.Clear()
	End Sub

	Private Sub ClearEditForm()
		selectedEmployeeId = -1
		txt_EditSalary.Clear()
		cmb_EditRole.SelectedIndex = -1
	End Sub

	' NAVIGATION
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Me.Hide()
		Admin_Homevb.Show()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Hide()
		Admin_ManageProducts.Show()
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Hide()
		Admin_ManageIngredients.Show()
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Admin_OrdLogs.Show()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Hide()
		Admin_InvLogs.Show()
	End Sub
End Class