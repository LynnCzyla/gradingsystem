<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form6
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
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        btnReset = New Button()
        txtConPass = New TextBox()
        txtNewPass = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ControlLightLight
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(btnReset)
        Panel1.Controls.Add(txtConPass)
        Panel1.Controls.Add(txtNewPass)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(99, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(390, 438)
        Panel1.TabIndex = 5
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.change_password_5_128
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(140, 26)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(141, 117)
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.Transparent
        btnReset.BackgroundImage = My.Resources.Resources.gold_111
        btnReset.BackgroundImageLayout = ImageLayout.Stretch
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReset.Location = New Point(91, 325)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(206, 51)
        btnReset.TabIndex = 9
        btnReset.Text = "Reset Password"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' txtConPass
        ' 
        txtConPass.Font = New Font("Franklin Gothic Medium Cond", 12F)
        txtConPass.Location = New Point(91, 278)
        txtConPass.Name = "txtConPass"
        txtConPass.Size = New Size(206, 30)
        txtConPass.TabIndex = 8
        ' 
        ' txtNewPass
        ' 
        txtNewPass.Font = New Font("Franklin Gothic Medium Cond", 12F)
        txtNewPass.Location = New Point(91, 201)
        txtNewPass.Name = "txtNewPass"
        txtNewPass.Size = New Size(206, 30)
        txtNewPass.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label2.Location = New Point(91, 253)
        Label2.Name = "Label2"
        Label2.Size = New Size(178, 25)
        Label2.TabIndex = 6
        Label2.Text = "Confirm New Password"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label1.Location = New Point(91, 176)
        Label1.Name = "Label1"
        Label1.Size = New Size(117, 25)
        Label1.TabIndex = 5
        Label1.Text = "New Password"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkGreen
        Panel2.Controls.Add(Panel1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(590, 553)
        Panel2.TabIndex = 6
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        ClientSize = New Size(590, 553)
        Controls.Add(Panel2)
        Name = "Form6"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form5"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnReset As Button
    Friend WithEvents txtConPass As TextBox
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
End Class
