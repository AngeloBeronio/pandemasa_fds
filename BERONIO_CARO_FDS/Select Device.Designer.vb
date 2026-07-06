<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Select_Device
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Select_Device))
		btnAdmin1 = New Button()
		btnAdmin2 = New Button()
		btnCashier1 = New Button()
		btnCashier2 = New Button()
		btnCashier3 = New Button()
		SuspendLayout()
		' 
		' btnAdmin1
		' 
		btnAdmin1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnAdmin1.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnAdmin1.ForeColor = Color.White
		btnAdmin1.Location = New Point(184, 257)
		btnAdmin1.Name = "btnAdmin1"
		btnAdmin1.Size = New Size(166, 156)
		btnAdmin1.TabIndex = 0
		btnAdmin1.Text = "1"
		btnAdmin1.UseVisualStyleBackColor = False
		' 
		' btnAdmin2
		' 
		btnAdmin2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnAdmin2.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnAdmin2.ForeColor = Color.White
		btnAdmin2.Location = New Point(541, 257)
		btnAdmin2.Name = "btnAdmin2"
		btnAdmin2.Size = New Size(166, 156)
		btnAdmin2.TabIndex = 1
		btnAdmin2.Text = "2"
		btnAdmin2.UseVisualStyleBackColor = False
		' 
		' btnCashier1
		' 
		btnCashier1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnCashier1.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnCashier1.ForeColor = Color.White
		btnCashier1.Location = New Point(184, 809)
		btnCashier1.Name = "btnCashier1"
		btnCashier1.Size = New Size(166, 156)
		btnCashier1.TabIndex = 3
		btnCashier1.Text = "1"
		btnCashier1.UseVisualStyleBackColor = False
		' 
		' btnCashier2
		' 
		btnCashier2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnCashier2.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnCashier2.ForeColor = Color.White
		btnCashier2.Location = New Point(541, 809)
		btnCashier2.Name = "btnCashier2"
		btnCashier2.Size = New Size(166, 156)
		btnCashier2.TabIndex = 4
		btnCashier2.Text = "2"
		btnCashier2.UseVisualStyleBackColor = False
		' 
		' btnCashier3
		' 
		btnCashier3.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnCashier3.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnCashier3.ForeColor = Color.White
		btnCashier3.Location = New Point(912, 809)
		btnCashier3.Name = "btnCashier3"
		btnCashier3.Size = New Size(166, 156)
		btnCashier3.TabIndex = 5
		btnCashier3.Text = "3"
		btnCashier3.UseVisualStyleBackColor = False
		' 
		' Select_Device
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
		ClientSize = New Size(1904, 1041)
		Controls.Add(btnCashier3)
		Controls.Add(btnCashier2)
		Controls.Add(btnCashier1)
		Controls.Add(btnAdmin2)
		Controls.Add(btnAdmin1)
		Name = "Select_Device"
		Text = "Select_Device"
		ResumeLayout(False)
	End Sub

	Friend WithEvents btnAdmin1 As Button
	Friend WithEvents btnAdmin2 As Button
	Friend WithEvents btnCashier1 As Button
	Friend WithEvents btnCashier2 As Button
	Friend WithEvents btnCashier3 As Button
End Class
