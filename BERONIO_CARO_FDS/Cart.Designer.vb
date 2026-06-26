<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cart
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cart))
		Button4 = New Button()
		Button3 = New Button()
		Button2 = New Button()
		Button1 = New Button()
		Button5 = New Button()
		Label1 = New Label()
		cartMenu = New DataGridView()
		btnAddtoCart = New Button()
		NumericUpDown1 = New NumericUpDown()
		Label2 = New Label()
		Label3 = New Label()
		lblSubtotal = New Label()
		CType(cartMenu, ComponentModel.ISupportInitialize).BeginInit()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' Button4
		' 
		Button4.BackColor = Color.Transparent
		Button4.Cursor = Cursors.Hand
		Button4.FlatAppearance.BorderColor = Color.White
		Button4.FlatAppearance.BorderSize = 0
		Button4.FlatStyle = FlatStyle.Flat
		Button4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button4.Location = New Point(122, 332)
		Button4.Name = "Button4"
		Button4.Size = New Size(196, 60)
		Button4.TabIndex = 16
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
		Button3.Location = New Point(122, 571)
		Button3.Name = "Button3"
		Button3.Size = New Size(196, 60)
		Button3.TabIndex = 15
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
		Button2.Location = New Point(122, 486)
		Button2.Name = "Button2"
		Button2.Size = New Size(196, 60)
		Button2.TabIndex = 14
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
		Button1.Location = New Point(122, 410)
		Button1.Name = "Button1"
		Button1.Size = New Size(196, 60)
		Button1.TabIndex = 13
		Button1.Text = "SOFT BREAD"
		Button1.TextAlign = ContentAlignment.MiddleLeft
		Button1.UseVisualStyleBackColor = False
		' 
		' Button5
		' 
		Button5.BackColor = Color.Transparent
		Button5.Cursor = Cursors.Hand
		Button5.FlatAppearance.BorderColor = Color.White
		Button5.FlatAppearance.BorderSize = 0
		Button5.FlatStyle = FlatStyle.Flat
		Button5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button5.Location = New Point(122, 664)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 17
		Button5.Text = "BEVERAGES"
		Button5.TextAlign = ContentAlignment.MiddleLeft
		Button5.UseVisualStyleBackColor = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.ForeColor = Color.White
		Label1.Location = New Point(122, 878)
		Label1.Name = "Label1"
		Label1.Size = New Size(114, 25)
		Label1.TabIndex = 18
		Label1.Text = "ORDER LIST"
		' 
		' cartMenu
		' 
		cartMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		cartMenu.Location = New Point(472, 129)
		cartMenu.Name = "cartMenu"
		cartMenu.Size = New Size(1238, 566)
		cartMenu.TabIndex = 19
		' 
		' btnAddtoCart
		' 
		btnAddtoCart.BackColor = Color.FromArgb(CByte(253), CByte(136), CByte(18))
		btnAddtoCart.Cursor = Cursors.Hand
		btnAddtoCart.FlatAppearance.BorderColor = Color.White
		btnAddtoCart.FlatAppearance.BorderSize = 2
		btnAddtoCart.FlatStyle = FlatStyle.Flat
		btnAddtoCart.Font = New Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnAddtoCart.ForeColor = Color.White
		btnAddtoCart.Location = New Point(1411, 817)
		btnAddtoCart.Name = "btnAddtoCart"
		btnAddtoCart.Size = New Size(281, 86)
		btnAddtoCart.TabIndex = 20
		btnAddtoCart.Text = "CHECKOUT"
		btnAddtoCart.UseVisualStyleBackColor = False
		' 
		' NumericUpDown1
		' 
		NumericUpDown1.Font = New Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		NumericUpDown1.Location = New Point(484, 796)
		NumericUpDown1.Name = "NumericUpDown1"
		NumericUpDown1.Size = New Size(120, 71)
		NumericUpDown1.TabIndex = 21
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.BackColor = Color.Transparent
		Label2.Font = New Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(472, 724)
		Label2.Name = "Label2"
		Label2.Size = New Size(270, 50)
		Label2.TabIndex = 22
		Label2.Text = "SET QUANTITY"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.BackColor = Color.Transparent
		Label3.Font = New Font("Segoe UI Semibold", 27.75F, FontStyle.Bold)
		Label3.Location = New Point(1203, 724)
		Label3.Name = "Label3"
		Label3.Size = New Size(202, 50)
		Label3.TabIndex = 23
		Label3.Text = "SUBTOTAL:"
		' 
		' lblSubtotal
		' 
		lblSubtotal.AutoSize = True
		lblSubtotal.BackColor = Color.Transparent
		lblSubtotal.Font = New Font("Segoe UI Semibold", 27.75F, FontStyle.Bold)
		lblSubtotal.Location = New Point(1432, 724)
		lblSubtotal.Name = "lblSubtotal"
		lblSubtotal.Size = New Size(220, 50)
		lblSubtotal.TabIndex = 24
		lblSubtotal.Text = "placeholder"
		' 
		' Cart
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(lblSubtotal)
		Controls.Add(Label3)
		Controls.Add(Label2)
		Controls.Add(NumericUpDown1)
		Controls.Add(btnAddtoCart)
		Controls.Add(cartMenu)
		Controls.Add(Label1)
		Controls.Add(Button5)
		Controls.Add(Button4)
		Controls.Add(Button3)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Name = "Cart"
		Text = "Cart"
		CType(cartMenu, ComponentModel.ISupportInitialize).EndInit()
		CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Button4 As Button
	Friend WithEvents Button3 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents cartMenu As DataGridView
	Friend WithEvents btnAddtoCart As Button
	Friend WithEvents NumericUpDown1 As NumericUpDown
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents lblSubtotal As Label
End Class
