<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Homevb
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
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
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		components = New ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_Homevb))
		Label1 = New Label()
		Label2 = New Label()
		Label3 = New Label()
		Label4 = New Label()
		DataGridView1 = New DataGridView()
		Label5 = New Label()
		Label6 = New Label()
		Button1 = New Button()
		Button2 = New Button()
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		Button4 = New Button()
		MonthCalendar1 = New MonthCalendar()
		Timer1 = New Timer(components)
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label1.ForeColor = Color.White
		Label1.Location = New Point(610, 241)
		Label1.Name = "Label1"
		Label1.Size = New Size(120, 47)
		Label1.TabIndex = 0
		Label1.Text = "Label1"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.BackColor = Color.Transparent
		Label2.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label2.ForeColor = Color.White
		Label2.Location = New Point(946, 241)
		Label2.Name = "Label2"
		Label2.Size = New Size(120, 47)
		Label2.TabIndex = 1
		Label2.Text = "Label2"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.BackColor = Color.Transparent
		Label3.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label3.ForeColor = Color.White
		Label3.Location = New Point(1283, 241)
		Label3.Name = "Label3"
		Label3.Size = New Size(120, 47)
		Label3.TabIndex = 2
		Label3.Text = "Label3"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.BackColor = Color.Transparent
		Label4.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label4.ForeColor = Color.White
		Label4.Location = New Point(523, 471)
		Label4.Name = "Label4"
		Label4.Size = New Size(120, 47)
		Label4.TabIndex = 3
		Label4.Text = "Label4"
		' 
		' DataGridView1
		' 
		DataGridView1.BackgroundColor = SystemColors.ButtonShadow
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(1070, 500)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.Size = New Size(502, 270)
		DataGridView1.TabIndex = 4
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.BackColor = Color.Transparent
		Label5.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label5.ForeColor = Color.White
		Label5.Location = New Point(523, 708)
		Label5.Name = "Label5"
		Label5.Size = New Size(120, 47)
		Label5.TabIndex = 5
		Label5.Text = "Label5"
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.BackColor = Color.Transparent
		Label6.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label6.ForeColor = Color.White
		Label6.Location = New Point(585, 933)
		Label6.Name = "Label6"
		Label6.Size = New Size(120, 47)
		Label6.TabIndex = 6
		Label6.Text = "Label6"
		' 
		' Button1
		' 
		Button1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button1.Location = New Point(1341, 870)
		Button1.Name = "Button1"
		Button1.Size = New Size(372, 54)
		Button1.TabIndex = 8
		Button1.Text = "SET LOW STOCK THRESHOLD"
		Button1.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button2.Location = New Point(1341, 961)
		Button2.Name = "Button2"
		Button2.Size = New Size(372, 54)
		Button2.TabIndex = 9
		Button2.Text = "SET TIME UNTIL ALERT "
		Button2.UseVisualStyleBackColor = True
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(111, 537)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 12
		Button3.Text = "INVENTORY LOGS"
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
		Button5.Location = New Point(111, 471)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 11
		Button5.Text = "ORDER LOGS"
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
		Button6.Location = New Point(111, 405)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 10
		Button6.Text = "MANAGE INVENTORY"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' Button4
		' 
		Button4.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button4.Location = New Point(1321, 141)
		Button4.Name = "Button4"
		Button4.Size = New Size(304, 54)
		Button4.TabIndex = 13
		Button4.Text = "DOWNLOAD REPORT"
		Button4.UseVisualStyleBackColor = True
		' 
		' MonthCalendar1
		' 
		MonthCalendar1.Location = New Point(532, 46)
		MonthCalendar1.Name = "MonthCalendar1"
		MonthCalendar1.TabIndex = 14
		' 
		' Admin_Homevb
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(MonthCalendar1)
		Controls.Add(Button4)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(Label6)
		Controls.Add(Label5)
		Controls.Add(DataGridView1)
		Controls.Add(Label4)
		Controls.Add(Label3)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Name = "Admin_Homevb"
		Text = "Admin_Homevb"
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Label5 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents MonthCalendar1 As MonthCalendar
	Friend WithEvents Timer1 As Timer
End Class
