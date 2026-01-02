<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        lkbBack = New LinkLabel()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        btnProg = New Button()
        btnYear = New Button()
        btnStudent = New Button()
        btnProfEncode = New Button()
        btnSub = New Button()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        txtSubjectCode = New TextBox()
        txtSubjectName = New TextBox()
        cmbType = New ComboBox()
        cmbDepartment = New ComboBox()
        cmbUnits = New ComboBox()
        cmbSemester = New ComboBox()
        cmbLecLab = New ComboBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        btnDelete = New Button()
        txtSearch = New TextBox()
        Label7 = New Label()
        cmbProgram = New ComboBox()
        Label11 = New Label()
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
        Panel3.Controls.Add(lkbBack)
        Panel3.Controls.Add(PictureBox1)
        Panel3.Location = New Point(68, -7)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(228, 1065)
        Panel3.TabIndex = 1
        ' 
        ' lkbBack
        ' 
        lkbBack.AutoSize = True
        lkbBack.Font = New Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lkbBack.LinkColor = Color.Black
        lkbBack.Location = New Point(56, 1006)
        lkbBack.Name = "lkbBack"
        lkbBack.Size = New Size(68, 27)
        lkbBack.TabIndex = 1
        lkbBack.TabStop = True
        lkbBack.Text = "Back"
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
        Panel5.Controls.Add(btnStudent)
        Panel5.Controls.Add(btnProfEncode)
        Panel5.Controls.Add(btnSub)
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
        btnProg.Size = New Size(329, 48)
        btnProg.TabIndex = 28
        btnProg.Text = "Department/Program"
        btnProg.UseVisualStyleBackColor = False
        ' 
        ' btnYear
        ' 
        btnYear.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnYear.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnYear.Location = New Point(327, 0)
        btnYear.Name = "btnYear"
        btnYear.Size = New Size(331, 48)
        btnYear.TabIndex = 3
        btnYear.Text = "Year/Section"
        btnYear.UseVisualStyleBackColor = False
        ' 
        ' btnStudent
        ' 
        btnStudent.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnStudent.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStudent.Location = New Point(1303, 0)
        btnStudent.Name = "btnStudent"
        btnStudent.Size = New Size(326, 48)
        btnStudent.TabIndex = 1
        btnStudent.Text = "Students"
        btnStudent.UseVisualStyleBackColor = False
        ' 
        ' btnProfEncode
        ' 
        btnProfEncode.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnProfEncode.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProfEncode.Location = New Point(978, 0)
        btnProfEncode.Name = "btnProfEncode"
        btnProfEncode.Size = New Size(326, 48)
        btnProfEncode.TabIndex = 0
        btnProfEncode.Text = "Professors"
        btnProfEncode.UseVisualStyleBackColor = False
        ' 
        ' btnSub
        ' 
        btnSub.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnSub.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSub.Location = New Point(655, 0)
        btnSub.Name = "btnSub"
        btnSub.Size = New Size(326, 48)
        btnSub.TabIndex = 2
        btnSub.Text = "Subjects"
        btnSub.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(475, 242)
        Label3.Name = "Label3"
        Label3.Size = New Size(130, 29)
        Label3.TabIndex = 7
        Label3.Text = "Subject Code"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(801, 242)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 29)
        Label4.TabIndex = 8
        Label4.Text = "Type"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(1132, 242)
        Label5.Name = "Label5"
        Label5.Size = New Size(118, 29)
        Label5.TabIndex = 9
        Label5.Text = "Department"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(475, 334)
        Label6.Name = "Label6"
        Label6.Size = New Size(135, 29)
        Label6.TabIndex = 10
        Label6.Text = "Subject Name"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(801, 420)
        Label8.Name = "Label8"
        Label8.Size = New Size(160, 29)
        Label8.TabIndex = 12
        Label8.Text = "Lec/Lec and Lab"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(475, 420)
        Label9.Name = "Label9"
        Label9.Size = New Size(58, 29)
        Label9.TabIndex = 13
        Label9.Text = "Units"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(801, 334)
        Label10.Name = "Label10"
        Label10.Size = New Size(97, 29)
        Label10.TabIndex = 14
        Label10.Text = "Semester"
        ' 
        ' txtSubjectCode
        ' 
        txtSubjectCode.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSubjectCode.Location = New Point(475, 274)
        txtSubjectCode.Name = "txtSubjectCode"
        txtSubjectCode.Size = New Size(248, 32)
        txtSubjectCode.TabIndex = 15
        ' 
        ' txtSubjectName
        ' 
        txtSubjectName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSubjectName.Location = New Point(475, 366)
        txtSubjectName.Name = "txtSubjectName"
        txtSubjectName.Size = New Size(248, 32)
        txtSubjectName.TabIndex = 16
        ' 
        ' cmbType
        ' 
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbType.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbType.FormattingEnabled = True
        cmbType.Items.AddRange(New Object() {"Major Subject", "General Subject"})
        cmbType.Location = New Point(801, 274)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(240, 36)
        cmbType.TabIndex = 19
        ' 
        ' cmbDepartment
        ' 
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDepartment.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbDepartment.FormattingEnabled = True
        cmbDepartment.Location = New Point(1132, 274)
        cmbDepartment.Name = "cmbDepartment"
        cmbDepartment.Size = New Size(240, 36)
        cmbDepartment.TabIndex = 20
        ' 
        ' cmbUnits
        ' 
        cmbUnits.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUnits.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbUnits.FormattingEnabled = True
        cmbUnits.Items.AddRange(New Object() {"2", "3"})
        cmbUnits.Location = New Point(475, 452)
        cmbUnits.Name = "cmbUnits"
        cmbUnits.Size = New Size(248, 36)
        cmbUnits.TabIndex = 21
        ' 
        ' cmbSemester
        ' 
        cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSemester.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbSemester.FormattingEnabled = True
        cmbSemester.Items.AddRange(New Object() {"1st Semester", "2nd Semester", "Summer"})
        cmbSemester.Location = New Point(801, 366)
        cmbSemester.Name = "cmbSemester"
        cmbSemester.Size = New Size(240, 36)
        cmbSemester.TabIndex = 22
        ' 
        ' cmbLecLab
        ' 
        cmbLecLab.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLecLab.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbLecLab.FormattingEnabled = True
        cmbLecLab.Items.AddRange(New Object() {"Lecture", "Lec/Lab"})
        cmbLecLab.Location = New Point(801, 452)
        cmbLecLab.Name = "cmbLecLab"
        cmbLecLab.Size = New Size(240, 36)
        cmbLecLab.TabIndex = 23
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Transparent
        btnAdd.BackgroundImage = My.Resources.Resources.gold_111
        btnAdd.BackgroundImageLayout = ImageLayout.Stretch
        btnAdd.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAdd.Location = New Point(1438, 384)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(155, 43)
        btnAdd.TabIndex = 25
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Transparent
        btnUpdate.BackgroundImage = My.Resources.Resources.gold_111
        btnUpdate.BackgroundImageLayout = ImageLayout.Stretch
        btnUpdate.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(1438, 452)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(155, 43)
        btnUpdate.TabIndex = 26
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(390, 537)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1440, 476)
        DataGridView1.TabIndex = 27
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImage = My.Resources.Resources.gold_111
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(1620, 452)
        Button1.Name = "Button1"
        Button1.Size = New Size(155, 43)
        Button1.TabIndex = 29
        Button1.Text = "CLEAR"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.BackgroundImage = My.Resources.Resources.gold_111
        btnDelete.BackgroundImageLayout = ImageLayout.Stretch
        btnDelete.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(1620, 384)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(155, 43)
        btnDelete.TabIndex = 28
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(1554, 274)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(274, 31)
        txtSearch.TabIndex = 30
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(1554, 242)
        Label7.Name = "Label7"
        Label7.Size = New Size(75, 29)
        Label7.TabIndex = 31
        Label7.Text = "Search"
        ' 
        ' cmbProgram
        ' 
        cmbProgram.DropDownStyle = ComboBoxStyle.DropDownList
        cmbProgram.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbProgram.FormattingEnabled = True
        cmbProgram.Location = New Point(1132, 366)
        cmbProgram.Name = "cmbProgram"
        cmbProgram.Size = New Size(240, 36)
        cmbProgram.TabIndex = 33
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(1132, 334)
        Label11.Name = "Label11"
        Label11.Size = New Size(88, 29)
        Label11.TabIndex = 32
        Label11.Text = "Program"
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
        Panel4.TabIndex = 36
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
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Panel4)
        Controls.Add(cmbProgram)
        Controls.Add(Label11)
        Controls.Add(Label7)
        Controls.Add(txtSearch)
        Controls.Add(Button1)
        Controls.Add(btnDelete)
        Controls.Add(DataGridView1)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(cmbLecLab)
        Controls.Add(cmbSemester)
        Controls.Add(cmbUnits)
        Controls.Add(cmbDepartment)
        Controls.Add(cmbType)
        Controls.Add(txtSubjectName)
        Controls.Add(txtSubjectCode)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Name = "Form7"
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
    Friend WithEvents lkbBack As LinkLabel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnProfEncode As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnYear As Button
    Friend WithEvents btnSub As Button
    Friend WithEvents btnStudent As Button
    Friend WithEvents txtSubjectCode As TextBox
    Friend WithEvents txtSubjectName As TextBox
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents cmbUnits As ComboBox
    Friend WithEvents cmbSemester As ComboBox
    Friend WithEvents cmbLecLab As ComboBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnProg As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbProgram As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
