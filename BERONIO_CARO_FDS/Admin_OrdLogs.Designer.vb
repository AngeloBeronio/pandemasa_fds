<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_OrdLogs
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_OrdLogs))
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		Button2 = New Button()
		Button1 = New Button()
		TextBox1 = New TextBox()
		DataGridView1 = New DataGridView()
		TextBox2 = New TextBox()
		Button7 = New Button()
		Button4 = New Button()
		btnClose = New Button()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(105, 587)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 15
		Button3.Text = "MANAGE EMPLOYEES"
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
		Button5.Location = New Point(105, 389)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 14
		Button5.Text = "HOME"
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
		Button6.Location = New Point(105, 455)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 13
		Button6.Text = "MANAGE PRODUCTS"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' Button2
		' 
		Button2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button2.ForeColor = Color.White
		Button2.Location = New Point(1111, 883)
		Button2.Name = "Button2"
		Button2.Size = New Size(39, 42)
		Button2.TabIndex = 19
		Button2.Text = ">"
		Button2.UseVisualStyleBackColor = False
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button1.ForeColor = Color.White
		Button1.Location = New Point(1010, 883)
		Button1.Name = "Button1"
		Button1.Size = New Size(39, 42)
		Button1.TabIndex = 18
		Button1.Text = "<"
		Button1.UseVisualStyleBackColor = False
		' 
		' TextBox1
		' 
		TextBox1.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		TextBox1.Location = New Point(1055, 883)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(50, 46)
		TextBox1.TabIndex = 17
		' 
		' DataGridView1
		' 
		DataGridView1.AllowUserToAddRows = False
		DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(506, 120)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.ReadOnly = True
		DataGridView1.RowHeadersVisible = False
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		DataGridView1.Size = New Size(1260, 613)
		DataGridView1.TabIndex = 16
		' 
		' TextBox2
		' 
		TextBox2.Location = New Point(506, 62)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(382, 23)
		TextBox2.TabIndex = 20
		' 
		' Button7
		' 
		Button7.BackColor = Color.Transparent
		Button7.Cursor = Cursors.Hand
		Button7.FlatAppearance.BorderColor = Color.White
		Button7.FlatAppearance.BorderSize = 0
		Button7.FlatStyle = FlatStyle.Flat
		Button7.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button7.Location = New Point(105, 731)
		Button7.Name = "Button7"
		Button7.Size = New Size(196, 60)
		Button7.TabIndex = 21
		Button7.Text = "INVENTORY LOGS"
		Button7.TextAlign = ContentAlignment.MiddleLeft
		Button7.UseVisualStyleBackColor = False
		' 
		' Button4
		' 
		Button4.BackColor = Color.Transparent
		Button4.Cursor = Cursors.Hand
		Button4.FlatAppearance.BorderColor = Color.White
		Button4.FlatAppearance.BorderSize = 0
		Button4.FlatStyle = FlatStyle.Flat
		Button4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button4.Location = New Point(105, 521)
		Button4.Name = "Button4"
		Button4.Size = New Size(196, 60)
		Button4.TabIndex = 22
		Button4.Text = "MANAGE INGREDIENTS"
		Button4.TextAlign = ContentAlignment.MiddleLeft
		Button4.UseVisualStyleBackColor = False
		' 
		' btnClose
		' 
		btnClose.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnClose.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnClose.ForeColor = Color.White
		btnClose.Location = New Point(41, 823)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(93, 43)
		btnClose.TabIndex = 23
		btnClose.Text = "Back"
		btnClose.UseVisualStyleBackColor = False
		' 
		' Admin_OrdLogs
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(btnClose)
		Controls.Add(Button4)
		Controls.Add(Button7)
		Controls.Add(TextBox2)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(TextBox1)
		Controls.Add(DataGridView1)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Name = "Admin_OrdLogs"
		Text = "Admin_OrdLogs"
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Button7 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents btnClose As Button
End Class
