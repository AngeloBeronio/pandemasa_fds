<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentMethod
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
		Button1 = New Button()
		Label1 = New Label()
		Button2 = New Button()
		Button3 = New Button()
		Button4 = New Button()
		SuspendLayout()
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
		Button1.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button1.ForeColor = Color.White
		Button1.Location = New Point(29, 183)
		Button1.Name = "Button1"
		Button1.Size = New Size(314, 77)
		Button1.TabIndex = 0
		Button1.Text = "Cash"
		Button1.UseVisualStyleBackColor = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(57, 76)
		Label1.Name = "Label1"
		Label1.Size = New Size(254, 40)
		Label1.TabIndex = 4
		Label1.Text = "Payment Method"
		' 
		' Button2
		' 
		Button2.BackColor = SystemColors.ControlDark
		Button2.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button2.Location = New Point(29, 300)
		Button2.Name = "Button2"
		Button2.Size = New Size(314, 77)
		Button2.TabIndex = 5
		Button2.Text = "Card"
		Button2.UseVisualStyleBackColor = False
		' 
		' Button3
		' 
		Button3.BackColor = Color.DodgerBlue
		Button3.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button3.ForeColor = Color.White
		Button3.Location = New Point(29, 415)
		Button3.Name = "Button3"
		Button3.Size = New Size(314, 77)
		Button3.TabIndex = 6
		Button3.Text = "GCash"
		Button3.UseVisualStyleBackColor = False
		' 
		' Button4
		' 
		Button4.BackColor = Color.Green
		Button4.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button4.ForeColor = Color.White
		Button4.Location = New Point(29, 535)
		Button4.Name = "Button4"
		Button4.Size = New Size(314, 77)
		Button4.TabIndex = 7
		Button4.Text = "Maya"
		Button4.UseVisualStyleBackColor = False
		' 
		' PaymentMethod
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(391, 678)
		Controls.Add(Button4)
		Controls.Add(Button3)
		Controls.Add(Button2)
		Controls.Add(Label1)
		Controls.Add(Button1)
		Name = "PaymentMethod"
		Text = "PaymentMethod"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Button1 As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Button2 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button4 As Button
End Class
