<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
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
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        txtStudentID = New TextBox()
        txtLastName = New TextBox()
        cmbProgram = New ComboBox()
        btnDelete = New Button()
        Button7 = New Button()
        DataGridView1 = New DataGridView()
        txtFirstName = New TextBox()
        txtMiddleName = New TextBox()
        txtEmailAddress = New TextBox()
        Label12 = New Label()
        btnUpdate = New Button()
        btnAdd = New Button()
        cmbYear = New ComboBox()
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
        LinkLabel1.Location = New Point(72, 1006)
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
        btnYear.Location = New Point(320, 0)
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
        btnSubjects.Location = New Point(643, 0)
        btnSubjects.Name = "btnSubjects"
        btnSubjects.Size = New Size(333, 48)
        btnSubjects.TabIndex = 2
        btnSubjects.Text = "Subjects"
        btnSubjects.UseVisualStyleBackColor = False
        ' 
        ' btnStudent
        ' 
        btnStudent.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnStudent.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStudent.Location = New Point(1301, 0)
        btnStudent.Name = "btnStudent"
        btnStudent.Size = New Size(327, 48)
        btnStudent.TabIndex = 1
        btnStudent.Text = "Students"
        btnStudent.UseVisualStyleBackColor = False
        ' 
        ' btnProf
        ' 
        btnProf.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        btnProf.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProf.Location = New Point(975, 0)
        btnProf.Name = "btnProf"
        btnProf.Size = New Size(328, 48)
        btnProf.TabIndex = 0
        btnProf.Text = "Professors"
        btnProf.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(416, 249)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 29)
        Label3.TabIndex = 7
        Label3.Text = "Student ID"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(416, 427)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 29)
        Label5.TabIndex = 9
        Label5.Text = "Program"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(416, 341)
        Label6.Name = "Label6"
        Label6.Size = New Size(105, 29)
        Label6.TabIndex = 10
        Label6.Text = "Last Name"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(742, 341)
        Label7.Name = "Label7"
        Label7.Size = New Size(106, 29)
        Label7.TabIndex = 11
        Label7.Text = "First Name"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(1073, 341)
        Label8.Name = "Label8"
        Label8.Size = New Size(128, 29)
        Label8.TabIndex = 12
        Label8.Text = "Middle Name"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(742, 249)
        Label9.Name = "Label9"
        Label9.Size = New Size(135, 29)
        Label9.TabIndex = 13
        Label9.Text = "Email Address"
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtStudentID.Location = New Point(416, 281)
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(248, 32)
        txtStudentID.TabIndex = 15
        ' 
        ' txtLastName
        ' 
        txtLastName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLastName.Location = New Point(416, 373)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(248, 32)
        txtLastName.TabIndex = 16
        ' 
        ' cmbProgram
        ' 
        cmbProgram.DropDownStyle = ComboBoxStyle.DropDownList
        cmbProgram.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbProgram.FormattingEnabled = True
        cmbProgram.Location = New Point(416, 459)
        cmbProgram.Name = "cmbProgram"
        cmbProgram.Size = New Size(248, 36)
        cmbProgram.TabIndex = 20
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.BackgroundImage = My.Resources.Resources.gold_111
        btnDelete.BackgroundImageLayout = ImageLayout.Stretch
        btnDelete.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(1620, 409)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(155, 43)
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
        Button7.Location = New Point(1620, 477)
        Button7.Name = "Button7"
        Button7.Size = New Size(155, 43)
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
        txtFirstName.Location = New Point(742, 373)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(248, 32)
        txtFirstName.TabIndex = 28
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMiddleName.Location = New Point(1073, 373)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(248, 32)
        txtMiddleName.TabIndex = 29
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmailAddress.Location = New Point(742, 281)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.ReadOnly = True
        txtEmailAddress.Size = New Size(363, 32)
        txtEmailAddress.TabIndex = 31
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(742, 427)
        Label12.Name = "Label12"
        Label12.Size = New Size(52, 29)
        Label12.TabIndex = 33
        Label12.Text = "Year"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Transparent
        btnUpdate.BackgroundImage = My.Resources.Resources.gold_111
        btnUpdate.BackgroundImageLayout = ImageLayout.Stretch
        btnUpdate.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(1436, 477)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(155, 43)
        btnUpdate.TabIndex = 36
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Transparent
        btnAdd.BackgroundImage = My.Resources.Resources.gold_111
        btnAdd.BackgroundImageLayout = ImageLayout.Stretch
        btnAdd.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAdd.Location = New Point(1436, 409)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(155, 43)
        btnAdd.TabIndex = 35
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cmbYear
        ' 
        cmbYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYear.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbYear.FormattingEnabled = True
        cmbYear.Location = New Point(742, 459)
        cmbYear.Name = "cmbYear"
        cmbYear.Size = New Size(248, 36)
        cmbYear.TabIndex = 37
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
        ' Form10
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Panel4)
        Controls.Add(cmbYear)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(Label12)
        Controls.Add(txtEmailAddress)
        Controls.Add(txtMiddleName)
        Controls.Add(txtFirstName)
        Controls.Add(DataGridView1)
        Controls.Add(Button7)
        Controls.Add(btnDelete)
        Controls.Add(cmbProgram)
        Controls.Add(txtLastName)
        Controls.Add(txtStudentID)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Name = "Form10"
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
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnYear As Button
    Friend WithEvents btnSubjects As Button
    Friend WithEvents btnStudent As Button
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents cmbProgram As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnProg As Button
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
