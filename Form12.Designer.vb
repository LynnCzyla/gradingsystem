<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form12
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form12))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        LinkLabel1 = New LinkLabel()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        Label2 = New Label()
        DataGridView1 = New DataGridView()
        btnDelete = New Button()
        btnRestore = New Button()
        Panel6 = New Panel()
        Label4 = New Label()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        Panel1.Controls.Add(Panel2)
        Panel1.Location = New Point(1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(67, 1055)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(3, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(117, 449)
        Panel2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        Panel3.Controls.Add(LinkLabel1)
        Panel3.Controls.Add(PictureBox1)
        Panel3.Location = New Point(68, -7)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(228, 1065)
        Panel3.TabIndex = 1
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel1.LinkColor = Color.Black
        LinkLabel1.Location = New Point(71, 977)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(68, 27)
        LinkLabel1.TabIndex = 1
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Back"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Image = My.Resources.Resources.poginiroi
        PictureBox1.Location = New Point(27, 33)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(162, 161)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        Panel5.Location = New Point(296, 164)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1628, 48)
        Panel5.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Gold
        Label2.Location = New Point(545, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(518, 34)
        Label2.TabIndex = 1
        Label2.Text = "C O L L E G E  A D M I N I S T R A T O R" & vbCrLf
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(399, 313)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1381, 582)
        DataGridView1.TabIndex = 27
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.BackgroundImage = My.Resources.Resources.gold_111
        btnDelete.BackgroundImageLayout = ImageLayout.Stretch
        btnDelete.Location = New Point(1636, 927)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(144, 48)
        btnDelete.TabIndex = 28
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnRestore
        ' 
        btnRestore.BackColor = Color.Transparent
        btnRestore.BackgroundImage = My.Resources.Resources.gold_111
        btnRestore.BackgroundImageLayout = ImageLayout.Stretch
        btnRestore.Location = New Point(1469, 927)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(144, 48)
        btnRestore.TabIndex = 29
        btnRestore.Text = "Restore"
        btnRestore.UseVisualStyleBackColor = False
        ' 
        ' Panel6
        ' 
        Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), Image)
        Panel6.BackgroundImageLayout = ImageLayout.Stretch
        Panel6.Controls.Add(Label4)
        Panel6.Controls.Add(Label2)
        Panel6.Location = New Point(296, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1628, 166)
        Panel6.TabIndex = 42
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Century Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(179, 40)
        Label4.Name = "Label4"
        Label4.Size = New Size(1229, 56)
        Label4.TabIndex = 0
        Label4.Text = "P A M A N T A S A N  N G  L U N G S O D  N G  P A S I G" & vbCrLf
        ' 
        ' Form12
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Panel6)
        Controls.Add(btnRestore)
        Controls.Add(btnDelete)
        Controls.Add(DataGridView1)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Name = "Form12"
        Text = "Subject - Encode"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRestore As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label4 As Label

End Class
