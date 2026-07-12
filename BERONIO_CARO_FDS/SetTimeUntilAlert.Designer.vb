<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setwarningtime
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
		TextBox1 = New TextBox()
		Button2 = New Button()
		Button1 = New Button()
		Label1 = New Label()
		Label3 = New Label()
		SuspendLayout()
		' 
		' TextBox1
		' 
		TextBox1.Location = New Point(41, 144)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(228, 23)
		TextBox1.TabIndex = 0
		' 
		' Button2
		' 
		Button2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button2.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
		Button2.ForeColor = Color.White
		Button2.Location = New Point(159, 202)
		Button2.Name = "Button2"
		Button2.Size = New Size(75, 55)
		Button2.TabIndex = 5
		Button2.Text = "Close"
		Button2.UseVisualStyleBackColor = False
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button1.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
		Button1.ForeColor = Color.White
		Button1.Location = New Point(41, 202)
		Button1.Name = "Button1"
		Button1.Size = New Size(75, 55)
		Button1.TabIndex = 4
		Button1.Text = "SET"
		Button1.UseVisualStyleBackColor = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(41, 100)
		Label1.Name = "Label1"
		Label1.Size = New Size(450, 15)
		Label1.TabIndex = 6
		Label1.Text = "Enter the time to show low stock warning on cashier screen (24hr format, e.g. 08:00):"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label3.Location = New Point(41, 48)
		Label3.Name = "Label3"
		Label3.Size = New Size(286, 40)
		Label3.TabIndex = 7
		Label3.Text = "Set Time Until Alert"
		' 
		' setwarningtime
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(613, 318)
		Controls.Add(Label3)
		Controls.Add(Label1)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(TextBox1)
		Name = "setwarningtime"
		Text = "setwarningtime"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Label3 As Label
End Class
