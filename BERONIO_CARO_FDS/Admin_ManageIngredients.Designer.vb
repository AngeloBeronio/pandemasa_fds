<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ManageIngredients
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_ManageIngredients))
		DataGridView1 = New DataGridView()
		Label8 = New Label()
		TextBox4 = New TextBox()
		TextBox5 = New TextBox()
		Button2 = New Button()
		Button1 = New Button()
		FlowLayoutPanel2 = New FlowLayoutPanel()
		Button3 = New Button()
		Label10 = New Label()
		Label11 = New Label()
		Panel4 = New Panel()
		Panel2 = New Panel()
		Label4 = New Label()
		TextBox3 = New TextBox()
		Label3 = New Label()
		TextBox2 = New TextBox()
		Label1 = New Label()
		TextBox1 = New TextBox()
		Label2 = New Label()
		Button8 = New Button()
		Button7 = New Button()
		Button5 = New Button()
		Button6 = New Button()
		Button4 = New Button()
		btnClose = New Button()
		CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
		Panel4.SuspendLayout()
		Panel2.SuspendLayout()
		SuspendLayout()
		' 
		' DataGridView1
		' 
		DataGridView1.AllowUserToAddRows = False
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridView1.Location = New Point(382, 81)
		DataGridView1.MultiSelect = False
		DataGridView1.Name = "DataGridView1"
		DataGridView1.ReadOnly = True
		DataGridView1.RowHeadersVisible = False
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		DataGridView1.Size = New Size(1087, 712)
		DataGridView1.TabIndex = 20
		' 
		' Label8
		' 
		Label8.AutoSize = True
		Label8.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
		Label8.Location = New Point(20, 17)
		Label8.Name = "Label8"
		Label8.Size = New Size(313, 32)
		Label8.TabIndex = 14
		Label8.Text = "ADD/DELETE INGREDIENT"
		' 
		' TextBox4
		' 
		TextBox4.Location = New Point(29, 93)
		TextBox4.Name = "TextBox4"
		TextBox4.Size = New Size(368, 23)
		TextBox4.TabIndex = 16
		' 
		' TextBox5
		' 
		TextBox5.Location = New Point(514, 93)
		TextBox5.Name = "TextBox5"
		TextBox5.Size = New Size(192, 23)
		TextBox5.TabIndex = 17
		' 
		' Button2
		' 
		Button2.Location = New Point(849, 25)
		Button2.Name = "Button2"
		Button2.Size = New Size(109, 103)
		Button2.TabIndex = 18
		Button2.Text = "ADD"
		Button2.UseVisualStyleBackColor = True
		' 
		' Button1
		' 
		Button1.Location = New Point(31, 408)
		Button1.Name = "Button1"
		Button1.Size = New Size(87, 79)
		Button1.TabIndex = 19
		Button1.Text = "SET"
		Button1.UseVisualStyleBackColor = True
		' 
		' FlowLayoutPanel2
		' 
		FlowLayoutPanel2.Location = New Point(993, 37)
		FlowLayoutPanel2.Name = "FlowLayoutPanel2"
		FlowLayoutPanel2.Size = New Size(2, 79)
		FlowLayoutPanel2.TabIndex = 20
		' 
		' Button3
		' 
		Button3.Location = New Point(1029, 25)
		Button3.Name = "Button3"
		Button3.Size = New Size(109, 103)
		Button3.TabIndex = 22
		Button3.Text = "REMOVE"
		Button3.UseVisualStyleBackColor = True
		' 
		' Label10
		' 
		Label10.AutoSize = True
		Label10.Location = New Point(29, 69)
		Label10.Name = "Label10"
		Label10.Size = New Size(110, 15)
		Label10.TabIndex = 23
		Label10.Text = "INGREDIENT NAME"
		' 
		' Label11
		' 
		Label11.AutoSize = True
		Label11.Location = New Point(516, 69)
		Label11.Name = "Label11"
		Label11.Size = New Size(98, 15)
		Label11.TabIndex = 24
		Label11.Text = "PRICE PER GRAM"
		' 
		' Panel4
		' 
		Panel4.Controls.Add(Label11)
		Panel4.Controls.Add(Label10)
		Panel4.Controls.Add(Button3)
		Panel4.Controls.Add(FlowLayoutPanel2)
		Panel4.Controls.Add(Button2)
		Panel4.Controls.Add(TextBox5)
		Panel4.Controls.Add(TextBox4)
		Panel4.Controls.Add(Label8)
		Panel4.Location = New Point(382, 818)
		Panel4.Name = "Panel4"
		Panel4.Size = New Size(1448, 167)
		Panel4.TabIndex = 23
		' 
		' Panel2
		' 
		Panel2.Controls.Add(Label4)
		Panel2.Controls.Add(TextBox3)
		Panel2.Controls.Add(Label3)
		Panel2.Controls.Add(TextBox2)
		Panel2.Controls.Add(Label1)
		Panel2.Controls.Add(TextBox1)
		Panel2.Controls.Add(Button1)
		Panel2.Controls.Add(Label2)
		Panel2.Location = New Point(1502, 81)
		Panel2.Name = "Panel2"
		Panel2.Size = New Size(328, 712)
		Panel2.TabIndex = 24
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Location = New Point(33, 321)
		Label4.Name = "Label4"
		Label4.Size = New Size(101, 15)
		Label4.TabIndex = 30
		Label4.Text = "GRAMS IN STOCK"
		' 
		' TextBox3
		' 
		TextBox3.Location = New Point(31, 345)
		TextBox3.Name = "TextBox3"
		TextBox3.Size = New Size(192, 23)
		TextBox3.TabIndex = 29
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Location = New Point(33, 227)
		Label3.Name = "Label3"
		Label3.Size = New Size(98, 15)
		Label3.TabIndex = 28
		Label3.Text = "PRICE PER GRAM"
		' 
		' TextBox2
		' 
		TextBox2.Location = New Point(31, 251)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(192, 23)
		TextBox2.TabIndex = 27
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(33, 141)
		Label1.Name = "Label1"
		Label1.Size = New Size(110, 15)
		Label1.TabIndex = 26
		Label1.Text = "INGREDIENT NAME"
		' 
		' TextBox1
		' 
		TextBox1.Location = New Point(33, 165)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(195, 23)
		TextBox1.TabIndex = 25
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(24, 30)
		Label2.Name = "Label2"
		Label2.Size = New Size(258, 32)
		Label2.TabIndex = 6
		Label2.Text = "UPDATE INGREDIENT"
		' 
		' Button8
		' 
		Button8.BackColor = Color.Transparent
		Button8.Cursor = Cursors.Hand
		Button8.FlatAppearance.BorderColor = Color.White
		Button8.FlatAppearance.BorderSize = 0
		Button8.FlatStyle = FlatStyle.Flat
		Button8.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button8.Location = New Point(120, 679)
		Button8.Name = "Button8"
		Button8.Size = New Size(196, 60)
		Button8.TabIndex = 29
		Button8.Text = "INVENTORY LOGS"
		Button8.TextAlign = ContentAlignment.MiddleLeft
		Button8.UseVisualStyleBackColor = False
		' 
		' Button7
		' 
		Button7.BackColor = Color.Transparent
		Button7.Cursor = Cursors.Hand
		Button7.FlatAppearance.BorderColor = Color.White
		Button7.FlatAppearance.BorderSize = 0
		Button7.FlatStyle = FlatStyle.Flat
		Button7.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button7.Location = New Point(120, 613)
		Button7.Name = "Button7"
		Button7.Size = New Size(196, 60)
		Button7.TabIndex = 28
		Button7.Text = "ORDER LOGS"
		Button7.TextAlign = ContentAlignment.MiddleLeft
		Button7.UseVisualStyleBackColor = False
		' 
		' Button5
		' 
		Button5.BackColor = Color.Transparent
		Button5.Cursor = Cursors.Hand
		Button5.FlatAppearance.BorderColor = Color.White
		Button5.FlatAppearance.BorderSize = 0
		Button5.FlatStyle = FlatStyle.Flat
		Button5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button5.Location = New Point(120, 547)
		Button5.Name = "Button5"
		Button5.Size = New Size(196, 60)
		Button5.TabIndex = 26
		Button5.Text = "MANAGE EMPLOYEES"
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
		Button6.Location = New Point(120, 332)
		Button6.Name = "Button6"
		Button6.Size = New Size(196, 60)
		Button6.TabIndex = 25
		Button6.Text = "HOME"
		Button6.TextAlign = ContentAlignment.MiddleLeft
		Button6.UseVisualStyleBackColor = False
		' 
		' Button4
		' 
		Button4.BackColor = Color.Transparent
		Button4.Cursor = Cursors.Hand
		Button4.FlatAppearance.BorderColor = Color.White
		Button4.FlatAppearance.BorderSize = 0
		Button4.FlatStyle = FlatStyle.Flat
		Button4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Button4.Location = New Point(120, 398)
		Button4.Name = "Button4"
		Button4.Size = New Size(196, 60)
		Button4.TabIndex = 30
		Button4.Text = "MANAGE PRODUCTS"
		Button4.TextAlign = ContentAlignment.MiddleLeft
		Button4.UseVisualStyleBackColor = False
		' 
		' btnClose
		' 
		btnClose.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnClose.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnClose.ForeColor = Color.White
		btnClose.Location = New Point(52, 772)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(93, 43)
		btnClose.TabIndex = 31
		btnClose.Text = "Back"
		btnClose.UseVisualStyleBackColor = False
		' 
		' Admin_ManageIngredients
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(btnClose)
		Controls.Add(Button4)
		Controls.Add(Button8)
		Controls.Add(Button7)
		Controls.Add(Button5)
		Controls.Add(Button6)
		Controls.Add(Panel2)
		Controls.Add(Panel4)
		Controls.Add(DataGridView1)
		Name = "Admin_ManageIngredients"
		Text = "Ingredients"
		CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
		Panel4.ResumeLayout(False)
		Panel4.PerformLayout()
		Panel2.ResumeLayout(False)
		Panel2.PerformLayout()
		ResumeLayout(False)
	End Sub
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Label8 As Label
	Friend WithEvents TextBox4 As TextBox
	Friend WithEvents TextBox5 As TextBox
	Friend WithEvents Button2 As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
	Friend WithEvents Button3 As Button
	Friend WithEvents Label10 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents Panel4 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents Label3 As Label
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents TextBox3 As TextBox
	Friend WithEvents Button8 As Button
	Friend WithEvents Button7 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents Button6 As Button
	Friend WithEvents Button4 As Button
	Friend WithEvents btnClose As Button
End Class
