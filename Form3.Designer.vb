<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Label6 = New Label()
        cmbYearSection = New ComboBox()
        Label5 = New Label()
        Label4 = New Label()
        txtSubjectCode = New TextBox()
        Label3 = New Label()
        btnGenerateReport = New Button()
        btnEncodeGrades = New Button()
        Panel3 = New Panel()
        lblDateTime = New Label()
        PictureBox2 = New PictureBox()
        cmbSubject = New ComboBox()
        Panel2 = New Panel()
        Panel1 = New Panel()
        Label8 = New Label()
        Panel5 = New Panel()
        Label11 = New Label()
        Label10 = New Label()
        dgvStudents = New DataGridView()
        txtSemester = New TextBox()
        btnShow = New Button()
        btnSendEmail = New Button()
        Panel3.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel5.SuspendLayout()
        CType(dgvStudents, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(902, 339)
        Label6.Name = "Label6"
        Label6.Size = New Size(97, 29)
        Label6.TabIndex = 26
        Label6.Text = "Semester"
        ' 
        ' cmbYearSection
        ' 
        cmbYearSection.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbYearSection.FormattingEnabled = True
        cmbYearSection.Location = New Point(1062, 263)
        cmbYearSection.Name = "cmbYearSection"
        cmbYearSection.Size = New Size(248, 37)
        cmbYearSection.TabIndex = 25
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(902, 271)
        Label5.Name = "Label5"
        Label5.Size = New Size(131, 29)
        Label5.TabIndex = 24
        Label5.Text = "Year/Section"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(442, 271)
        Label4.Name = "Label4"
        Label4.Size = New Size(84, 29)
        Label4.TabIndex = 22
        Label4.Text = "Subject "
        ' 
        ' txtSubjectCode
        ' 
        txtSubjectCode.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSubjectCode.Location = New Point(600, 339)
        txtSubjectCode.Name = "txtSubjectCode"
        txtSubjectCode.Size = New Size(248, 34)
        txtSubjectCode.TabIndex = 21
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(442, 344)
        Label3.Name = "Label3"
        Label3.Size = New Size(130, 29)
        Label3.TabIndex = 19
        Label3.Text = "Subject Code"
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
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(btnGenerateReport)
        Panel3.Controls.Add(btnEncodeGrades)
        Panel3.Location = New Point(329, 184)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1595, 53)
        Panel3.TabIndex = 20
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
        ' cmbSubject
        ' 
        cmbSubject.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbSubject.FormattingEnabled = True
        cmbSubject.Location = New Point(600, 263)
        cmbSubject.Name = "cmbSubject"
        cmbSubject.Size = New Size(248, 37)
        cmbSubject.TabIndex = 23
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(47), CByte(149), CByte(9))
        Panel2.Controls.Add(lblDateTime)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Location = New Point(69, -2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(261, 1058)
        Panel2.TabIndex = 18
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(227), CByte(219), CByte(36))
        Panel1.Location = New Point(0, -2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(70, 1058)
        Panel1.TabIndex = 17
        ' 
        ' Label8
        ' 
        Label8.BackColor = SystemColors.ButtonShadow
        Label8.Location = New Point(330, 396)
        Label8.Name = "Label8"
        Label8.Size = New Size(1594, 2)
        Label8.TabIndex = 33
        ' 
        ' Panel5
        ' 
        Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), Image)
        Panel5.BackgroundImageLayout = ImageLayout.Stretch
        Panel5.Controls.Add(Label11)
        Panel5.Controls.Add(Label10)
        Panel5.Location = New Point(329, -2)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1595, 187)
        Panel5.TabIndex = 34
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Gold
        Label11.Location = New Point(642, 106)
        Label11.Name = "Label11"
        Label11.Size = New Size(495, 74)
        Label11.TabIndex = 1
        Label11.Text = "S T U D E N T  G R A D E  R E P O R T" & vbCrLf & vbCrLf
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
        ' dgvStudents
        ' 
        dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStudents.Location = New Point(549, 464)
        dgvStudents.Name = "dgvStudents"
        dgvStudents.RowHeadersWidth = 51
        dgvStudents.Size = New Size(1173, 540)
        dgvStudents.TabIndex = 35
        ' 
        ' txtSemester
        ' 
        txtSemester.Font = New Font("Franklin Gothic Demi Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSemester.Location = New Point(1062, 339)
        txtSemester.Name = "txtSemester"
        txtSemester.Size = New Size(248, 34)
        txtSemester.TabIndex = 36
        ' 
        ' btnShow
        ' 
        btnShow.BackgroundImage = My.Resources.Resources.gold_111
        btnShow.BackgroundImageLayout = ImageLayout.Stretch
        btnShow.Location = New Point(1448, 297)
        btnShow.Name = "btnShow"
        btnShow.Size = New Size(203, 34)
        btnShow.TabIndex = 37
        btnShow.Text = "Show"
        btnShow.UseVisualStyleBackColor = True
        ' 
        ' btnSendEmail
        ' 
        btnSendEmail.BackgroundImage = My.Resources.Resources.gold_111
        btnSendEmail.BackgroundImageLayout = ImageLayout.Stretch
        btnSendEmail.Location = New Point(1448, 344)
        btnSendEmail.Name = "btnSendEmail"
        btnSendEmail.Size = New Size(203, 34)
        btnSendEmail.TabIndex = 38
        btnSendEmail.Text = "Send Email"
        btnSendEmail.UseVisualStyleBackColor = True
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 1055)
        Controls.Add(btnSendEmail)
        Controls.Add(btnShow)
        Controls.Add(txtSemester)
        Controls.Add(dgvStudents)
        Controls.Add(Panel5)
        Controls.Add(Label8)
        Controls.Add(Label6)
        Controls.Add(cmbYearSection)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(txtSubjectCode)
        Controls.Add(Label3)
        Controls.Add(Panel3)
        Controls.Add(cmbSubject)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form3"
        Text = "Form3"
        WindowState = FormWindowState.Maximized
        Panel3.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(dgvStudents, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbYearSection As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSubjectCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents btnEncodeGrades As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblDateTime As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents cmbSubject As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dgvStudents As DataGridView
    Friend WithEvents txtSemester As TextBox
    Friend WithEvents btnShow As Button
    Friend WithEvents btnSendEmail As Button
End Class
