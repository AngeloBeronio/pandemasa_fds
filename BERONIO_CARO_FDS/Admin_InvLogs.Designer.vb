<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_InvLogs
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_InvLogs))
		DataGridView1 = New DataGridView()
		TextBox1 = New TextBox()
		Button1 = New Button()
		Button2 = New Button()
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		TextBox2 = New TextBox()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' DataGridView1
		' 
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(491, 146)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.Size = New Size(1260, 613)
		DataGridView1.TabIndex = 0
		' 
		' TextBox1
		' 
		TextBox1.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		TextBox1.Location = New Point(1040, 909)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(50, 46)
		TextBox1.TabIndex = 1
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button1.ForeColor = Color.White
		Button1.Location = New Point(995, 909)
		Button1.Name = "Button1"
		Button1.Size = New Size(39, 42)
		Button1.TabIndex = 2
		Button1.Text = "<"
		Button1.UseVisualStyleBackColor = False
		' 
		' Button2
		' 
		Button2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button2.ForeColor = Color.White
		Button2.Location = New Point(1096, 909)
		Button2.Name = "Button2"
		Button2.Size = New Size(39, 42)
		Button2.TabIndex = 3
		Button2.Text = ">"
		Button2.UseVisualStyleBackColor = False
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(116, 469)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 18
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
		Button5.Location = New Point(116, 337)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 17
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
		Button6.Location = New Point(116, 403)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 16
		Button6.Text = "MANAGE INVENTORY"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' TextBox2
		' 
		TextBox2.Location = New Point(491, 102)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(232, 23)
		TextBox2.TabIndex = 19
		' 
		' Admin_InvLogs
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(TextBox2)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(TextBox1)
		Controls.Add(DataGridView1)
		Name = "Admin_InvLogs"
		Text = "Admin_InvLogs"
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents TextBox2 As TextBox
End Class
