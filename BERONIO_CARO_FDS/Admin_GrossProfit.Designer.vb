<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_GrossProfit
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_GrossProfit))
		PictureBox1 = New PictureBox()
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		Button1 = New Button()
		PictureBox2 = New PictureBox()
		DataGridView1 = New DataGridView()
		MonthCalendar1 = New MonthCalendar()
		ComboBox1 = New ComboBox()
		RadioButton1 = New RadioButton()
		RadioButton2 = New RadioButton()
		Label1 = New Label()
		Label2 = New Label()
		CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
		CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' PictureBox1
		' 
		PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
		PictureBox1.Location = New Point(12, 415)
		PictureBox1.Name = "PictureBox1"
		PictureBox1.Size = New Size(64, 191)
		PictureBox1.TabIndex = 0
		PictureBox1.TabStop = False
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(82, 546)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 21
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
		Button5.Location = New Point(82, 415)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 20
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
		Button6.Location = New Point(82, 480)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 19
		Button6.Text = "MANAGE INVENTORY"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' Button1
		' 
		Button1.BackColor = Color.Transparent
		Button1.Cursor = Cursors.Hand
		Button1.FlatAppearance.BorderColor = Color.White
		Button1.FlatAppearance.BorderSize = 0
		Button1.FlatStyle = FlatStyle.Flat
		Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button1.Location = New Point(82, 602)
		Button1.Name = "Button1"
		Button1.Size = New Size(196, 60)
		Button1.TabIndex = 22
		Button1.Text = "INVENTORY LOGS"
		Button1.TextAlign = ContentAlignment.MiddleLeft
		Button1.UseVisualStyleBackColor = False
		' 
		' PictureBox2
		' 
		PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
		PictureBox2.Location = New Point(12, 612)
		PictureBox2.Name = "PictureBox2"
		PictureBox2.Size = New Size(64, 50)
		PictureBox2.TabIndex = 23
		PictureBox2.TabStop = False
		' 
		' DataGridView1
		' 
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(604, 266)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.Size = New Size(898, 530)
		DataGridView1.TabIndex = 24
		' 
		' MonthCalendar1
		' 
		MonthCalendar1.Location = New Point(604, 83)
		MonthCalendar1.Name = "MonthCalendar1"
		MonthCalendar1.TabIndex = 25
		' 
		' ComboBox1
		' 
		ComboBox1.FormattingEnabled = True
		ComboBox1.Location = New Point(1228, 83)
		ComboBox1.Name = "ComboBox1"
		ComboBox1.Size = New Size(180, 23)
		ComboBox1.TabIndex = 26
		' 
		' RadioButton1
		' 
		RadioButton1.AutoSize = True
		RadioButton1.BackColor = Color.Transparent
		RadioButton1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		RadioButton1.Location = New Point(604, 52)
		RadioButton1.Name = "RadioButton1"
		RadioButton1.Size = New Size(132, 19)
		RadioButton1.TabIndex = 27
		RadioButton1.TabStop = True
		RadioButton1.Text = "Gross Profit By Day"
		RadioButton1.UseVisualStyleBackColor = False
		' 
		' RadioButton2
		' 
		RadioButton2.AutoSize = True
		RadioButton2.BackColor = Color.Transparent
		RadioButton2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		RadioButton2.Location = New Point(1228, 52)
		RadioButton2.Name = "RadioButton2"
		RadioButton2.Size = New Size(148, 19)
		RadioButton2.TabIndex = 28
		RadioButton2.TabStop = True
		RadioButton2.Text = "Gross profit By Month"
		RadioButton2.UseVisualStyleBackColor = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(1188, 817)
		Label1.Name = "Label1"
		Label1.Size = New Size(85, 32)
		Label1.TabIndex = 29
		Label1.Text = "TOTAL"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.BackColor = Color.Transparent
		Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(1293, 817)
		Label2.Name = "Label2"
		Label2.Size = New Size(88, 32)
		Label2.TabIndex = 30
		Label2.Text = "Label2"
		' 
		' Admin_GrossProfit
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		BackgroundImageLayout = ImageLayout.Stretch
		ClientSize = New Size(1904, 1041)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Controls.Add(RadioButton2)
		Controls.Add(RadioButton1)
		Controls.Add(ComboBox1)
		Controls.Add(MonthCalendar1)
		Controls.Add(DataGridView1)
		Controls.Add(PictureBox2)
		Controls.Add(Button1)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Controls.Add(PictureBox1)
		Name = "Admin_GrossProfit"
		Text = "Admin_GrossProfit"
		CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
		CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents PictureBox2 As PictureBox
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents MonthCalendar1 As MonthCalendar
	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents RadioButton1 As RadioButton
	Friend WithEvents RadioButton2 As RadioButton
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
End Class
