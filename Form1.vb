Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports Mysqlx
Imports System.Data.OleDb
Imports System.Net
Imports Microsoft.VisualBasic.ApplicationServices


Public Class Form1


    Dim connection As MySqlConnection = database.GetConnection()

    Dim isAdmin As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(130, 0, 0, 0)
        Panel3.BackColor = Color.FromArgb(150, 255, 255, 255)

        MakeButtonRoundedCorners(btnLogin, 50)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        Dim cornerRadius As Integer = 80
        Dim graphicsPath As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, Panel3.Width, Panel3.Height)

        graphicsPath.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        graphicsPath.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        graphicsPath.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        graphicsPath.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        graphicsPath.CloseFigure()

        Panel3.Region = New Region(graphicsPath)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Using gradientBrush As New LinearGradientBrush(Panel2.ClientRectangle, Color.Transparent, Color.Transparent, 90.0F)
            Dim blend As New ColorBlend()
            blend.Colors = New Color() {Color.DarkGreen, Color.DarkSeaGreen, Color.DarkGreen}
            blend.Positions = New Single() {0.0F, 0.5F, 1.0F}

            gradientBrush.InterpolationColors = blend

            e.Graphics.FillRectangle(gradientBrush, Panel2.ClientRectangle)
        End Using
    End Sub

    Private Sub MakeButtonRoundedCorners(button As Button, cornerRadius As Integer)
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(0, 0, button.Width, button.Height)

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()
        button.Region = New Region(path)
    End Sub



    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPass.Focus()
        End If
    End Sub


    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub




    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim inputUsername As String = txtEmail.Text
        Dim inputPassword As String = txtPass.Text

        If Not ValidateUserFromDatabase(inputUsername, inputPassword) Then
            MessageBox.Show("Invalid Username or Password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim authResult As Tuple(Of Integer, String, Integer, Integer) = AuthenticateUser(inputUsername, inputPassword)

        Dim authenticatedUserID As Integer = authResult.Item1
        Dim role As String = authResult.Item2
        Dim authenticatedProfessorID As Integer = authResult.Item3
        Dim assignmentID As Integer = authResult.Item4

        If authenticatedUserID > 0 Then
            If role = "Professor" Then
                Me.Hide()

                Dim form2 As New Form2(authenticatedProfessorID, assignmentID)
                form2.Show()

            ElseIf role = "Admin" Then

                Me.Hide()

                Dim form4 As New Form4(authenticatedUserID)
                form4.Show()

            Else
                MessageBox.Show("User role not recognized: " & role)
            End If
        Else
            MessageBox.Show("Invalid Username or Password. Please try again.")
        End If
    End Sub

    Private Function ValidateUserFromDatabase(email As String, password As String) As Boolean
        Try
            Using connection As MySqlConnection = database.GetConnection()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Dim query As String = "SELECT COUNT(*) FROM user WHERE Email = @Email AND password = @password"

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Email", email)
                    command.Parameters.AddWithValue("@password", password)

                    Dim userCount As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return userCount > 0
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred while validating the user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function





    Public Function AuthenticateUser(email As String, password As String) As Tuple(Of Integer, String, Integer, Integer)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT u.UserID, u.Role, p.ProfessorID " &
                              "FROM user AS u " &
                              "LEFT JOIN professor AS p ON u.UserID = p.UserID " &
                              "WHERE u.Email = @EMAIL AND u.IsArchived = 0;"

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@EMAIL", email.Trim())

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim userID As Integer = Convert.ToInt32(reader("UserID"))
                Dim role As String = reader("Role").ToString()
                Dim professorID As Integer = If(Not IsDBNull(reader("ProfessorID")), Convert.ToInt32(reader("ProfessorID")), 0)

                Dim assignmentID As Integer = 0

                Return Tuple.Create(userID, role, professorID, assignmentID)
            Else
                Return Tuple.Create(0, "", 0, 0)
            End If

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message)
            Return Tuple.Create(0, "", 0, 0)

        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message)
            Return Tuple.Create(0, "", 0, 0)

        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function


    Private Sub lnkForgot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgot.LinkClicked
        Dim userEmail As String = txtEmail.Text.Trim()

        If String.IsNullOrEmpty(userEmail) Then
            MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim queryUser As String = "SELECT COUNT(*) FROM user WHERE Email = @Email"
            Dim queryAdmin As String = "SELECT COUNT(*) FROM admin WHERE Email = @Email"
            Dim isEmailFound As Boolean = False
            Dim accountType As String = ""

            Using connection As MySqlConnection = database.GetConnection()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using cmd As New MySqlCommand(queryUser, connection)
                    cmd.Parameters.AddWithValue("@Email", userEmail)
                    Dim userCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If userCount > 0 Then
                        isEmailFound = True
                        accountType = "User"
                    End If
                End Using

                If Not isEmailFound Then
                    Using cmd As New MySqlCommand(queryAdmin, connection)
                        cmd.Parameters.AddWithValue("@Email", userEmail)
                        Dim adminCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        If adminCount > 0 Then
                            isEmailFound = True
                            accountType = "Admin"
                        End If
                    End Using
                End If
            End Using

            If Not isEmailFound Then
                MessageBox.Show("This email address is not registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim verificationCode As String = GenerateVerificationCode()

            Dim smtpServer As New SmtpClient("smtp.gmail.com")
            smtpServer.Port = 587
            smtpServer.EnableSsl = True
            smtpServer.UseDefaultCredentials = False
            smtpServer.Credentials = New System.Net.NetworkCredential("plpa73399@gmail.com", "qqwj erge tatm nnoo")

            smtpServer.Timeout = 30000

            Dim mail As New MailMessage()
            mail.From = New MailAddress("plpa73399@gmail.com")
            mail.To.Add(userEmail)
            mail.Subject = "Password Reset Verification Code"
            mail.Body = "Your verification code is: " & verificationCode

            smtpServer.Send(mail)

            MessageBox.Show("A verification code has been sent to your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim verifyForm As New Form5(verificationCode, userEmail, accountType)
            verifyForm.Show()

        Catch ex As SmtpException
            MessageBox.Show("Email sending failed: " & ex.Message & vbCrLf & "Stack Trace: " & ex.StackTrace, "SMTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If ex.InnerException IsNot Nothing Then
                MessageBox.Show("Inner Exception: " & ex.InnerException.Message, "SMTP Inner Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As MySqlException
            MessageBox.Show("Database connection failed: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function GenerateVerificationCode() As String
        Dim rand As New Random()
        Return rand.Next(100000, 999999).ToString()
    End Function
End Class


