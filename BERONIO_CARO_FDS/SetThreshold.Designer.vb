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
		Label1 = New Label()
		Label2 = New Label()
		Label3 = New Label()
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
		Button1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button1.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
		Button1.ForeColor = Color.White
		Button1.Location = New Point(146, 194)
		Button1.Name = "Button1"
		Button1.Size = New Size(75, 55)
		Button1.TabIndex = 2
		Button1.Text = "SET"
		Button1.UseVisualStyleBackColor = False
		' 
		' Button2
		' 
		Button2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button2.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
		Button2.ForeColor = Color.White
		Button2.Location = New Point(263, 194)
		Button2.Name = "Button2"
		Button2.Size = New Size(75, 55)
		Button2.TabIndex = 3
		Button2.Text = "Close"
		Button2.UseVisualStyleBackColor = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(21, 119)
		Label1.Name = "Label1"
		Label1.Size = New Size(84, 15)
		Label1.TabIndex = 4
		Label1.Text = "Product Name"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(263, 119)
		Label2.Name = "Label2"
		Label2.Size = New Size(53, 15)
		Label2.TabIndex = 5
		Label2.Text = "Qty limit"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label3.Location = New Point(21, 30)
		Label3.Name = "Label3"
		Label3.Size = New Size(204, 40)
		Label3.TabIndex = 6
		Label3.Text = "Set Threshold"
		' 
		' SetThreshold
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(383, 306)
		Controls.Add(Label3)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(NumericUpDown1)
		Controls.Add(ComboBox1)
		Name = "SetThreshold"
		Text = "SetThreshold"
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents NumericUpDown1 As NumericUpDown
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
End Class
