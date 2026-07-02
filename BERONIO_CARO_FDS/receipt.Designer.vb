<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receipt
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
		dgvReceipt = New DataGridView()
		lblOrderId = New Label()
		lblDate = New Label()
		lblSubtotal = New Label()
		lblVat = New Label()
		lblDiscount = New Label()
		lblTotal = New Label()
		lblChange = New Label()
		btnClose = New Button()
		Panel1 = New Panel()
		Label1 = New Label()
		Label2 = New Label()
		Label3 = New Label()
		Label4 = New Label()
		Label5 = New Label()
		CType(dgvReceipt, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' dgvReceipt
		' 
		dgvReceipt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = SystemColors.Window
		DataGridViewCellStyle1.Font = New Font("Segoe UI", 10F)
		DataGridViewCellStyle1.ForeColor = SystemColors.ControlText
		DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False
		dgvReceipt.DefaultCellStyle = DataGridViewCellStyle1
		dgvReceipt.Location = New Point(24, 46)
		dgvReceipt.Name = "dgvReceipt"
		dgvReceipt.Size = New Size(540, 244)
		dgvReceipt.TabIndex = 0
		' 
		' lblOrderId
		' 
		lblOrderId.AutoSize = True
		lblOrderId.Location = New Point(24, 26)
		lblOrderId.Name = "lblOrderId"
		lblOrderId.Size = New Size(41, 15)
		lblOrderId.TabIndex = 1
		lblOrderId.Text = "Label1"
		' 
		' lblDate
		' 
		lblDate.AutoSize = True
		lblDate.Location = New Point(480, 26)
		lblDate.Name = "lblDate"
		lblDate.Size = New Size(41, 15)
		lblDate.TabIndex = 2
		lblDate.Text = "Label1"
		' 
		' lblSubtotal
		' 
		lblSubtotal.AutoSize = True
		lblSubtotal.Location = New Point(152, 336)
		lblSubtotal.Name = "lblSubtotal"
		lblSubtotal.Size = New Size(41, 15)
		lblSubtotal.TabIndex = 3
		lblSubtotal.Text = "Label1"
		' 
		' lblVat
		' 
		lblVat.AutoSize = True
		lblVat.Location = New Point(152, 375)
		lblVat.Name = "lblVat"
		lblVat.Size = New Size(41, 15)
		lblVat.TabIndex = 4
		lblVat.Text = "Label1"
		' 
		' lblDiscount
		' 
		lblDiscount.AutoSize = True
		lblDiscount.Location = New Point(152, 415)
		lblDiscount.Name = "lblDiscount"
		lblDiscount.Size = New Size(41, 15)
		lblDiscount.TabIndex = 6
		lblDiscount.Text = "Label1"
		' 
		' lblTotal
		' 
		lblTotal.AutoSize = True
		lblTotal.Location = New Point(35, 532)
		lblTotal.Name = "lblTotal"
		lblTotal.Size = New Size(41, 15)
		lblTotal.TabIndex = 7
		lblTotal.Text = "Label1"
		' 
		' lblChange
		' 
		lblChange.AutoSize = True
		lblChange.Location = New Point(503, 532)
		lblChange.Name = "lblChange"
		lblChange.Size = New Size(61, 15)
		lblChange.TabIndex = 9
		lblChange.Text = "lblChange"
		' 
		' btnClose
		' 
		btnClose.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnClose.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnClose.ForeColor = Color.White
		btnClose.Location = New Point(251, 598)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(117, 57)
		btnClose.TabIndex = 12
		btnClose.Text = "Close"
		btnClose.UseVisualStyleBackColor = False
		' 
		' Panel1
		' 
		Panel1.BackColor = Color.Black
		Panel1.Location = New Point(31, 471)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(540, 4)
		Panel1.TabIndex = 13
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(31, 493)
		Label1.Name = "Label1"
		Label1.Size = New Size(68, 25)
		Label1.TabIndex = 14
		Label1.Text = "TOTAL"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(480, 493)
		Label2.Name = "Label2"
		Label2.Size = New Size(91, 25)
		Label2.TabIndex = 15
		Label2.Text = "CHANGE"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label3.Location = New Point(31, 328)
		Label3.Name = "Label3"
		Label3.Size = New Size(88, 25)
		Label3.TabIndex = 16
		Label3.Text = "Subtotal"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label4.Location = New Point(35, 365)
		Label4.Name = "Label4"
		Label4.Size = New Size(47, 25)
		Label4.TabIndex = 17
		Label4.Text = "VAT"
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label5.Location = New Point(35, 407)
		Label5.Name = "Label5"
		Label5.Size = New Size(91, 25)
		Label5.TabIndex = 18
		Label5.Text = "Discount"
		' 
		' receipt
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(615, 667)
		Controls.Add(Label5)
		Controls.Add(Label4)
		Controls.Add(Label3)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Controls.Add(Panel1)
		Controls.Add(btnClose)
		Controls.Add(lblChange)
		Controls.Add(lblTotal)
		Controls.Add(lblDiscount)
		Controls.Add(lblVat)
		Controls.Add(lblSubtotal)
		Controls.Add(lblDate)
		Controls.Add(lblOrderId)
		Controls.Add(dgvReceipt)
		Name = "receipt"
		Text = "receipt"
		CType(dgvReceipt, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents dgvReceipt As DataGridView
	Friend WithEvents lblOrderId As Label
	Friend WithEvents lblDate As Label
	Friend WithEvents lblSubtotal As Label
	Friend WithEvents lblVat As Label
	Friend WithEvents lblDiscount As Label
	Friend WithEvents lblTotal As Label
	Friend WithEvents lblChange As Label
	Friend WithEvents btnClose As Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
End Class
