Imports MySql.Data.MySqlClient

Public Class SetThreshold
    Private Sub SetThresholdForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            OpenConnection()
            Dim query As String = "SELECT product_id, product_name FROM products ORDER BY product_name ASC"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ComboBox1.Items.Clear()
            While reader.Read()
                ComboBox1.Items.Add(New ProductItem(
                    Convert.ToInt32(reader("product_id")),
                    reader("product_name").ToString()))
            End While

            reader.Close()
            If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selected As ProductItem = TryCast(ComboBox1.SelectedItem, ProductItem)
        If selected Is Nothing Then Exit Sub

        Try
            OpenConnection()
            Dim query As String = "SELECT low_stock_threshold FROM products WHERE product_id = @id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", selected.Id)
            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                NumericUpDown1.Value = Convert.ToDecimal(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading threshold: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selected As ProductItem = TryCast(ComboBox1.SelectedItem, ProductItem)
        If selected Is Nothing Then
            MessageBox.Show("Please select a product.", "No Product Selected",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim newThreshold As Integer = Convert.ToInt32(NumericUpDown1.Value)

        Try
            OpenConnection()

            Dim updateThreshold As String =
                "UPDATE products SET low_stock_threshold = @threshold WHERE product_id = @id"
            Dim cmd1 As New MySqlCommand(updateThreshold, conn)
            cmd1.Parameters.AddWithValue("@threshold", newThreshold)
            cmd1.Parameters.AddWithValue("@id", selected.Id)
            cmd1.ExecuteNonQuery()

            Dim updateStatus As String =
                "UPDATE products SET status = CASE " &
                "WHEN stock_quantity <= 0 THEN 'Unavailable' " &
                "WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock' " &
                "ELSE 'Available' " &
                "END WHERE product_id = @id"
            Dim cmd2 As New MySqlCommand(updateStatus, conn)
            cmd2.Parameters.AddWithValue("@id", selected.Id)
            cmd2.ExecuteNonQuery()

            MessageBox.Show("Threshold updated for " & selected.Name & "!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving threshold: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class

Public Class ProductItem
    Public Property Id As Integer
    Public Property Name As String
    Public Sub New(id As Integer, name As String)
        Me.Id = id
        Me.Name = name
    End Sub
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class