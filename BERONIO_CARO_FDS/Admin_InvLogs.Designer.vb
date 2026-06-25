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
		' Admin_InvLogs
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
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
End Class
