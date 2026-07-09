<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin_ManageEmp
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_ManageEmp))
		Panel2 = New Panel()
		cmb_EditRole = New ComboBox()
		btn_Set = New Button()
		Label5 = New Label()
		txt_EditSalary = New TextBox()
		Label4 = New Label()
		Panel3 = New Panel()
		Label2 = New Label()
		Panel1 = New Panel()
		Label7 = New Label()
		Label3 = New Label()
		btn_Find = New Button()
		Label6 = New Label()
		cmb_FilterRole = New ComboBox()
		txt_FilterId = New TextBox()
		Label1 = New Label()
		DataGridView1 = New DataGridView()
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		Panel4 = New Panel()
		Label14 = New Label()
		Label13 = New Label()
		Label11 = New Label()
		Label10 = New Label()
		Label9 = New Label()
		txt_Passcode = New TextBox()
		btn_RemoveRole = New Button()
		btn_AddRole = New Button()
		txt_RoleName = New TextBox()
		txt_MI = New TextBox()
		txt_FirstName = New TextBox()
		txt_LastName = New TextBox()
		Label8 = New Label()
		FlowLayoutPanel1 = New FlowLayoutPanel()
		btn_RemoveEmployee = New Button()
		btn_AddEmployee = New Button()
		Button1 = New Button()
		Button2 = New Button()
		Panel2.SuspendLayout()
		Panel1.SuspendLayout()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		Panel4.SuspendLayout()
		SuspendLayout()
		' 
		' Panel2
		' 
		Panel2.Controls.Add(cmb_EditRole)
		Panel2.Controls.Add(btn_Set)
		Panel2.Controls.Add(Label5)
		Panel2.Controls.Add(txt_EditSalary)
		Panel2.Controls.Add(Label4)
		Panel2.Controls.Add(Panel3)
		Panel2.Controls.Add(Label2)
		Panel2.Location = New Point(1407, 39)
		Panel2.Name = "Panel2"
		Panel2.Size = New Size(328, 737)
		Panel2.TabIndex = 24
		' 
		' cmb_EditRole
		' 
		cmb_EditRole.FormattingEnabled = True
		cmb_EditRole.Location = New Point(34, 370)
		cmb_EditRole.Name = "cmb_EditRole"
		cmb_EditRole.Size = New Size(211, 23)
		cmb_EditRole.TabIndex = 18
		' 
		' btn_Set
		' 
		btn_Set.Location = New Point(34, 451)
		btn_Set.Name = "btn_Set"
		btn_Set.Size = New Size(130, 31)
		btn_Set.TabIndex = 17
		btn_Set.Text = "SET"
		btn_Set.UseVisualStyleBackColor = True
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Location = New Point(34, 334)
		Label5.Name = "Label5"
		Label5.Size = New Size(35, 15)
		Label5.TabIndex = 14
		Label5.Text = "Roles"
		' 
		' txt_EditSalary
		' 
		txt_EditSalary.Location = New Point(34, 286)
		txt_EditSalary.Name = "txt_EditSalary"
		txt_EditSalary.Size = New Size(100, 23)
		txt_EditSalary.TabIndex = 13
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Location = New Point(34, 264)
		Label4.Name = "Label4"
		Label4.Size = New Size(38, 15)
		Label4.TabIndex = 12
		Label4.Text = "Salary"
		' 
		' Panel3
		' 
		Panel3.Location = New Point(24, 432)
		Panel3.Name = "Panel3"
		Panel3.Size = New Size(270, 2)
		Panel3.TabIndex = 11
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(24, 192)
		Label2.Name = "Label2"
		Label2.Size = New Size(106, 32)
		Label2.TabIndex = 6
		Label2.Text = "UPDATE"
		' 
		' Panel1
		' 
		Panel1.Controls.Add(Label7)
		Panel1.Controls.Add(Label3)
		Panel1.Controls.Add(btn_Find)
		Panel1.Controls.Add(Label6)
		Panel1.Controls.Add(cmb_FilterRole)
		Panel1.Controls.Add(txt_FilterId)
		Panel1.Controls.Add(Label1)
		Panel1.Location = New Point(386, 39)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(1003, 140)
		Panel1.TabIndex = 23
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Location = New Point(530, 55)
		Label7.Name = "Label7"
		Label7.Size = New Size(35, 15)
		Label7.TabIndex = 29
		Label7.Text = "Roles"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Location = New Point(21, 55)
		Label3.Name = "Label3"
		Label3.Size = New Size(18, 15)
		Label3.TabIndex = 28
		Label3.Text = "ID"
		' 
		' btn_Find
		' 
		btn_Find.Location = New Point(285, 60)
		btn_Find.Name = "btn_Find"
		btn_Find.Size = New Size(97, 43)
		btn_Find.TabIndex = 27
		btn_Find.Text = "Find"
		btn_Find.UseVisualStyleBackColor = True
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label6.Location = New Point(21, 13)
		Label6.Name = "Label6"
		Label6.Size = New Size(87, 32)
		Label6.TabIndex = 26
		Label6.Text = "FILTER"
		' 
		' cmb_FilterRole
		' 
		cmb_FilterRole.FormattingEnabled = True
		cmb_FilterRole.Location = New Point(530, 73)
		cmb_FilterRole.Name = "cmb_FilterRole"
		cmb_FilterRole.Size = New Size(211, 23)
		cmb_FilterRole.TabIndex = 7
		' 
		' txt_FilterId
		' 
		txt_FilterId.Location = New Point(21, 73)
		txt_FilterId.Name = "txt_FilterId"
		txt_FilterId.Size = New Size(253, 23)
		txt_FilterId.TabIndex = 6
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(20, 30)
		Label1.Name = "Label1"
		Label1.Size = New Size(0, 15)
		Label1.TabIndex = 5
		' 
		' DataGridView1
		' 
		DataGridView1.AllowUserToAddRows = False
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(386, 231)
		DataGridView1.MultiSelect = False
		DataGridView1.Name = "DataGridView1"
		DataGridView1.ReadOnly = True
		DataGridView1.RowHeadersVisible = False
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		DataGridView1.Size = New Size(1003, 545)
		DataGridView1.TabIndex = 22
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(108, 617)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 21
		Button3.Text = "ORDER LOGS"
		Button3.TextAlign = ContentAlignment.MiddleLeft
		Button3.UseVisualStyleBackColor = False
		' 
		' Button5
		' 
		Button5.BackColor = Color.Transparent
		Button5.Cursor = Cursors.Hand
		Button5.FlatAppearance.BorderColor = Color.White
		Button5.FlatAppearance.BorderSize = 0
		Button5.FlatStyle = FlatStyle.Flat
		Button5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button5.Location = New Point(108, 468)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 20
		Button5.Text = "MANAGE INGREDIENTS"
		Button5.TextAlign = ContentAlignment.MiddleLeft
		Button5.UseVisualStyleBackColor = False
		' 
		' Button6
		' 
		Button6.BackColor = Color.Transparent
		Button6.Cursor = Cursors.Hand
		Button6.FlatAppearance.BorderColor = Color.White
		Button6.FlatAppearance.BorderSize = 0
		Button6.FlatStyle = FlatStyle.Flat
		Button6.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button6.Location = New Point(108, 337)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 19
		Button6.Text = "HOME"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' Panel4
		' 
		Panel4.Controls.Add(Label14)
		Panel4.Controls.Add(Label13)
		Panel4.Controls.Add(Label11)
		Panel4.Controls.Add(Label10)
		Panel4.Controls.Add(Label9)
		Panel4.Controls.Add(txt_Passcode)
		Panel4.Controls.Add(btn_RemoveRole)
		Panel4.Controls.Add(btn_AddRole)
		Panel4.Controls.Add(txt_RoleName)
		Panel4.Controls.Add(txt_MI)
		Panel4.Controls.Add(txt_FirstName)
		Panel4.Controls.Add(txt_LastName)
		Panel4.Controls.Add(Label8)
		Panel4.Controls.Add(FlowLayoutPanel1)
		Panel4.Controls.Add(btn_RemoveEmployee)
		Panel4.Controls.Add(btn_AddEmployee)
		Panel4.Location = New Point(386, 782)
		Panel4.Name = "Panel4"
		Panel4.Size = New Size(1349, 199)
		Panel4.TabIndex = 25
		' 
		' Label14
		' 
		Label14.AutoSize = True
		Label14.Location = New Point(853, 94)
		Label14.Name = "Label14"
		Label14.Size = New Size(35, 15)
		Label14.TabIndex = 35
		Label14.Text = "Roles"
		' 
		' Label13
		' 
		Label13.AutoSize = True
		Label13.Location = New Point(367, 136)
		Label13.Name = "Label13"
		Label13.Size = New Size(56, 15)
		Label13.TabIndex = 34
		Label13.Text = "Passcode"
		' 
		' Label11
		' 
		Label11.AutoSize = True
		Label11.Location = New Point(468, 73)
		Label11.Name = "Label11"
		Label11.Size = New Size(24, 15)
		Label11.TabIndex = 32
		Label11.Text = "M.I"
		' 
		' Label10
		' 
		Label10.AutoSize = True
		Label10.Location = New Point(237, 73)
		Label10.Name = "Label10"
		Label10.Size = New Size(64, 15)
		Label10.TabIndex = 31
		Label10.Text = "First Name"
		' 
		' Label9
		' 
		Label9.AutoSize = True
		Label9.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label9.Location = New Point(21, 25)
		Label9.Name = "Label9"
		Label9.Size = New Size(218, 32)
		Label9.TabIndex = 30
		Label9.Text = "ADD AND DELETE"
		' 
		' txt_Passcode
		' 
		txt_Passcode.Location = New Point(367, 156)
		txt_Passcode.Name = "txt_Passcode"
		txt_Passcode.Size = New Size(168, 23)
		txt_Passcode.TabIndex = 29
		' 
		' btn_RemoveRole
		' 
		btn_RemoveRole.Location = New Point(1228, 73)
		btn_RemoveRole.Name = "btn_RemoveRole"
		btn_RemoveRole.Size = New Size(87, 79)
		btn_RemoveRole.TabIndex = 25
		btn_RemoveRole.Text = "REMOVE"
		btn_RemoveRole.UseVisualStyleBackColor = True
		' 
		' btn_AddRole
		' 
		btn_AddRole.Location = New Point(1098, 72)
		btn_AddRole.Name = "btn_AddRole"
		btn_AddRole.Size = New Size(87, 79)
		btn_AddRole.TabIndex = 24
		btn_AddRole.Text = "ADD"
		btn_AddRole.UseVisualStyleBackColor = True
		' 
		' txt_RoleName
		' 
		txt_RoleName.Location = New Point(853, 118)
		txt_RoleName.Name = "txt_RoleName"
		txt_RoleName.Size = New Size(206, 23)
		txt_RoleName.TabIndex = 23
		' 
		' txt_MI
		' 
		txt_MI.Location = New Point(468, 91)
		txt_MI.Name = "txt_MI"
		txt_MI.Size = New Size(43, 23)
		txt_MI.TabIndex = 22
		' 
		' txt_FirstName
		' 
		txt_FirstName.Location = New Point(237, 91)
		txt_FirstName.Name = "txt_FirstName"
		txt_FirstName.Size = New Size(168, 23)
		txt_FirstName.TabIndex = 21
		' 
		' txt_LastName
		' 
		txt_LastName.Location = New Point(21, 91)
		txt_LastName.Name = "txt_LastName"
		txt_LastName.Size = New Size(168, 23)
		txt_LastName.TabIndex = 20
		' 
		' Label8
		' 
		Label8.AutoSize = True
		Label8.Location = New Point(21, 73)
		Label8.Name = "Label8"
		Label8.Size = New Size(63, 15)
		Label8.TabIndex = 14
		Label8.Text = "Last Name"
		' 
		' FlowLayoutPanel1
		' 
		FlowLayoutPanel1.Location = New Point(807, 25)
		FlowLayoutPanel1.Name = "FlowLayoutPanel1"
		FlowLayoutPanel1.Size = New Size(2, 150)
		FlowLayoutPanel1.TabIndex = 12
		' 
		' btn_RemoveEmployee
		' 
		btn_RemoveEmployee.Location = New Point(696, 72)
		btn_RemoveEmployee.Name = "btn_RemoveEmployee"
		btn_RemoveEmployee.Size = New Size(87, 79)
		btn_RemoveEmployee.TabIndex = 11
		btn_RemoveEmployee.Text = "REMOVE"
		btn_RemoveEmployee.UseVisualStyleBackColor = True
		' 
		' btn_AddEmployee
		' 
		btn_AddEmployee.Location = New Point(593, 73)
		btn_AddEmployee.Name = "btn_AddEmployee"
		btn_AddEmployee.Size = New Size(87, 79)
		btn_AddEmployee.TabIndex = 10
		btn_AddEmployee.Text = "ADD"
		btn_AddEmployee.UseVisualStyleBackColor = True
		' 
		' Button1
		' 
		Button1.BackColor = Color.Transparent
		Button1.Cursor = Cursors.Hand
		Button1.FlatAppearance.BorderColor = Color.White
		Button1.FlatAppearance.BorderSize = 0
		Button1.FlatStyle = FlatStyle.Flat
		Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button1.Location = New Point(108, 403)
		Button1.Name = "Button1"
		Button1.Size = New Size(196, 60)
		Button1.TabIndex = 26
		Button1.Text = "MANAGE PRODUCTS"
		Button1.TextAlign = ContentAlignment.MiddleLeft
		Button1.UseVisualStyleBackColor = False
		' 
		' Button2
		' 
		Button2.BackColor = Color.Transparent
		Button2.Cursor = Cursors.Hand
		Button2.FlatAppearance.BorderColor = Color.White
		Button2.FlatAppearance.BorderSize = 0
		Button2.FlatStyle = FlatStyle.Flat
		Button2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button2.Location = New Point(108, 687)
		Button2.Name = "Button2"
		Button2.Size = New Size(196, 60)
		Button2.TabIndex = 27
		Button2.Text = "INVENTORY LOGS"
		Button2.TextAlign = ContentAlignment.MiddleLeft
		Button2.UseVisualStyleBackColor = False
		' 
		' Admin_ManageEmp
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(Panel4)
		Controls.Add(Panel2)
		Controls.Add(Panel1)
		Controls.Add(DataGridView1)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Name = "Admin_ManageEmp"
		Text = "EmpManage"
		Panel2.ResumeLayout(False)
		Panel2.PerformLayout()
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		Panel4.ResumeLayout(False)
		Panel4.PerformLayout()
		ResumeLayout(False)
	End Sub

	Friend WithEvents Panel2 As Panel
	Friend WithEvents btn_Set As Button
	Friend WithEvents Label5 As Label
	Friend WithEvents txt_EditSalary As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Panel3 As Panel
	Friend WithEvents Panel4 As Panel
	Friend WithEvents Label8 As Label
	Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
	Friend WithEvents btn_RemoveEmployee As Button
	Friend WithEvents btn_AddEmployee As Button
	Friend WithEvents btn_RemoveRole As Button
	Friend WithEvents cmb_FilterRole As ComboBox
	Friend WithEvents txt_FilterId As TextBox
	Friend WithEvents btn_AddRole As Button
	Friend WithEvents txt_RoleName As TextBox
	Friend WithEvents txt_LastName As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents cmb_EditRole As ComboBox
	Friend WithEvents txt_MI As TextBox
	Friend WithEvents txt_FirstName As TextBox
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents btn_Find As Button
	Friend WithEvents txt_Passcode As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label14 As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents Label9 As Label
End Class