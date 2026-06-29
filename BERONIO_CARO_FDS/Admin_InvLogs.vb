Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Admin_InvLogs
    Private currentPage As Integer = 1
    Private Const pageSize As Integer = 10 ' Items per page

    Private Sub Admin_InvLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupLogsGrid()
        TextBox1.Text = currentPage.ToString()
        LoadLogs()
    End Sub

    ' ---------- GRID SETUP ----------
    Private Sub SetupLogsGrid()
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowHeadersVisible = False

        ' Match the columns from your UI layout screenshot
        DataGridView1.Columns.Add("colLogId", "LOGS ID")
        DataGridView1.Columns.Add("colProductId", "PRODUCT ID")
        DataGridView1.Columns.Add("colUserId", "USER ID")
        DataGridView1.Columns.Add("colQty", "ADJ QUANTITY")
        DataGridView1.Columns.Add("colUnit", "ADJ UNIT")
        DataGridView1.Columns.Add("colDate", "DATE")

        ' Design adjustments
        DataGridView1.Columns("colDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    ' ---------- BACKEND LOAD LOGS DATA ----------
    Private Sub LoadLogs()
        Try
            OpenConnection()
            DataGridView1.Rows.Clear()

            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim searchKeyword As String = TextBox2.Text.Trim()

            ' Base query pulling from inventory_logs schema
            Dim query As String = "
                SELECT log_id, product_id, user_id, adjustment_quantity, adjustment_unit, timestamp 
                FROM inventory_logs"

            ' Dynamically insert filters if searching
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query &= " WHERE product_id LIKE @search OR log_id LIKE @search"
            End If

            query &= " ORDER BY timestamp DESC LIMIT @limit OFFSET @offset"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@limit", pageSize)
            cmd.Parameters.AddWithValue("@offset", offset)

            If Not String.IsNullOrEmpty(searchKeyword) Then
                cmd.Parameters.AddWithValue("@search", "%" & searchKeyword & "%")
            End If

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim rowIndex As Integer = DataGridView1.Rows.Add()
                Dim row As DataGridViewRow = DataGridView1.Rows(rowIndex)

                row.Cells("colLogId").Value = reader("log_id")
                row.Cells("colProductId").Value = reader("product_id")
                row.Cells("colUserId").Value = If(IsDBNull(reader("user_id")), "N/A", reader("user_id"))
                row.Cells("colQty").Value = reader("adjustment_quantity")
                row.Cells("colUnit").Value = reader("adjustment_unit").ToString()
                row.Cells("colDate").Value = Convert.ToDateTime(reader("timestamp")).ToString("yyyy-MM-dd HH:mm:ss")
            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- PAGINATION: PREVIOUS PAGE BUTTON ----------
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 1 Then
            currentPage -= 1
            TextBox1.Text = currentPage.ToString() ' Triggers TextChanged to refresh grid
        End If
    End Sub

    ' ---------- PAGINATION: NEXT PAGE BUTTON ----------
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Increment page and refresh
        currentPage += 1
        TextBox1.Text = currentPage.ToString() ' Triggers TextChanged to refresh grid
    End Sub

    ' ---------- PAGE NUMBER DISPLAY CHANGED ----------
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim targetedPage As Integer
        If Integer.TryParse(TextBox1.Text, targetedPage) AndAlso targetedPage > 0 Then
            currentPage = targetedPage
            LoadLogs()
        End If
    End Sub

    ' ---------- SEARCH FUNCTIONALITY ----------
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ' Whenever the user types inside the search bar, reset page to 1 and query
        currentPage = 1
        TextBox1.Text = "1"
        LoadLogs()
    End Sub

    ' ---------- NAVIGATION ----------
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Admin_Inv.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Admin_Homevb.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Admin_OrdLogs.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Leave empty unless specialized individual logs inspection is required
    End Sub
End Class