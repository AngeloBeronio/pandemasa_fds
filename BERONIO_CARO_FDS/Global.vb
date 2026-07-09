Imports MySql.Data.MySqlClient
Imports System.IO

Module [Global]
    Public conn As MySqlConnection
    Public connStr As String = "Server=localhost;Database=pan_de_masa_db;Uid=root;Pwd=;"
    Public LoggedInUserId As Integer
    Public CartItems As New List(Of CartItem)
    Public EmployeeID As Integer
    Public EmployeeName As String
    Public RoleID As Integer

    ' CONNECTION
    Public Sub OpenConnection()
        conn = New MySqlConnection(connStr)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Public Sub CloseConnection()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    ' DATE
    Public Function GetGreeting() As String
        Dim hour As Integer = DateTime.Now.Hour
        Dim greeting As String

        If hour >= 5 AndAlso hour < 12 Then
            greeting = "Good Morning"
        ElseIf hour >= 12 AndAlso hour < 18 Then
            greeting = "Good Afternoon"
        Else
            greeting = "Good Evening"
        End If

        Return greeting
    End Function

    ' DEFAULT MENU
    Public Sub SetupMenuGrid(dgv As DataGridView)
        dgv.Columns.Clear()
        dgv.RowTemplate.Height = 110
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.RowHeadersVisible = False

        dgv.Columns.Add("colProductId", "ID")
        dgv.Columns.Add("colName", "Product")
        dgv.Columns.Add("colPrice", "Price")
        dgv.Columns.Add("colStatus", "Status")
        dgv.Columns.Add("colImagePath", "ImagePath")

        dgv.Columns("colProductId").Visible = False
        dgv.Columns("colImagePath").Visible = False
        dgv.Columns("colName").Width = 300
        dgv.Columns("colPrice").Width = 120
        dgv.Columns("colStatus").Width = 150
        dgv.Columns("colName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Public Sub LoadProductImage(pictureBox As PictureBox, imgPath As String)
        If pictureBox.Image IsNot Nothing Then
            Dim oldImage As Image = pictureBox.Image
            pictureBox.Image = Nothing
            oldImage.Dispose()
        End If

        Dim fullPath As String = Path.Combine(Application.StartupPath, imgPath)

        If imgPath <> "" AndAlso File.Exists(fullPath) Then
            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read)
                pictureBox.Image = Image.FromStream(fs)
            End Using
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom
        Else
            pictureBox.Image = Nothing
        End If
    End Sub

    ' ADD ITEMS TO CART
    Public Sub AddToCart(productId As Integer, productName As String,
                         price As Decimal, qty As Integer)
        Dim existing As CartItem = CartItems.FirstOrDefault(
            Function(c) c.ProductId = productId)

        If existing IsNot Nothing Then
            existing.Quantity += qty
            existing.Total = existing.Quantity * existing.UnitPrice
        Else
            CartItems.Add(New CartItem With {
                .ProductId = productId,
                .ProductName = productName,
                .Quantity = qty,
                .UnitPrice = price,
                .Total = price * qty
            })
        End If
        MessageBox.Show(qty & "x " & productName & " added to cart",
                        "Added to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Class CartItem
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property Quantity As Integer
        Public Property UnitPrice As Decimal
        Public Property Total As Decimal
    End Class
End Module