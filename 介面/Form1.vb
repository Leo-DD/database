Imports MySql.Data.MySqlClient
Imports System.Data.Entity
Imports Mysqlx.XDevAPI.Relational
Imports System.Data.SqlClient
Imports Mysqlx.Crud
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Form1
    Dim rand As New Random()
    Dim connect As New MySqlConnection()
    Dim COMMAND As New MySqlCommand()
    Dim ConnString As String = "server = localhost;User = root;database = store"
    Public orderId As Integer = rand.Next(1, 10000)
    Private db As storeEntities4

    Dim mycmd As New MySqlCommand
    Dim myconnection As New DTConnection
    Dim dadapter As MySqlDataAdapter
    Dim dtable As New DataTable
    Dim objdatareader As MySqlDataReader

    Dim savedPath As String ' Declare a global variable
    Dim xAxisData As Object ' Global variable
    Dim yAxisData As Object ' Global variable
#Region "Form1Loading"
    Private currentTabPageIndex As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(-7, 0)
        Me.Icon = My.Resources.ICON
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.Size = New Size(1552, 832)
        TabControl1.Size = New Size(1536, 793)
        TabControl1.SelectedIndex = 0
        currentTabPageIndex = TabControl1.SelectedIndex
        'tabpage3_T_password.PasswordChar = "*"c
        For i As Integer = 1 To 14
            Dim pictureBoxName As String = "tabpage" & i.ToString() & "_P_background"
            Dim pictureBox As PictureBox = CType(Me.Controls.Find(pictureBoxName, True).FirstOrDefault(), PictureBox)
            If pictureBox IsNot Nothing Then
                pictureBox.SendToBack()
                pictureBox.Size = New Size(Me.ClientSize.Width, Me.ClientSize.Height)
            End If
        Next

        Try

            TabControl1.Appearance = TabAppearance.Buttons
            TabControl1.ItemSize = New Size(0, 1)
            TabControl1.SizeMode = TabSizeMode.Fixed

        Catch ex As Exception

        End Try

        Timer1.Start()
        Getconnect()

        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM menu"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage5_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
    End Sub


    Public Sub Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            connect.Close()
        End If

        connect = New MySqlConnection(ConnString)

        Try
            connect.Open()
        Catch ex As Exception
            MsgBox("MYSQL資料庫連線失敗: " & ex.Message)
        End Try
    End Sub


#End Region
#Region "Form1Resize"
    Private Sub Form1_resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        Centertabpage1()
        Centertabpage2()
        Centertabpage3()
        Centertabpage4()
        Centertabpage5()
        Centertabpage6()
        Centertabpage7()
        Centertabpage8()
        Centertabpage9()
        Centertabpage10()
        Centertabpage11()
        Centertabpage12()
        Centertabpage13()
        Centertabpage14()

    End Sub
#End Region
#Region "進入畫面"
#Region "頁面page1設計"
    Private Sub Centertabpage1()

        tabpage1_P_background.Image = My.Resources.主畫面1
        Dim x As Integer = (Me.ClientSize.Width - tabpage1_B_login.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height - tabpage1_B_login.Height) / 2
        tabpage1_B_register.Location = New Point(x, y)
        tabpage1_B_login.Location = New Point(x - 200, y)
        tabpage1_B_leave.Location = New Point(x + 200, y)
        tabpage1_L_name.Location = New Point(x - 250, y - 200)
        tabpage1_L_timer.Location = New Point(Me.Width - 350, 10)

        tabpage1_B_register.Parent = tabpage1_P_background
        tabpage1_B_login.Parent = tabpage1_P_background
        tabpage1_B_leave.Parent = tabpage1_P_background
        tabpage1_L_name.Parent = tabpage1_P_background
        tabpage1_L_timer.Parent = tabpage1_P_background

    End Sub
#End Region
    Private Sub tabpage1_B_leave_Click(sender As Object, e As EventArgs) Handles tabpage1_B_leave.Click
        Me.Close()
        Timer1.Stop()
    End Sub

    Private Sub tabpage1_B_register_Click(sender As Object, e As EventArgs) Handles tabpage1_B_register.Click
        TabControl1.SelectedIndex = 1
    End Sub
    Private Sub tabpage1_B_login_Click(sender As Object, e As EventArgs) Handles tabpage1_B_login.Click
        TabControl1.SelectedIndex = 2
    End Sub
#End Region
#Region "註冊"
#Region "頁面page2設計"
    Private Sub Centertabpage2()

        tabpage2_P_background.Image = My.Resources.主畫面1
        tabpage2_B_return.Image = My.Resources.home鍵
        tabpage2_B_check.Image = My.Resources.黃橙

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage2_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage2_B_check.Location = New Point(x + 350, y + 300)
        tabpage2_B_return.Location = New Point(x + 550, y + 300)
        tabpage2_L_name.Location = New Point(x - 500, y - 250)
        tabpage2_T_name.Location = New Point(x - 490, y - 170)
        tabpage2_L_phone.Location = New Point(x - 500, y - 90)
        tabpage2_T_phone.Location = New Point(x - 490, y - 10)
        tabpage2_L_gmail.Location = New Point(x, y - 90)
        tabpage2_T_gmail.Location = New Point(x + 10, y - 10)
        tabpage2_L_birth.Location = New Point(x, y - 250)
        tabpage2_C_year.Location = New Point(x + 10, y - 170)
        tabpage2_L_year.Location = New Point(x + 170, y - 178)
        tabpage2_C_month.Location = New Point(x + 240, y - 170)
        tabpage2_L_month.Location = New Point(x + 340, y - 178)
        tabpage2_C_day.Location = New Point(x + 400, y - 170)
        tabpage2_L_day.Location = New Point(x + 500, y - 178)
        tabpage2_L_password.Location = New Point(x - 500, y + 70)
        tabpage2_T_password.Location = New Point(x - 490, y + 150)

        tabpage2_L_timer.Parent = tabpage2_P_background
        tabpage2_B_check.Parent = tabpage2_P_background
        tabpage2_B_return.Parent = tabpage2_P_background
        tabpage2_L_birth.Parent = tabpage2_P_background
        tabpage2_L_day.Parent = tabpage2_P_background
        tabpage2_L_gmail.Parent = tabpage2_P_background
        tabpage2_L_month.Parent = tabpage2_P_background
        tabpage2_L_name.Parent = tabpage2_P_background
        tabpage2_L_phone.Parent = tabpage2_P_background
        tabpage2_L_year.Parent = tabpage2_P_background
        tabpage2_L_password.Parent = tabpage2_P_background

    End Sub
#End Region
    Private Sub tabpage2_B_return_Click(sender As Object, e As EventArgs) Handles tabpage2_B_return.Click
        TabControl1.SelectedIndex = currentTabPageIndex
        tabpage2_T_name.Text = ""
        tabpage2_T_phone.Text = ""
        tabpage2_T_gmail.Text = ""
        tabpage2_C_year.Text = ""
        tabpage2_C_month.Text = ""
        tabpage2_C_day.Text = ""
        tabpage2_T_password.Text = ""
    End Sub
    Private Sub tabpage2_B_check_Click(sender As Object, e As EventArgs) Handles tabpage2_B_check.Click
        connect = New MySqlConnection
        connect.ConnectionString = "server = localhost ; user = root ; database = store "
        Try
            '檢查所有TEXTBOX是否有值
            If String.IsNullOrEmpty(tabpage2_T_name.Text) OrElse
                String.IsNullOrEmpty(tabpage2_T_phone.Text) OrElse
                String.IsNullOrEmpty(tabpage2_T_gmail.Text) OrElse
                String.IsNullOrEmpty(tabpage2_C_year.Text) OrElse
                String.IsNullOrEmpty(tabpage2_C_month.Text) OrElse
                String.IsNullOrEmpty(tabpage2_C_day.Text) OrElse
                String.IsNullOrEmpty(tabpage2_T_password.Text) Then
                MessageBox.Show("所有欄位都是必填的。")
                Return
            End If
            connect.Open()
            Dim checkQuery As String = "SELECT COUNT(*) FROM member WHERE member_phone = @Phone and member_password = @password" '檢查是否有重複的電話
            Dim checkCommand As New MySqlCommand(checkQuery, connect)
            checkCommand.Parameters.AddWithValue("@Phone", tabpage2_T_phone.Text)
            checkCommand.Parameters.AddWithValue("@password", tabpage2_T_password.Text)
            Dim count As Integer = Convert.ToInt32(checkCommand.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("該電話或密碼已被註冊")
            Else
                Dim Query As String
                Query = "insert into store.member(member_name,member_phone,member_email,member_birthday,member_password) VALUES (@Name, @Phone, @Gmail, @Birthday, @password)"
                COMMAND = New MySqlCommand(Query, connect)
                COMMAND.Parameters.AddWithValue("@Name", tabpage2_T_name.Text)
                COMMAND.Parameters.AddWithValue("@Phone", tabpage2_T_phone.Text)
                COMMAND.Parameters.AddWithValue("@Gmail", tabpage2_T_gmail.Text)
                COMMAND.Parameters.AddWithValue("@Birthday", tabpage2_C_year.Text + "/" + tabpage2_C_month.Text + "/" + tabpage2_C_day.Text)
                COMMAND.Parameters.AddWithValue("@password", tabpage2_T_password.Text)
                COMMAND.ExecuteNonQuery()
                MessageBox.Show("註冊成功")
                TabControl1.SelectedIndex = 0
                tabpage2_T_name.Text = ""
                tabpage2_T_phone.Text = ""
                tabpage2_T_gmail.Text = ""
                tabpage2_C_year.Text = ""
                tabpage2_C_month.Text = ""
                tabpage2_C_day.Text = ""
                tabpage2_T_password.Text = ""
            End If
            connect.Close()
        Catch ex As MySqlException
            MessageBox.Show("註冊失敗：" & ex.Message)
        Finally
            If connect.State = ConnectionState.Open Then
                connect.Close()
            End If
            connect.Dispose()
        End Try
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub tabpage2_C_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabpage2_C_month.SelectedIndexChanged
        Dim daysInMonth As Integer = 0
        Dim selectedMonth As Integer = Convert.ToInt32(tabpage2_C_month.Text)
        Dim selectedYear As Integer = Convert.ToInt32(tabpage2_C_year.Text)

        tabpage2_C_day.Items.Clear()

        Select Case selectedMonth
            Case 1, 3, 5, 7, 8, 10, 12
                daysInMonth = 31
            Case 4, 6, 9, 11
                daysInMonth = 30
            Case 2
                If (selectedYear Mod 4 = 0 And selectedYear Mod 100 <> 0) Or (selectedYear Mod 100 = 0 And selectedYear Mod 400 = 0) Then
                    daysInMonth = 29
                Else
                    daysInMonth = 28
                End If
        End Select

        For i As Integer = 1 To daysInMonth
            tabpage2_C_day.Items.Add(i.ToString())
        Next
    End Sub

#End Region
#Region "登入"
#Region "頁面page3設計"
    Private Sub Centertabpage3()

        tabpage3_B_return.Image = My.Resources.home鍵
        tabpage3_P_background.Image = My.Resources.登入畫面1
        tabpage3_B_login.Image = My.Resources.黃橙
        tabpage3_B_register.Image = My.Resources.黃橙

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage3_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage3_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage3_B_login.Location = New Point(x - 180, y + 130)
        tabpage3_B_register.Location = New Point(x + 30, y + 130)
        tabpage3_L_phone.Location = New Point(x - 220, y - 50)
        tabpage3_T_phone.Location = New Point(x + 30, y - 50)
        tabpage3_L_password.Location = New Point(x - 220, y + 30)
        tabpage3_T_password.Location = New Point(x + 30, y + 30)
        tabpage3_T_password.PasswordChar = "*"c

        tabpage3_B_return.Parent = tabpage3_P_background
        tabpage3_B_login.Parent = tabpage3_P_background
        tabpage3_B_register.Parent = tabpage3_P_background
        tabpage3_L_phone.Parent = tabpage3_P_background
        tabpage3_L_timer.Parent = tabpage3_P_background
        tabpage3_L_password.Parent = tabpage3_P_background

    End Sub
#End Region
    Private Sub tabpage3_B_register_Click(sender As Object, e As EventArgs) Handles tabpage3_B_register.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub tabpage3_B_return_Click(sender As Object, e As EventArgs) Handles tabpage3_B_return.Click
        TabControl1.SelectedIndex = 0
    End Sub
    Private Sub tabpage3_B_login_Click(sender As Object, e As EventArgs) Handles tabpage3_B_login.Click
        Dim mysqlconnect As New MySqlConnection("host=localhost;user=root;database=store")
        If (tabpage3_T_phone.Text = "0975806803" And tabpage3_T_password.Text = "0975806803") Then
            MessageBox.Show("商家管理頁面登入成功！")
            TabControl1.SelectedIndex = 8
        Else
            Try
                mysqlconnect.Open()
                Dim checkQuery As String = "SELECT COUNT(*) FROM member WHERE member_phone = @Phone AND member_password = @password"
                Dim command As New MySqlCommand(checkQuery, mysqlconnect)
                command.Parameters.AddWithValue("@Phone", tabpage3_T_phone.Text)
                command.Parameters.AddWithValue("@password", tabpage3_T_password.Text)
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                If count = 1 Then
                    MessageBox.Show("登入成功！")
                    TabControl1.SelectedIndex = 3

                    Dim nameQuery As String = "SELECT * FROM member WHERE member_phone = @Phone AND member_password = @password"
                    command = New MySqlCommand(nameQuery, mysqlconnect)
                    command.Parameters.AddWithValue("@Phone", tabpage3_T_phone.Text)
                    command.Parameters.AddWithValue("@password", tabpage3_T_password.Text)
                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        tabpage4_T_name.Text = reader("member_name").ToString()
                        tabpage4_T_phone.Text = reader("member_phone").ToString()
                        tabpage4_T_gmail.Text = reader("member_email").ToString()
                        tabpage4_L_point2.Text = reader("member_point").ToString() & " 點"
                        Dim birthday As Date = reader.GetDateTime("member_birthday")
                        tabpage4_T_year.Text = birthday.Year.ToString()
                        tabpage4_T_month.Text = birthday.Month.ToString()
                        tabpage4_T_day.Text = birthday.Day.ToString()
                        tabpage4_T_password.Text = reader("member_password").ToString()
                    End If
                    tabpage4_T_password.PasswordChar = "*"c
                    reader.Close()
                Else
                    MessageBox.Show("登入失敗：電話或密碼不正確！")
                    TabControl1.SelectedIndex = 2
                    tabpage3_T_password.Text = ""
                    tabpage3_T_phone.Text = ""
                End If
            Catch ex As MySqlException
                MessageBox.Show("登入失敗：" & ex.Message)
            Finally
                mysqlconnect.Close()
            End Try
        End If
        tabpage3_T_phone.Text = ""
        tabpage3_T_password.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TabControl1.SelectedIndex = 8
    End Sub

#End Region
#Region "會員資料"

#Region "頁面page4設計"
    Private Sub Centertabpage4()

        tabpage4_B_logout.Image = My.Resources.home鍵
        tabpage4_P_background.Image = My.Resources.會員畫面1
        tabpage4_B_change.Image = My.Resources.黃橙
        tabpage4_B_check.Image = My.Resources.黃橙
        tabpage4_B_order.Image = My.Resources.黃橙
        tabpage4_B_ordercheck.Image = My.Resources.黃橙

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage4_L_timer.Location = New Point(2 * x - 350, 10)
        tabpage4_B_ordercheck.Location = New Point(x + 350, y + 300)
        tabpage4_B_order.Location = New Point(x + 550, y + 300)
        tabpage4_B_logout.Location = New Point(x - 750, y + 300)
        tabpage4_B_check.Location = New Point(x - 550, y + 300)
        tabpage4_B_change.Location = New Point(x - 550, y + 300)
        tabpage4_L_name.Location = New Point(x - 500, y - 250)
        tabpage4_T_name.Location = New Point(x - 490, y - 170)
        tabpage4_L_phone.Location = New Point(x - 500, y - 90)
        tabpage4_T_phone.Location = New Point(x - 490, y - 10)
        tabpage4_L_password.Location = New Point(x - 500, y + 70)
        tabpage4_T_password.Location = New Point(x - 490, y + 150)
        tabpage4_L_gmail.Location = New Point(x + 10, y - 70)
        tabpage4_T_gmail.Location = New Point(x + 10, y - 150)
        tabpage4_L_birth.Location = New Point(x, y - 250)
        tabpage4_T_year.Location = New Point(x + 10, y - 170)
        tabpage4_L_year.Location = New Point(x + 170, y - 178)
        tabpage4_T_month.Location = New Point(x + 240, y - 170)
        tabpage4_L_month.Location = New Point(x + 340, y - 178)
        tabpage4_T_day.Location = New Point(x + 400, y - 170)
        tabpage4_L_day.Location = New Point(x + 500, y - 178)
        tabpage4_L_gmail.Location = New Point(x, y - 90)
        tabpage4_T_gmail.Location = New Point(x + 10, y - 10)
        tabpage4_L_point.Location = New Point(x, y + 70)
        tabpage4_L_point2.Location = New Point(x + 130, y + 70)
        'tabpage4_T_password.PasswordChar = "*"c

        tabpage4_L_timer.Parent = tabpage4_P_background
        tabpage4_B_change.Parent = tabpage4_P_background
        tabpage4_B_check.Parent = tabpage4_P_background
        tabpage4_B_order.Parent = tabpage4_P_background
        tabpage4_B_logout.Parent = tabpage4_P_background
        tabpage4_B_ordercheck.Parent = tabpage4_P_background
        tabpage4_L_birth.Parent = tabpage4_P_background
        tabpage4_L_day.Parent = tabpage4_P_background
        tabpage4_L_gmail.Parent = tabpage4_P_background
        tabpage4_L_month.Parent = tabpage4_P_background
        tabpage4_L_name.Parent = tabpage4_P_background
        tabpage4_L_phone.Parent = tabpage4_P_background
        tabpage4_L_year.Parent = tabpage4_P_background
        tabpage4_L_point.Parent = tabpage4_P_background
        tabpage4_L_point2.Parent = tabpage4_P_background
        tabpage4_L_password.Parent = tabpage4_P_background

    End Sub
#End Region
    Private Sub tabpage4_B_change_Click(sender As Object, e As EventArgs) Handles tabpage4_B_change.Click
        For Each ctrl As Control In TabPage4.Controls
            If TypeOf ctrl Is TextBox Then
                Dim textBox As TextBox = CType(ctrl, TextBox)
                If textBox.Name <> "tabpage4_T_phone" Then
                    textBox.ReadOnly = False
                    textBox.TabStop = False
                End If
            End If
        Next
        tabpage4_B_check.Visible = True
        tabpage4_B_change.Visible = False
        tabpage4_B_order.Visible = False
        tabpage4_B_ordercheck.Visible = False
        tabpage4_B_logout.Visible = False
        If tabpage4_T_password.PasswordChar = "*"c Then
            tabpage4_T_password.PasswordChar = ControlChars.NullChar
        End If

    End Sub

    Private Sub tabpage4_B_check_Click(sender As Object, e As EventArgs) Handles tabpage4_B_check.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 更新會員資料
                Dim updateQuery As String = "UPDATE member SET member_name = @name, member_email = @email, member_phone = @phone, member_birthday = @birthday ,member_password = @password WHERE  member_phone = @phone"
                Using updateCmd As New MySqlCommand(updateQuery, connect)
                    updateCmd.Parameters.AddWithValue("@name", tabpage4_T_name.Text)
                    updateCmd.Parameters.AddWithValue("@email", tabpage4_T_gmail.Text)
                    updateCmd.Parameters.AddWithValue("@phone", tabpage4_T_phone.Text)
                    updateCmd.Parameters.AddWithValue("@birthday", tabpage4_T_year.Text + "/" + tabpage4_T_month.Text + "/" + tabpage4_T_day.Text)
                    updateCmd.Parameters.AddWithValue("@password", tabpage4_T_password.Text)
                    updateCmd.ExecuteNonQuery()
                End Using
                MsgBox("會員資料已成功更新。")
            Catch
                MsgBox("會員資料已成功更新。")
            End Try
        End If

        For Each ctrl As Control In TabPage4.Controls
            If TypeOf ctrl Is TextBox Then
                Dim textBox As TextBox = CType(ctrl, TextBox)
                textBox.ReadOnly = True
                textBox.TabStop = False
            End If
        Next
        tabpage4_B_check.Visible = False
        tabpage4_B_change.Visible = True
        tabpage4_B_order.Visible = True
        tabpage4_B_ordercheck.Visible = True
        tabpage4_B_logout.Visible = True
        Me.ActiveControl = Nothing
        tabpage4_T_password.PasswordChar = "*"c

    End Sub
    Private Sub tabpage4_B_ordercheck_Click(sender As Object, e As EventArgs) Handles tabpage4_B_ordercheck.Click
        TabControl1.SelectedIndex = 5
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 查詢指定訂單編號的訂單內容
                Dim query As String = "SELECT ol.*,om.Order_status FROM order_list ol " &
                                      "INNER JOIN order_management om ON om.Order_number = ol.oId " &
                                      "INNER JOIN member m ON m.member_phone = ol.member_phone " &
                                      "WHERE m.member_phone = @phone order by ol.Order_Time desc"
                Using cmd As New MySqlCommand(query, connect)
                    cmd.Parameters.AddWithValue("@phone", tabpage4_T_phone.Text)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)
                    tabpage6_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("無法獲取訂單資料: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        ChangeRowColors6()
        ChangeColumnHeaders6()
    End Sub
    Public Sub ChangeColumnHeaders6()
        If tabpage6_DataGridView.Columns.Count > 0 Then
            tabpage6_DataGridView.Columns(0).HeaderText = "訂單編號"
            tabpage6_DataGridView.Columns(1).HeaderText = "商品編號"
            tabpage6_DataGridView.Columns(2).HeaderText = "商品名稱"
            tabpage6_DataGridView.Columns(3).HeaderText = "數量"
            tabpage6_DataGridView.Columns(4).HeaderText = "總金額"
            tabpage6_DataGridView.Columns(5).HeaderText = "下單時間"
            tabpage6_DataGridView.Columns(6).HeaderText = "會員電話"
            tabpage6_DataGridView.Columns(7).HeaderText = "訂單狀態"
        End If
    End Sub
    Private Sub ChangeRowColors6()

        For Each row As DataGridViewRow In tabpage6_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub tabpage4_B_order_Click(sender As Object, e As EventArgs) Handles tabpage4_B_order.Click
        TabControl1.SelectedIndex = 4
        ChangeColumnHeaders5()
        ChangeRowColors5()
    End Sub
    Private Sub tabpage4_B_logout_Click(sender As Object, e As EventArgs) Handles tabpage4_B_logout.Click
        TabControl1.SelectedIndex = 0
    End Sub
#End Region
#Region "菜單"
#Region "頁面page5設計"
    Private Sub Centertabpage5()

        tabpage5_P_background.Image = My.Resources.點餐畫面2
        tabpage5_B_return.Image = My.Resources.home鍵

        tabpage5_B_add.Image = My.Resources.大淡藍
        tabpage5_B_query.Image = My.Resources.大淡藍
        tabpage5_B_check.Image = My.Resources.大淡藍

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage5_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage5_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage5_B_add.Location = New Point(x - 650, y - 100)
        tabpage5_B_query.Location = New Point(x - 650, y + 25)
        tabpage5_B_check.Location = New Point(x - 650, y + 150)
        tabpage5_DataGridView.Location = New Point(x - 230, y - 150)

        tabpage5_B_add.Parent = tabpage5_P_background
        tabpage5_B_check.Parent = tabpage5_P_background
        tabpage5_B_query.Parent = tabpage5_P_background
        tabpage5_B_return.Parent = tabpage5_P_background
        tabpage5_L_timer.Parent = tabpage5_P_background


    End Sub

    Private Sub ChangeRowColors5()

        For Each row As DataGridViewRow In tabpage5_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.LightBlue
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

#End Region
    Private Sub tabpage5_B_query_Click(sender As Object, e As EventArgs) Handles tabpage5_B_query.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim query As String = "SELECT oc.oId, oc.iId, m.iName, m.iPrice, oc.oQuantity, oc.oQuantity * m.iPrice AS oSum " &
                                      "FROM orders_contain oc " &
                                      "INNER JOIN menu m ON oc.iId = m.iId"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)

                    tabpage7_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢資料失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If

        TabControl1.SelectedIndex = 6
        TabControl1.SelectedIndex = 6
        ChangeColumnHeaders7()
        ChangeRowColors7()
    End Sub
    Public Sub ChangeColumnHeaders8()
        If tabpage8_DataGridView.Columns.Count > 0 Then
            tabpage8_DataGridView.Columns(0).HeaderText = "訂單編號"
            tabpage8_DataGridView.Columns(1).HeaderText = "商品編號"
            tabpage8_DataGridView.Columns(2).HeaderText = "商品名稱"
            tabpage8_DataGridView.Columns(3).HeaderText = "單價"
            tabpage8_DataGridView.Columns(4).HeaderText = "數量"
            tabpage8_DataGridView.Columns(5).HeaderText = "金額"
        End If
    End Sub
    Private Sub ChangeRowColors8()

        For Each row As DataGridViewRow In tabpage8_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Public Sub ChangeColumnHeaders7()
        If tabpage7_DataGridView.Columns.Count > 0 Then
            tabpage7_DataGridView.Columns(0).HeaderText = "訂單編號"
            tabpage7_DataGridView.Columns(1).HeaderText = "商品編號"
            tabpage7_DataGridView.Columns(2).HeaderText = "商品名稱"
            tabpage7_DataGridView.Columns(3).HeaderText = "單價"
            tabpage7_DataGridView.Columns(4).HeaderText = "數量"
            tabpage7_DataGridView.Columns(5).HeaderText = "金額"
        End If
    End Sub
    Private Sub ChangeRowColors7()

        For Each row As DataGridViewRow In tabpage7_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Public Sub ChangeColumnHeaders5()
        If tabpage5_DataGridView.Columns.Count > 0 Then
            tabpage5_DataGridView.Columns(0).HeaderText = "商品編號"
            tabpage5_DataGridView.Columns(1).HeaderText = "商品"
            tabpage5_DataGridView.Columns(2).HeaderText = "價格"
        End If
    End Sub
    Private Sub tabpage5_B_check_Click(sender As Object, e As EventArgs) Handles tabpage5_B_check.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim query As String = "SELECT oc.oId, oc.iId, m.iName, m.iPrice, oc.oQuantity, oc.oQuantity * m.iPrice AS oSum FROM orders_contain oc INNER JOIN menu m ON oc.iId = m.iId"
                Using cmd As New MySqlCommand(query, connect)
                    cmd.Parameters.AddWithValue("@oId", orderId)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)
                    tabpage8_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢資料失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        TabControl1.SelectedIndex = 7
        ChangeColumnHeaders8()
        ChangeRowColors8()
    End Sub

    Private Sub tabpage5_B_add_Click(sender As Object, e As EventArgs) Handles tabpage5_B_add.Click
        If tabpage5_DataGridView.SelectedRows.Count = 0 Then
            MsgBox("請選擇餐點")
            Return
        End If
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                For Each row As DataGridViewRow In tabpage5_DataGridView.SelectedRows
                    Dim itemId As Integer = row.Cells("iId").Value
                    Dim quantity As Integer = 1
                    Dim iPrice As Decimal = 0
                    ' 獲取 iPrice 的值
                    Dim priceCmd As New MySqlCommand("SELECT iPrice FROM menu WHERE iId = @iId", connect)
                    priceCmd.Parameters.AddWithValue("@iId", itemId)
                    Using reader As MySqlDataReader = priceCmd.ExecuteReader()
                        If reader.Read() Then
                            iPrice = reader("iPrice")
                        Else
                            MsgBox("無法找到選擇的商品價格。")
                            Return
                        End If
                    End Using
                    ' 計算 oSum 的值
                    Dim oSum As Decimal = quantity * iPrice
                    ' 插入 orders_contain 表
                    Dim insertCmd As New MySqlCommand("INSERT INTO orders_contain (oId, iId, oQuantity, oSum) VALUES (@oId, @iId, @oQuantity, @oSum)", connect)
                    insertCmd.Parameters.AddWithValue("@oId", orderId)
                    insertCmd.Parameters.AddWithValue("@iId", itemId)
                    insertCmd.Parameters.AddWithValue("@oQuantity", quantity)
                    insertCmd.Parameters.AddWithValue("@oSum", oSum)
                    insertCmd.ExecuteNonQuery()
                Next

                MsgBox("點餐成功")
            Catch ex As Exception
                MsgBox("重複選擇相同商品")
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
    End Sub
    Private Sub tabpage5_B_return_Click(sender As Object, e As EventArgs) Handles tabpage5_B_return.Click
        TabControl1.SelectedIndex = 3
    End Sub

#End Region
#Region "訂單查詢"
#Region "頁面page6設計"
    Private Sub Centertabpage6()

        tabpage6_B_return.Image = My.Resources.home鍵
        tabpage6_P_background.Image = My.Resources.會員畫面1

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage6_B_return.Location = New Point(x + 550, y + 300)
        tabpage6_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage6_DataGridView.Location = New Point(x - 600, y - 250)

        tabpage6_B_return.Parent = tabpage6_P_background
        tabpage6_L_timer.Parent = tabpage6_P_background

    End Sub

#End Region
    Private Sub tabpage6_B_return_Click(sender As Object, e As EventArgs) Handles tabpage6_B_return.Click
        TabControl1.SelectedIndex = 3
    End Sub
#End Region
#Region "查詢餐點"
#Region "頁面page7設計"
    Private Sub Centertabpage7()

        tabpage7_B_return.Image = My.Resources.返回箭頭
        tabpage7_P_background.Image = My.Resources.會員畫面1
        tabpage7_B_delete.Image = My.Resources.黃橙
        tabpage7_B_update.Image = My.Resources.黃橙

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage7_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage7_B_delete.Location = New Point(x - 600, y + 150)
        tabpage7_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage7_B_update.Location = New Point(x - 380, y + 150)
        tabpage7_L_goods.Location = New Point(x - 610, y - 200)
        tabpage7_T_goods.Location = New Point(x - 410, y - 200)
        tabpage7_L_money.Location = New Point(x - 610, y - 100)
        tabpage7_T_money.Location = New Point(x - 410, y - 100)
        tabpage7_L_number.Location = New Point(x - 610, y)
        tabpage7_T_number.Location = New Point(x - 410, y)
        tabpage7_DataGridView.Location = New Point(x - 150, y - 200)



        tabpage7_B_delete.Parent = tabpage7_P_background
        tabpage7_B_return.Parent = tabpage7_P_background
        tabpage7_B_update.Parent = tabpage7_P_background
        tabpage7_L_goods.Parent = tabpage7_P_background
        tabpage7_L_money.Parent = tabpage7_P_background
        tabpage7_L_number.Parent = tabpage7_P_background
        tabpage7_L_timer.Parent = tabpage7_P_background

    End Sub
#End Region
    Private Sub tabpage7_B_update_Click(sender As Object, e As EventArgs) Handles tabpage7_B_update.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                If tabpage7_DataGridView.SelectedRows.Count > 0 Then
                    Dim selectedRow As DataGridViewRow = tabpage7_DataGridView.SelectedRows(0)
                    Dim newQuantity As Integer = Integer.Parse(tabpage7_T_number.Text)

                    Dim orderId As Integer = Integer.Parse(selectedRow.Cells("iId").Value.ToString())
                    Dim price As Decimal = 0

                    ' 獲取 iPrice 的值
                    Dim priceCmd As New MySqlCommand("SELECT iPrice FROM menu WHERE iId = @iId", connect)
                    priceCmd.Parameters.AddWithValue("@iId", orderId)
                    Using reader As MySqlDataReader = priceCmd.ExecuteReader()
                        If reader.Read() Then
                            price = reader("iPrice")
                        Else
                            MsgBox("無法找到選擇的商品價格。")
                            Return
                        End If
                    End Using

                    ' 計算 oSum 的值
                    Dim oSum As Decimal = newQuantity * price

                    ' 更新 oQuantity 和 oSum 的值
                    Dim updateCmd As New MySqlCommand("UPDATE orders_contain SET oQuantity = @oQuantity, oSum = @oSum WHERE iId = @iId", connect)
                    updateCmd.Parameters.AddWithValue("@oQuantity", newQuantity)
                    updateCmd.Parameters.AddWithValue("@oSum", oSum)
                    updateCmd.Parameters.AddWithValue("@iId", orderId)
                    updateCmd.ExecuteNonQuery()
                    MsgBox("餐點數量已成功更新。")
                Else
                    MsgBox("請選擇要更新數量的餐點。")
                End If
            Catch ex As Exception
                MsgBox("更新失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim query As String = "SELECT oc.oId, oc.iId, m.iName, m.iPrice, oc.oQuantity, oc.oSum " &
                                  "FROM orders_contain oc " &
                                  "INNER JOIN menu m ON oc.iId = m.iId"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)

                    tabpage7_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢資料失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage7_T_goods.Text = ""
        tabpage7_T_money.Text = ""
        tabpage7_T_number.Text = ""
        ChangeRowColors7()
    End Sub
    Private Sub tabpage7_B_delete_Click(sender As Object, e As EventArgs) Handles tabpage7_B_delete.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                For Each row As DataGridViewRow In tabpage7_DataGridView.SelectedRows
                    Dim iId As Integer = Convert.ToInt32(row.Cells("iId").Value)

                    Dim deleteCmd As New MySqlCommand("DELETE FROM orders_contain WHERE iId = @iId", connect)
                    deleteCmd.Parameters.AddWithValue("@iId", iId)
                    deleteCmd.ExecuteNonQuery()
                Next
                MsgBox("所選資料已成功刪除。")
            Catch ex As Exception
                MsgBox("刪除資料失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If

        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim query As String = "SELECT oc.oId, oc.iId, m.iName, m.iPrice, oc.oQuantity, oc.oSum " &
                                  "FROM orders_contain oc " &
                                  "INNER JOIN menu m ON oc.iId = m.iId"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)

                    tabpage7_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢資料失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage7_T_goods.Text = ""
        tabpage7_T_money.Text = ""
        tabpage7_T_number.Text = ""
        ChangeRowColors7()
    End Sub
    Private Sub tabpage7_DataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles tabpage7_DataGridView.SelectionChanged
        If tabpage7_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = tabpage7_DataGridView.SelectedRows(0)
            tabpage7_T_goods.Text = selectedRow.Cells("iName").Value.ToString()
            tabpage7_T_money.Text = selectedRow.Cells("iPrice").Value.ToString()
            tabpage7_T_number.Text = selectedRow.Cells("oQuantity").Value.ToString()
        End If
    End Sub
    Private Sub tabpage7_B_return_Click(sender As Object, e As EventArgs) Handles tabpage7_B_return.Click
        TabControl1.SelectedIndex = 4
    End Sub

#End Region
#Region "確認餐點"
#Region "頁面page8設計"
    Private Sub Centertabpage8()

        tabpage8_B_return.Image = My.Resources.返回箭頭
        tabpage8_P_background.Image = My.Resources.會員畫面1
        tabpage8_B_order.Image = My.Resources.黃橙

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage8_B_order.Location = New Point(x + 550, y + 300)
        tabpage8_B_return.Location = New Point(x - 550 - 161, y + 300)
        tabpage8_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage8_DataGridView.Location = New Point(x - 600, y - 250)

        tabpage8_B_order.Parent = tabpage8_P_background
        tabpage8_B_return.Parent = tabpage8_P_background
        tabpage8_L_timer.Parent = tabpage8_P_background

    End Sub
#End Region
    Private Sub tabpage8_B_order_Click(sender As Object, e As EventArgs) Handles tabpage8_B_order.Click
        Dim Mphone As String = tabpage4_T_phone.Text
        Dim OTime As DateTime = tabpage8_L_timer.Text
        Dim orderSum As Integer
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 遍歷每一行，並插入到 order_list 資料表中
                For Each row As DataGridViewRow In tabpage8_DataGridView.Rows
                    If Not row.IsNewRow Then
                        Dim oId As Integer = Integer.Parse(row.Cells("oId").Value.ToString())
                        Dim iId As Integer = Integer.Parse(row.Cells("iId").Value.ToString())
                        Dim iName As String = row.Cells("iName").Value.ToString()
                        Dim oQuantity As Integer = Integer.Parse(row.Cells("oQuantity").Value.ToString())
                        Dim iPrice As Decimal = Decimal.Parse(row.Cells("iPrice").Value.ToString())
                        Dim oSum As Decimal = iPrice * oQuantity
                        orderSum += oSum
                        Dim insertCmd As New MySqlCommand("INSERT INTO order_list (oId, iId, iName, oQuantity, oSum, member_phone, Order_Time) VALUES (@oId, @iId, @iName, @oQuantity, @oSum, @Mphone, @OTime) " &
                                                          "ON DUPLICATE KEY UPDATE oQuantity = @oQuantity, oSum = @oSum, member_phone = @Mphone, Order_Time = @OTime", connect)
                        insertCmd.Parameters.AddWithValue("@oId", orderId)
                        insertCmd.Parameters.AddWithValue("@iId", iId)
                        insertCmd.Parameters.AddWithValue("@iName", iName)
                        insertCmd.Parameters.AddWithValue("@oQuantity", oQuantity)
                        insertCmd.Parameters.AddWithValue("@oSum", oSum)
                        insertCmd.Parameters.AddWithValue("@Mphone", Mphone)
                        insertCmd.Parameters.AddWithValue("@OTime", OTime)
                        insertCmd.ExecuteNonQuery()
                    End If
                Next
                Dim insertOrderManagementCmd As New MySqlCommand("INSERT INTO order_management (Order_number, Order_time, Order_status, Order_sum, member_phone) VALUES (@Order_number, @Order_time, @Order_status, @Order_sum, @member_phone)", connect)
                insertOrderManagementCmd.Parameters.AddWithValue("@Order_number", orderId)
                insertOrderManagementCmd.Parameters.AddWithValue("@Order_time", OTime)
                insertOrderManagementCmd.Parameters.AddWithValue("@Order_status", "未接單")
                insertOrderManagementCmd.Parameters.AddWithValue("@Order_sum", orderSum)
                insertOrderManagementCmd.Parameters.AddWithValue("@member_phone", Mphone)
                insertOrderManagementCmd.ExecuteNonQuery()

                Dim deleteCmd As New MySqlCommand("DELETE FROM orders_contain", connect)
                deleteCmd.ExecuteNonQuery()
                MsgBox("訂單已成功提交。")
                orderId += 1
            Catch ex As Exception
                orderId = rand.Next(0, 10000)
                MsgBox("訂單提交失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接資料表:。")
        End If
        TabControl1.SelectedIndex = 3
    End Sub
    Private Sub tabpage8_B_return_Click(sender As Object, e As EventArgs) Handles tabpage8_B_return.Click
        TabControl1.SelectedIndex = 4
    End Sub

#End Region
#Region "商家頁面"
#Region "頁面page9設計"
    Private Sub Centertabpage9()

        tabpage9_B_return.Image = My.Resources.home鍵
        tabpage9_B_paper.Image = My.Resources.圖表
        tabpage9_P_background.Image = My.Resources.主商家畫面

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2


        tabpage9_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage9_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage9_B_menu.Location = New Point(x - 200, y - 200)
        tabpage9_B_ordercheck.Location = New Point(x, y - 200)
        tabpage9_B_stockcheck.Location = New Point(x - 200, y)
        tabpage9_B_restock.Location = New Point(x, y)
        tabpage9_B_paper.Location = New Point(x + 680, 2 * y - 75)

        tabpage9_B_menu.Parent = tabpage9_P_background
        tabpage9_B_ordercheck.Parent = tabpage9_P_background
        tabpage9_B_restock.Parent = tabpage9_P_background
        tabpage9_B_return.Parent = tabpage9_P_background
        tabpage9_B_stockcheck.Parent = tabpage9_P_background
        tabpage9_B_paper.Parent = tabpage9_P_background
        tabpage9_L_timer.Parent = tabpage9_P_background

    End Sub
#End Region
    Private Sub tabpage9_B_menu_Click(sender As Object, e As EventArgs) Handles tabpage9_B_menu.Click
        TabControl1.SelectedIndex = 9
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM menu"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage10_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        ChangeColumnHeaders10()
        ChangeRowColors10()
    End Sub
    Public Sub ChangeColumnHeaders10()
        If tabpage10_DataGridView.Columns.Count > 0 Then
            tabpage10_DataGridView.Columns(0).HeaderText = "商品編號"
            tabpage10_DataGridView.Columns(1).HeaderText = "商品"
            tabpage10_DataGridView.Columns(2).HeaderText = "價格"
        End If
    End Sub
    Private Sub ChangeRowColors10()
        For Each row As DataGridViewRow In tabpage10_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.SkyBlue
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub tabpage9_B_ordercheck_Click(sender As Object, e As EventArgs) Handles tabpage9_B_ordercheck.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim query As String = "SELECT Order_number, Order_time, Order_status, Order_sum, member_phone FROM order_management order by Order_time desc"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset, "1a")
                    '連接DataGridView 的資料來源
                    tabpage11_DataGridView.DataSource = dataset.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("訂單顯示失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接資料庫。")
        End If
        TabControl1.SelectedIndex = 10
        ChangeColumnHeaders11()
        ChangeRowColors11()
    End Sub
    Public Sub ChangeColumnHeaders11()
        If tabpage11_DataGridView.Columns.Count > 0 Then
            tabpage11_DataGridView.Columns(0).HeaderText = "訂單編號"
            tabpage11_DataGridView.Columns(1).HeaderText = "下單時間"
            tabpage11_DataGridView.Columns(2).HeaderText = "訂單狀態"
            tabpage11_DataGridView.Columns(3).HeaderText = "總金額"
            tabpage11_DataGridView.Columns(4).HeaderText = "會員電話"
        End If
    End Sub
    Private Sub ChangeRowColors11()

        For Each row As DataGridViewRow In tabpage11_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.PowderBlue
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub tabpage9_B_stockcheck_Click(sender As Object, e As EventArgs) Handles tabpage9_B_stockcheck.Click
        Getconnect()
        tabpage12_T_goods.Text = ""
        tabpage12_T_money.Text = ""
        tabpage12_T_number.Text = ""

        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM stock"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage12_DataGridView.DataSource = Nothing
                    tabpage12_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If

        ' 計算數量小於10的資料列數量
        Dim lowStockCount As Integer = 0
        For Each row As DataGridViewRow In tabpage12_DataGridView.Rows
            If Not row.IsNewRow AndAlso Convert.ToInt32(row.Cells("material_amount").Value) < 10 Then
                lowStockCount += 1
            End If
        Next
        TabControl1.SelectedIndex = 11
        If (lowStockCount > 0) Then
            MsgBox("有" & lowStockCount & "筆庫存即將用完")
        End If
        ChangeColumnHeaders12()
        ChangeStockRowColors12()
        ChangeRowColors12()
    End Sub
    Private Sub ChangeStockRowColors12()
        Dim boldFont As New Font(tabpage12_DataGridView.DefaultCellStyle.Font, FontStyle.Bold)
        For Each row As DataGridViewRow In tabpage12_DataGridView.Rows
            If Not row.IsNewRow AndAlso Convert.ToInt32(row.Cells("material_amount").Value) < 10 Then
                row.DefaultCellStyle.ForeColor = Color.Red
                row.DefaultCellStyle.Font = boldFont
            End If
        Next
    End Sub
    Public Sub ChangeColumnHeaders12()
        If tabpage12_DataGridView.Columns.Count > 0 Then
            tabpage12_DataGridView.Columns(0).HeaderText = "庫存編號"
            tabpage12_DataGridView.Columns(1).HeaderText = "食材名稱"
            tabpage12_DataGridView.Columns(2).HeaderText = "數量"
        End If
    End Sub
    Private Sub ChangeRowColors12()

        For Each row As DataGridViewRow In tabpage12_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.LightSteelBlue
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub tabpage9_B_restock_Click(sender As Object, e As EventArgs) Handles tabpage9_B_restock.Click
        Getconnect()
        tabpage13_T_amount.Text = ""
        tabpage13_T_date.Text = ""
        tabpage13_T_goods.Text = ""
        tabpage13_T_id.Text = ""
        tabpage13_T_number.Text = ""
        tabpage13_T_total.Text = ""
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM purchase_records"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage13_DataGridView.DataSource = Nothing
                    tabpage13_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        TabControl1.SelectedIndex = 11
        TabControl1.SelectedIndex = 12
        tabpage13_MonthCalendar.Visible = False
        ChangeColumnHeaders13()
        ChangeRowColors13()
    End Sub
    Public Sub ChangeColumnHeaders13()
        If tabpage13_DataGridView.Columns.Count > 0 Then
            tabpage13_DataGridView.Columns(0).HeaderText = "庫存代碼"
            tabpage13_DataGridView.Columns(1).HeaderText = "進貨單編號"
            tabpage13_DataGridView.Columns(2).HeaderText = "進貨原物料名稱"
            tabpage13_DataGridView.Columns(3).HeaderText = "數量"
            tabpage13_DataGridView.Columns(4).HeaderText = "進貨日期"
            tabpage13_DataGridView.Columns(5).HeaderText = "總金額"
        End If
    End Sub
    Private Sub ChangeRowColors13()

        For Each row As DataGridViewRow In tabpage13_DataGridView.Rows
            If row.Index Mod 2 = 0 Then
                row.DefaultCellStyle.BackColor = Color.Lavender
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub tabpage9_B_return_Click(sender As Object, e As EventArgs) Handles tabpage9_B_return.Click
        TabControl1.SelectedIndex = 0
    End Sub
    Private Sub tabpage9_B_paper_Click(sender As Object, e As EventArgs) Handles tabpage9_B_paper.Click
        TabControl1.SelectedIndex = 13
    End Sub

#End Region
#Region "商家菜單管理"
#Region "頁面page10設計"
    Private Sub Centertabpage10()

        tabpage10_B_return.Image = My.Resources.home鍵
        tabpage10_P_background.Image = My.Resources.菜單畫面
        tabpage10_B_add.Image = My.Resources.藍紫
        tabpage10_B_delete.Image = My.Resources.藍紫
        tabpage10_B_back.Image = My.Resources.返回箭頭
        tabpage10_B_update.Image = My.Resources.藍紫
        tabpage10_B_query.Image = My.Resources.藍紫

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage10_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage10_B_add.Location = New Point(x - 610, y + 100)
        tabpage10_B_delete.Location = New Point(x - 390, y + 100)
        tabpage10_B_query.Location = New Point(x - 610, y + 200)
        tabpage10_B_update.Location = New Point(x - 390, y + 200)
        tabpage10_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage10_L_goods.Location = New Point(x - 630, y - 200)
        tabpage10_T_goods.Location = New Point(x - 410, y - 200)
        tabpage10_L_number.Location = New Point(x - 630, y - 100)
        tabpage10_T_number.Location = New Point(x - 410, y - 100)
        tabpage10_L_money.Location = New Point(x - 630, y)
        tabpage10_T_money.Location = New Point(x - 410, y)
        tabpage10_DataGridView.Location = New Point(x - 150, y - 200)
        tabpage10_B_back.Location = New Point(x + 650, y + 300)

        tabpage10_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage10_B_add.Parent = tabpage10_P_background
        tabpage10_B_delete.Parent = tabpage10_P_background
        tabpage10_B_back.Parent = tabpage10_P_background
        tabpage10_B_return.Parent = tabpage10_P_background
        tabpage10_B_update.Parent = tabpage10_P_background
        tabpage10_B_query.Parent = tabpage10_P_background
        tabpage10_L_goods.Parent = tabpage10_P_background
        tabpage10_L_money.Parent = tabpage10_P_background
        tabpage10_L_number.Parent = tabpage10_P_background
        tabpage10_L_timer.Parent = tabpage10_P_background

    End Sub
#End Region
    Private Sub tabpage10_DataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles tabpage10_DataGridView.SelectionChanged
        If tabpage10_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = tabpage10_DataGridView.SelectedRows(0)
            tabpage10_T_goods.Text = selectedRow.Cells("iName").Value.ToString()
            tabpage10_T_money.Text = selectedRow.Cells("iPrice").Value.ToString()
            tabpage10_T_number.Text = selectedRow.Cells("iId").Value.ToString()
        End If
    End Sub
    Private Sub tabpage10_B_add_Click(sender As Object, e As EventArgs) Handles tabpage10_B_add.Click
        connect = New MySqlConnection
        connect.ConnectionString = "server = localhost ; user = root ; database = store "
        Try
            connect.Open()
            Dim checkQuery As String = "SELECT COUNT(*) FROM menu WHERE iName = @iName" '檢查是否有重複的電話
            Dim checkCommand As New MySqlCommand(checkQuery, connect)
            checkCommand.Parameters.AddWithValue("@iName", tabpage10_L_goods.Text)
            Dim Query As String
            Query = "insert into store.menu(iId, iName, iPrice) VALUES (@iId, @iName, @iPrice)"
            COMMAND = New MySqlCommand(Query, connect)
            COMMAND.Parameters.AddWithValue("@iId", tabpage10_T_number.Text)
            COMMAND.Parameters.AddWithValue("@iName", tabpage10_T_goods.Text)
            COMMAND.Parameters.AddWithValue("@iPrice", tabpage10_T_money.Text)
            COMMAND.ExecuteNonQuery()
            MessageBox.Show("新增餐點成功")
            connect.Close()
        Catch ex As MySqlException
            MessageBox.Show("新增失敗：" & ex.Message)
        Finally
            If connect.State = ConnectionState.Open Then
                connect.Close()
            End If
            connect.Dispose()
        End Try
        Getconnect()

        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM menu"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage10_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage10_T_goods.Text = ""
        tabpage10_T_money.Text = ""
        tabpage10_T_number.Text = ""
        ChangeRowColors10()
    End Sub

    Private Sub tabpage10_B_delete_Click(sender As Object, e As EventArgs) Handles tabpage10_B_delete.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                For Each row As DataGridViewRow In tabpage10_DataGridView.SelectedRows
                    Dim iId As Integer = Convert.ToInt32(row.Cells("iId").Value)
                    Dim deleteCmd As New MySqlCommand("DELETE FROM menu WHERE iId = @iId", connect)
                    deleteCmd.Parameters.AddWithValue("@iId", iId)
                    deleteCmd.ExecuteNonQuery()
                Next
                MsgBox("所選餐點已成功刪除。")
            Catch ex As Exception
                MsgBox("刪除餐點失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM menu"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage10_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage10_T_goods.Text = ""
        tabpage10_T_money.Text = ""
        tabpage10_T_number.Text = ""
        ChangeRowColors10()
    End Sub

    Private Sub tabpage10_B_update_Click(sender As Object, e As EventArgs) Handles tabpage10_B_update.Click
        Getconnect()

        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                If tabpage10_DataGridView.SelectedRows.Count > 0 Then
                    Dim selectedRow As DataGridViewRow = tabpage10_DataGridView.SelectedRows(0)
                    Dim newQuantity As Integer = Integer.Parse(tabpage10_T_money.Text)

                    Dim orderId As Integer = Integer.Parse(selectedRow.Cells("iId").Value.ToString())

                    Dim updateCmd As New MySqlCommand("UPDATE menu SET iPrice = @iPrice WHERE iId = @iId", connect)
                    updateCmd.Parameters.AddWithValue("@iPrice", newQuantity)
                    updateCmd.Parameters.AddWithValue("@iId", orderId)
                    updateCmd.ExecuteNonQuery()

                    MsgBox("餐點金額已成功更新。")
                Else
                    MsgBox("請選擇要更新金額的餐點。")
                End If
            Catch ex As Exception
                MsgBox("更新失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM menu"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage10_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage10_T_goods.Text = ""
        tabpage10_T_money.Text = ""
        tabpage10_T_number.Text = ""
        ChangeRowColors10()
    End Sub
    Private Sub tabpage10_B_back_Click(sender As Object, e As EventArgs) Handles tabpage10_B_back.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim str1 As String = "SELECT * FROM menu"
                Using adp1 As New MySqlDataAdapter(str1, connect)
                    Dim set1 As New DataSet
                    adp1.Fill(set1, "1a")
                    tabpage10_DataGridView.DataSource = set1.Tables("1a")
                End Using
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        ChangeColumnHeaders10()
        ChangeRowColors10()
        tabpage10_T_goods.Text = ""
        tabpage10_T_money.Text = ""
        tabpage10_T_number.Text = ""
    End Sub
    Private Sub tabpage10_B_query_Click(sender As Object, e As EventArgs) Handles tabpage10_B_query.Click
        Dim itemName As String = tabpage10_T_goods.Text
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 使用 LIKE 進行模糊搜尋
                Dim query As String = "SELECT * FROM menu WHERE iName LIKE @iName"
                Dim cmd As New MySqlCommand(query, connect)
                cmd.Parameters.AddWithValue("@iName", "%" & itemName & "%")
                Using adp As New MySqlDataAdapter(cmd)
                    Dim set1 As New DataSet
                    adp.Fill(set1, "menu")
                    tabpage10_DataGridView.DataSource = Nothing
                    tabpage10_DataGridView.DataSource = set1.Tables("menu")
                End Using
                ChangeRowColors10()
                ChangeColumnHeaders10()
            Catch ex As Exception
                MsgBox("資料查詢失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
    End Sub

    Private Sub tabpage10_B_return_Click(sender As Object, e As EventArgs) Handles tabpage10_B_return.Click
        TabControl1.SelectedIndex = 8
    End Sub

#End Region
#Region "訂單"
#Region "頁面page11設計"
    Private Sub Centertabpage11()

        tabpage11_B_return.Image = My.Resources.home鍵
        tabpage11_P_background.Image = My.Resources.商家頁面
        tabpage11_B_list.Image = My.Resources.淡藍
        tabpage11_B_query.Image = My.Resources.淡藍
        tabpage11_B_update.Image = My.Resources.淡藍

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage11_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage11_T_ordernumber.Location = New Point(x - 350, y + 233)
        tabpage11_C_state.Location = New Point(x - 350, y + 305)
        tabpage11_B_query.Location = New Point(x - 150, y + 227)
        tabpage11_B_list.Location = New Point(x + 50, y + 227)
        tabpage11_B_return.Location = New Point(x + 550, y + 300)
        tabpage11_B_update.Location = New Point(x - 150, y + 300)
        tabpage11_L_ordernumber.Location = New Point(x - 600, y + 230)
        tabpage11_L_state.Location = New Point(x - 600, y + 300)
        tabpage11_DataGridView.Location = New Point(x - 600, y - 300)

        tabpage11_B_list.Parent = tabpage11_P_background
        tabpage11_B_query.Parent = tabpage11_P_background
        tabpage11_B_return.Parent = tabpage11_P_background
        tabpage11_B_update.Parent = tabpage11_P_background
        tabpage11_L_ordernumber.Parent = tabpage11_P_background
        tabpage11_L_state.Parent = tabpage11_P_background
        tabpage11_L_timer.Parent = tabpage11_P_background

    End Sub
#End Region
    Private Sub tabpage11_B_update_Click(sender As Object, e As EventArgs) Handles tabpage11_B_update.Click
        ' 獲取DataGridView中選中的行數
        If tabpage11_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = tabpage11_DataGridView.SelectedRows(0)
            Dim oId As Integer = Integer.Parse(selectedRow.Cells("Order_number").Value.ToString())

            ' 獲取ComboBox中的新值
            Dim newOrderStatus As String = tabpage11_C_state.SelectedItem.ToString()

            ' 更新資料表中的 Order_status
            Getconnect()
            If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
                Try
                    ' 更新訂單狀態
                    Dim updateQuery As String = "UPDATE order_management SET Order_status = @OrderStatus WHERE Order_number = @OrderNumber"
                    Using updateCmd As New MySqlCommand(updateQuery, connect)
                        updateCmd.Parameters.AddWithValue("@OrderStatus", newOrderStatus)
                        updateCmd.Parameters.AddWithValue("@OrderNumber", oId)
                        updateCmd.ExecuteNonQuery()
                    End Using

                    ' 如果訂單狀態為 "已完成"，則更新庫存數量
                    If newOrderStatus = "已完成" Then
                        ' 獲取與Order_number對應的所有iId和oQuantity
                        Dim orderListQuery As String = "SELECT iId, oQuantity FROM order_list WHERE oId = @OrderNumber"
                        Dim orderList As New List(Of Tuple(Of Integer, Integer))
                        Using orderListCmd As New MySqlCommand(orderListQuery, connect)
                            orderListCmd.Parameters.AddWithValue("@OrderNumber", oId)
                            Using reader As MySqlDataReader = orderListCmd.ExecuteReader()
                                While reader.Read()
                                    Dim iId As Integer = Convert.ToInt32(reader("iId"))
                                    Dim oQuantity As Integer = Convert.ToInt32(reader("oQuantity"))
                                    orderList.Add(Tuple.Create(iId, oQuantity))
                                End While
                            End Using ' 確保在開啟新 reader 之前關閉它
                        End Using

                        ' 遍歷所有iId，更新對應的庫存
                        For Each item In orderList
                            Dim iId As Integer = item.Item1
                            Dim oQuantity As Integer = item.Item2

                            ' 獲取與iId對應的所有stock_id和material_name
                            Dim materialQuery As String = "SELECT stock_id, material_name FROM products_material WHERE iId = @iId"
                            Dim materialList As New List(Of Tuple(Of Integer, String))
                            Using materialCmd As New MySqlCommand(materialQuery, connect)
                                materialCmd.Parameters.AddWithValue("@iId", iId)
                                Using reader As MySqlDataReader = materialCmd.ExecuteReader()
                                    While reader.Read()
                                        Dim stockId As Integer = Convert.ToInt32(reader("stock_id"))
                                        Dim materialName As String = reader("material_name").ToString()
                                        materialList.Add(Tuple.Create(stockId, materialName))
                                    End While
                                End Using ' 確保在開啟新 reader 之前關閉它
                            End Using

                            ' 更新對應的庫存數量
                            For Each material In materialList
                                Dim stockId As Integer = material.Item1
                                Dim materialName As String = material.Item2

                                Dim updateStockQuery As String = "UPDATE stock SET material_amount = material_amount - @oQuantity WHERE stock_id = @stockId AND material_name = @materialName"
                                Using updateStockCmd As New MySqlCommand(updateStockQuery, connect)
                                    updateStockCmd.Parameters.AddWithValue("@oQuantity", oQuantity)
                                    updateStockCmd.Parameters.AddWithValue("@stockId", stockId)
                                    updateStockCmd.Parameters.AddWithValue("@materialName", materialName)
                                    updateStockCmd.ExecuteNonQuery()
                                End Using
                            Next
                        Next

                        ' 獲取會員電話號碼
                        Dim memberPhoneQuery As String = "SELECT member_phone FROM order_management WHERE Order_number = @OrderNumber"
                        Dim memberPhone As String = ""
                        Using memberPhoneCmd As New MySqlCommand(memberPhoneQuery, connect)
                            memberPhoneCmd.Parameters.AddWithValue("@OrderNumber", oId)
                            memberPhone = Convert.ToString(memberPhoneCmd.ExecuteScalar())
                        End Using

                        ' 確認會員電話號碼是否存在
                        If Not String.IsNullOrEmpty(memberPhone) Then
                            ' 更新會員點數
                            Dim updateMemberPointsQuery As String = "UPDATE member SET member_point = member_point + 1 WHERE member_phone = @Phone"
                            Using updateMemberPointsCmd As New MySqlCommand(updateMemberPointsQuery, connect)
                                updateMemberPointsCmd.Parameters.AddWithValue("@Phone", memberPhone)
                                updateMemberPointsCmd.ExecuteNonQuery()
                            End Using
                        Else
                            MsgBox("無法獲取會員電話號碼，無法更新會員點數。")
                        End If
                    End If

                    MsgBox("訂單狀態已成功更新。")
                    tabpage11_C_state.Text = " "
                    ' 重新查詢並更新 DataGridView
                    Dim query As String = "SELECT Order_number, Order_time, Order_status, Order_sum, member_phone FROM order_management order by Order_time desc"
                    Using cmd As New MySqlCommand(query, connect)
                        Dim adapter As New MySqlDataAdapter(cmd)
                        Dim dataset As New DataSet
                        adapter.Fill(dataset)
                        tabpage11_DataGridView.DataSource = dataset.Tables(0)
                    End Using
                Catch ex As Exception
                    MsgBox("訂單狀態更新失敗: " & ex.Message)
                Finally
                    connect.Close()
                End Try
            Else
                MsgBox("無法連接到資料庫。")
            End If
        Else
            MsgBox("請選擇要修改狀態的訂單")
        End If
        ChangeColumnHeaders11()
        ChangeRowColors11()
    End Sub
    Private Sub tabpage11_B_query_Click(sender As Object, e As EventArgs) Handles tabpage11_B_query.Click
        tabpage11_DataGridView.DataSource = Nothing
        Dim oId As Integer
        ' 嘗試將文本框的值轉換為整數
        If Integer.TryParse(tabpage11_T_ordernumber.Text, oId) Then
            Getconnect()
            If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
                Try
                    Dim query As String = "SELECT * FROM order_list WHERE oid = @oId"
                    Using cmd As New MySqlCommand(query, connect)
                        cmd.Parameters.AddWithValue("@oId", oId)
                        ' 建立資料適配器
                        Dim adapter As New MySqlDataAdapter(cmd)
                        ' 建立資料集
                        Dim dataset As New DataSet
                        ' 填充資料集
                        adapter.Fill(dataset)
                        tabpage11_DataGridView.DataSource = dataset.Tables(0)
                    End Using
                Catch ex As Exception
                    MsgBox("查詢訂單失敗: " & ex.Message)
                Finally
                    connect.Close()
                End Try
            Else
                MsgBox("無法連接資料庫。")
            End If
        Else
            MsgBox("無效的訂單號碼。")
        End If
        ChangeColumnHeaders14()
        ChangeRowColors11()
    End Sub
    Private Sub tabpage11_B_list_Click(sender As Object, e As EventArgs) Handles tabpage11_B_list.Click
        tabpage11_DataGridView.DataSource = Nothing
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                Dim query As String = "SELECT Order_number, Order_time, Order_status, Order_sum, member_phone FROM order_management order by Order_time desc"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)
                    '連接DataGridView 的資料來源
                    tabpage11_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("訂單顯示失敗: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接資料庫。")
        End If
        tabpage11_T_ordernumber.Text = ""
        ChangeColumnHeaders11()
        ChangeRowColors11()
    End Sub
    Private Sub tabpage11_B_return_Click(sender As Object, e As EventArgs) Handles tabpage11_B_return.Click
        TabControl1.SelectedIndex = 8
    End Sub
    Public Sub ChangeColumnHeaders14()
        If tabpage11_DataGridView.Columns.Count > 0 Then
            tabpage11_DataGridView.Columns(0).HeaderText = "訂單編號"
            tabpage11_DataGridView.Columns(1).HeaderText = "商品編號"
            tabpage11_DataGridView.Columns(2).HeaderText = "商品名稱"
            tabpage11_DataGridView.Columns(3).HeaderText = "數量"
            tabpage11_DataGridView.Columns(4).HeaderText = "總金額"
            tabpage11_DataGridView.Columns(5).HeaderText = "下單時間"
            tabpage11_DataGridView.Columns(6).HeaderText = "會員電話"
        End If
    End Sub

#End Region
#Region "庫存查詢"
#Region "頁面page12設計"
    Private Sub Centertabpage12()

        tabpage12_B_return.Image = My.Resources.返回箭頭
        tabpage12_P_background.Image = My.Resources.存貨畫面
        tabpage12_B_delete.Image = My.Resources.黃橙
        tabpage12_B_back.Image = My.Resources.黃橙
        tabpage12_B_query.Image = My.Resources.黃橙

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage12_L_timer.Location = New Point(Me.Width - 350, 10)

        tabpage12_B_delete.Location = New Point(x - 390, y + 100)
        tabpage12_B_query.Location = New Point(x - 610, y + 100)
        tabpage12_B_back.Location = New Point(x - 390, y + 200)

        tabpage12_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage12_L_goods.Location = New Point(x - 630, y - 200)
        tabpage12_T_goods.Location = New Point(x - 410, y - 200)
        tabpage12_L_number.Location = New Point(x - 630, y - 100)
        tabpage12_T_number.Location = New Point(x - 410, y - 100)
        tabpage12_L_amount.Location = New Point(x - 630, y)
        tabpage12_T_money.Location = New Point(x - 410, y)
        tabpage12_DataGridView.Location = New Point(x - 150, y - 200)


        tabpage12_B_delete.Parent = tabpage12_P_background
        tabpage12_B_query.Parent = tabpage12_P_background
        tabpage12_B_return.Parent = tabpage12_P_background
        tabpage12_B_back.Parent = tabpage12_P_background
        tabpage12_L_goods.Parent = tabpage12_P_background
        tabpage12_L_amount.Parent = tabpage12_P_background
        tabpage12_L_number.Parent = tabpage12_P_background
        tabpage12_L_timer.Parent = tabpage12_P_background

    End Sub
#End Region
    Private Sub LoadStockData() '更新庫存DataGridView
        Try
            Using connection As New MySqlConnection("server=localhost;user=root;database=store")
                connection.Open()
                Dim query As String = "SELECT * FROM store.stock"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    tabpage12_DataGridView.DataSource = dataTable
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tabpage12_B_delete_Click(sender As Object, e As EventArgs) Handles tabpage12_B_delete.Click
        connect = New MySqlConnection
        connect.ConnectionString = "server=localhost;user=root;database=store"
        Try
            connect.Open()
            Dim Query As String
            Query = "DELETE FROM store.stock WHERE stock_id = @id"
            COMMAND = New MySqlCommand(Query, connect)
            COMMAND.Parameters.AddWithValue("@id", tabpage12_T_number.Text) ' 使用 stock_id 作為刪除條件
            COMMAND.ExecuteNonQuery()
            LoadStockData()
            MsgBox("刪除成功")
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            connect.Close()
        End Try
        tabpage12_T_goods.Text = ""
        tabpage12_T_money.Text = ""
        tabpage12_T_number.Text = ""
        ChangeRowColors12()
    End Sub
    Private Sub tabpage12_B_query_Click(sender As Object, e As EventArgs) Handles tabpage12_B_query.Click
        ' 獲取使用者輸入的庫存名稱
        Dim stockname As String = tabpage12_T_goods.Text
        ' 確保庫存名稱不是空的
        If String.IsNullOrEmpty(stockname) Then
            MsgBox("請輸入庫存代碼。")
            Return
        End If
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 查詢庫存資料
                Dim query As String = "SELECT * FROM stock WHERE material_name = @name"
                Using cmd As New MySqlCommand(query, connect)
                    cmd.Parameters.AddWithValue("@name", stockname)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)
                    tabpage12_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢庫存時出錯: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage12_T_number.Text = ""
        ChangeRowColors12()
    End Sub
    Private Sub tabpage12_DataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles tabpage12_DataGridView.SelectionChanged
        If tabpage12_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = tabpage12_DataGridView.SelectedRows(0)
            tabpage12_T_goods.Text = selectedRow.Cells("material_name").Value.ToString()
            tabpage12_T_number.Text = selectedRow.Cells("stock_id").Value.ToString()
            tabpage12_T_money.Text = selectedRow.Cells("material_amount").Value.ToString()
        End If
    End Sub
    Private Sub tabpage12_B_back_Click(sender As Object, e As EventArgs) Handles tabpage12_B_back.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 查詢所有庫存資料
                Dim query As String = "SELECT * FROM stock"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)
                    tabpage12_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢庫存時出錯: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage12_T_goods.Text = ""
        ChangeRowColors12()
    End Sub

    Private Sub tabpage12_B_return_Click(sender As Object, e As EventArgs) Handles tabpage12_B_return.Click
        TabControl1.SelectedIndex = 8
    End Sub


#End Region
#Region "進貨查詢"
#Region "頁面page13設計"
    Private Sub Centertabpage13()

        tabpage13_B_return.Image = My.Resources.home鍵
        tabpage13_B_back.Image = My.Resources.返回箭頭
        tabpage13_P_background.Image = My.Resources.商家頁面
        tabpage13_B_add.Image = My.Resources.藍烏雲
        tabpage13_B_delete.Image = My.Resources.藍烏雲
        tabpage13_B_query.Image = My.Resources.藍烏雲
        tabpage13_B_update.Image = My.Resources.藍烏雲

        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2
        tabpage13_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage13_B_add.Location = New Point(x - 650, y + 150)
        tabpage13_B_back.Location = New Point(x + 550, y + 300)
        tabpage13_B_delete.Location = New Point(x - 390, y + 150)
        tabpage13_B_query.Location = New Point(x - 650, y + 240)
        tabpage13_B_update.Location = New Point(x - 390, y + 240)
        tabpage13_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage13_L_id.Location = New Point(x - 680, y - 277)
        tabpage13_T_id.Location = New Point(x - 380, y - 280)
        tabpage13_L_amount.Location = New Point(x - 680, y - 207)
        tabpage13_T_amount.Location = New Point(x - 380, y - 210)
        tabpage13_L_number.Location = New Point(x - 680, y - 137)
        tabpage13_T_number.Location = New Point(x - 380, y - 140)
        tabpage13_L_goods.Location = New Point(x - 680, y - 67)
        tabpage13_T_goods.Location = New Point(x - 380, y - 70)
        tabpage13_L_total.Location = New Point(x - 680, y + 3)
        tabpage13_T_total.Location = New Point(x - 380, y)
        tabpage13_L_date.Location = New Point(x - 680, y + 73)
        tabpage13_T_date.Location = New Point(x - 380, y + 70)
        tabpage13_MonthCalendar.Location = New Point(x - 380, y + 70)
        tabpage13_DataGridView.Location = New Point(x - 150, y - 280)

        tabpage13_B_add.Parent = tabpage13_P_background
        tabpage13_B_back.Parent = tabpage13_P_background
        tabpage13_B_delete.Parent = tabpage13_P_background
        tabpage13_B_query.Parent = tabpage13_P_background
        tabpage13_B_return.Parent = tabpage13_P_background
        tabpage13_B_update.Parent = tabpage13_P_background
        tabpage13_L_id.Parent = tabpage13_P_background
        tabpage13_L_goods.Parent = tabpage13_P_background
        tabpage13_L_amount.Parent = tabpage13_P_background
        tabpage13_L_number.Parent = tabpage13_P_background
        tabpage13_L_total.Parent = tabpage13_P_background
        tabpage13_L_date.Parent = tabpage13_P_background
        tabpage13_L_timer.Parent = tabpage13_P_background

    End Sub
#End Region
    Private Sub LoadPurchaseData() '更新進貨的DataGridView'
        Try
            Using connection As New MySqlConnection("server=localhost;user=root;database=store")
                connection.Open()
                Dim query As String = "SELECT * FROM store.purchase_records"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    tabpage13_DataGridView.DataSource = dataTable
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("更新出錯!：" & ex.Message)
        End Try
    End Sub

    Private Sub tabpage13_B_add_Click(sender As Object, e As EventArgs) Handles tabpage13_B_add.Click
        connect = New MySqlConnection
        connect.ConnectionString = "server=localhost;user=root;database=store"
        Try
            connect.Open()

            ' 檢查 material_name 是否存在於 stock 表格中
            Dim checkStockQuery As String = "SELECT stock_id FROM store.stock WHERE material_name = @name"
            Dim checkStockCommand As New MySqlCommand(checkStockQuery, connect)
            checkStockCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
            Dim stockId As Object = checkStockCommand.ExecuteScalar()

            If stockId IsNot Nothing Then
                ' material_name 存在於 stock 表格中，獲取 stock_id
                Dim stockIdInt As Integer = Convert.ToInt32(stockId)
                ' 插入 purchase_records 資料
                Dim insertPurchaseQuery As String = "INSERT INTO store.purchase_records(stock_id, purchase_order,material_name, quantity, purchase_date, purchase_sum) " &
                                                "VALUES (@stock_id,@purchase_order,@name, @amount, @date, @sum)"
                Dim insertPurchaseCommand As New MySqlCommand(insertPurchaseQuery, connect)
                insertPurchaseCommand.Parameters.AddWithValue("@stock_id", stockIdInt)
                insertPurchaseCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@amount", tabpage13_T_amount.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@date", tabpage13_T_date.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@sum", tabpage13_T_total.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@purchase_order", tabpage13_T_number.Text)
                insertPurchaseCommand.ExecuteNonQuery()

                ' 更新庫存資料
                Dim updateStockQuery As String = "UPDATE store.stock SET material_amount = material_amount + @amount WHERE stock_id = @stock_id"
                Dim updateStockCommand As New MySqlCommand(updateStockQuery, connect)
                updateStockCommand.Parameters.AddWithValue("@amount", tabpage13_T_amount.Text)
                updateStockCommand.Parameters.AddWithValue("@stock_id", stockIdInt)
                updateStockCommand.ExecuteNonQuery()
            Else
                ' material_name 不存在於 stock 表格中，插入新的庫存資料並獲取 stock_id
                Dim insertStockQuery As String = "INSERT INTO store.stock(material_name, material_amount) VALUES (@name, @amount)"
                Dim insertStockCommand As New MySqlCommand(insertStockQuery, connect)
                insertStockCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
                insertStockCommand.Parameters.AddWithValue("@amount", tabpage13_T_amount.Text)
                insertStockCommand.ExecuteNonQuery()

                ' 獲取新插入的 stock_id
                Dim newStockIdQuery As String = "SELECT stock_id FROM store.stock WHERE material_name = @name"
                Dim newStockIdCommand As New MySqlCommand(newStockIdQuery, connect)
                newStockIdCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
                Dim newStockId As Integer = Convert.ToInt32(newStockIdCommand.ExecuteScalar())

                ' 插入 purchase_records 資料
                Dim insertPurchaseQuery As String = "INSERT INTO store.purchase_records(stock_id, material_name, quantity, purchase_date, purchase_sum) " &
                                                "VALUES (@stock_id, @name, @amount, @date, @sum)"
                Dim insertPurchaseCommand As New MySqlCommand(insertPurchaseQuery, connect)
                insertPurchaseCommand.Parameters.AddWithValue("@stock_id", newStockId)
                insertPurchaseCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@amount", tabpage13_T_amount.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@date", tabpage13_T_date.Text)
                insertPurchaseCommand.Parameters.AddWithValue("@sum", tabpage13_T_total.Text)
                insertPurchaseCommand.ExecuteNonQuery()
            End If

            LoadPurchaseData()
            LoadStockData()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            connect.Close()
        End Try

        tabpage13_T_goods.Text = ""
        tabpage13_T_amount.Text = ""
        tabpage13_T_date.Text = ""
        tabpage13_T_id.Text = ""
        tabpage13_T_number.Text = ""
        tabpage13_T_total.Text = ""
        ChangeRowColors13()
    End Sub
    Private Sub tabpage13_B_delete_Click(sender As Object, e As EventArgs) Handles tabpage13_B_delete.Click
        connect = New MySqlConnection
        connect.ConnectionString = "server=localhost;user=root;database=store"
        Try
           connect.Open()

        ' 獲取要刪除的數量
        Dim quantityQuery As String = "SELECT quantity FROM store.purchase_records WHERE purchase_order = @id AND material_name = @name"
        Dim quantityCommand As New MySqlCommand(quantityQuery, connect)
        quantityCommand.Parameters.AddWithValue("@id", tabpage13_T_number.Text)
        quantityCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
        Dim quantity As Integer = Convert.ToInt32(quantityCommand.ExecuteScalar())

        ' 刪除 purchase_records 中的記錄
        Dim deleteQuery As String = "DELETE FROM store.purchase_records WHERE purchase_order = @id AND material_name = @name"
        Dim deleteCommand As New MySqlCommand(deleteQuery, connect)
        deleteCommand.Parameters.AddWithValue("@id", tabpage13_T_number.Text)
        deleteCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
        deleteCommand.ExecuteNonQuery()

        ' 更新 stock 中的 material_amount
        Dim updateStockQuery As String = "UPDATE store.stock SET material_amount = material_amount - @quantity WHERE material_name = @name"
        Dim updateStockCommand As New MySqlCommand(updateStockQuery, connect)
        updateStockCommand.Parameters.AddWithValue("@quantity", quantity)
        updateStockCommand.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
            updateStockCommand.ExecuteNonQuery()
            LoadPurchaseData()
            LoadStockData()
        Catch ex As MySqlException
            MessageBox.Show("删除資料時出錯：" & ex.Message)
        Finally
            connect.Close()
        End Try
        tabpage13_T_goods.Text = ""
        tabpage13_T_amount.Text = ""
        tabpage13_T_date.Text = ""
        tabpage13_T_id.Text = ""
        tabpage13_T_number.Text = ""
        tabpage13_T_total.Text = ""
        ChangeRowColors13()
    End Sub
    Private Sub tabpage13_B_update_Click(sender As Object, e As EventArgs) Handles tabpage13_B_update.Click
        connect = New MySqlConnection
        connect.ConnectionString = "server=localhost;user=root;database=store"
        Try
            connect.Open()
            Dim Query As String
            Query = "UPDATE store.purchase_records SET material_name = @name, quantity = @amount, purchase_date = @date, purchase_sum = @sum WHERE  stock_id = @id and purchase_order = @order"
            COMMAND = New MySqlCommand(Query, connect)
            COMMAND.Parameters.AddWithValue("@id", tabpage13_T_id.Text)
            COMMAND.Parameters.AddWithValue("@order", tabpage13_T_number.Text)
            COMMAND.Parameters.AddWithValue("@name", tabpage13_T_goods.Text)
            COMMAND.Parameters.AddWithValue("@amount", tabpage13_T_amount.Text)
            COMMAND.Parameters.AddWithValue("@date", tabpage13_T_date.Text)
            COMMAND.Parameters.AddWithValue("@sum", tabpage13_T_total.Text)
            COMMAND.ExecuteNonQuery()
            MessageBox.Show("更新成功")
            LoadPurchaseData()
        Catch ex As MySqlException
            MessageBox.Show("更新資料時出錯：" & ex.Message)
        Finally
            connect.Close()
        End Try
        tabpage13_T_goods.Text = ""
        tabpage13_T_amount.Text = ""
        tabpage13_T_date.Text = ""
        tabpage13_T_id.Text = ""
        tabpage13_T_number.Text = ""
        tabpage13_T_total.Text = ""
        ChangeRowColors13()
    End Sub
    Private Sub tabpage13_B_query_Click(sender As Object, e As EventArgs) Handles tabpage13_B_query.Click
        Dim connect As New MySqlConnection("server=localhost;user=root;database=store")
        Try
            connect.Open()
            Dim Query As String = "SELECT * FROM store.purchase_records WHERE purchase_order = @order"
            Dim COMMAND As New MySqlCommand(Query, connect)
            COMMAND.Parameters.AddWithValue("@order", tabpage13_T_number.Text)
            Dim adapter As New MySqlDataAdapter(COMMAND)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            '查詢結果綁定到到 BindingSource
            If dataTable.Rows.Count > 0 Then
                tabpage13_T_number.Text = " "
                PurchaserecordsBindingSource.DataSource = dataTable
                tabpage13_DataGridView.DataSource = PurchaserecordsBindingSource
                MessageBox.Show("查詢成功！")
            Else
                MessageBox.Show("未找到該筆資料。")
                PurchaserecordsBindingSource.DataSource = Nothing
            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
                connect.Close()
            End If
        End Try
        ChangeRowColors13()
    End Sub
    Private Sub tabpage13_DataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles tabpage13_DataGridView.SelectionChanged
        If tabpage13_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = tabpage13_DataGridView.SelectedRows(0)
            tabpage13_T_goods.Text = selectedRow.Cells("material_name").Value.ToString()
            tabpage13_T_number.Text = selectedRow.Cells("purchase_order").Value.ToString()
            tabpage13_T_amount.Text = selectedRow.Cells("quantity").Value.ToString()
            tabpage13_T_date.Text = selectedRow.Cells("purchase_date").Value.ToString()
            tabpage13_T_total.Text = selectedRow.Cells("purchase_sum").Value.ToString()
            tabpage13_T_id.Text = selectedRow.Cells("stock_id").Value.ToString()
        End If
    End Sub
    Private Sub tabpage13_B_back_Click(sender As Object, e As EventArgs) Handles tabpage13_B_back.Click
        Getconnect()
        If connect IsNot Nothing AndAlso connect.State = ConnectionState.Open Then
            Try
                ' 查詢所有庫存資料
                Dim query As String = "SELECT * FROM purchase_records"
                Using cmd As New MySqlCommand(query, connect)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataset As New DataSet
                    adapter.Fill(dataset)
                    tabpage13_DataGridView.DataSource = dataset.Tables(0)
                End Using
            Catch ex As Exception
                MsgBox("查詢庫存時出錯: " & ex.Message)
            Finally
                connect.Close()
            End Try
        Else
            MsgBox("無法連接到資料庫。")
        End If
        tabpage13_T_goods.Text = ""
        tabpage13_T_number.Text = ""
        tabpage13_T_amount.Text = ""
        tabpage13_T_date.Text = ""
        tabpage13_T_total.Text = ""
        tabpage13_T_id.Text = ""
        ChangeRowColors13()
    End Sub
    Private Sub tabpage13_B_return_Click(sender As Object, e As EventArgs) Handles tabpage13_B_return.Click
        TabControl1.SelectedIndex = 8
    End Sub
    Private Sub tabpage13_T_date_TextChanged(sender As Object, e As EventArgs) Handles tabpage13_T_date.Click
        tabpage13_MonthCalendar.Visible = True
    End Sub
    Private Sub tabpage13_MonthCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles tabpage13_MonthCalendar.DateSelected
        tabpage13_T_date.Text = tabpage13_MonthCalendar.SelectionStart.ToShortDateString()
        tabpage13_MonthCalendar.Visible = False
    End Sub
#End Region
#Region "報表"
#Region "頁面page14設計"
    Private Sub Centertabpage14()

        tabpage14_B_return.Image = My.Resources.home鍵
        tabpage14_P_background.Image = My.Resources.報表畫面1
        tabpage14_B_query.Image = My.Resources.紅色
        Dim x As Integer = (Me.ClientSize.Width) / 2
        Dim y As Integer = (Me.ClientSize.Height) / 2

        tabpage14_L_timer.Location = New Point(Me.Width - 350, 10)
        tabpage14_B_return.Location = New Point(x - 750, 2 * y - 75)
        tabpage14_B_query.Location = New Point(x + 580, 2 * y - 75)
        ChartSalary.Location = New Point(x - 300, y - 250)
        DataGridView1.Location = New Point(x - 650, y - 150)

        tabpage14_L_timer.Parent = tabpage14_P_background
        tabpage14_B_return.Parent = tabpage14_P_background
        tabpage14_B_query.Parent = tabpage14_P_background

    End Sub

    Private Sub tabpage14_B_return_Click(sender As Object, e As EventArgs) Handles tabpage14_B_return.Click
        TabControl1.SelectedIndex = 8
        CloseChartAndDataGridView()
    End Sub

    Private Sub CloseChartAndDataGridView()

        DataGridView1.DataSource = Nothing
        ChartSalary.Series.Clear()
        ChartSalary.Titles.Clear()

    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Class DTConnection
        Dim conect As New MySqlConnection("server=localhost;user=root;password=;database=store")
        Public Function Open() As MySqlConnection
            Try
                conect.Open()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return conect
        End Function

        Public Function Close() As MySqlConnection
            Try
                conect.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return conect
        End Function
    End Class
    Private Sub tabpage14_B_query_Click(sender As Object, e As EventArgs) Handles tabpage14_B_query.Click
        mycmd.Connection = myconnection.Open
        '這裡改database相關訊息'
        'mycmd.CommandText = "select Order_number,Order_time,Order_sum from order_management order by length(Order_number),Order_time asc "'
        'mycmd.CommandText = "SELECT Order_time AS order_date, SUM(Order_sum) AS daily_order_sum FROM order_management WHERE Order_time >= DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY) GROUP BY Order_time ORDER BY Order_time ASC;"
        mycmd.CommandText = "Select 
                             Date(Order_time) As order_date, 
                             SUM(Order_sum) As daily_order_sum 
                             FROM
                             order_management
                             WHERE
                             Order_time >= DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY) 
                             GROUP BY 
                             order_date
                             ORDER BY 
                             order_date Asc;"
        dadapter = New MySqlDataAdapter(mycmd)
        dtable.Rows.Clear()
        dadapter.Fill(dtable)
        DataGridView1.DataSource = dtable
        myconnection.Close()
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ChangeColumnHeaders15()
        outputEXcel()
        chart()
        AdjustDataGridViewSize(DataGridView1)

    End Sub

    Private Sub AdjustDataGridViewSize(dgv As DataGridView)
        ' 計算所有列的總寬度
        Dim totalWidth As Integer = dgv.RowHeadersWidth
        For Each column As DataGridViewColumn In dgv.Columns
            totalWidth += column.Width
        Next

        ' 計算所有行的總高度
        Dim totalHeight As Integer = dgv.ColumnHeadersHeight
        For Each row As DataGridViewRow In dgv.Rows
            totalHeight += row.Height
        Next

        ' 增加一些額外的空間，以確保不會出現滾動條
        Const extraSpace As Integer = 5
        totalWidth += extraSpace
        totalHeight += extraSpace

        ' 設置 DataGridView 的大小
        dgv.ClientSize = New Size(totalWidth, totalHeight)
    End Sub

    Public Sub ChangeColumnHeaders15()
        If DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns(0).HeaderText = "日期"
            DataGridView1.Columns(1).HeaderText = "當日營業額"
        End If
    End Sub
    Public Sub outputEXcel()
        Try
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer
            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.Columns.AutoFit()
            For i = 0 To DataGridView1.RowCount - 2
                For j = 0 To DataGridView1.ColumnCount - 1
                    For k As Integer = 1 To DataGridView1.Columns.Count
                        xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                    Next
                Next
            Next
            Dim fName As String = "Data"
            Using sfd As New SaveFileDialog
                sfd.Title = "Save As"
                sfd.OverwritePrompt = True
                sfd.FileName = fName
                sfd.DefaultExt = ".xlsx"
                sfd.Filter = "Excel Workbook(*.xlsx)|"
                sfd.AddExtension = True
                If sfd.ShowDialog() = DialogResult.OK Then
                    xlWorkSheet.SaveAs(sfd.FileName)
                    xlWorkBook.Close()
                    xlApp.Quit()
                    ReleaseObject(xlApp)
                    ReleaseObject(xlWorkBook)
                    ReleaseObject(xlWorkSheet)
                    MsgBox("Excel Builded !", MsgBoxStyle.Information, "Notice")
                End If
            End Using
        Catch ex As Exception
            myconnection.Close()
            'MsgBox("Fail To Build Excel ! " & vbCrLf & " Error: " & ex.Message)
        End Try
    End Sub

    Public Sub chart()
        ' Check if DataGridView1 has data
        If DataGridView1.Rows.Count > 0 Then
            ' Get a reference to the chart control (assuming it's named 'ChartSalary')
            Dim chart1 As Chart = Me.ChartSalary

            ' Clear existing series (if any)
            chart1.Series.Clear()

            ' Calculate the starting date for past 7 days
            Dim startDate As DateTime = DateTime.Now.Subtract(TimeSpan.FromDays(7))

            ' Create a new line series
            Dim lineSeries As Series = chart1.Series.Add("營業額")
            lineSeries.ChartType = SeriesChartType.Line


            ' 設定圖表的主標題
            chart1.Titles.Add("當周營業額")
            chart1.Titles(0).Font = New Font("Arial", 16, FontStyle.Bold)

            ' Set marker style
            lineSeries.MarkerStyle = MarkerStyle.Circle  ' Adjust marker style as desired
            lineSeries.MarkerSize = 8  ' Adjust marker size as desired

            ' Extract data from DataGridView1 within the past 7 days
            For i As Integer = 0 To DataGridView1.RowCount - 1
                Try
                    ' Assuming date in first column and daily order sum in second column
                    Dim orderDate As DateTime = Convert.ToDateTime(DataGridView1.Item(0, i).Value)
                    Dim dailyOrderSum As Double = Convert.ToDouble(DataGridView1.Item(1, i).Value)

                    ' Filter data for dates within the past 7 days
                    If orderDate.Date >= startDate.Date Then
                        lineSeries.Points.AddXY(orderDate, dailyOrderSum)
                    End If
                Catch ex As Exception
                    ' Handle potential conversion errors gracefully (e.g., log or display a message)
                    Debug.WriteLine("Error converting data in row " & (i + 1) & ": " & ex.Message)
                End Try
            Next

            ' Set chart X-axis properties
            chart1.ChartAreas(0).AxisX.Minimum = startDate.Date.ToOADate()
            chart1.ChartAreas(0).AxisX.Maximum = DateTime.Now.Date.ToOADate()  ' Adjust for inclusive end date
            chart1.ChartAreas(0).AxisX.Title = "日期(天)"
            chart1.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 12, FontStyle.Bold)

            ' Set chart Y-axis properties and manually adjust Y-axis range
            ' 設定圖表Y軸標題
            chart1.ChartAreas(0).AxisY.Title = "總\n金\n額\n(元)"
            ' 設定Y軸標題對齊
            chart1.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center
            ' 確保Y軸標題垂直顯示
            chart1.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Horizontal
            ' (可選) 設定標題字體大小和樣式
            chart1.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 12, FontStyle.Bold)
            Dim minDailyOrderSum As Integer = Integer.MaxValue  ' Initialize with maximum value
            Dim maxDailyOrderSum As Integer = Integer.MinValue  ' Initialize with minimum value

            For Each point As DataPoint In lineSeries.Points
                minDailyOrderSum = Math.Min(minDailyOrderSum, point.YValues(0))
                maxDailyOrderSum = Math.Max(maxDailyOrderSum, point.YValues(0))
            Next

            chart1.ChartAreas(0).AxisY.Minimum = minDailyOrderSum - (minDailyOrderSum) ' Add a buffer of 10% below minimum
            chart1.ChartAreas(0).AxisY.Maximum = maxDailyOrderSum + (maxDailyOrderSum) ' Add a buffer of 10% above maximum
        Else
            MsgBox("There is no data in DataGridView1 to display in the chart.", MsgBoxStyle.Information, "No Data")
        End If
    End Sub
#End Region
#End Region
#Region "時間"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim thisDate As Date
        thisDate = Today

        tabpage1_L_timer.Text = Today & "  " & TimeString
        tabpage2_L_timer.Text = Today & "  " & TimeString
        tabpage3_L_timer.Text = Today & "  " & TimeString
        tabpage4_L_timer.Text = Today & "  " & TimeString
        tabpage5_L_timer.Text = Today & "  " & TimeString
        tabpage6_L_timer.Text = Today & "  " & TimeString
        tabpage7_L_timer.Text = Today & "  " & TimeString
        tabpage8_L_timer.Text = Today & "  " & TimeString
        tabpage9_L_timer.Text = Today & "  " & TimeString
        tabpage10_L_timer.Text = Today & "  " & TimeString
        tabpage11_L_timer.Text = Today & "  " & TimeString
        tabpage12_L_timer.Text = Today & "  " & TimeString
        tabpage13_L_timer.Text = Today & "  " & TimeString
        tabpage14_L_timer.Text = Today & "  " & TimeString

    End Sub

#End Region
#Region "FormClosing"
    Private Sub Form_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
    End Sub









#End Region
End Class
