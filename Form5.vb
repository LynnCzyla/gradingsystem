Imports System.Drawing.Drawing2D

Public Class Form5
    Private ReadOnly _verificationCode As String
    Private ReadOnly _userEmail As String
    Private ReadOnly _accountType As String

    Public Sub New(code As String, userEmail As String, accountType As String)
        InitializeComponent()
        _verificationCode = code
        _userEmail = userEmail
        _accountType = accountType
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If txtCode.Text.Trim() = _verificationCode Then
            MessageBox.Show("Verification successful! You can now reset your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim newPass As New Form6(_verificationCode, _userEmail, _accountType)
            newPass.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnConfirm.Focus()
        End If
    End Sub
End Class
