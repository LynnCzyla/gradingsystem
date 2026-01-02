<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Panel1 = New Panel()
        Panel2 = New Panel()
        lkLogout = New LinkLabel()
        lblDateTime = New Label()
        PictureBox2 = New PictureBox()
        Panel3 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        btnGenerateReport = New Button()
        btnEncodeGrades = New Button()
        Label3 = New Label()
        txtSubjectCode = New TextBox()
        Label4 = New Label()
        cmbSubject = New ComboBox()
        Label5 = New Label()
        cmbYearSection = New ComboBox()
        Label6 = New Label()
        cmbSemester = New ComboBox()
        Label8 = New Label()
        Panel5 = New Panel()
        Label11 = New Label()
        Label10 = New Label()
        txtPercentageforquiz = New TextBox()
        Label9 = New Label()
        Label12 = New Label()
        txtPercantageforExam = New TextBox()
        Label13 = New Label()
        txtPercentageforExercise = New TextBox()
        btnAddQuiz = New Button()
        pnlExercise = New Panel()
        btnAddExercise = New Button()
        txtExamScore = New TextBox()
        Panel6 = New Panel()
        Label15 = New Label()
        Label14 = New Label()
        txtExamTotalItems = New TextBox()
        txtGrade = New TextBox()
        Label17 = New Label()
        cmbStudents = New ComboBox()
        Label16 = New Label()
        pnlquiz = New Panel()
        btnCalculate = New Button()
        btnSave = New Button()
        btnUpdate = New Button()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        Panel1.Location = New Point(0, -2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(70, 1058)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        Panel2.Controls.Add(lkLogout)
        Panel2.Controls.Add(lblDateTime)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Location = New Point(69, -2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(261, 1058)
        Panel2.TabIndex = 1
        ' 
        ' lkLogout
        ' 
        lkLogout.AutoSize = True
        lkLogout.Font = New Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lkLogout.LinkColor = Color.Black
        lkLogout.Location = New Point(81, 956)
        lkLogout.Name = "lkLogout"
        lkLogout.Size = New Size(101, 27)
        lkLogout.TabIndex = 3
        lkLogout.TabStop = True
        lkLogout.Text = "Log Out"
        ' 
        ' lblDateTime
        ' 
        lblDateTime.BackColor = Color.Transparent
        lblDateTime.Font = New Font("Franklin Gothic Demi Cond", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDateTime.ForeColor = Color.White
        lblDateTime.Location = New Point(25, 238)
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New Size(216, 25)
        lblDateTime.TabIndex = 1
        lblDateTime.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(25, 29)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(216, 195)
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(btnGenerateReport)
        Panel3.Controls.Add(btnEncodeGrades)
        Panel3.Location = New Point(329, 184)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1595, 53)
        Panel3.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(1142, 12)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 25)
        Label2.TabIndex = 3
        Label2.Text = "Professor:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(787, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(109, 25)
        Label1.TabIndex = 2
        Label1.Text = "School Year:"
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.FlatAppearance.BorderSize = 0
        btnGenerateReport.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(207), CByte(159), CByte(39))
        btnGenerateReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(207), CByte(159), CByte(39))
        btnGenerateReport.FlatStyle = FlatStyle.Flat
        btnGenerateReport.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGenerateReport.Location = New Point(325, 1)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(314, 48)
        btnGenerateReport.TabIndex = 1
        btnGenerateReport.Text = "Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = True
        ' 
        ' btnEncodeGrades
        ' 
        btnEncodeGrades.FlatAppearance.BorderSize = 0
        btnEncodeGrades.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(207), CByte(159), CByte(39))
        btnEncodeGrades.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(207), CByte(159), CByte(39))
        btnEncodeGrades.FlatStyle = FlatStyle.Flat
        btnEncodeGrades.Font = New Font("Franklin Gothic Demi Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnEncodeGrades.Location = New Point(0, 0)
        btnEncodeGrades.Name = "btnEncodeGrades"
        btnEncodeGrades.Size = New Size(314, 49)
        btnEncodeGrades.TabIndex = 0
        btnEncodeGrades.Text = "Encode Grades"
        btnEncodeGrades.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(447, 331)
        Label3.Name = "Label3"
        Label3.Size = New Size(130, 29)
        Label3.TabIndex = 4
        Label3.Text = "Subject Code"
        ' 
        ' txtSubjectCode
        ' 
        txtSubjectCode.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSubjectCode.Location = New Point(605, 326)
        txtSubjectCode.Name = "txtSubjectCode"
        txtSubjectCode.ReadOnly = True
        txtSubjectCode.Size = New Size(248, 34)
        txtSubjectCode.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(447, 276)
        Label4.Name = "Label4"
        Label4.Size = New Size(84, 29)
        Label4.TabIndex = 6
        Label4.Text = "Subject "
        ' 
        ' cmbSubject
        ' 
        cmbSubject.AllowDrop = True
        cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSubject.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbSubject.FormattingEnabled = True
        cmbSubject.Location = New Point(605, 268)
        cmbSubject.Name = "cmbSubject"
        cmbSubject.Size = New Size(248, 37)
        cmbSubject.TabIndex = 7
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(902, 271)
        Label5.Name = "Label5"
        Label5.Size = New Size(131, 29)
        Label5.TabIndex = 8
        Label5.Text = "Year/Section"
        ' 
        ' cmbYearSection
        ' 
        cmbYearSection.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYearSection.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbYearSection.FormattingEnabled = True
        cmbYearSection.Location = New Point(1062, 263)
        cmbYearSection.Name = "cmbYearSection"
        cmbYearSection.Size = New Size(248, 37)
        cmbYearSection.TabIndex = 9
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(902, 339)
        Label6.Name = "Label6"
        Label6.Size = New Size(97, 29)
        Label6.TabIndex = 10
        Label6.Text = "Semester"
        ' 
        ' cmbSemester
        ' 
        cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSemester.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbSemester.FormattingEnabled = True
        cmbSemester.Location = New Point(1062, 331)
        cmbSemester.Name = "cmbSemester"
        cmbSemester.Size = New Size(248, 37)
        cmbSemester.TabIndex = 11
        ' 
        ' Label8
        ' 
        Label8.BackColor = SystemColors.ButtonShadow
        Label8.Location = New Point(329, 400)
        Label8.Name = "Label8"
        Label8.Size = New Size(1594, 2)
        Label8.TabIndex = 34
        ' 
        ' Panel5
        ' 
        Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), Image)
        Panel5.BackgroundImageLayout = ImageLayout.Stretch
        Panel5.Controls.Add(Label11)
        Panel5.Controls.Add(Label10)
        Panel5.Location = New Point(330, -2)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1595, 187)
        Panel5.TabIndex = 35
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Gold
        Label11.Location = New Point(411, 106)
        Label11.Name = "Label11"
        Label11.Size = New Size(763, 37)
        Label11.TabIndex = 1
        Label11.Text = "D A L U Y A N  N G  U M A A G O S  N A  P A G - A S A" & vbCrLf
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Century Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(181, 50)
        Label10.Name = "Label10"
        Label10.Size = New Size(1229, 56)
        Label10.TabIndex = 0
        Label10.Text = "P A M A N T A S A N  N G  L U N G S O D  N G  P A S I G" & vbCrLf
        ' 
        ' txtPercentageforquiz
        ' 
        txtPercentageforquiz.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        txtPercentageforquiz.Location = New Point(538, 522)
        txtPercentageforquiz.Name = "txtPercentageforquiz"
        txtPercentageforquiz.Size = New Size(91, 34)
        txtPercentageforquiz.TabIndex = 36
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(470, 527)
        Label9.Name = "Label9"
        Label9.Size = New Size(62, 29)
        Label9.TabIndex = 37
        Label9.Text = "QUIZ:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(931, 527)
        Label12.Name = "Label12"
        Label12.Size = New Size(70, 29)
        Label12.TabIndex = 39
        Label12.Text = "EXAM:"
        ' 
        ' txtPercantageforExam
        ' 
        txtPercantageforExam.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        txtPercantageforExam.Location = New Point(1007, 522)
        txtPercantageforExam.Name = "txtPercantageforExam"
        txtPercantageforExam.Size = New Size(91, 34)
        txtPercantageforExam.TabIndex = 38
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(670, 527)
        Label13.Name = "Label13"
        Label13.Size = New Size(107, 29)
        Label13.TabIndex = 41
        Label13.Text = "EXERCISE:"
        ' 
        ' txtPercentageforExercise
        ' 
        txtPercentageforExercise.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        txtPercentageforExercise.Location = New Point(796, 524)
        txtPercentageforExercise.Name = "txtPercentageforExercise"
        txtPercentageforExercise.Size = New Size(91, 34)
        txtPercentageforExercise.TabIndex = 40
        ' 
        ' btnAddQuiz
        ' 
        btnAddQuiz.BackColor = Color.Transparent
        btnAddQuiz.BackgroundImage = My.Resources.Resources.gold_111
        btnAddQuiz.BackgroundImageLayout = ImageLayout.Stretch
        btnAddQuiz.Location = New Point(696, 987)
        btnAddQuiz.Name = "btnAddQuiz"
        btnAddQuiz.Size = New Size(111, 37)
        btnAddQuiz.TabIndex = 0
        btnAddQuiz.Text = "Add Quiz"
        btnAddQuiz.UseVisualStyleBackColor = False
        ' 
        ' pnlExercise
        ' 
        pnlExercise.BorderStyle = BorderStyle.Fixed3D
        pnlExercise.Location = New Point(864, 578)
        pnlExercise.Name = "pnlExercise"
        pnlExercise.Size = New Size(469, 403)
        pnlExercise.TabIndex = 43
        ' 
        ' btnAddExercise
        ' 
        btnAddExercise.BackColor = Color.Transparent
        btnAddExercise.BackgroundImage = My.Resources.Resources.gold_1111
        btnAddExercise.BackgroundImageLayout = ImageLayout.Stretch
        btnAddExercise.Location = New Point(1210, 987)
        btnAddExercise.Name = "btnAddExercise"
        btnAddExercise.Size = New Size(123, 37)
        btnAddExercise.TabIndex = 0
        btnAddExercise.Text = "Add Exercise"
        btnAddExercise.UseVisualStyleBackColor = False
        ' 
        ' txtExamScore
        ' 
        txtExamScore.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        txtExamScore.Location = New Point(172, 22)
        txtExamScore.Name = "txtExamScore"
        txtExamScore.Size = New Size(79, 34)
        txtExamScore.TabIndex = 44
        ' 
        ' Panel6
        ' 
        Panel6.BorderStyle = BorderStyle.Fixed3D
        Panel6.Controls.Add(Label15)
        Panel6.Controls.Add(Label14)
        Panel6.Controls.Add(txtExamTotalItems)
        Panel6.Controls.Add(txtExamScore)
        Panel6.Controls.Add(txtGrade)
        Panel6.Controls.Add(Label17)
        Panel6.Location = New Point(1392, 578)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(409, 172)
        Panel6.TabIndex = 44
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(257, 25)
        Label15.Name = "Label15"
        Label15.Size = New Size(25, 29)
        Label15.TabIndex = 46
        Label15.Text = "/"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(25, 27)
        Label14.Name = "Label14"
        Label14.Size = New Size(121, 29)
        Label14.TabIndex = 45
        Label14.Text = "Exam Score:"
        ' 
        ' txtExamTotalItems
        ' 
        txtExamTotalItems.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        txtExamTotalItems.Location = New Point(286, 22)
        txtExamTotalItems.Name = "txtExamTotalItems"
        txtExamTotalItems.Size = New Size(79, 34)
        txtExamTotalItems.TabIndex = 45
        ' 
        ' txtGrade
        ' 
        txtGrade.Font = New Font("Franklin Gothic Demi Cond", 13.8F)
        txtGrade.Location = New Point(114, 116)
        txtGrade.Name = "txtGrade"
        txtGrade.ReadOnly = True
        txtGrade.Size = New Size(168, 34)
        txtGrade.TabIndex = 47
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(28, 119)
        Label17.Name = "Label17"
        Label17.Size = New Size(81, 29)
        Label17.TabIndex = 48
        Label17.Text = "GRADE:"
        ' 
        ' cmbStudents
        ' 
        cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStudents.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbStudents.FormattingEnabled = True
        cmbStudents.Location = New Point(538, 439)
        cmbStudents.Name = "cmbStudents"
        cmbStudents.Size = New Size(385, 37)
        cmbStudents.TabIndex = 45
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(443, 442)
        Label16.Name = "Label16"
        Label16.Size = New Size(89, 29)
        Label16.TabIndex = 46
        Label16.Text = "Student:"
        ' 
        ' pnlquiz
        ' 
        pnlquiz.BorderStyle = BorderStyle.Fixed3D
        pnlquiz.Location = New Point(377, 578)
        pnlquiz.Name = "pnlquiz"
        pnlquiz.Size = New Size(430, 403)
        pnlquiz.TabIndex = 44
        ' 
        ' btnCalculate
        ' 
        btnCalculate.BackgroundImage = My.Resources.Resources.gold_111
        btnCalculate.BackgroundImageLayout = ImageLayout.Stretch
        btnCalculate.Location = New Point(1678, 843)
        btnCalculate.Name = "btnCalculate"
        btnCalculate.Size = New Size(123, 38)
        btnCalculate.TabIndex = 1
        btnCalculate.Text = "Calculate"
        btnCalculate.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.Transparent
        btnSave.BackgroundImage = My.Resources.Resources.gold_111
        btnSave.BackgroundImageLayout = ImageLayout.Stretch
        btnSave.Location = New Point(1537, 843)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(123, 38)
        btnSave.TabIndex = 49
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackgroundImage = My.Resources.Resources.gold_111
        btnUpdate.BackgroundImageLayout = ImageLayout.Stretch
        btnUpdate.Location = New Point(1537, 895)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(123, 38)
        btnUpdate.TabIndex = 50
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(230))
        ClientSize = New Size(1924, 1055)
        Controls.Add(btnUpdate)
        Controls.Add(btnAddExercise)
        Controls.Add(btnAddQuiz)
        Controls.Add(btnSave)
        Controls.Add(btnCalculate)
        Controls.Add(pnlquiz)
        Controls.Add(Label16)
        Controls.Add(cmbStudents)
        Controls.Add(Panel6)
        Controls.Add(pnlExercise)
        Controls.Add(Label13)
        Controls.Add(txtPercentageforExercise)
        Controls.Add(Label12)
        Controls.Add(txtPercantageforExam)
        Controls.Add(Label9)
        Controls.Add(txtPercentageforquiz)
        Controls.Add(Panel5)
        Controls.Add(Label8)
        Controls.Add(cmbSemester)
        Controls.Add(Label6)
        Controls.Add(cmbYearSection)
        Controls.Add(Label5)
        Controls.Add(cmbSubject)
        Controls.Add(Label4)
        Controls.Add(txtSubjectCode)
        Controls.Add(Label3)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form2"
        Text = "a"
        WindowState = FormWindowState.Maximized
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnEncodeGrades As Button
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSubjectCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbSubject As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbYearSection As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbSemester As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPercentageforquiz As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPercantageforExam As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPercentageforExercise As TextBox
    Friend WithEvents btnAddQuiz As Button
    Friend WithEvents pnlExercise As Panel
    Friend WithEvents btnAddExercise As Button
    Friend WithEvents txtExamScore As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtExamTotalItems As TextBox
    Friend WithEvents cmbStudents As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents pnlquiz As Panel
    Friend WithEvents txtGrade As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btnCalculate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lkLogout As LinkLabel
End Class
