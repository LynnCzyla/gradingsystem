<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form9
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form9))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        LinkLabel1 = New LinkLabel()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        btnProg = New Button()
        btnYear = New Button()
        btnSubjects = New Button()
        btnStudent = New Button()
        btnProf = New Button()
        Label3 = New Label()
        Label5 = New Label()
        txtDepartmentName = New TextBox()
        txtProgramName = New TextBox()
        btnSubmit = New Button()
        btnClear = New Button()
        DataGridView1 = New DataGridView()
        btnDelete = New Button()
        btnUpdate = New Button()
        Panel4 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
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
        LinkLabel1.Location = New Point(73, 995)
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
        Panel5.Controls.Add(btnProg)
        Panel5.Controls.Add(btnYear)
        Panel5.Controls.Add(btnSubjects)
        Panel5.Controls.Add(btnStudent)
        Panel5.Controls.Add(btnProf)
        Panel5.Location = New Point(296, 164)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1628, 48)
        Panel5.TabIndex = 3
        ' 
        ' btnProg
        ' 
        btnProg.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnProg.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProg.Location = New Point(0, 0)
        btnProg.Name = "btnProg"
        btnProg.Size = New Size(326, 48)
        btnProg.TabIndex = 28
        btnProg.Text = "Department/Program"
        btnProg.UseVisualStyleBackColor = False
        ' 
        ' btnYear
        ' 
        btnYear.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnYear.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnYear.Location = New Point(323, 0)
        btnYear.Name = "btnYear"
        btnYear.Size = New Size(326, 48)
        btnYear.TabIndex = 3
        btnYear.Text = "Year/Section"
        btnYear.UseVisualStyleBackColor = False
        ' 
        ' btnSubjects
        ' 
        btnSubjects.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnSubjects.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSubjects.Location = New Point(646, 0)
        btnSubjects.Name = "btnSubjects"
        btnSubjects.Size = New Size(329, 48)
        btnSubjects.TabIndex = 2
        btnSubjects.Text = "Subjects"
        btnSubjects.UseVisualStyleBackColor = False
        ' 
        ' btnStudent
        ' 
        btnStudent.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnStudent.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStudent.Location = New Point(1305, 0)
        btnStudent.Name = "btnStudent"
        btnStudent.Size = New Size(323, 48)
        btnStudent.TabIndex = 1
        btnStudent.Text = "Students"
        btnStudent.UseVisualStyleBackColor = False
        ' 
        ' btnProf
        ' 
        btnProf.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnProf.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProf.Location = New Point(973, 0)
        btnProf.Name = "btnProf"
        btnProf.Size = New Size(334, 48)
        btnProf.TabIndex = 0
        btnProf.Text = "Professors"
        btnProf.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(1000, 321)
        Label3.Name = "Label3"
        Label3.Size = New Size(88, 29)
        Label3.TabIndex = 7
        Label3.Text = "Program"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(674, 321)
        Label5.Name = "Label5"
        Label5.Size = New Size(118, 29)
        Label5.TabIndex = 9
        Label5.Text = "Department"
        ' 
        ' txtDepartmentName
        ' 
        txtDepartmentName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtDepartmentName.Location = New Point(674, 353)
        txtDepartmentName.Name = "txtDepartmentName"
        txtDepartmentName.Size = New Size(248, 32)
        txtDepartmentName.TabIndex = 15
        ' 
        ' txtProgramName
        ' 
        txtProgramName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtProgramName.Location = New Point(1000, 353)
        txtProgramName.Name = "txtProgramName"
        txtProgramName.Size = New Size(248, 32)
        txtProgramName.TabIndex = 16
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.Transparent
        btnSubmit.BackgroundImage = My.Resources.Resources.gold_111
        btnSubmit.BackgroundImageLayout = ImageLayout.Stretch
        btnSubmit.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSubmit.Location = New Point(1440, 366)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(155, 43)
        btnSubmit.TabIndex = 25
        btnSubmit.Text = "SUBMIT"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Transparent
        btnClear.BackgroundImage = My.Resources.Resources.gold_111
        btnClear.BackgroundImageLayout = ImageLayout.Stretch
        btnClear.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClear.Location = New Point(1620, 427)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(155, 43)
        btnClear.TabIndex = 26
        btnClear.Text = "CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(380, 539)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1440, 476)
        DataGridView1.TabIndex = 27
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.BackgroundImage = My.Resources.Resources.gold_111
        btnDelete.BackgroundImageLayout = ImageLayout.Stretch
        btnDelete.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(1620, 366)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(155, 43)
        btnDelete.TabIndex = 28
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Transparent
        btnUpdate.BackgroundImage = My.Resources.Resources.gold_111
        btnUpdate.BackgroundImageLayout = ImageLayout.Stretch
        btnUpdate.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(1440, 427)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(155, 43)
        btnUpdate.TabIndex = 29
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), Image)
        Panel4.BackgroundImageLayout = ImageLayout.Stretch
        Panel4.Controls.Add(Label1)
        Panel4.Controls.Add(Label2)
        Panel4.Location = New Point(296, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1628, 166)
        Panel4.TabIndex = 37
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Gold
        Label1.Location = New Point(606, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(410, 37)
        Label1.TabIndex = 1
        Label1.Text = "A D M I N  D A S H B O A R D" & vbCrLf
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Century Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(179, 40)
        Label2.Name = "Label2"
        Label2.Size = New Size(1229, 56)
        Label2.TabIndex = 0
        Label2.Text = "P A M A N T A S A N  N G  L U N G S O D  N G  P A S I G" & vbCrLf
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Panel4)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(DataGridView1)
        Controls.Add(btnClear)
        Controls.Add(btnSubmit)
        Controls.Add(txtProgramName)
        Controls.Add(txtDepartmentName)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Name = "Form9"
        Text = "Subject - Encode"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnProf As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnYear As Button
    Friend WithEvents btnSubjects As Button
    Friend WithEvents btnStudent As Button
    Friend WithEvents txtDepartmentName As TextBox
    Friend WithEvents txtProgramName As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnProg As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
