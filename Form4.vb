Imports System.Drawing.Drawing2D

Public Class Form4
    Private originalColor As ColorBlend
    Private hoverColor As ColorBlend

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Using gradientBrush As New LinearGradientBrush(Panel2.ClientRectangle, Color.Transparent, Color.Transparent, 90.0F)
            Dim blend As New ColorBlend()
            blend.Colors = New Color() {Color.FromArgb(90, 173, 59), Color.FromArgb(47, 149, 9), Color.FromArgb(21, 59, 7)} ' Use RGB colors
            blend.Positions = New Single() {0.0F, 0.5F, 1.0F}

            gradientBrush.InterpolationColors = blend

            e.Graphics.FillRectangle(gradientBrush, Panel2.ClientRectangle)
        End Using
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs, panel As Panel, blend As ColorBlend)
        Dim cornerRadius = 80
        Dim graphicsPath As New GraphicsPath
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)

        graphicsPath.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        graphicsPath.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        graphicsPath.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        graphicsPath.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        graphicsPath.CloseFigure()

        panel.Region = New Region(graphicsPath)

        Using gradientBrush As New LinearGradientBrush(panel.ClientRectangle, Color.Transparent, Color.Transparent, 90.0F)
            gradientBrush.InterpolationColors = blend
            e.Graphics.FillRectangle(gradientBrush, panel.ClientRectangle)
        End Using
    End Sub

    Private Sub pnEncode_Paint(sender As Object, e As PaintEventArgs) Handles pnEncode.Paint
        Panel_Paint(sender, e, pnEncode, originalColor)
    End Sub

    Private Sub pnAssign_Paint(sender As Object, e As PaintEventArgs) Handles pnAssign.Paint
        Panel_Paint(sender, e, pnAssign, originalColor)
    End Sub

    Private Sub Panel_MouseEnter(sender As Object, e As EventArgs)
        Dim panel As Panel = CType(sender, Panel)

        panel.Tag = hoverColor
        panel.Invalidate()
    End Sub

    Private Sub Panel_MouseLeave(sender As Object, e As EventArgs)
        Dim panel As Panel = CType(sender, Panel)
        panel.Tag = originalColor
        panel.Invalidate()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDoubleBuffered(pnEncode, True)
        SetDoubleBuffered(pnAssign, True)

        originalColor = New ColorBlend()
        originalColor.Colors = New Color() {Color.FromArgb(90, 173, 59), Color.FromArgb(47, 149, 9), Color.FromArgb(21, 59, 7)}
        originalColor.Positions = New Single() {0.0F, 0.5F, 1.0F}

        hoverColor = New ColorBlend()
        hoverColor.Colors = New Color() {Color.FromArgb(255, 255, 0), Color.FromArgb(255, 204, 0), Color.FromArgb(204, 153, 0)} ' Yellow gradient
        hoverColor.Positions = New Single() {0.0F, 0.5F, 1.0F}

        AddHandler pnEncode.MouseEnter, AddressOf Panel_MouseEnter
        AddHandler pnEncode.MouseLeave, AddressOf Panel_MouseLeave
        AddHandler pnAssign.MouseEnter, AddressOf Panel_MouseEnter
        AddHandler pnAssign.MouseLeave, AddressOf Panel_MouseLeave
    End Sub

    Private Sub SetDoubleBuffered(panel As Panel, value As Boolean)
        Dim pi As System.Reflection.PropertyInfo = GetType(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        pi.SetValue(panel, value, Nothing)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles pnEncode.Paint, pnAssign.Paint
        Dim panel = CType(sender, Panel)
        Dim blend = CType(panel.Tag, ColorBlend)

        If blend Is Nothing Then
            blend = originalColor
        End If

        Panel_Paint(sender, e, panel, blend)
    End Sub

    Private Sub pnEncode_Click(sender As Object, e As EventArgs) Handles pnEncode.Click
        Dim enCode As New Form9()
        enCode.Show()
        Me.Hide()
    End Sub

    Private Sub pnAssign_Click(sender As Object, e As EventArgs) Handles pnAssign.Click
        Dim Assign As New Form13()
        Assign.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim Assign As New Form1()
            Assign.Show()
            Me.Hide()
        End If
    End Sub

    Dim CurrentProfessorID As Integer
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(profID As Integer)
        InitializeComponent()
        CurrentProfessorID = profID
    End Sub


End Class
