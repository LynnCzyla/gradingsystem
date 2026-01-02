Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Text

Public Class Form6
    Private ReadOnly _verificationCode As String
    Private ReadOnly _userEmail As String
    Private ReadOnly _accountType As String

    Public Sub New(verificationCode As String, email As String, accountType As String)
        InitializeComponent()
        _verificationCode = verificationCode
        _userEmail = email
        _accountType = accountType
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, 255, 255, 255)

        MakeButtonRoundedCorners(btnReset, 50)
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim cornerRadius As Integer = 80
        Dim graphicsPath As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

        graphicsPath.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        graphicsPath.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        graphicsPath.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        graphicsPath.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        graphicsPath.CloseFigure()

        Panel1.Region = New Region(graphicsPath)
    End Sub

    Private Sub txtNewPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtConPass.Focus()
        End If
    End Sub



    Private Sub txtConPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnReset.Focus()
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim newPassword As String = txtNewPass.Text.Trim()
        Dim confirmPassword As String = txtConPass.Text.Trim()

        If String.IsNullOrEmpty(newPassword) OrElse String.IsNullOrEmpty(confirmPassword) Then
            MessageBox.Show("Please enter and confirm your new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If newPassword <> confirmPassword Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If newPassword.Length < 10 Then
            MessageBox.Show("Password must be at least 10 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsValidPassword(newPassword) Then
            MessageBox.Show("Password must contain a combination of uppercase and lowercase letters, numbers, and symbols.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Check account type to determine which table to update
            Dim tableName As String
            If _accountType = "Admin" Then
                tableName = "admin"
            ElseIf _accountType = "User" Then
                tableName = "user"
            Else
                MessageBox.Show("Invalid account type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim query As String = $"UPDATE {tableName} SET Password = @Password WHERE Email = @Email"

            Using connection As MySqlConnection = database.GetConnection()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Password", newPassword)
                    cmd.Parameters.AddWithValue("@Email", _userEmail)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Your password has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNewPass.Clear()
            txtConPass.Clear()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsValidPassword(password As String) As Boolean
        Dim hasUpperCase As Boolean = password.Any(Function(c) Char.IsUpper(c))
        Dim hasLowerCase As Boolean = password.Any(Function(c) Char.IsLower(c))
        Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
        Dim hasSpecialChar As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

        Return hasUpperCase AndAlso hasLowerCase AndAlso hasDigit AndAlso hasSpecialChar
    End Function

    Private Sub txtNewPass_TextChanged(sender As Object, e As EventArgs) Handles txtNewPass.TextChanged

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
End Class