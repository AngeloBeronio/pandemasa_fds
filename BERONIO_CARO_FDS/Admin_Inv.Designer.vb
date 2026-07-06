<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Inv
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_Inv))
		Button3 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		DataGridView1 = New DataGridView()
		Panel1 = New Panel()
		Label1 = New Label()
		CheckBox5 = New CheckBox()
		CheckBox4 = New CheckBox()
		CheckBox3 = New CheckBox()
		CheckBox2 = New CheckBox()
		CheckBox1 = New CheckBox()
		Panel2 = New Panel()
		Button8 = New Button()
		Button7 = New Button()
		TextBox2 = New TextBox()
		Label5 = New Label()
		TextBox1 = New TextBox()
		Label4 = New Label()
		Panel3 = New Panel()
		NumericUpDown1 = New NumericUpDown()
		RadioButton2 = New RadioButton()
		RadioButton1 = New RadioButton()
		Label3 = New Label()
		Label2 = New Label()
		Panel4 = New Panel()
		Label9 = New Label()
		Label8 = New Label()
		Label7 = New Label()
		FlowLayoutPanel1 = New FlowLayoutPanel()
		Button4 = New Button()
		Button2 = New Button()
		ComboBox1 = New ComboBox()
		Button1 = New Button()
		TextBox3 = New TextBox()
		Label6 = New Label()
		Button9 = New Button()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		Panel1.SuspendLayout()
		Panel2.SuspendLayout()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
		Panel4.SuspendLayout()
		SuspendLayout()
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(108, 535)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 15
		Button3.Text = "INVENTORY LOGS"
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
		Button5.Location = New Point(108, 469)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 14
		Button5.Text = "ORDER LOGS"
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
		Button6.Location = New Point(108, 338)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 13
		Button6.Text = "HOME"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' DataGridView1
		' 
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(446, 287)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.Size = New Size(1003, 545)
		DataGridView1.TabIndex = 16
		' 
		' Panel1
		' 
		Panel1.Controls.Add(Label1)
		Panel1.Controls.Add(CheckBox5)
		Panel1.Controls.Add(CheckBox4)
		Panel1.Controls.Add(CheckBox3)
		Panel1.Controls.Add(CheckBox2)
		Panel1.Controls.Add(CheckBox1)
		Panel1.Location = New Point(446, 95)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(1003, 140)
		Panel1.TabIndex = 17
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(20, 30)
		Label1.Name = "Label1"
		Label1.Size = New Size(41, 15)
		Label1.TabIndex = 5
		Label1.Text = "FILTER"
		' 
		' CheckBox5
		' 
		CheckBox5.AutoSize = True
		CheckBox5.Location = New Point(696, 84)
		CheckBox5.Name = "CheckBox5"
		CheckBox5.Size = New Size(87, 19)
		CheckBox5.TabIndex = 4
		CheckBox5.Text = "BEVERAGES"
		CheckBox5.UseVisualStyleBackColor = True
		' 
		' CheckBox4
		' 
		CheckBox4.AutoSize = True
		CheckBox4.Location = New Point(524, 84)
		CheckBox4.Name = "CheckBox4"
		CheckBox4.Size = New Size(109, 19)
		CheckBox4.TabIndex = 3
		CheckBox4.Text = "CAKES & SWEETS"
		CheckBox4.UseVisualStyleBackColor = True
		' 
		' CheckBox3
		' 
		CheckBox3.AutoSize = True
		CheckBox3.Location = New Point(323, 84)
		CheckBox3.Name = "CheckBox3"
		CheckBox3.Size = New Size(75, 19)
		CheckBox3.TabIndex = 2
		CheckBox3.Text = "PASTRIES"
		CheckBox3.UseVisualStyleBackColor = True
		' 
		' CheckBox2
		' 
		CheckBox2.AutoSize = True
		CheckBox2.Location = New Point(173, 84)
		CheckBox2.Name = "CheckBox2"
		CheckBox2.Size = New Size(93, 19)
		CheckBox2.TabIndex = 1
		CheckBox2.Text = "SOFT BREAD"
		CheckBox2.UseVisualStyleBackColor = True
		' 
		' CheckBox1
		' 
		CheckBox1.AutoSize = True
		CheckBox1.Location = New Point(20, 84)
		CheckBox1.Name = "CheckBox1"
		CheckBox1.Size = New Size(111, 19)
		CheckBox1.TabIndex = 0
		CheckBox1.Text = "HOUSE SPECIAL"
		CheckBox1.UseVisualStyleBackColor = True
		' 
		' Panel2
		' 
		Panel2.Controls.Add(Button8)
		Panel2.Controls.Add(Button7)
		Panel2.Controls.Add(TextBox2)
		Panel2.Controls.Add(Label5)
		Panel2.Controls.Add(TextBox1)
		Panel2.Controls.Add(Label4)
		Panel2.Controls.Add(Panel3)
		Panel2.Controls.Add(NumericUpDown1)
		Panel2.Controls.Add(RadioButton2)
		Panel2.Controls.Add(RadioButton1)
		Panel2.Controls.Add(Label3)
		Panel2.Controls.Add(Label2)
		Panel2.Location = New Point(1467, 95)
		Panel2.Name = "Panel2"
		Panel2.Size = New Size(328, 737)
		Panel2.TabIndex = 18
		' 
		' Button8
		' 
		Button8.Location = New Point(34, 627)
		Button8.Name = "Button8"
		Button8.Size = New Size(130, 31)
		Button8.TabIndex = 17
		Button8.Text = "SET"
		Button8.UseVisualStyleBackColor = True
		' 
		' Button7
		' 
		Button7.Location = New Point(34, 260)
		Button7.Name = "Button7"
		Button7.Size = New Size(130, 31)
		Button7.TabIndex = 16
		Button7.Text = "SET"
		Button7.UseVisualStyleBackColor = True
		' 
		' TextBox2
		' 
		TextBox2.Location = New Point(34, 557)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(100, 23)
		TextBox2.TabIndex = 15
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Location = New Point(34, 539)
		Label5.Name = "Label5"
		Label5.Size = New Size(31, 15)
		Label5.TabIndex = 14
		Label5.Text = "Cost"
		' 
		' TextBox1
		' 
		TextBox1.Location = New Point(34, 462)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(100, 23)
		TextBox1.TabIndex = 13
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Location = New Point(34, 440)
		Label4.Name = "Label4"
		Label4.Size = New Size(42, 15)
		Label4.TabIndex = 12
		Label4.Text = "Selling"
		' 
		' Panel3
		' 
		Panel3.Location = New Point(24, 319)
		Panel3.Name = "Panel3"
		Panel3.Size = New Size(270, 2)
		Panel3.TabIndex = 11
		' 
		' NumericUpDown1
		' 
		NumericUpDown1.Location = New Point(34, 212)
		NumericUpDown1.Name = "NumericUpDown1"
		NumericUpDown1.Size = New Size(120, 23)
		NumericUpDown1.TabIndex = 10
		' 
		' RadioButton2
		' 
		RadioButton2.AutoSize = True
		RadioButton2.Location = New Point(34, 151)
		RadioButton2.Name = "RadioButton2"
		RadioButton2.Size = New Size(69, 19)
		RadioButton2.TabIndex = 9
		RadioButton2.TabStop = True
		RadioButton2.Text = "By Piece"
		RadioButton2.UseVisualStyleBackColor = True
		' 
		' RadioButton1
		' 
		RadioButton1.AutoSize = True
		RadioButton1.Location = New Point(34, 87)
		RadioButton1.Name = "RadioButton1"
		RadioButton1.Size = New Size(63, 19)
		RadioButton1.TabIndex = 8
		RadioButton1.TabStop = True
		RadioButton1.Text = "By Tray"
		RadioButton1.UseVisualStyleBackColor = True
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label3.Location = New Point(24, 360)
		Label3.Name = "Label3"
		Label3.Size = New Size(180, 32)
		Label3.TabIndex = 7
		Label3.Text = "UPDATE PRICE"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(24, 30)
		Label2.Name = "Label2"
		Label2.Size = New Size(234, 32)
		Label2.TabIndex = 6
		Label2.Text = "UPDATE QUANTITY"
		' 
		' Panel4
		' 
		Panel4.Controls.Add(Label9)
		Panel4.Controls.Add(Label8)
		Panel4.Controls.Add(Label7)
		Panel4.Controls.Add(FlowLayoutPanel1)
		Panel4.Controls.Add(Button4)
		Panel4.Controls.Add(Button2)
		Panel4.Controls.Add(ComboBox1)
		Panel4.Controls.Add(Button1)
		Panel4.Controls.Add(TextBox3)
		Panel4.Controls.Add(Label6)
		Panel4.Location = New Point(446, 865)
		Panel4.Name = "Panel4"
		Panel4.Size = New Size(1349, 140)
		Panel4.TabIndex = 19
		' 
		' Label9
		' 
		Label9.AutoSize = True
		Label9.Location = New Point(143, 44)
		Label9.Name = "Label9"
		Label9.Size = New Size(43, 15)
		Label9.TabIndex = 15
		Label9.Text = "IMAGE"
		' 
		' Label8
		' 
		Label8.AutoSize = True
		Label8.Location = New Point(20, 15)
		Label8.Name = "Label8"
		Label8.Size = New Size(97, 15)
		Label8.TabIndex = 14
		Label8.Text = "EDIT INVENTORY"
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Location = New Point(272, 44)
		Label7.Name = "Label7"
		Label7.Size = New Size(66, 15)
		Label7.TabIndex = 13
		Label7.Text = "CATEGORY"
		' 
		' FlowLayoutPanel1
		' 
		FlowLayoutPanel1.Location = New Point(1001, 31)
		FlowLayoutPanel1.Name = "FlowLayoutPanel1"
		FlowLayoutPanel1.Size = New Size(2, 79)
		FlowLayoutPanel1.TabIndex = 12
		' 
		' Button4
		' 
		Button4.Location = New Point(1031, 30)
		Button4.Name = "Button4"
		Button4.Size = New Size(87, 79)
		Button4.TabIndex = 11
		Button4.Text = "REMOVE"
		Button4.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Location = New Point(878, 30)
		Button2.Name = "Button2"
		Button2.Size = New Size(87, 79)
		Button2.TabIndex = 10
		Button2.Text = "ADD"
		Button2.UseVisualStyleBackColor = True
		' 
		' ComboBox1
		' 
		ComboBox1.FormattingEnabled = True
		ComboBox1.Location = New Point(272, 75)
		ComboBox1.Name = "ComboBox1"
		ComboBox1.Size = New Size(155, 23)
		ComboBox1.TabIndex = 8
		' 
		' Button1
		' 
		Button1.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button1.Location = New Point(143, 68)
		Button1.Name = "Button1"
		Button1.Size = New Size(112, 35)
		Button1.TabIndex = 7
		Button1.Text = "ATTACH"
		Button1.UseVisualStyleBackColor = True
		' 
		' TextBox3
		' 
		TextBox3.Location = New Point(20, 75)
		TextBox3.Name = "TextBox3"
		TextBox3.Size = New Size(100, 23)
		TextBox3.TabIndex = 6
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Location = New Point(20, 44)
		Label6.Name = "Label6"
		Label6.Size = New Size(98, 15)
		Label6.TabIndex = 5
		Label6.Text = "PRODUCT NAME"
		' 
		' Button9
		' 
		Button9.BackColor = Color.Transparent
		Button9.Cursor = Cursors.Hand
		Button9.FlatAppearance.BorderColor = Color.White
		Button9.FlatAppearance.BorderSize = 0
		Button9.FlatStyle = FlatStyle.Flat
		Button9.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button9.Location = New Point(108, 609)
		Button9.Name = "Button9"
		Button9.Size = New Size(196, 60)
		Button9.TabIndex = 20
		Button9.Text = "GROSS PROFIT"
		Button9.TextAlign = ContentAlignment.MiddleLeft
		Button9.UseVisualStyleBackColor = False
		' 
		' Admin_Inv
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(Button9)
		Controls.Add(Panel4)
		Controls.Add(Panel2)
		Controls.Add(Panel1)
		Controls.Add(DataGridView1)
		Controls.Add(Button3)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Name = "Admin_Inv"
		Text = "Admin_Inv"
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		Panel2.ResumeLayout(False)
		Panel2.PerformLayout()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
		Panel4.ResumeLayout(False)
		Panel4.PerformLayout()
		ResumeLayout(False)
	End Sub

	Friend WithEvents Button3 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents CheckBox5 As CheckBox
	Friend WithEvents CheckBox4 As CheckBox
	Friend WithEvents CheckBox3 As CheckBox
	Friend WithEvents CheckBox2 As CheckBox
	Friend WithEvents CheckBox1 As CheckBox
	Friend WithEvents Panel2 As Panel
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Panel3 As Panel
	Friend WithEvents NumericUpDown1 As NumericUpDown
	Friend WithEvents RadioButton2 As RadioButton
	Friend WithEvents RadioButton1 As RadioButton
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Panel4 As Panel
	Friend WithEvents TextBox3 As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
	Friend WithEvents Button4 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents Button1 As Button
	Friend WithEvents Label7 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents Button8 As Button
	Friend WithEvents Button7 As Button
	Friend WithEvents Button9 As Button
End Class
