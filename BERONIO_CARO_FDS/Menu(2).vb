Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Menu_2_

	Private selectedProductId As Integer = -1
	Private selectedProductName As String = ""
	Private selectedPrice As Decimal = 0

	' FORM LOAD
	Private Sub Menu__1__Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetupMenuGrid(itemMenu)
		LoadHouseSpecials()
		Label1.Text = GetGreeting()
		Label2.Text = DateTime.Now.ToString("hh:mm tt")
		Timer1.Interval = 1000
		Timer1.Start()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Hide()
		Menu__1_.Show()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Me.Hide()
		Menu_3_.Show()
	End Sub
	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Hide()
		Menu_4_.Show()
	End Sub
	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Me.Hide()
		Menu_5_.Show()
	End Sub
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		If CartItems.Count = 0 Then
			MessageBox.Show("Your cart is empty. Please add items first.",
						"Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return
		End If
		Me.Hide()
		Cart.Show()
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Label2.Text = DateTime.Now.ToString("hh:mm tt")
		Label1.Text = GetGreeting()
	End Sub

	' LOAD GRIDVIEW WITH PRODUCTS FROM DATABASE
	Private Sub LoadHouseSpecials()
		itemMenu.Rows.Clear()

		Try
			OpenConnection()
			Dim query As String =
			"SELECT p.product_id, p.product_name, p.selling_price, p.status, p.image_path
             FROM products p
             INNER JOIN categories c ON p.category_id = c.category_id
             WHERE c.category_name = 'Soft Bread'
             ORDER BY p.selling_price ASC"

			Dim cmd As New MySqlCommand(query, conn)
			Dim reader As MySqlDataReader = cmd.ExecuteReader()

			While reader.Read()
				Dim imgPath As String = If(IsDBNull(reader("image_path")), "", reader("image_path"))

				itemMenu.Rows.Add(
				reader("product_id"),
				reader("product_name"),
				"₱" & CDec(reader("selling_price")).ToString("0.00"),
				reader("status"),
				imgPath
			)

				If reader("status").ToString() = "Unavailable" Then
					itemMenu.Rows(itemMenu.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Gray
					itemMenu.Rows(itemMenu.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
				End If

				If reader("status").ToString() = "Low in Stock" Then
					itemMenu.Rows(itemMenu.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkOrange
				End If
			End While

			reader.Close()

			' Auto select on load
			For i As Integer = 0 To itemMenu.Rows.Count - 1
				reader.Close()
				If itemMenu.Rows.Count > 0 Then
					itemMenu.Rows(0).Selected = True
					itemMenu.CurrentCell = itemMenu.Rows(0).Cells("colName")

					selectedProductId = CInt(itemMenu.Rows(0).Cells("colProductId").Value)
					selectedProductName = itemMenu.Rows(0).Cells("colName").Value.ToString()
					selectedPrice = CDec(itemMenu.Rows(0).Cells("colPrice").Value.ToString().Replace("₱", ""))
					LoadProductImage(PictureBox1, itemMenu.Rows(0).Cells("colImagePath").Value.ToString())
					NumericUpDown1.Value = 1
				End If
			Next

		Catch ex As Exception
			MessageBox.Show("Error loading menu: " & ex.Message, "Database Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			CloseConnection()
		End Try
	End Sub

	' ROW CLICK — SHOW IMAGE + SELECT PRODUCT
	Private Sub itemMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles itemMenu.CellClick
		If e.RowIndex < 0 Then Return

		Dim row As DataGridViewRow = itemMenu.Rows(e.RowIndex)

		If row.Cells("colStatus").Value.ToString() = "Unavailable" Then
			MessageBox.Show("This product is currently unavailable.", "Unavailable",
						MessageBoxButtons.OK, MessageBoxIcon.Warning)
			selectedProductId = -1
			Return
		End If

		selectedProductId = CInt(row.Cells("colProductId").Value)
		selectedProductName = row.Cells("colName").Value.ToString()
		selectedPrice = CDec(row.Cells("colPrice").Value.ToString().Replace("₱", ""))

		Dim imgPath As String = row.Cells("colImagePath").Value.ToString()
		Dim fullPath As String = Path.Combine(Application.StartupPath, imgPath)

		LoadProductImage(PictureBox1, imgPath)
		NumericUpDown1.Value = 1
	End Sub

	' ADD TO CART
	Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles Button5.Click
		If selectedProductId = -1 Then
			MessageBox.Show("Please select a product from the menu first.",
							"No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return
		End If

		AddToCart(selectedProductId, selectedProductName, selectedPrice, NumericUpDown1.Value)
		NumericUpDown1.Value = 1
	End Sub

	' DISPOSE IMAGE ON CLOSE TO PREVENT CRASHING
	Private Sub Menu__1__FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		If PictureBox1.Image IsNot Nothing Then
			PictureBox1.Image.Dispose()
			PictureBox1.Image = Nothing
		End If
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Me.Hide()
		Start.Show()
	End Sub
End Class