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

    ' ---------- LABEL1/2/3: STOCK STATUS COUNTS ----------
    Private Sub LoadStatusCounts()
        Try
            OpenConnection()
            Dim query As String = "SELECT status, COUNT(*) AS cnt FROM products GROUP BY status"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            Dim unavailable As Integer = 0
            Dim lowStock As Integer = 0
            Dim available As Integer = 0

            While reader.Read()
                Select Case reader("status").ToString()
                    Case "Unavailable"
                        unavailable = Convert.ToInt32(reader("cnt"))
                    Case "Low in Stock"
                        lowStock = Convert.ToInt32(reader("cnt"))
                    Case "Available"
                        available = Convert.ToInt32(reader("cnt"))
                End Select
            End While
            reader.Close()

            Label1.Text = unavailable.ToString()
            Label2.Text = lowStock.ToString()
            Label3.Text = available.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading status counts: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- LABEL4/5: GROSS REVENUE + PROFIT FOR THE DAY ----------
    Private Sub LoadRevenueAndProfit(selectedDate As Date)
        Try
            OpenConnection()

            ' Gross revenue for the selected day
            Dim revQuery As String = "SELECT COALESCE(SUM(total_amount), 0) AS gross FROM orders WHERE DATE(created_at) = @selDate"
            Dim revCmd As New MySqlCommand(revQuery, conn)
            revCmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
            Dim gross As Decimal = Convert.ToDecimal(revCmd.ExecuteScalar())
            Label4.Text = "₱" & gross.ToString("N2")

            ' Profit for the selected day = SUM((price_at_sale - estimated_cost) * quantity)
            Dim profitQuery As String = "
                SELECT COALESCE(SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity), 0) AS profit
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id
                WHERE DATE(o.created_at) = @selDate"
            Dim profitCmd As New MySqlCommand(profitQuery, conn)
            profitCmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
            Dim profit As Decimal = Convert.ToDecimal(profitCmd.ExecuteScalar())
            Label5.Text = "₱" & profit.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error loading revenue/profit: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- LABEL6: NUMBER OF ORDERS ----------
    Private Sub LoadOrderCount(selectedDate As Date)
        Try
            OpenConnection()
            Dim query As String = "SELECT COUNT(*) FROM orders WHERE DATE(created_at) = @selDate"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Label6.Text = count.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading order count: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- DATAGRIDVIEW1: TOP-SELLING PRODUCTS + REVENUE ----------
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

            Dim query As String = "
                SELECT p.product_name,
                       SUM(oi.quantity) AS total_qty,
                       SUM(oi.quantity * oi.price_at_sale) AS total_revenue
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id
                WHERE DATE(o.created_at) = @d
                GROUP BY p.product_id, p.product_name
                ORDER BY total_qty DESC
                LIMIT 9"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim pname As String = reader("product_name").ToString()
                Dim revenue As Decimal = Convert.ToDecimal(reader("total_revenue"))
                DataGridView1.Rows.Add(pname, "₱" & revenue.ToString("N2"))
            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading top-selling products: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ---------- NAVIGATION ----------
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Admin_Inv.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Admin_OrdLogs.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Admin_InvLogs.Show()
    End Sub

    ' ---------- BUTTON1: SET LOW STOCK THRESHOLD ----------
    ' This defines what counts as "Low in Stock" globally. After updating the
    ' threshold value itself, we also re-evaluate every product's `status`
    ' column against it, since the dashboard's Label1/2/3 counts read from
    ' `status`, not from the raw threshold number.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input As String = InputBox("Enter new low stock threshold (applies to all products):", "Set Low Stock Threshold", "10")

        Dim newThreshold As Integer
        If Integer.TryParse(input, newThreshold) AndAlso newThreshold >= 0 Then
            Try
                OpenConnection()

                ' 1. Update the threshold value itself
                Dim updateThresholdQuery As String = "UPDATE products SET low_stock_threshold = @threshold"
                Dim cmd As New MySqlCommand(updateThresholdQuery, conn)
                cmd.Parameters.AddWithValue("@threshold", newThreshold)
                cmd.ExecuteNonQuery()

                ' 2. Recalculate status for every product based on the new threshold
                '    0 stock = Unavailable, <= threshold = Low in Stock, else Available
                Dim updateStatusQuery As String = "
                    UPDATE products
                    SET status = CASE
                        WHEN stock_quantity <= 0 THEN 'Unavailable'
                        WHEN stock_quantity <= low_stock_threshold THEN 'Low in Stock'
                        ELSE 'Available'
                    END"
                Dim statusCmd As New MySqlCommand(updateStatusQuery, conn)
                statusCmd.ExecuteNonQuery()

                MessageBox.Show("Low stock threshold updated and product statuses refreshed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDashboard(MonthCalendar1.SelectionStart.Date)
            Catch ex As Exception
                MessageBox.Show("Error updating threshold: " & ex.Message)
            Finally
                CloseConnection()
            End Try
        ElseIf input <> "" Then
            MessageBox.Show("Please enter a valid non-negative number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' DOOOOOOOOOOOOO NOOOOOOOOOOOOOOOT DEEEEEEEEEEEEELEEEEEEEEEETEEEEEEEE
    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '   Dim currentMinutes As Integer = My.Settings.StockAlertMinutes
    '  Dim input As String = InputBox("Enter time until stock alert (in minutes):", "Set Stock Alert Time", currentMinutes.ToString())

    '   Dim newMinutes As Integer
    '  If Integer.TryParse(input, newMinutes) AndAlso newMinutes > 0 Then
    '     My.Settings.StockAlertMinutes = newMinutes
    '    My.Settings.Save()

    ' Convert minutes to milliseconds for the Timer interval
    '   Timer1.Interval = newMinutes * 60000
    '  Timer1.Stop()
    ' Timer1.Start()

    '      MessageBox.Show("Stock alert time updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ' ElseIf input <> "" Then
    '     MessageBox.Show("Please enter a valid number of minutes.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    'End If
    'End Sub

    ' Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    LoadStatusCounts()
    ' End Sub

    ' ---------- BUTTON4: DOWNLOAD REPORT ----------
    ' Exports a CSV summary (product, qty sold, revenue, profit) for the selected date.
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim selectedDate As Date = MonthCalendar1.SelectionStart.Date

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV Files (*.csv)|*.csv"
            sfd.FileName = "Sales_Report_" & selectedDate.ToString("yyyy-MM-dd") & ".csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    OpenConnection()

                    Dim query As String = "
                        SELECT p.product_name,
                               SUM(oi.quantity) AS total_qty,
                               SUM(oi.quantity * oi.price_at_sale) AS total_revenue,
                               SUM((oi.price_at_sale - p.estimated_cost) * oi.quantity) AS total_profit
                        FROM order_items oi
                        INNER JOIN orders o ON oi.order_id = o.order_id
                        INNER JOIN products p ON oi.product_id = p.product_id
                        WHERE DATE(o.created_at) = @selDate
                        GROUP BY p.product_id, p.product_name
                        ORDER BY total_qty DESC"

                    Dim cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@selDate", selectedDate.ToString("yyyy-MM-dd"))
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    Using writer As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                        writer.WriteLine("Sales Report - " & selectedDate.ToString("MMMM d, yyyy"))
                        writer.WriteLine("Product,Quantity Sold,Revenue,Profit")

                        While reader.Read()
                            Dim pname As String = reader("product_name").ToString()
                            Dim qty As Integer = Convert.ToInt32(reader("total_qty"))
                            Dim revenue As Decimal = Convert.ToDecimal(reader("total_revenue"))
                            Dim profit As Decimal = Convert.ToDecimal(reader("total_profit"))
                            writer.WriteLine($"{pname},{qty},{revenue},{profit}")
                        End While
                    End Using
                    reader.Close()

                    MessageBox.Show("Report saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error generating report: " & ex.Message)
                Finally
                    CloseConnection()
                End Try
            End If
        End Using
    End Sub

End Class