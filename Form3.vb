Imports System.Drawing.Drawing2D
Imports System.Net.Mail
Imports MySql.Data.MySqlClient

Public Class Form3

    Dim connection As MySqlConnection = database.GetConnection()

    Friend WithEvents Timer1 As Timer

    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing

    Public ProfessorID As Integer

    Public Sub New(profID As Integer)
        InitializeComponent()
        ProfessorID = profID
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1 = New Timer()
        Timer1.Interval = 1000
        Timer1.Start()
        UpdateDateTime()

        ToggleButtonState(btnGenerateReport)


        LoadSubjects()
        MakeButtonRoundedCorners(btnSendEmail, 50)
        MakeButtonRoundedCorners(btnShow, 50)
    End Sub

    Private Sub MakeButtonRoundedCorners(button As Button, cornerRadius As Integer)
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(0, 0, button.Width, button.Height)

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()
        button.Region = New Region(path)
    End Sub

    Private Sub LoadSubjects()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
            SELECT DISTINCT 
                ps.SubjectCode, 
                sub.SubjectName, 
                sub.Semester 
            FROM 
                proftosubject ps
            INNER JOIN 
                Subjects sub ON ps.SubjectCode = sub.SubjectCode
            WHERE 
                ps.ProfessorID = @ProfessorID
        "

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@ProfessorID", ProfessorID)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            cmbSubject.DataSource = Nothing

            Dim selectRow As DataRow = dt.NewRow()
            selectRow("SubjectCode") = DBNull.Value
            selectRow("SubjectName") = "-- Select Subject --"
            selectRow("Semester") = DBNull.Value
            dt.Rows.InsertAt(selectRow, 0)

            cmbSubject.DataSource = dt
            cmbSubject.DisplayMember = "SubjectName"
            cmbSubject.ValueMember = "SubjectCode"
            cmbSubject.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading subjects: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub



    Private Sub btnEncodeGrades_Click(sender As Object, e As EventArgs) Handles btnEncodeGrades.Click
        ToggleButtonState(btnEncodeGrades)
        Dim form2Instance As New Form2(ProfessorID)
        form2Instance.Show()

        Me.Close()
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        ToggleButtonState(btnGenerateReport)
    End Sub

    Private Sub btn_MouseHover(sender As Object, e As EventArgs) Handles _
        btnEncodeGrades.MouseHover, btnGenerateReport.MouseHover
        Dim btn As Button = CType(sender, Button)
        If activeButton IsNot btn Then
            btn.BackColor = hoverColor
        End If
    End Sub

    Private Sub btn_MouseLeave(sender As Object, e As EventArgs) Handles _
        btnEncodeGrades.MouseLeave, btnGenerateReport.MouseLeave
        Dim btn As Button = CType(sender, Button)
        If activeButton IsNot btn Then
            btn.BackColor = originalColor
        End If
    End Sub

    Private Sub ToggleButtonState(clickedButton As Button)
        If activeButton Is clickedButton Then
            clickedButton.BackColor = originalColor
            activeButton = Nothing
        Else
            If activeButton IsNot Nothing Then
                activeButton.BackColor = originalColor
            End If

            clickedButton.BackColor = hoverColor
            activeButton = clickedButton
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateDateTime()
    End Sub

    Private Sub UpdateDateTime()
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Using gradientBrush As New LinearGradientBrush(Panel2.ClientRectangle, Color.Transparent, Color.Transparent, 90.0F)
            Dim blend As New ColorBlend()
            blend.Colors = New Color() {Color.FromArgb(90, 173, 59), Color.FromArgb(47, 149, 9), Color.FromArgb(21, 59, 7)} ' Use RGB colors
            blend.Positions = New Single() {0.0F, 0.5F, 1.0F}

            gradientBrush.InterpolationColors = blend

            e.Graphics.FillRectangle(gradientBrush, Panel2.ClientRectangle)
        End Using
    End Sub

    Private Sub cmbSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubject.SelectedIndexChanged
        If cmbSubject.SelectedIndex > 0 Then
            Dim selectedSubject As String = cmbSubject.SelectedValue.ToString()

            Dim query As String = "
            SELECT DISTINCT sub.Semester 
            FROM 
                Subjects sub 
            WHERE 
                sub.SubjectCode = @SubjectCode
        "

            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SubjectCode", selectedSubject)

                Dim result As Object = cmd.ExecuteScalar()

                If result IsNot Nothing Then
                    txtSemester.Text = result.ToString()
                Else
                    txtSemester.Clear()
                End If

            Catch ex As Exception
                MessageBox.Show("Error loading semester: " & ex.Message)
            Finally
                If connection.State = ConnectionState.Open Then connection.Close()
            End Try

            txtSubjectCode.Text = selectedSubject
            LoadSections(selectedSubject)

        Else
            cmbYearSection.DataSource = Nothing
            txtSemester.Clear()
            txtSubjectCode.Clear()
        End If
    End Sub



    Private Sub LoadSections(subjectCode As String)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
            SELECT DISTINCT 
                ps.SectionID, 
                ps.YearLevel 
            FROM 
                proftosection ps
            INNER JOIN 
                proftosubject sub ON ps.SectionID = sub.SectionID
            WHERE 
                sub.SubjectCode = @SubjectCode AND sub.ProfessorID = @ProfessorID
        "

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)
            cmd.Parameters.AddWithValue("@ProfessorID", ProfessorID)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbYearSection.DataSource = dt
                cmbYearSection.DisplayMember = "YearLevel"
                cmbYearSection.ValueMember = "YearLevel"
            Else
                MessageBox.Show("No sections found for the selected subject.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading sections: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub



    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim selectedYearLevel As String = cmbYearSection.SelectedValue?.ToString()
        Dim selectedSubjectCode As String = cmbSubject.SelectedValue?.ToString()

        ' Validate if Year Level and Subject Code are selected
        If String.IsNullOrEmpty(selectedYearLevel) OrElse String.IsNullOrEmpty(selectedSubjectCode) Then
            MessageBox.Show("Please select both Year Level and Subject Code.")
            Return
        End If

        Try
            ' Ensure database connection is open
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' SQL Query to retrieve data based on Year Level and Subject Code
            Dim query As String = "
            SELECT 
                s.StudentID,
                s.LastName,
                s.FirstName,
                s.Email,
                f.SubjectCode,
                sub.SubjectName,
                f.FinalGrade
            FROM 
                STUDENT s
            LEFT JOIN 
                finalgrades f ON s.StudentID = f.StudentID
            LEFT JOIN 
                Subjects sub ON f.SubjectCode = sub.SubjectCode
            WHERE 
                s.YearLevel = @YearLevel AND f.SubjectCode = @SubjectCode
        "

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@YearLevel", selectedYearLevel)
            cmd.Parameters.AddWithValue("@SubjectCode", selectedSubjectCode)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            dgvStudents.DataSource = dt

            If dgvStudents.Columns.Contains("StudentID") Then
                dgvStudents.Columns("StudentID").Visible = False
            End If

            dgvStudents.Columns("LastName").Width = 150
            dgvStudents.Columns("FirstName").Width = 150
            dgvStudents.Columns("Email").Width = 300
            dgvStudents.Columns("SubjectCode").Width = 150
            dgvStudents.Columns("SubjectName").Width = 200
            dgvStudents.Columns("FinalGrade").Width = 150

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)

        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    Private Sub btnSendEmail_Click(sender As Object, e As EventArgs) Handles btnSendEmail.Click
        If dgvStudents.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = dgvStudents.SelectedRows(0)
            Dim lastName As String = selectedRow.Cells("LastName").Value.ToString()
            Dim firstName As String = selectedRow.Cells("FirstName").Value.ToString()
            Dim email As String = selectedRow.Cells("Email").Value.ToString()
            Dim subjectCode As String = selectedRow.Cells("SubjectCode").Value.ToString()
            Dim subjectName As String = selectedRow.Cells("SubjectName").Value.ToString()
            Dim finalGrade As String = selectedRow.Cells("FinalGrade").Value.ToString()

            Dim smtpClient As New SmtpClient("smtp.gmail.com")
            smtpClient.Port = 587
            smtpClient.Credentials = New Net.NetworkCredential("plpa73399@gmail.com", "qqwj erge tatm nnoo")
            smtpClient.EnableSsl = True

            Dim mailMessage As New MailMessage()
            mailMessage.From = New MailAddress("plpa73399@gmail.com")
            mailMessage.To.Add(email)
            mailMessage.Subject = $"Grade Notification for {subjectName} ({subjectCode})"
            mailMessage.Body = $"Dear {firstName} {lastName}," & vbCrLf &
                               $"Your final grade for {subjectName} ({subjectCode}) is: {finalGrade}." & vbCrLf &
                               "Best regards," & vbCrLf &
                               "PAMANTASAN NG LUNGSOD NG PASIG"

            smtpClient.Send(mailMessage)

            MessageBox.Show("Email sent successfully to " & email, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("An error occurred while sending the email: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
