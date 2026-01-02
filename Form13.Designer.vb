<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form13
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form13))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        LinkLabel1 = New LinkLabel()
        PictureBox1 = New PictureBox()
        Panel5 = New Panel()
        Label3 = New Label()
        Label5 = New Label()
        Label9 = New Label()
        cmbSubject = New ComboBox()
        btnDelete = New Button()
        Button7 = New Button()
        DataGridView1 = New DataGridView()
        btnUpdate = New Button()
        btnSubmit = New Button()
        cmbYear = New ComboBox()
        cmbGrade = New ComboBox()
        txtSemester = New TextBox()
        Label7 = New Label()
        cmbProf = New ComboBox()
        Label8 = New Label()
        Label10 = New Label()
        cmbDepartment = New ComboBox()
        txtSubjectCode = New TextBox()
        Label4 = New Label()
        cmbProgram = New ComboBox()
        Label6 = New Label()
        Panel6 = New Panel()
        Label11 = New Label()
        Label13 = New Label()
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
        LinkLabel1.Location = New Point(56, 1006)
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
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(718, 351)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 29)
        Label3.TabIndex = 7
        Label3.Text = "Subject"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(718, 454)
        Label5.Name = "Label5"
        Label5.Size = New Size(131, 29)
        Label5.TabIndex = 9
        Label5.Text = "Year/Section"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(416, 351)
        Label9.Name = "Label9"
        Label9.Size = New Size(143, 29)
        Label9.TabIndex = 13
        Label9.Text = "Grading Period"
        ' 
        ' cmbSubject
        ' 
        cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSubject.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbSubject.FormattingEnabled = True
        cmbSubject.Location = New Point(718, 383)
        cmbSubject.Name = "cmbSubject"
        cmbSubject.Size = New Size(248, 36)
        cmbSubject.TabIndex = 19
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
        DataGridView1.Location = New Point(379, 550)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1440, 476)
        DataGridView1.TabIndex = 27
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Transparent
        btnUpdate.BackgroundImage = My.Resources.Resources.gold_111
        btnUpdate.BackgroundImageLayout = ImageLayout.Stretch
        btnUpdate.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(1435, 477)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(155, 43)
        btnUpdate.TabIndex = 39
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.Transparent
        btnSubmit.BackgroundImage = My.Resources.Resources.gold_111
        btnSubmit.BackgroundImageLayout = ImageLayout.Stretch
        btnSubmit.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSubmit.Location = New Point(1435, 409)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(155, 43)
        btnSubmit.TabIndex = 38
        btnSubmit.Text = "SUBMIT"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' cmbYear
        ' 
        cmbYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYear.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbYear.FormattingEnabled = True
        cmbYear.Location = New Point(718, 486)
        cmbYear.Name = "cmbYear"
        cmbYear.Size = New Size(248, 36)
        cmbYear.TabIndex = 40
        ' 
        ' cmbGrade
        ' 
        cmbGrade.DropDownStyle = ComboBoxStyle.DropDownList
        cmbGrade.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbGrade.FormattingEnabled = True
        cmbGrade.Items.AddRange(New Object() {"MIDTERM", "FINAL"})
        cmbGrade.Location = New Point(416, 383)
        cmbGrade.Name = "cmbGrade"
        cmbGrade.Size = New Size(248, 36)
        cmbGrade.TabIndex = 41
        ' 
        ' txtSemester
        ' 
        txtSemester.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSemester.Location = New Point(1016, 383)
        txtSemester.Name = "txtSemester"
        txtSemester.ReadOnly = True
        txtSemester.Size = New Size(248, 32)
        txtSemester.TabIndex = 42
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(1016, 351)
        Label7.Name = "Label7"
        Label7.Size = New Size(97, 29)
        Label7.TabIndex = 43
        Label7.Text = "Semester"
        ' 
        ' cmbProf
        ' 
        cmbProf.DropDownStyle = ComboBoxStyle.DropDownList
        cmbProf.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbProf.FormattingEnabled = True
        cmbProf.Location = New Point(416, 486)
        cmbProf.Name = "cmbProf"
        cmbProf.Size = New Size(248, 36)
        cmbProf.TabIndex = 45
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(416, 454)
        Label8.Name = "Label8"
        Label8.Size = New Size(97, 29)
        Label8.TabIndex = 44
        Label8.Text = "Professor"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(416, 249)
        Label10.Name = "Label10"
        Label10.Size = New Size(118, 29)
        Label10.TabIndex = 46
        Label10.Text = "Department"
        ' 
        ' cmbDepartment
        ' 
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDepartment.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbDepartment.FormattingEnabled = True
        cmbDepartment.Location = New Point(416, 281)
        cmbDepartment.Name = "cmbDepartment"
        cmbDepartment.Size = New Size(248, 36)
        cmbDepartment.TabIndex = 47
        ' 
        ' txtSubjectCode
        ' 
        txtSubjectCode.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSubjectCode.Location = New Point(1016, 281)
        txtSubjectCode.Name = "txtSubjectCode"
        txtSubjectCode.ReadOnly = True
        txtSubjectCode.Size = New Size(248, 32)
        txtSubjectCode.TabIndex = 48
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(1020, 249)
        Label4.Name = "Label4"
        Label4.Size = New Size(130, 29)
        Label4.TabIndex = 49
        Label4.Text = "Subject Code"
        ' 
        ' cmbProgram
        ' 
        cmbProgram.DropDownStyle = ComboBoxStyle.DropDownList
        cmbProgram.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbProgram.FormattingEnabled = True
        cmbProgram.Location = New Point(718, 281)
        cmbProgram.Name = "cmbProgram"
        cmbProgram.Size = New Size(248, 36)
        cmbProgram.TabIndex = 50
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi Cond", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(718, 249)
        Label6.Name = "Label6"
        Label6.Size = New Size(88, 29)
        Label6.TabIndex = 51
        Label6.Text = "Program"
        ' 
        ' Panel6
        ' 
        Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), Image)
        Panel6.BackgroundImageLayout = ImageLayout.Stretch
        Panel6.Controls.Add(Label11)
        Panel6.Controls.Add(Label13)
        Panel6.Location = New Point(296, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1628, 166)
        Panel6.TabIndex = 52
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Century Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(179, 40)
        Label11.Name = "Label11"
        Label11.Size = New Size(1229, 56)
        Label11.TabIndex = 0
        Label11.Text = "P A M A N T A S A N  N G  L U N G S O D  N G  P A S I G" & vbCrLf
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.Gold
        Label13.Location = New Point(545, 112)
        Label13.Name = "Label13"
        Label13.Size = New Size(518, 34)
        Label13.TabIndex = 1
        Label13.Text = "C O L L E G E  A D M I N I S T R A T O R" & vbCrLf
        ' 
        ' Form13
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(Panel6)
        Controls.Add(Label6)
        Controls.Add(cmbProgram)
        Controls.Add(Label4)
        Controls.Add(txtSubjectCode)
        Controls.Add(cmbDepartment)
        Controls.Add(Label10)
        Controls.Add(cmbProf)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(txtSemester)
        Controls.Add(cmbGrade)
        Controls.Add(cmbYear)
        Controls.Add(btnUpdate)
        Controls.Add(btnSubmit)
        Controls.Add(DataGridView1)
        Controls.Add(Button7)
        Controls.Add(btnDelete)
        Controls.Add(cmbSubject)
        Controls.Add(Label9)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Name = "Form13"
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
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSchoolYear As TextBox
    Friend WithEvents cmbSubject As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbSection As ComboBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents cmbGrade As ComboBox
    Friend WithEvents txtSemester As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbProf As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents txtSubjectCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbProgram As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label


End Class
