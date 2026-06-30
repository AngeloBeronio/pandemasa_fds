Imports MySql.Data.MySqlClient

Public Class Admin_Homevb

    Private Sub Admin_Homevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MonthCalendar1.MaxSelectionCount = 1
        MonthCalendar1.SetDate(DateTime.Today)
        LoadDashboard(DateTime.Today)
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        LoadDashboard(MonthCalendar1.SelectionStart.Date)
    End Sub

    Private Sub LoadDashboard(selectedDate As Date)
        LoadStatusCounts()
        LoadRevenueAndProfit(selectedDate)
        LoadOrderCount(selectedDate)
        LoadTopSelling(selectedDate)
    End Sub

    Private Sub LoadStatusCounts()
        Try
            OpenConnection()
            Dim cmd As New MySqlCommand("SELECT status, COUNT(*) AS cnt FROM products GROUP BY status", conn)

            Dim unavailable As Integer = 0, lowStock As Integer = 0, available As Integer = 0

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Select Case reader("status").ToString()
                        Case "Unavailable" : unavailable = Convert.ToInt32(reader("cnt"))
                        Case "Low in Stock" : lowStock = Convert.ToInt32(reader("cnt"))
                        Case "Available" : available = Convert.ToInt32(reader("cnt"))
                    End Select
                End While
            End Using

            Label1.Text = unavailable.ToString()
            Label2.Text = lowStock.ToString()
            Label3.Text = available.ToString()
        Catch ex As Exception
            MessageBox.Show($"Error loading status counts: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub LoadRevenueAndProfit(selectedDate As Date)
        Try
            OpenConnection()
            Dim dateStr As String = selectedDate.ToString("yyyy-MM-dd")

            Dim grossCmd As New MySqlCommand("SELECT COALESCE(SUM(total_amount), 0) FROM orders WHERE DATE(created_at) = @d", conn)
            grossCmd.Parameters.AddWithValue("@d", dateStr)
            Dim gross As Decimal = Convert.ToDecimal(grossCmd.ExecuteScalar())

            Dim profitCmd As New MySqlCommand("
                SELECT COALESCE(SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity), 0)
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id
                WHERE DATE(o.created_at) = @d", conn)
            profitCmd.Parameters.AddWithValue("@d", dateStr)
            Dim profit As Decimal = Convert.ToDecimal(profitCmd.ExecuteScalar())

            Label4.Text = $"₱{gross:N2}"
            Label5.Text = $"₱{profit:N2}"
        Catch ex As Exception
            MessageBox.Show($"Error loading financial stats: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub LoadOrderCount(selectedDate As Date)
        Try
            OpenConnection()
            Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM orders WHERE DATE(created_at) = @d", conn)
            cmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))
            Label6.Text = cmd.ExecuteScalar().ToString()
        Catch ex As Exception
            MessageBox.Show($"Error loading order count: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub LoadTopSelling(selectedDate As Date)
        Try
            OpenConnection()

            DataGridView1.Columns.Clear()
            DataGridView1.RowHeadersVisible = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.ReadOnly = True
            DataGridView1.Columns.Add("colProduct", "Top-selling")
            DataGridView1.Columns.Add("colRevenue", "Revenue")
            DataGridView1.Columns("colProduct").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            Dim cmd As New MySqlCommand("
                SELECT p.product_name, SUM(oi.quantity * oi.price_at_sale) AS total_revenue
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id
                WHERE DATE(o.created_at) = @d
                GROUP BY p.product_id, p.product_name
                ORDER BY SUM(oi.quantity) DESC LIMIT 9", conn)
            cmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    DataGridView1.Rows.Add(reader("product_name").ToString(), $"₱{Convert.ToDecimal(reader("total_revenue")):N2}")
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading top sellers: {ex.Message}")
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input As String = InputBox("Enter new low stock threshold:", "Set Threshold", "10")
        Dim newThreshold As Integer

        If Integer.TryParse(input, newThreshold) AndAlso newThreshold >= 0 Then
            Try
                OpenConnection()

                Dim updateThreshold As New MySqlCommand("UPDATE products SET low_stock_threshold = @threshold", conn)
                updateThreshold.Parameters.AddWithValue("@threshold", newThreshold)
                updateThreshold.ExecuteNonQuery()

                Dim updateStatus As New MySqlCommand("
                    UPDATE products SET status = CASE
                        WHEN stock_quantity <= 0 THEN 'Unavailable'
                        WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock'
                        ELSE 'Available'
                    END", conn)
                updateStatus.ExecuteNonQuery()

                MessageBox.Show("Threshold updated and stock states recalculated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDashboard(MonthCalendar1.SelectionStart.Date)
            Catch ex As Exception
                MessageBox.Show($"Error saving threshold: {ex.Message}")
            Finally
                CloseConnection()
            End Try
        ElseIf input <> "" Then
            MessageBox.Show("Please enter a valid positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim selectedDate As Date = MonthCalendar1.SelectionStart.Date

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV Files (*.csv)|*.csv"
            sfd.FileName = $"Sales_Report_{selectedDate:yyyy-MM-dd}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    OpenConnection()

                    Dim cmd As New MySqlCommand("
                        SELECT p.product_name, SUM(oi.quantity) AS total_qty,
                               SUM(oi.quantity * oi.price_at_sale) AS total_revenue,
                               SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity) AS total_profit
                        FROM order_items oi
                        INNER JOIN orders o ON oi.order_id = o.order_id
                        INNER JOIN products p ON oi.product_id = p.product_id
                        WHERE DATE(o.created_at) = @d
                        GROUP BY p.product_id, p.product_name
                        ORDER BY total_qty DESC", conn)
                    cmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"))

                    Using reader As MySqlDataReader = cmd.ExecuteReader(),
                          writer As New IO.StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)

                        writer.WriteLine($"Sales Report - {selectedDate:MMMM d, yyyy}")
                        writer.WriteLine("Product,Quantity Sold,Revenue,Profit")

                        While reader.Read()
                            writer.WriteLine($"{reader("product_name")},{reader("total_qty")},{reader("total_revenue")},{reader("total_profit")}")
                        End While
                    End Using

                    MessageBox.Show("Report exported smoothly!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error exporting file: {ex.Message}")
                Finally
                    CloseConnection()
                End Try
            End If
        End Using
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide() : Admin_Inv.Show()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide() : Admin_OrdLogs.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide() : Admin_InvLogs.Show()
    End Sub
End Class