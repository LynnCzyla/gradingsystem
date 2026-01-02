<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Panel1 = New Panel()
        Panel3 = New Panel()
        lnkForgot = New LinkLabel()
        PictureBox4 = New PictureBox()
        PictureBox3 = New PictureBox()
        btnLogin = New Button()
        Label6 = New Label()
        txtPass = New TextBox()
        Label5 = New Label()
        txtEmail = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Panel2 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1924, 1055)
        Panel1.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.WhiteSmoke
        Panel3.Controls.Add(lnkForgot)
        Panel3.Controls.Add(PictureBox4)
        Panel3.Controls.Add(PictureBox3)
        Panel3.Controls.Add(btnLogin)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(txtPass)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(txtEmail)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(1159, 244)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(584, 581)
        Panel3.TabIndex = 1
        ' 
        ' lnkForgot
        ' 
        lnkForgot.AutoSize = True
        lnkForgot.Font = New Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnkForgot.Location = New Point(371, 411)
        lnkForgot.Name = "lnkForgot"
        lnkForgot.Size = New Size(142, 25)
        lnkForgot.TabIndex = 12
        lnkForgot.TabStop = True
        lnkForgot.Text = "Forgot Password?"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), Image)
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.Location = New Point(66, 338)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(40, 34)
        PictureBox4.TabIndex = 11
        PictureBox4.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), Image)
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.Location = New Point(66, 203)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(40, 35)
        PictureBox3.TabIndex = 10
        PictureBox3.TabStop = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Green
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatAppearance.MouseDownBackColor = Color.Green
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogin.Location = New Point(104, 476)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(375, 49)
        btnLogin.TabIndex = 9
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Franklin Gothic Demi Cond", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(55, 289)
        Label6.Name = "Label6"
        Label6.Size = New Size(115, 36)
        Label6.TabIndex = 6
        Label6.Text = "Password"
        ' 
        ' txtPass
        ' 
        txtPass.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPass.Location = New Point(122, 338)
        txtPass.Name = "txtPass"
        txtPass.PasswordChar = "*"c
        txtPass.Size = New Size(391, 34)
        txtPass.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Franklin Gothic Demi Cond", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(55, 153)
        Label5.Name = "Label5"
        Label5.Size = New Size(75, 36)
        Label5.TabIndex = 4
        Label5.Text = "Email"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(122, 203)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(391, 34)
        txtEmail.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Black
        Label4.Location = New Point(35, 90)
        Label4.Name = "Label4"
        Label4.Size = New Size(513, 3)
        Label4.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Franklin Gothic Demi Cond", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        Label3.Location = New Point(188, 16)
        Label3.Name = "Label3"
        Label3.Size = New Size(224, 63)
        Label3.TabIndex = 1
        Label3.Text = "L O G I N"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkGreen
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(962, 1055)
        Panel2.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.WhiteSmoke
        Label2.Location = New Point(197, 813)
        Label2.Name = "Label2"
        Label2.Size = New Size(581, 27)
        Label2.TabIndex = 3
        Label2.Text = "D A L U Y A N  N G  U M A A G O S  N A  P A G - A S A"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.WhiteSmoke
        Label1.Location = New Point(67, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(591, 27)
        Label1.TabIndex = 2
        Label1.Text = "P A M A N T A S A N  N G  L U N G S O D  N G  P A S I G"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(12, 31)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(40, 30)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(158, 215)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(675, 595)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1924, 1055)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lnkForgot As LinkLabel

End Class
