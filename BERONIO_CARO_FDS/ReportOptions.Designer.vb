<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportOptions
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
		MonthCalendar1 = New MonthCalendar()
		ComboBox1 = New ComboBox()
		RadioButton1 = New RadioButton()
		RadioButton2 = New RadioButton()
		BackgroundWorker1 = New ComponentModel.BackgroundWorker()
		btnClose = New Button()
		Label1 = New Label()
		Button1 = New Button()
		SuspendLayout()
		' 
		' MonthCalendar1
		' 
		MonthCalendar1.Location = New Point(37, 199)
		MonthCalendar1.Name = "MonthCalendar1"
		MonthCalendar1.TabIndex = 0
		' 
		' ComboBox1
		' 
		ComboBox1.FormattingEnabled = True
		ComboBox1.Location = New Point(37, 127)
		ComboBox1.Name = "ComboBox1"
		ComboBox1.Size = New Size(227, 23)
		ComboBox1.TabIndex = 1
		' 
		' RadioButton1
		' 
		RadioButton1.AutoSize = True
		RadioButton1.Location = New Point(37, 102)
		RadioButton1.Name = "RadioButton1"
		RadioButton1.Size = New Size(77, 19)
		RadioButton1.TabIndex = 2
		RadioButton1.TabStop = True
		RadioButton1.Text = "By Month"
		RadioButton1.UseVisualStyleBackColor = True
		' 
		' RadioButton2
		' 
		RadioButton2.AutoSize = True
		RadioButton2.Location = New Point(37, 168)
		RadioButton2.Name = "RadioButton2"
		RadioButton2.Size = New Size(61, 19)
		RadioButton2.TabIndex = 3
		RadioButton2.TabStop = True
		RadioButton2.Text = "By Day"
		RadioButton2.UseVisualStyleBackColor = True
		' 
		' btnClose
		' 
		btnClose.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnClose.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnClose.ForeColor = Color.White
		btnClose.Location = New Point(98, 478)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(93, 43)
		btnClose.TabIndex = 14
		btnClose.Text = "Close"
		btnClose.UseVisualStyleBackColor = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI Semibold", 20.75F, FontStyle.Bold)
		Label1.Location = New Point(12, 32)
		Label1.Name = "Label1"
		Label1.Size = New Size(259, 38)
		Label1.TabIndex = 15
		Label1.Text = "Categorize Reports"
		' 
		' Button1
		' 
		Button1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button1.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button1.ForeColor = Color.White
		Button1.Location = New Point(54, 416)
		Button1.Name = "Button1"
		Button1.Size = New Size(177, 43)
		Button1.TabIndex = 16
		Button1.Text = "GENERATE"
		Button1.UseVisualStyleBackColor = False
		' 
		' ReportOptions
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(311, 533)
		Controls.Add(Button1)
		Controls.Add(Label1)
		Controls.Add(btnClose)
		Controls.Add(RadioButton2)
		Controls.Add(RadioButton1)
		Controls.Add(ComboBox1)
		Controls.Add(MonthCalendar1)
		Name = "ReportOptions"
		Text = "ReportOptions"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents MonthCalendar1 As MonthCalendar
	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents RadioButton1 As RadioButton
	Friend WithEvents RadioButton2 As RadioButton
	Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
	Friend WithEvents btnClose As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Button1 As Button
End Class
