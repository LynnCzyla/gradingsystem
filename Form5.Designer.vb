<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtCode = New TextBox()
        btnConfirm = New Button()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        Panel1 = New Panel()
        Label1 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtCode
        ' 
        txtCode.Font = New Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCode.Location = New Point(74, 256)
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(294, 30)
        txtCode.TabIndex = 2
        ' 
        ' btnConfirm
        ' 
        btnConfirm.BackColor = Color.Transparent
        btnConfirm.BackgroundImage = My.Resources.Resources.gold_111
        btnConfirm.BackgroundImageLayout = ImageLayout.Stretch
        btnConfirm.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        btnConfirm.Location = New Point(74, 305)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(294, 40)
        btnConfirm.TabIndex = 5
        btnConfirm.Text = "Confirm"
        btnConfirm.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Franklin Gothic Demi Cond", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(142, 179)
        Label4.Name = "Label4"
        Label4.Size = New Size(157, 38)
        Label4.TabIndex = 6
        Label4.Text = "Confirm OTP"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.otp
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(165, 52)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(108, 110)
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.GhostWhite
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(btnConfirm)
        Panel1.Controls.Add(txtCode)
        Panel1.Location = New Point(67, 80)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(434, 413)
        Panel1.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Franklin Gothic Medium", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(74, 217)
        Label1.Name = "Label1"
        Label1.Size = New Size(294, 23)
        Label1.TabIndex = 9
        Label1.Text = "Enter the OTP we sent to your email."
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(579, 577)
        Controls.Add(Panel1)
        DoubleBuffered = True
        Name = "Form5"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form4"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtCode As TextBox
    Friend WithEvents btnConfirm As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
