Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Admin_GrossProfit

    Private Sub Admin_GrossProfit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupProfitGrid()
        PopulateMonthsDropdown()

        RadioButton1.Checked = True
        MonthCalendar1.SetDate(DateTime.Today)
        UpdateUIState()
        LoadProfitData()
    End Sub

    Private Sub SetupProfitGrid()
        With DataGridView1
            .Columns.Clear()
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .RowHeadersVisible = False

            .Columns.Add("colProduct", "Product")
            .Columns.Add("colCost", "Cost Price")
            .Columns.Add("colProfit", "Gross Profit")

            .Columns("colProduct").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    Private Sub PopulateMonthsDropdown()
        Dim dt As New DataTable()
        dt.Columns.Add("MonthValue", GetType(String))
        dt.Columns.Add("MonthDisplay", GetType(String))

        For i As Integer = 0 To 11
            Dim d As DateTime = New DateTime(DateTime.Today.Year, 1, 1).AddMonths(i)
            dt.Rows.Add(d.ToString("yyyy-MM"), d.ToString("MMMM yyyy"))
        Next

        ComboBox1.DataSource = dt
        ComboBox1.ValueMember = "MonthValue"
        ComboBox1.DisplayMember = "MonthDisplay"
        ComboBox1.SelectedValue = DateTime.Today.ToString("yyyy-MM")
    End Sub

    Private Sub UpdateUIState()
        MonthCalendar1.Enabled = RadioButton1.Checked
        ComboBox1.Enabled = RadioButton2.Checked
    End Sub

    Private Sub LoadProfitData()
        Try
            OpenConnection()
            DataGridView1.Rows.Clear()
            Label2.Text = "₱0.00"

            Dim query As String = "
                SELECT p.product_name, p.estimated_cost,
                       SUM((oi.net_price_sale - p.estimated_cost) * oi.quantity) AS total_profit
                FROM order_items oi
                INNER JOIN orders o ON oi.order_id = o.order_id
                INNER JOIN products p ON oi.product_id = p.product_id"

            If RadioButton1.Checked Then
                query &= " WHERE DATE(o.order_date) = @date"
            Else
                query &= " WHERE DATE_FORMAT(o.order_date, '%Y-%m') = @month"
            End If

            query &= " GROUP BY p.product_id, p.product_name ORDER BY total_profit DESC"

            Dim cmd As New MySqlCommand(query, conn)

            If RadioButton1.Checked Then
                cmd.Parameters.AddWithValue("@date", MonthCalendar1.SelectionStart.ToString("yyyy-MM-dd"))
            Else
                cmd.Parameters.AddWithValue("@month", ComboBox1.SelectedValue.ToString())
            End If

            Dim totalGrossProfit As Decimal = 0

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim profit As Decimal = Convert.ToDecimal(reader("total_profit"))
                    totalGrossProfit += profit

                    DataGridView1.Rows.Add(
                        reader("product_name").ToString(),
                        $"₱{Convert.ToDecimal(reader("estimated_cost")):N2}",
                        $"₱{profit:N2}"
                    )
                End While
            End Using

            Label2.Text = $"₱{totalGrossProfit:N2}"

        Catch ex As Exception
            MessageBox.Show($"Error loading profit metrics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        UpdateUIState()
        LoadProfitData()
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        If RadioButton1.Checked Then LoadProfitData()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If RadioButton2.Checked AndAlso ComboBox1.SelectedValue IsNot Nothing Then LoadProfitData()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide() : Admin_Homevb.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide() : Admin_Inv.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide() : Admin_OrdLogs.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide() : Admin_InvLogs.Show()
    End Sub

    'Testing testing
End Class