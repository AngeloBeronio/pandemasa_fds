<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_4_
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
		Label1 = New Label()
		PictureBox1 = New PictureBox()
		NumericUpDown1 = New NumericUpDown()
		Button5 = New Button()
		Button4 = New Button()
		Button3 = New Button()
		Button2 = New Button()
		Button1 = New Button()
		Button6 = New Button()
		DataGridView1 = New DataGridView()
		CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(442, 119)
		Label1.Name = "Label1"
		Label1.Size = New Size(67, 25)
		Label1.TabIndex = 17
		Label1.Text = "Label1"
		' 
		' PictureBox1
		' 
		PictureBox1.Location = New Point(454, 253)
		PictureBox1.Name = "PictureBox1"
		PictureBox1.Size = New Size(386, 399)
		PictureBox1.TabIndex = 16
		PictureBox1.TabStop = False
		' 
		' NumericUpDown1
		' 
		NumericUpDown1.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		NumericUpDown1.Location = New Point(454, 706)
		NumericUpDown1.Name = "NumericUpDown1"
		NumericUpDown1.Size = New Size(120, 39)
		NumericUpDown1.TabIndex = 15
		' 
		' Button5
		' 
		Button5.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button5.Cursor = Cursors.Hand
		Button5.FlatAppearance.BorderColor = Color.White
		Button5.FlatAppearance.BorderSize = 2
		Button5.FlatStyle = FlatStyle.Flat
		Button5.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button5.ForeColor = Color.White
		Button5.Location = New Point(454, 795)
		Button5.Name = "Button5"
		Button5.Size = New Size(281, 86)
		Button5.TabIndex = 14
		Button5.Text = "ADD TO CART"
		Button5.UseVisualStyleBackColor = False
		' 
		' Button4
		' 
		Button4.BackColor = Color.Transparent
		Button4.Cursor = Cursors.Hand
		Button4.FlatAppearance.BorderColor = Color.White
		Button4.FlatAppearance.BorderSize = 0
		Button4.FlatStyle = FlatStyle.Flat
		Button4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button4.Location = New Point(124, 648)
		Button4.Name = "Button4"
		Button4.Size = New Size(196, 60)
		Button4.TabIndex = 12
		Button4.Text = "BEVERAGES"
		Button4.TextAlign = ContentAlignment.MiddleLeft
		Button4.UseVisualStyleBackColor = False
		' 
		' Button3
		' 
		Button3.BackColor = Color.Transparent
		Button3.Cursor = Cursors.Hand
		Button3.FlatAppearance.BorderColor = Color.White
		Button3.FlatAppearance.BorderSize = 0
		Button3.FlatStyle = FlatStyle.Flat
		Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button3.Location = New Point(124, 310)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 11
		Button3.Text = "HOUSE SPECIALS"
		Button3.TextAlign = ContentAlignment.MiddleLeft
		Button3.UseVisualStyleBackColor = False
		' 
		' Button2
		' 
		Button2.BackColor = Color.Transparent
		Button2.Cursor = Cursors.Hand
		Button2.FlatAppearance.BorderColor = Color.White
		Button2.FlatAppearance.BorderSize = 0
		Button2.FlatStyle = FlatStyle.Flat
		Button2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button2.Location = New Point(124, 473)
		Button2.Name = "Button2"
		Button2.Size = New Size(196, 60)
		Button2.TabIndex = 10
		Button2.Text = "PASTRIES"
		Button2.TextAlign = ContentAlignment.MiddleLeft
		Button2.UseVisualStyleBackColor = False
		' 
		' Button1
		' 
		Button1.BackColor = Color.Transparent
		Button1.Cursor = Cursors.Hand
		Button1.FlatAppearance.BorderColor = Color.White
		Button1.FlatAppearance.BorderSize = 0
		Button1.FlatStyle = FlatStyle.Flat
		Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button1.Location = New Point(124, 397)
		Button1.Name = "Button1"
		Button1.Size = New Size(196, 60)
		Button1.TabIndex = 9
		Button1.Text = "SOFT BREAD"
		Button1.TextAlign = ContentAlignment.MiddleLeft
		Button1.UseVisualStyleBackColor = False
		' 
		' Button6
		' 
		Button6.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Button6.Cursor = Cursors.Hand
		Button6.FlatAppearance.BorderColor = Color.White
		Button6.FlatStyle = FlatStyle.Flat
		Button6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button6.ForeColor = Color.White
		Button6.Location = New Point(30, 855)
		Button6.Name = "Button6"
		Button6.Size = New Size(293, 72)
		Button6.TabIndex = 18
		Button6.Text = "ORDER LIST"
		Button6.UseVisualStyleBackColor = False
		' 
		' DataGridView1
		' 
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(960, 226)
		DataGridView1.Name = "DataGridView1"
		DataGridView1.Size = New Size(872, 686)
		DataGridView1.TabIndex = 19
		' 
		' Menu_4_
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = My.Resources.Resources.Cashier___Menu__4_
		BackgroundImageLayout = ImageLayout.Stretch
		ClientSize = New Size(1904, 1041)
		Controls.Add(DataGridView1)
		Controls.Add(Button6)
		Controls.Add(Label1)
		Controls.Add(PictureBox1)
		Controls.Add(NumericUpDown1)
		Controls.Add(Button5)
		Controls.Add(Button4)
		Controls.Add(Button3)
		Controls.Add(Button2)
		Controls.Add(Button1)
		DoubleBuffered = True
		Name = "Menu_4_"
		Text = "Menu_4_"
		CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents NumericUpDown1 As NumericUpDown
	Friend WithEvents Button5 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents DataGridView1 As DataGridView
End Class
