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
		Label6 = New Label()
		Button1 = New Button()
		Button2 = New Button()
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		Button4 = New Button()
		Timer1 = New Timer(components)
		Button7 = New Button()
		Button8 = New Button()
		Label5 = New Label()
		Label7 = New Label()
		btnClose = New Button()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label1.ForeColor = Color.White
		Label1.Location = New Point(498, 115)
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
		Label2.Location = New Point(895, 115)
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
		Label3.Location = New Point(1323, 115)
		Label3.Name = "Label3"
		Label3.Size = New Size(120, 47)
		Label3.TabIndex = 2
		Label3.Text = "Label3"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.BackColor = Color.Transparent
		Label4.Font = New Font("Segoe UI", 40.25F)
		Label4.ForeColor = Color.White
		Label4.Location = New Point(434, 593)
		Label4.Name = "Label4"
		Label4.Size = New Size(184, 72)
		Label4.TabIndex = 3
		Label4.Text = "Label4"
		' 
		' DataGridView1
		' 
		DataGridView1.BackgroundColor = SystemColors.ButtonShadow
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(965, 580)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.Size = New Size(502, 121)
		DataGridView1.TabIndex = 4
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.BackColor = Color.Transparent
		Label6.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label6.ForeColor = Color.White
		Label6.Location = New Point(432, 842)
		Label6.Name = "Label6"
		Label6.Size = New Size(120, 47)
		Label6.TabIndex = 6
		Label6.Text = "Label6"
		' 
		' Button1
		' 
		Button1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button1.Location = New Point(816, 330)
		Button1.Name = "Button1"
		Button1.Size = New Size(304, 54)
		Button1.TabIndex = 8
		Button1.Text = "SET LOW STOCK THRESHOLD"
		Button1.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button2.Location = New Point(1177, 332)
		Button2.Name = "Button2"
		Button2.Size = New Size(304, 54)
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
		Button3.Location = New Point(111, 461)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 12
		Button3.Text = "MANAGE INGREDIENTS"
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
		Button5.Location = New Point(111, 593)
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
		Button6.Text = "MANAGE PRODUCTS"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' Button4
		' 
		Button4.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button4.Location = New Point(432, 330)
		Button4.Name = "Button4"
		Button4.Size = New Size(304, 54)
		Button4.TabIndex = 13
		Button4.Text = "DOWNLOAD REPORT"
		Button4.UseVisualStyleBackColor = True
		' 
		' Button7
		' 
		Button7.BackColor = Color.Transparent
		Button7.Cursor = Cursors.Hand
		Button7.FlatAppearance.BorderColor = Color.White
		Button7.FlatAppearance.BorderSize = 0
		Button7.FlatStyle = FlatStyle.Flat
		Button7.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button7.Location = New Point(111, 527)
		Button7.Name = "Button7"
		Button7.Size = New Size(196, 60)
		Button7.TabIndex = 15
		Button7.Text = "MANAGE EMPLOYEES"
		Button7.TextAlign = ContentAlignment.MiddleLeft
		Button7.UseVisualStyleBackColor = False
		' 
		' Button8
		' 
		Button8.BackColor = Color.Transparent
		Button8.Cursor = Cursors.Hand
		Button8.FlatAppearance.BorderColor = Color.White
		Button8.FlatAppearance.BorderSize = 0
		Button8.FlatStyle = FlatStyle.Flat
		Button8.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button8.Location = New Point(111, 659)
		Button8.Name = "Button8"
		Button8.Size = New Size(196, 60)
		Button8.TabIndex = 16
		Button8.Text = "INVENTORY LOGS"
		Button8.TextAlign = ContentAlignment.MiddleLeft
		Button8.UseVisualStyleBackColor = False
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.BackColor = Color.Transparent
		Label5.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label5.ForeColor = Color.White
		Label5.Location = New Point(975, 857)
		Label5.Name = "Label5"
		Label5.Size = New Size(120, 47)
		Label5.TabIndex = 17
		Label5.Text = "Label5"
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.BackColor = Color.Transparent
		Label7.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label7.ForeColor = Color.White
		Label7.Location = New Point(1323, 857)
		Label7.Name = "Label7"
		Label7.Size = New Size(120, 47)
		Label7.TabIndex = 18
		Label7.Text = "Label7"
		' 
		' btnClose
		' 
		btnClose.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnClose.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnClose.ForeColor = Color.White
		btnClose.Location = New Point(47, 766)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(93, 43)
		btnClose.TabIndex = 19
		btnClose.Text = "Back"
		btnClose.UseVisualStyleBackColor = False
		' 
		' Admin_Homevb
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(btnClose)
		Controls.Add(Label7)
		Controls.Add(Label5)
		Controls.Add(Button8)
		Controls.Add(Button7)
		Controls.Add(Button4)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(Label6)
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
	Friend WithEvents Label6 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents Timer1 As Timer
	Friend WithEvents Button7 As Button
	Friend WithEvents Button8 As Button
	Friend WithEvents Label5 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents btnClose As Button
End Class
