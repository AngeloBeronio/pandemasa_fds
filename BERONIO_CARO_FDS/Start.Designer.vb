<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Start
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(disposing As Boolean)
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Start))
		Button1 = New Button()
		Button2 = New Button()
		TextBox1 = New TextBox()
		TextBox2 = New TextBox()
		Label1 = New Label()
		Label2 = New Label()
		SuspendLayout()
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button1.Font = New Font("Segoe UI", 26F, FontStyle.Bold)
		Button1.ForeColor = Color.White
		Button1.Location = New Point(757, 877)
		Button1.Name = "Button1"
		Button1.Size = New Size(380, 138)
		Button1.TabIndex = 0
		Button1.Text = "SIGN IN"
		Button1.UseVisualStyleBackColor = False
		' 
		' Button2
		' 
		Button2.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
		Button2.ForeColor = Color.White
		Button2.Location = New Point(28, 160)
		Button2.Name = "Button2"
		Button2.Size = New Size(79, 73)
		Button2.TabIndex = 1
		Button2.Text = "SWITCH"
		Button2.UseVisualStyleBackColor = False
		' 
		' TextBox1
		' 
		TextBox1.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		TextBox1.Location = New Point(772, 646)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(348, 46)
		TextBox1.TabIndex = 2
		' 
		' TextBox2
		' 
		TextBox2.Font = New Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		TextBox2.Location = New Point(772, 778)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(348, 46)
		TextBox2.TabIndex = 3
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(772, 596)
		Label1.Name = "Label1"
		Label1.Size = New Size(57, 47)
		Label1.TabIndex = 4
		Label1.Text = "ID"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.BackColor = Color.Transparent
		Label2.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(772, 728)
		Label2.Name = "Label2"
		Label2.Size = New Size(81, 47)
		Label2.TabIndex = 5
		Label2.Text = "PIN"
		' 
		' Start
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		BackgroundImageLayout = ImageLayout.Stretch
		ClientSize = New Size(1904, 1041)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Controls.Add(TextBox2)
		Controls.Add(TextBox1)
		Controls.Add(Button2)
		Controls.Add(Button1)
		DoubleBuffered = True
		Name = "Start"
		Text = "Start"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label

End Class
