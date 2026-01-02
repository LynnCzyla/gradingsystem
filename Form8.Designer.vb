<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        likArchive = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        btnProg = New Button()
        btnYear = New Button()
        btnSubjects = New Button()
        btnStudent = New Button()
        btnProf = New Button()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        txtProfID = New TextBox()
        txtLastName = New TextBox()
        cboType = New ComboBox()
        cmDepart = New ComboBox()
        btnDelete = New Button()
        Button7 = New Button()
        DataGridView1 = New DataGridView()
        txtFirstName = New TextBox()
        txtMiddleName = New TextBox()
        txtContactNo = New TextBox()
        txtEmail = New TextBox()
        Label11 = New Label()
        txtPassword = New TextBox()
        Label12 = New Label()
        btnUpdate = New Button()
        btnAdd = New Button()
        txtSearch = New TextBox()
        Panel4 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Label13 = New Label()
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
        Panel3.Controls.Add(likArchive)
        Panel3.Controls.Add(LinkLabel1)
        Panel3.Controls.Add(PictureBox1)
        Panel3.Location = New Point(68, -7)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(228, 1065)
        Panel3.TabIndex = 1
        ' 
        ' likArchive
        ' 
        likArchive.AutoSize = True
        likArchive.Font = New Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        likArchive.LinkColor = Color.Black
        likArchive.Location = New Point(56, 956)
        likArchive.Name = "likArchive"
        likArchive.Size = New Size(101, 27)
        likArchive.TabIndex = 2
        likArchive.TabStop = True
        likArchive.Text = "Archive"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel1.LinkColor = Color.Black
        LinkLabel1.Location = New Point(71, 995)
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
        btnSubjects.Location = New Point(644, 0)
        btnSubjects.Name = "btnSubjects"
        btnSubjects.Size = New Size(326, 48)
        btnSubjects.TabIndex = 2
        btnSubjects.Text = "Subjects"
        btnSubjects.UseVisualStyleBackColor = False
        ' 
        ' btnStudent
        ' 
        btnStudent.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnStudent.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStudent.Location = New Point(1299, 0)
        btnStudent.Name = "btnStudent"
        btnStudent.Size = New Size(329, 48)
        btnStudent.TabIndex = 1
        btnStudent.Text = "Students"
        btnStudent.UseVisualStyleBackColor = False
        ' 
        ' btnProf
        ' 
        btnProf.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnProf.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProf.Location = New Point(967, 0)
        btnProf.Name = "btnProf"
        btnProf.Size = New Size(335, 48)
        btnProf.TabIndex = 0
        btnProf.Text = "Professors"
        btnProf.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(459, 257)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 29)
        Label3.TabIndex = 7
        Label3.Text = "Professor ID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(785, 257)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 29)
        Label4.TabIndex = 8
        Label4.Text = "Type"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(1116, 257)
        Label5.Name = "Label5"
        Label5.Size = New Size(118, 29)
        Label5.TabIndex = 9
        Label5.Text = "Department"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(459, 349)
        Label6.Name = "Label6"
        Label6.Size = New Size(105, 29)
        Label6.TabIndex = 10
        Label6.Text = "Last Name"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(785, 349)
        Label7.Name = "Label7"
        Label7.Size = New Size(106, 29)
        Label7.TabIndex = 11
        Label7.Text = "First Name"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(1116, 349)
        Label8.Name = "Label8"
        Label8.Size = New Size(128, 29)
        Label8.TabIndex = 12
        Label8.Text = "Middle Name"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(459, 435)
        Label9.Name = "Label9"
        Label9.Size = New Size(61, 29)
        Label9.TabIndex = 13
        Label9.Text = "Email"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(1116, 435)
        Label10.Name = "Label10"
        Label10.Size = New Size(17, 29)
        Label10.TabIndex = 14
        Label10.Text = " "
        ' 
        ' txtProfID
        ' 
        txtProfID.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtProfID.Location = New Point(459, 289)
        txtProfID.Name = "txtProfID"
        txtProfID.Size = New Size(248, 32)
        txtProfID.TabIndex = 15
        ' 
        ' txtLastName
        ' 
        txtLastName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLastName.Location = New Point(459, 381)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(248, 32)
        txtLastName.TabIndex = 16
        ' 
        ' cboType
        ' 
        cboType.DropDownStyle = ComboBoxStyle.DropDownList
        cboType.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cboType.FormattingEnabled = True
        cboType.Items.AddRange(New Object() {"Full-Time", "Part-Time"})
        cboType.Location = New Point(785, 289)
        cboType.Name = "cboType"
        cboType.Size = New Size(248, 36)
        cboType.TabIndex = 19
        ' 
        ' cmDepart
        ' 
        cmDepart.DropDownStyle = ComboBoxStyle.DropDownList
        cmDepart.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmDepart.FormattingEnabled = True
        cmDepart.Location = New Point(1116, 289)
        cmDepart.Name = "cmDepart"
        cmDepart.Size = New Size(248, 36)
        cmDepart.TabIndex = 20
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.BackgroundImage = My.Resources.Resources.gold_111
        btnDelete.BackgroundImageLayout = ImageLayout.Stretch
        btnDelete.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(1623, 406)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(152, 46)
        btnDelete.TabIndex = 25
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.Transparent
        Button7.BackgroundImage = My.Resources.Resources.gold_111
        Button7.BackgroundImageLayout = ImageLayout.Stretch
        Button7.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button7.Location = New Point(1623, 474)
        Button7.Name = "Button7"
        Button7.Size = New Size(152, 46)
        Button7.TabIndex = 26
        Button7.Text = "CLEAR"
        Button7.UseVisualStyleBackColor = False
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
        ' txtFirstName
        ' 
        txtFirstName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFirstName.Location = New Point(785, 381)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(248, 32)
        txtFirstName.TabIndex = 28
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMiddleName.Location = New Point(1116, 381)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(248, 32)
        txtMiddleName.TabIndex = 29
        ' 
        ' txtContactNo
        ' 
        txtContactNo.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContactNo.Location = New Point(1116, 467)
        txtContactNo.Name = "txtContactNo"
        txtContactNo.Size = New Size(248, 32)
        txtContactNo.TabIndex = 30
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(459, 467)
        txtEmail.Name = "txtEmail"
        txtEmail.ReadOnly = True
        txtEmail.Size = New Size(248, 32)
        txtEmail.TabIndex = 31
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(1116, 435)
        Label11.Name = "Label11"
        Label11.Size = New Size(117, 29)
        Label11.TabIndex = 32
        Label11.Text = "Contact No."
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(785, 467)
        txtPassword.Name = "txtPassword"
        txtPassword.ReadOnly = True
        txtPassword.Size = New Size(248, 32)
        txtPassword.TabIndex = 34
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(785, 435)
        Label12.Name = "Label12"
        Label12.Size = New Size(96, 29)
        Label12.TabIndex = 33
        Label12.Text = "Password"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Transparent
        btnUpdate.BackgroundImage = My.Resources.Resources.gold_111
        btnUpdate.BackgroundImageLayout = ImageLayout.Stretch
        btnUpdate.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(1446, 474)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(152, 46)
        btnUpdate.TabIndex = 35
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Transparent
        btnAdd.BackgroundImage = My.Resources.Resources.gold_111
        btnAdd.BackgroundImageLayout = ImageLayout.Stretch
        btnAdd.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAdd.Location = New Point(1446, 406)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(152, 46)
        btnAdd.TabIndex = 36
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(1620, 273)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(248, 32)
        txtSearch.TabIndex = 37
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
        Panel4.TabIndex = 38
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
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(1620, 241)
        Label13.Name = "Label13"
        Label13.Size = New Size(75, 29)
        Label13.TabIndex = 39
        Label13.Text = "Search"
        ' 
        ' Form8
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Label13)
        Controls.Add(Panel4)
        Controls.Add(txtSearch)
        Controls.Add(btnAdd)
        Controls.Add(btnUpdate)
        Controls.Add(txtPassword)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(txtEmail)
        Controls.Add(txtContactNo)
        Controls.Add(txtMiddleName)
        Controls.Add(txtFirstName)
        Controls.Add(DataGridView1)
        Controls.Add(Button7)
        Controls.Add(btnDelete)
        Controls.Add(cmDepart)
        Controls.Add(cboType)
        Controls.Add(txtLastName)
        Controls.Add(txtProfID)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Name = "Form8"
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnYear As Button
    Friend WithEvents btnSubjects As Button
    Friend WithEvents btnStudent As Button
    Friend WithEvents txtProfID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents cboType As ComboBox
    Friend WithEvents cmDepart As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnProg As Button
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtContactNo As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents likArchive As LinkLabel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label

End Class
