<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_SignIn
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_SignIn))
		Button2 = New Button()
		Button1 = New Button()
		SuspendLayout()
		' 
		' Button2
		' 
		Button2.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
		Button2.ForeColor = Color.White
		Button2.Location = New Point(28, 160)
		Button2.Name = "Button2"
		Button2.Size = New Size(79, 73)
		Button2.TabIndex = 2
		Button2.Text = "SWITCH"
		Button2.UseVisualStyleBackColor = False
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button1.Font = New Font("Segoe UI", 26F, FontStyle.Bold)
		Button1.ForeColor = Color.White
		Button1.Location = New Point(763, 568)
		Button1.Name = "Button1"
		Button1.Size = New Size(380, 138)
		Button1.TabIndex = 3
		Button1.Text = "PLACEHOLDER"
		Button1.UseVisualStyleBackColor = False
		' 
		' Admin_SignIn
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(Button1)
		Controls.Add(Button2)
		DoubleBuffered = True
		Name = "Admin_SignIn"
		Text = "Admin_SignIn"
		ResumeLayout(False)
	End Sub

	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
End Class
