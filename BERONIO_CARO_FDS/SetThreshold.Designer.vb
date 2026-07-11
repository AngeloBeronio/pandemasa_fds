<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetThreshold
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
		ComboBox1 = New ComboBox()
		NumericUpDown1 = New NumericUpDown()
		Button1 = New Button()
		Button2 = New Button()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' ComboBox1
		' 
		ComboBox1.FormattingEnabled = True
		ComboBox1.Location = New Point(21, 137)
		ComboBox1.Name = "ComboBox1"
		ComboBox1.Size = New Size(200, 23)
		ComboBox1.TabIndex = 0
		' 
		' NumericUpDown1
		' 
		NumericUpDown1.Location = New Point(263, 137)
		NumericUpDown1.Name = "NumericUpDown1"
		NumericUpDown1.Size = New Size(84, 23)
		NumericUpDown1.TabIndex = 1
		' 
		' Button1
		' 
		Button1.Location = New Point(146, 194)
		Button1.Name = "Button1"
		Button1.Size = New Size(75, 23)
		Button1.TabIndex = 2
		Button1.Text = "SET"
		Button1.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Location = New Point(263, 194)
		Button2.Name = "Button2"
		Button2.Size = New Size(75, 23)
		Button2.TabIndex = 3
		Button2.Text = "Close"
		Button2.UseVisualStyleBackColor = True
		' 
		' SetThreshold
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(383, 306)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(NumericUpDown1)
		Controls.Add(ComboBox1)
		Name = "SetThreshold"
		Text = "SetThresholdForm"
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
	End Sub

	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents NumericUpDown1 As NumericUpDown
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
End Class
