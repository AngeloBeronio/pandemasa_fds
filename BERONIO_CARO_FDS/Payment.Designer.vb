<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment
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
		Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payment))
		Button5 = New Button()
		Button4 = New Button()
		Button3 = New Button()
		Button2 = New Button()
		Button1 = New Button()
		btnConfirm = New Button()
		amoTendered = New TextBox()
		Button7 = New Button()
		Button8 = New Button()
		Button9 = New Button()
		Button10 = New Button()
		Button11 = New Button()
		Button12 = New Button()
		Button13 = New Button()
		Button14 = New Button()
		Button15 = New Button()
		Button17 = New Button()
		Button18 = New Button()
		Button16 = New Button()
		dgvOrder = New DataGridView()
		Label1 = New Label()
		lblSubtotal = New Label()
		lblTotal = New Label()
		lblDiscount = New Label()
		lblchange = New Label()
		Button19 = New Button()
		Button20 = New Button()
		Button6 = New Button()
		Label2 = New Label()
		Panel2 = New Panel()
		Button21 = New Button()
		Label3 = New Label()
		hchangelbl = New Label()
		CType(dgvOrder, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Button5
		' 
		Button5.BackColor = Color.Transparent
		Button5.Cursor = Cursors.Hand
		Button5.FlatAppearance.BorderColor = Color.White
		Button5.FlatAppearance.BorderSize = 0
		Button5.FlatStyle = FlatStyle.Flat
		Button5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button5.Location = New Point(118, 642)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 22
		Button5.Text = "BEVERAGES"
		Button5.TextAlign = ContentAlignment.MiddleLeft
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
		Button4.Location = New Point(118, 310)
		Button4.Name = "Button4"
		Button4.Size = New Size(196, 60)
		Button4.TabIndex = 21
		Button4.Text = "HOUSE SPECIALS"
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
		Button3.Location = New Point(118, 549)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 20
		Button3.Text = "CAKE AND SWEETS"
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
		Button2.Location = New Point(118, 464)
		Button2.Name = "Button2"
		Button2.Size = New Size(196, 60)
		Button2.TabIndex = 19
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
		Button1.Location = New Point(118, 388)
		Button1.Name = "Button1"
		Button1.Size = New Size(196, 60)
		Button1.TabIndex = 18
		Button1.Text = "SOFT BREAD"
		Button1.TextAlign = ContentAlignment.MiddleLeft
		Button1.UseVisualStyleBackColor = False
		' 
		' btnConfirm
		' 
		btnConfirm.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		btnConfirm.Cursor = Cursors.Hand
		btnConfirm.FlatAppearance.BorderColor = Color.White
		btnConfirm.FlatAppearance.BorderSize = 2
		btnConfirm.FlatStyle = FlatStyle.Flat
		btnConfirm.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnConfirm.ForeColor = Color.White
		btnConfirm.Location = New Point(1493, 850)
		btnConfirm.Name = "btnConfirm"
		btnConfirm.Size = New Size(281, 86)
		btnConfirm.TabIndex = 23
		btnConfirm.Text = "PRINT"
		btnConfirm.UseVisualStyleBackColor = False
		' 
		' amoTendered
		' 
		amoTendered.Font = New Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		amoTendered.Location = New Point(428, 183)
		amoTendered.Name = "amoTendered"
		amoTendered.Size = New Size(605, 93)
		amoTendered.TabIndex = 24
		' 
		' Button7
		' 
		Button7.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button7.Location = New Point(478, 329)
		Button7.Name = "Button7"
		Button7.Size = New Size(110, 108)
		Button7.TabIndex = 25
		Button7.Text = "7"
		Button7.UseVisualStyleBackColor = True
		' 
		' Button8
		' 
		Button8.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button8.Location = New Point(664, 329)
		Button8.Name = "Button8"
		Button8.Size = New Size(110, 108)
		Button8.TabIndex = 26
		Button8.Text = "8"
		Button8.UseVisualStyleBackColor = True
		' 
		' Button9
		' 
		Button9.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button9.Location = New Point(844, 329)
		Button9.Name = "Button9"
		Button9.Size = New Size(110, 108)
		Button9.TabIndex = 27
		Button9.Text = "9"
		Button9.UseVisualStyleBackColor = True
		' 
		' Button10
		' 
		Button10.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button10.Location = New Point(844, 484)
		Button10.Name = "Button10"
		Button10.Size = New Size(110, 108)
		Button10.TabIndex = 30
		Button10.Text = "6"
		Button10.UseVisualStyleBackColor = True
		' 
		' Button11
		' 
		Button11.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button11.Location = New Point(664, 484)
		Button11.Name = "Button11"
		Button11.Size = New Size(110, 108)
		Button11.TabIndex = 29
		Button11.Text = "5"
		Button11.UseVisualStyleBackColor = True
		' 
		' Button12
		' 
		Button12.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button12.Location = New Point(478, 484)
		Button12.Name = "Button12"
		Button12.Size = New Size(110, 108)
		Button12.TabIndex = 28
		Button12.Text = "4"
		Button12.UseVisualStyleBackColor = True
		' 
		' Button13
		' 
		Button13.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button13.Location = New Point(844, 642)
		Button13.Name = "Button13"
		Button13.Size = New Size(110, 108)
		Button13.TabIndex = 33
		Button13.Text = "3"
		Button13.UseVisualStyleBackColor = True
		' 
		' Button14
		' 
		Button14.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button14.Location = New Point(664, 642)
		Button14.Name = "Button14"
		Button14.Size = New Size(110, 108)
		Button14.TabIndex = 32
		Button14.Text = "2"
		Button14.UseVisualStyleBackColor = True
		' 
		' Button15
		' 
		Button15.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button15.Location = New Point(478, 642)
		Button15.Name = "Button15"
		Button15.Size = New Size(110, 108)
		Button15.TabIndex = 31
		Button15.Text = "1"
		Button15.UseVisualStyleBackColor = True
		' 
		' Button17
		' 
		Button17.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button17.Location = New Point(664, 809)
		Button17.Name = "Button17"
		Button17.Size = New Size(110, 108)
		Button17.TabIndex = 35
		Button17.Text = "0"
		Button17.UseVisualStyleBackColor = True
		' 
		' Button18
		' 
		Button18.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button18.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button18.ForeColor = Color.White
		Button18.Location = New Point(1048, 484)
		Button18.Name = "Button18"
		Button18.Size = New Size(195, 108)
		Button18.TabIndex = 34
		Button18.Text = "Other Methods"
		Button18.UseVisualStyleBackColor = False
		' 
		' Button16
		' 
		Button16.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button16.Location = New Point(478, 809)
		Button16.Name = "Button16"
		Button16.Size = New Size(110, 108)
		Button16.TabIndex = 36
		Button16.Text = "."
		Button16.UseVisualStyleBackColor = True
		' 
		' dgvOrder
		' 
		dgvOrder.AllowUserToAddRows = False
		dgvOrder.AllowUserToDeleteRows = False
		dgvOrder.AllowUserToResizeColumns = False
		dgvOrder.AllowUserToResizeRows = False
		dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgvOrder.BackgroundColor = Color.White
		DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = SystemColors.Control
		DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
		dgvOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = SystemColors.Window
		DataGridViewCellStyle2.Font = New Font("Segoe UI", 11F)
		DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
		DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
		dgvOrder.DefaultCellStyle = DataGridViewCellStyle2
		dgvOrder.GridColor = Color.Black
		dgvOrder.Location = New Point(1351, 148)
		dgvOrder.Name = "dgvOrder"
		dgvOrder.ReadOnly = True
		dgvOrder.RowHeadersVisible = False
		dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvOrder.Size = New Size(413, 461)
		dgvOrder.TabIndex = 39
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.ForeColor = Color.White
		Label1.Location = New Point(118, 848)
		Label1.Name = "Label1"
		Label1.Size = New Size(114, 25)
		Label1.TabIndex = 40
		Label1.Text = "ORDER LIST"
		' 
		' lblSubtotal
		' 
		lblSubtotal.AutoSize = True
		lblSubtotal.BackColor = Color.Transparent
		lblSubtotal.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lblSubtotal.ForeColor = Color.White
		lblSubtotal.Location = New Point(1482, 620)
		lblSubtotal.Name = "lblSubtotal"
		lblSubtotal.Size = New Size(53, 25)
		lblSubtotal.TabIndex = 42
		lblSubtotal.Text = "STlbl"
		' 
		' lblTotal
		' 
		lblTotal.AutoSize = True
		lblTotal.BackColor = Color.Transparent
		lblTotal.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lblTotal.ForeColor = Color.White
		lblTotal.Location = New Point(1534, 724)
		lblTotal.Name = "lblTotal"
		lblTotal.Size = New Size(97, 45)
		lblTotal.TabIndex = 43
		lblTotal.Text = "ttllbl"
		' 
		' lblDiscount
		' 
		lblDiscount.AutoSize = True
		lblDiscount.BackColor = Color.Transparent
		lblDiscount.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lblDiscount.ForeColor = Color.White
		lblDiscount.Location = New Point(1482, 668)
		lblDiscount.Name = "lblDiscount"
		lblDiscount.Size = New Size(57, 25)
		lblDiscount.TabIndex = 44
		lblDiscount.Text = "dislbl"
		' 
		' lblchange
		' 
		lblchange.AutoSize = True
		lblchange.BackColor = Color.Transparent
		lblchange.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lblchange.ForeColor = Color.White
		lblchange.Location = New Point(1568, 787)
		lblchange.Name = "lblchange"
		lblchange.Size = New Size(174, 45)
		lblchange.TabIndex = 45
		lblchange.Text = "changelbl"
		' 
		' Button19
		' 
		Button19.Font = New Font("Segoe UI Semibold", 26F, FontStyle.Bold)
		Button19.Location = New Point(844, 809)
		Button19.Name = "Button19"
		Button19.Size = New Size(110, 108)
		Button19.TabIndex = 46
		Button19.Text = "00"
		Button19.UseVisualStyleBackColor = True
		' 
		' Button20
		' 
		Button20.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button20.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button20.ForeColor = Color.White
		Button20.Location = New Point(1048, 809)
		Button20.Name = "Button20"
		Button20.Size = New Size(195, 108)
		Button20.TabIndex = 47
		Button20.Text = "Clear"
		Button20.UseVisualStyleBackColor = False
		' 
		' Button6
		' 
		Button6.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button6.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button6.ForeColor = Color.White
		Button6.Location = New Point(1048, 642)
		Button6.Name = "Button6"
		Button6.Size = New Size(195, 108)
		Button6.TabIndex = 48
		Button6.Text = "X"
		Button6.UseVisualStyleBackColor = False
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		Label2.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.ForeColor = Color.White
		Label2.Location = New Point(535, 88)
		Label2.Name = "Label2"
		Label2.Size = New Size(371, 47)
		Label2.TabIndex = 49
		Label2.Text = "AMOUNT TENDERED"
		' 
		' Panel2
		' 
		Panel2.BackColor = Color.Red
		Panel2.Location = New Point(1010, 381)
		Panel2.Name = "Panel2"
		Panel2.Size = New Size(21, 23)
		Panel2.TabIndex = 51
		' 
		' Button21
		' 
		Button21.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		Button21.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Button21.ForeColor = Color.White
		Button21.Location = New Point(1048, 340)
		Button21.Name = "Button21"
		Button21.Size = New Size(195, 108)
		Button21.TabIndex = 50
		Button21.Text = "PWD/SENIOR"
		Button21.UseVisualStyleBackColor = False
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Location = New Point(675, 28)
		Label3.Name = "Label3"
		Label3.Size = New Size(0, 15)
		Label3.TabIndex = 52
		' 
		' hchangelbl
		' 
		hchangelbl.AutoSize = True
		hchangelbl.BackColor = Color.Transparent
		hchangelbl.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		hchangelbl.ForeColor = Color.White
		hchangelbl.Location = New Point(1342, 787)
		hchangelbl.Name = "hchangelbl"
		hchangelbl.Size = New Size(194, 45)
		hchangelbl.TabIndex = 53
		hchangelbl.Text = "hchangelbl"
		' 
		' Payment
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		BackgroundImageLayout = ImageLayout.Stretch
		ClientSize = New Size(1904, 1041)
		Controls.Add(hchangelbl)
		Controls.Add(Label3)
		Controls.Add(Panel2)
		Controls.Add(Button21)
		Controls.Add(Label2)
		Controls.Add(Button6)
		Controls.Add(Button20)
		Controls.Add(Button19)
		Controls.Add(lblchange)
		Controls.Add(lblDiscount)
		Controls.Add(lblTotal)
		Controls.Add(lblSubtotal)
		Controls.Add(Label1)
		Controls.Add(dgvOrder)
		Controls.Add(Button16)
		Controls.Add(Button17)
		Controls.Add(Button18)
		Controls.Add(Button13)
		Controls.Add(Button14)
		Controls.Add(Button15)
		Controls.Add(Button10)
		Controls.Add(Button11)
		Controls.Add(Button12)
		Controls.Add(Button9)
		Controls.Add(Button8)
		Controls.Add(Button7)
		Controls.Add(amoTendered)
		Controls.Add(btnConfirm)
		Controls.Add(Button5)
		Controls.Add(Button4)
		Controls.Add(Button3)
		Controls.Add(Button2)
		Controls.Add(Button1)
		DoubleBuffered = True
		Name = "Payment"
		Text = "Payment"
		CType(dgvOrder, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Button5 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents btnConfirm As Button
	Friend WithEvents amoTendered As TextBox
	Friend WithEvents Button7 As Button
	Friend WithEvents Button8 As Button
	Friend WithEvents Button9 As Button
	Friend WithEvents Button10 As Button
	Friend WithEvents Button11 As Button
	Friend WithEvents Button12 As Button
	Friend WithEvents Button13 As Button
	Friend WithEvents Button14 As Button
	Friend WithEvents Button15 As Button
	Friend WithEvents Button17 As Button
	Friend WithEvents Button18 As Button
	Friend WithEvents Button16 As Button
	Friend WithEvents dgvOrder As DataGridView
	Friend WithEvents Label1 As Label
	Friend WithEvents lblSubtotal As Label
	Friend WithEvents lblTotal As Label
	Friend WithEvents lblDiscount As Label
	Friend WithEvents lblchange As Label
	Friend WithEvents Button19 As Button
	Friend WithEvents Button20 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Label2 As Label
	Friend WithEvents Panel2 As Panel
	Friend WithEvents Button21 As Button
	Friend WithEvents Label3 As Label
	Friend WithEvents hchangelbl As Label
End Class
