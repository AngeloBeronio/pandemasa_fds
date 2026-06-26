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
		dgvReceipt = New DataGridView()
		lblOrderId = New Label()
		lblDate = New Label()
		lblSubtotal = New Label()
		lblVat = New Label()
		lblDiscountType = New Label()
		lblDiscount = New Label()
		lblTotal = New Label()
		lblCash = New Label()
		lblChange = New Label()
		btnPrint = New Button()
		btnNewTransaction = New Button()
		btnClose = New Button()
		CType(dgvReceipt, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' dgvReceipt
		' 
		dgvReceipt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgvReceipt.Location = New Point(24, 46)
		dgvReceipt.Name = "dgvReceipt"
		dgvReceipt.Size = New Size(270, 237)
		dgvReceipt.TabIndex = 0
		' 
		' lblOrderId
		' 
		lblOrderId.AutoSize = True
		lblOrderId.Location = New Point(38, 314)
		lblOrderId.Name = "lblOrderId"
		lblOrderId.Size = New Size(41, 15)
		lblOrderId.TabIndex = 1
		lblOrderId.Text = "Label1"
		' 
		' lblDate
		' 
		lblDate.AutoSize = True
		lblDate.Location = New Point(38, 349)
		lblDate.Name = "lblDate"
		lblDate.Size = New Size(41, 15)
		lblDate.TabIndex = 2
		lblDate.Text = "Label1"
		' 
		' lblSubtotal
		' 
		lblSubtotal.AutoSize = True
		lblSubtotal.Location = New Point(38, 394)
		lblSubtotal.Name = "lblSubtotal"
		lblSubtotal.Size = New Size(41, 15)
		lblSubtotal.TabIndex = 3
		lblSubtotal.Text = "Label1"
		' 
		' lblVat
		' 
		lblVat.AutoSize = True
		lblVat.Location = New Point(156, 314)
		lblVat.Name = "lblVat"
		lblVat.Size = New Size(41, 15)
		lblVat.TabIndex = 4
		lblVat.Text = "Label1"
		' 
		' lblDiscountType
		' 
		lblDiscountType.AutoSize = True
		lblDiscountType.Location = New Point(156, 349)
		lblDiscountType.Name = "lblDiscountType"
		lblDiscountType.Size = New Size(41, 15)
		lblDiscountType.TabIndex = 5
		lblDiscountType.Text = "Label1"
		' 
		' lblDiscount
		' 
		lblDiscount.AutoSize = True
		lblDiscount.Location = New Point(156, 394)
		lblDiscount.Name = "lblDiscount"
		lblDiscount.Size = New Size(41, 15)
		lblDiscount.TabIndex = 6
		lblDiscount.Text = "Label1"
		' 
		' lblTotal
		' 
		lblTotal.AutoSize = True
		lblTotal.Location = New Point(253, 314)
		lblTotal.Name = "lblTotal"
		lblTotal.Size = New Size(41, 15)
		lblTotal.TabIndex = 7
		lblTotal.Text = "Label1"
		' 
		' lblCash
		' 
		lblCash.AutoSize = True
		lblCash.Location = New Point(253, 349)
		lblCash.Name = "lblCash"
		lblCash.Size = New Size(41, 15)
		lblCash.TabIndex = 8
		lblCash.Text = "Label1"
		' 
		' lblChange
		' 
		lblChange.AutoSize = True
		lblChange.Location = New Point(253, 394)
		lblChange.Name = "lblChange"
		lblChange.Size = New Size(61, 15)
		lblChange.TabIndex = 9
		lblChange.Text = "lblChange"
		' 
		' btnPrint
		' 
		btnPrint.Location = New Point(219, 426)
		btnPrint.Name = "btnPrint"
		btnPrint.Size = New Size(75, 23)
		btnPrint.TabIndex = 10
		btnPrint.Text = "Button1"
		btnPrint.UseVisualStyleBackColor = True
		' 
		' btnNewTransaction
		' 
		btnNewTransaction.Location = New Point(138, 426)
		btnNewTransaction.Name = "btnNewTransaction"
		btnNewTransaction.Size = New Size(75, 23)
		btnNewTransaction.TabIndex = 11
		btnNewTransaction.Text = "Button1"
		btnNewTransaction.UseVisualStyleBackColor = True
		' 
		' btnClose
		' 
		btnClose.Location = New Point(57, 426)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(75, 23)
		btnClose.TabIndex = 12
		btnClose.Text = "Button1"
		btnClose.UseVisualStyleBackColor = True
		' 
		' receipt
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(338, 450)
		Controls.Add(btnClose)
		Controls.Add(btnNewTransaction)
		Controls.Add(btnPrint)
		Controls.Add(lblChange)
		Controls.Add(lblCash)
		Controls.Add(lblTotal)
		Controls.Add(lblDiscount)
		Controls.Add(lblDiscountType)
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
	Friend WithEvents lblDiscountType As Label
	Friend WithEvents lblDiscount As Label
	Friend WithEvents lblTotal As Label
	Friend WithEvents lblCash As Label
	Friend WithEvents lblChange As Label
	Friend WithEvents btnPrint As Button
	Friend WithEvents btnNewTransaction As Button
	Friend WithEvents btnClose As Button
End Class
