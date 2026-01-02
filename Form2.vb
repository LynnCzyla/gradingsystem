Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class Form2
    Public Property AuthenticatedProfessorID As Integer
    Public Property AssignmentID As Integer
    Public Property ProfessorID As Integer

    Dim connection As MySqlConnection = database.GetConnection()

    Friend WithEvents Timer1 As Timer

    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing
    Public Sub New(professorID As Integer, assignmentID As Integer)
        InitializeComponent()
        Me.AuthenticatedProfessorID = professorID
        Me.AssignmentID = assignmentID
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(profID As Integer)
        InitializeComponent()
        AuthenticatedProfessorID = profID
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulateSubjectComboBox()
        PopulateSectionComboBox()

        Timer1 = New Timer()
        Timer1.Interval = 1000
        Timer1.Start()
        UpdateDateTime()
        ToggleButtonState(btnEncodeGrades)
    End Sub

    Private Sub btnEncodeGrades_Click(sender As Object, e As EventArgs) Handles btnEncodeGrades.Click
        ToggleButtonState(btnEncodeGrades)
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        Dim reportForm As New Form3(AuthenticatedProfessorID)
        reportForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_MouseHover(sender As Object, e As EventArgs) Handles btnEncodeGrades.MouseHover, btnGenerateReport.MouseHover
        Dim btn = CType(sender, Button)
        If activeButton IsNot btn Then
            btn.BackColor = hoverColor
        End If
    End Sub

    Private Sub btn_MouseLeave(sender As Object, e As EventArgs) Handles btnEncodeGrades.MouseLeave, btnGenerateReport.MouseLeave
        Dim btn = CType(sender, Button)
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateDateTime()
    End Sub

    Private Sub UpdateDateTime()
        lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    End Sub

    Private Sub PopulateSubjectComboBox()
        Try
            Dim subjects As DataTable = GetSubjectsForProfessor(AuthenticatedProfessorID)

            If subjects IsNot Nothing AndAlso subjects.Rows.Count > 0 Then
                cmbSubject.DataSource = Nothing
                cmbSubject.Items.Clear()

                Dim placeholder As New DataTable()
                placeholder.Columns.Add("SubjectName")
                placeholder.Columns.Add("SubjectCode")

                Dim placeholderRow As DataRow = placeholder.NewRow()
                placeholderRow("SubjectName") = "---- Select Subject ----"
                placeholderRow("SubjectCode") = DBNull.Value
                placeholder.Rows.Add(placeholderRow)

                placeholder.Merge(subjects)

                cmbSubject.DataSource = placeholder
                cmbSubject.DisplayMember = "SubjectName"
                cmbSubject.ValueMember = "SubjectCode"
            Else
                MessageBox.Show("No subjects found for this professor!")
            End If

        Catch ex As Exception
            MessageBox.Show("Error fetching subjects: " & ex.Message)
        End Try
    End Sub


    Private Sub PopulateSectionComboBox()
        Try
            Dim sections As DataTable = GetSectionsForProfessor(AuthenticatedProfessorID)

            If sections IsNot Nothing AndAlso sections.Rows.Count > 0 Then
                Dim placeholderRow As DataRow = sections.NewRow()
                placeholderRow("YearLevel") = "-----Section-----"
                sections.Rows.InsertAt(placeholderRow, 0)

                cmbYearSection.DataSource = sections
                cmbYearSection.DisplayMember = "YearLevel"
                cmbYearSection.ValueMember = "YearLevel"

                cmbYearSection.SelectedIndex = 0
            Else
                MessageBox.Show("No sections were found for the professor!", "Info", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show($"Database query failed. {ex.Message}")
        End Try
    End Sub

    Private Function GetSubjectsForProfessor(professorID As Integer) As DataTable
        Dim dt As New DataTable()

        Try
            Using connection As MySqlConnection = database.GetConnection()

                If connection Is Nothing Then
                    MessageBox.Show("Database connection failed.")
                    Return Nothing
                End If

                Dim query As String = "
                SELECT DISTINCT s.SubjectName, s.SubjectCode 
                FROM ProftoSubject AS ps
                INNER JOIN Subjects AS s ON ps.SubjectCode = s.SubjectCode 
                WHERE ps.ProfessorID = @ProfessorID;
            "

                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@ProfessorID", professorID)

                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)



            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        End Try

        Return dt
    End Function

    Private Function GetSectionsForProfessor(professorID As Integer) As DataTable
        Dim dt As New DataTable()

        Try
            Using connection As MySqlConnection = database.GetConnection()

                If connection.State <> ConnectionState.Open Then
                    connection.Open()
                End If

                Dim query As String = "
                SELECT DISTINCT YearLevel 
                FROM PROFTOSECTION 
                WHERE ProfessorID = @ProfessorID
            "

                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@ProfessorID", professorID)

                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)

            End Using

        Catch ex As Exception
            MessageBox.Show("Failed to load sections: " & ex.Message)
        End Try

        Return dt
    End Function

    Private Sub LoadSemesterComboBox(subjectCode As String)
        Try
            Dim query As String = "
            SELECT DISTINCT Semester 
            FROM ProftoSubject 
            WHERE SubjectCode = @SubjectCode 
            AND ProfessorID = @ProfessorID;
        "

            Using connection As MySqlConnection = database.GetConnection()
                If connection.State <> ConnectionState.Open Then
                    connection.Open()
                End If

                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)
                cmd.Parameters.AddWithValue("@ProfessorID", AuthenticatedProfessorID)

                Dim dt As New DataTable()
                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)

                cmbSemester.Items.Clear()
                For Each row As DataRow In dt.Rows
                    cmbSemester.Items.Add(row("Semester").ToString().Trim())
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading semesters: " & ex.Message)
        End Try
    End Sub


    Private Sub btnAddQuiz_Click(sender As Object, e As EventArgs) Handles btnAddQuiz.Click

        If Not IsNumeric(txtPercentageforquiz.Text) OrElse Not IsNumeric(txtPercantageforExam.Text) OrElse Not IsNumeric(txtPercentageforExercise.Text) Then
            MessageBox.Show("Please fill in valid percentages for Quiz, Exercise, and Exam first.", "Percentage Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim quizLabelsCount As Integer = pnlquiz.Controls.OfType(Of Label)().Count(Function(lbl) lbl.Text.StartsWith("Quiz"))
        Dim quizNumber As Integer = quizLabelsCount + 1

        Dim yPos As Integer = 5 + (quizNumber) * 30

        Dim lblQuiz As New Label With {
            .Text = $"Quiz {quizNumber}",
            .AutoSize = True,
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .Location = New Point(10, yPos)
        }

        Dim txtScore As New TextBox With {
            .Name = $"txtScore{quizNumber}",
            .Width = 100,
            .Location = New Point(100, yPos)
        }

        Dim lblSeparator As New Label With {
            .Text = "/",
            .AutoSize = True,
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .Location = New Point(210, yPos)
        }

        Dim txtTotalItems As New TextBox With {
            .Name = $"txtTotalItems{quizNumber}",
            .Width = 100,
            .Location = New Point(230, yPos)
        }

        pnlquiz.Controls.Add(lblQuiz)
        pnlquiz.Controls.Add(txtScore)
        pnlquiz.Controls.Add(lblSeparator)
        pnlquiz.Controls.Add(txtTotalItems)


        pnlquiz.Refresh()

    End Sub

    Private Sub btnAddExercise_Click(sender As Object, e As EventArgs) Handles btnAddExercise.Click
        Dim exerciseNumber As Integer = pnlExercise.Controls.OfType(Of Label)().
                                Count(Function(lbl) lbl.Text.StartsWith("Exercise")) + 1

        Dim yPos As Integer = 5 + (exerciseNumber) * 30

        Dim lblExercise As New Label With {
    .Text = $"Exercise {exerciseNumber}",
    .AutoSize = True,
    .Font = New Font("Arial", 12, FontStyle.Bold),
    .Location = New Point(10, yPos)
}
        Dim txtScore As New TextBox With {
    .Name = $"txtExerciseScore{exerciseNumber}",
    .Width = 100,
    .Location = New Point(120, yPos)
}
        Dim lblSeparator As New Label With {
    .Text = "/",
    .AutoSize = True,
    .Font = New Font("Arial", 12, FontStyle.Bold),
    .Location = New Point(220, yPos)
}
        Dim txtTotalItems As New TextBox With {
    .Name = $"txtExerciseTotalItems{exerciseNumber}",
    .Width = 100,
    .Location = New Point(240, yPos)
}

        pnlExercise.Controls.Add(lblExercise)
        pnlExercise.Controls.Add(txtScore)
        pnlExercise.Controls.Add(lblSeparator)
        pnlExercise.Controls.Add(txtTotalItems)
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim quizPercentage As Decimal
        Dim exercisePercentage As Decimal
        Dim examPercentage As Decimal

        If String.IsNullOrWhiteSpace(txtPercentageforquiz.Text) OrElse
       String.IsNullOrWhiteSpace(txtPercentageforExercise.Text) OrElse
       String.IsNullOrWhiteSpace(txtPercantageforExam.Text) OrElse
       Not Decimal.TryParse(txtPercentageforquiz.Text, quizPercentage) OrElse
       Not Decimal.TryParse(txtPercentageforExercise.Text, exercisePercentage) OrElse
       Not Decimal.TryParse(txtPercantageforExam.Text, examPercentage) Then
            MessageBox.Show("Please fill in all percentage fields with valid numbers.", "Incomplete Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim examScore As Decimal, examTotalItems As Decimal
        If String.IsNullOrWhiteSpace(txtExamScore.Text) OrElse
       String.IsNullOrWhiteSpace(txtExamTotalItems.Text) OrElse
       Not Decimal.TryParse(txtExamScore.Text, examScore) OrElse
       Not Decimal.TryParse(txtExamTotalItems.Text, examTotalItems) OrElse
       examTotalItems <= 0 Then
            MessageBox.Show("Please provide valid scores and total items for the Exam.", "Incomplete Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim totalPercent As Decimal = quizPercentage + exercisePercentage + examPercentage
        If totalPercent <> 100 Then
            MessageBox.Show("Percentages should add up to 100.", "Percentage Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim quizzesFilled As Boolean = False
        For Each ctrl As Control In pnlquiz.Controls
            If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtScore") Then
                Dim quizNumber As String = ctrl.Name.Substring("txtScore".Length)
                Dim txtTotalItems As TextBox = pnlquiz.Controls.OfType(Of TextBox)().
                                            FirstOrDefault(Function(x) x.Name = $"txtTotalItems{quizNumber}")

                If txtTotalItems IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ctrl.Text) AndAlso Not String.IsNullOrWhiteSpace(txtTotalItems.Text) Then
                    quizzesFilled = True
                    Exit For
                End If
            End If
        Next

        If Not quizzesFilled Then
            MessageBox.Show("Please provide scores and total items for at least one quiz.", "Incomplete Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim exercisesFilled As Boolean = False
        For Each ctrl As Control In pnlExercise.Controls
            If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtExerciseScore") Then
                Dim exerciseNumber As String = ctrl.Name.Substring("txtExerciseScore".Length)
                Dim txtTotalItems As TextBox = pnlExercise.Controls.OfType(Of TextBox)().
                                            FirstOrDefault(Function(x) x.Name = $"txtExerciseTotalItems{exerciseNumber}")

                If txtTotalItems IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ctrl.Text) AndAlso Not String.IsNullOrWhiteSpace(txtTotalItems.Text) Then
                    exercisesFilled = True
                    Exit For
                End If
            End If
        Next

        If Not exercisesFilled Then
            MessageBox.Show("Please provide scores and total items for at least one exercise.", "Incomplete Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim totalQuizScore As Decimal = 0
        Dim totalQuizItems As Decimal = 0
        Dim totalValidQuizzes As Integer = 0

        Dim totalExerciseScore As Decimal = 0
        Dim totalExerciseItems As Decimal = 0
        Dim totalValidExercises As Integer = 0

        Dim weightedExamScore As Decimal = (examScore / examTotalItems) * 100 * (examPercentage / 100)

        For Each ctrl As Control In pnlquiz.Controls
            If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtScore") Then
                Dim quizNumber As String = ctrl.Name.Substring("txtScore".Length)
                Dim txtTotalItems As TextBox = pnlquiz.Controls.OfType(Of TextBox)().
                                                FirstOrDefault(Function(x) x.Name = $"txtTotalItems{quizNumber}")

                If txtTotalItems IsNot Nothing Then
                    Dim score As Decimal
                    Dim totalItems As Decimal

                    If Decimal.TryParse(ctrl.Text, score) AndAlso Decimal.TryParse(txtTotalItems.Text, totalItems) AndAlso totalItems > 0 Then
                        totalQuizScore += (score / totalItems) * 100
                        totalValidQuizzes += 1
                    End If
                End If
            End If
        Next

        For Each ctrl As Control In pnlExercise.Controls
            If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtExerciseScore") Then
                Dim exerciseNumber As String = ctrl.Name.Substring("txtExerciseScore".Length)
                Dim txtTotalItems As TextBox = pnlExercise.Controls.OfType(Of TextBox)().
                                            FirstOrDefault(Function(x) x.Name = $"txtExerciseTotalItems{exerciseNumber}")

                If txtTotalItems IsNot Nothing Then
                    Dim score As Decimal
                    Dim totalItems As Decimal

                    If Decimal.TryParse(ctrl.Text, score) AndAlso Decimal.TryParse(txtTotalItems.Text, totalItems) AndAlso totalItems > 0 Then
                        totalExerciseScore += (score / totalItems) * 100
                        totalValidExercises += 1
                    End If
                End If
            End If
        Next

        If totalValidQuizzes = 0 Then
            MessageBox.Show("No valid quizzes found. Please enter scores and total items.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim averageQuizScore As Decimal = totalQuizScore / totalValidQuizzes
        Dim weightedQuizScore As Decimal = averageQuizScore * (quizPercentage / 100)

        Dim averageExerciseScore As Decimal = If(totalValidExercises > 0, totalExerciseScore / totalValidExercises, 0)
        Dim weightedExerciseScore As Decimal = averageExerciseScore * (exercisePercentage / 100)

        Dim finalWeightedScore As Decimal = weightedQuizScore + weightedExerciseScore + weightedExamScore
        txtGrade.Text = finalWeightedScore.ToString("F2")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim selectedStudentID As Object = cmbStudents.SelectedValue

            Dim selectedYearLevel As String = cmbYearSection.SelectedValue?.ToString()

            If String.IsNullOrEmpty(selectedYearLevel) Then
                MessageBox.Show("Please select a Year Level.")
                Return
            End If

            Dim yearID As Integer = GetYearIDFromYearLevel(selectedYearLevel)

            If yearID = -1 Then
                MessageBox.Show("Year Level not found in the database.")
                Return
            End If

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim transaction As MySqlTransaction = connection.BeginTransaction()

            Try
                For Each ctrl As Control In pnlquiz.Controls
                    If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtScore") Then
                        Dim quizNumber As String = ctrl.Name.Substring("txtScore".Length)
                        Dim txtTotalItems As TextBox = pnlquiz.Controls.OfType(Of TextBox)().FirstOrDefault(Function(x) x.Name = $"txtTotalItems{quizNumber}")

                        If txtTotalItems IsNot Nothing Then
                            Dim score As Decimal
                            Dim totalItems As Decimal

                            If Decimal.TryParse(ctrl.Text, score) AndAlso Decimal.TryParse(txtTotalItems.Text, totalItems) Then
                                UpdateOrInsertActivity(selectedStudentID, yearID, txtSubjectCode.Text, "Quiz", $"Quiz {quizNumber}", score, txtPercentageforquiz.Text, totalItems, transaction)
                            End If
                        End If
                    End If
                Next

                For Each ctrl As Control In pnlExercise.Controls
                    If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtExerciseScore") Then
                        Dim exerciseNumber As String = ctrl.Name.Substring("txtExerciseScore".Length)
                        Dim txtTotalItems As TextBox = pnlExercise.Controls.OfType(Of TextBox)().FirstOrDefault(Function(x) x.Name = $"txtExerciseTotalItems{exerciseNumber}")

                        If txtTotalItems IsNot Nothing Then
                            Dim score As Decimal
                            Dim totalItems As Decimal

                            If Decimal.TryParse(ctrl.Text, score) AndAlso Decimal.TryParse(txtTotalItems.Text, totalItems) Then
                                UpdateOrInsertActivity(selectedStudentID, yearID, txtSubjectCode.Text, "Exercise", $"Exercise {exerciseNumber}", score, txtPercentageforquiz.Text, totalItems, transaction)
                            End If
                        End If
                    End If
                Next

                Dim examScore As Decimal
                Dim examTotalItems As Decimal

                If Decimal.TryParse(txtExamScore.Text, examScore) AndAlso Decimal.TryParse(txtExamTotalItems.Text, examTotalItems) Then
                    UpdateOrInsertActivity(selectedStudentID, yearID, txtSubjectCode.Text, "Exam", "Exam", examScore, txtPercantageforExam.Text, examTotalItems, transaction)
                Else
                    MessageBox.Show("Invalid exam score or total items.")
                    Return
                End If

                Dim finalGrade As Decimal
                If Decimal.TryParse(txtGrade.Text, finalGrade) Then
                    Dim cmdCheckFinalGrade As New MySqlCommand("SELECT COUNT(*) FROM finalgrades WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode", connection, transaction)
                    cmdCheckFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmdCheckFinalGrade.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)

                    Dim recordExists As Boolean = Convert.ToInt32(cmdCheckFinalGrade.ExecuteScalar()) > 0

                    If recordExists Then
                        Dim cmdUpdateFinalGrade As New MySqlCommand("UPDATE finalgrades SET FinalGrade = @FinalGrade WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode", connection, transaction)
                        cmdUpdateFinalGrade.Parameters.AddWithValue("@FinalGrade", finalGrade)
                        cmdUpdateFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
                        cmdUpdateFinalGrade.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)
                        cmdUpdateFinalGrade.ExecuteNonQuery()
                    Else
                        Dim cmdInsertFinalGrade As New MySqlCommand("INSERT INTO finalgrades (StudentID, SubjectCode, FinalGrade) VALUES (@StudentID, @SubjectCode, @FinalGrade)", connection, transaction)
                        cmdInsertFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
                        cmdInsertFinalGrade.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)
                        cmdInsertFinalGrade.Parameters.AddWithValue("@FinalGrade", finalGrade)
                        cmdInsertFinalGrade.ExecuteNonQuery()
                    End If
                End If

                transaction.Commit()

                txtGrade.Text = finalGrade.ToString("F2")

                MessageBox.Show("Records saved successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch innerEx As Exception
                If transaction IsNot Nothing Then transaction.Rollback()
                MessageBox.Show($"An error occurred: {innerEx.Message}", "Save Error", MessageBoxButtons.OK)
            End Try

        Catch outerEx As Exception
            MessageBox.Show($"Database Connection Error: {outerEx.Message}")
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Function GetYearIDFromYearLevel(yearLevel As String) As Integer
        Dim yearID As Integer = -1

        Try
            Using connection As MySqlConnection = database.GetConnection()

                Dim query As String = "SELECT YearID FROM schooldetails WHERE YearLevel = @YearLevel;"
                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel)

                If connection.State <> ConnectionState.Open Then
                    connection.Open()
                End If
                Dim result = cmd.ExecuteScalar()

                If result IsNot Nothing Then
                    yearID = Convert.ToInt32(result)
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show($"Database Error: {ex.Message}")
        End Try

        Return yearID
    End Function

    Private Sub PopulateStudentsComboBox(yearLevel As String)
        Try
            Using connection As MySqlConnection = database.GetConnection()

                Dim query As String = "SELECT StudentID, CONCAT(lastname, ', ', firstname, ' ', middlename) AS FullName FROM student WHERE yearLevel = @YearLevel;"
                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()

                adapter.Fill(dt)

                Dim placeholderRow As DataRow = dt.NewRow()
                placeholderRow("StudentID") = DBNull.Value
                placeholderRow("FullName") = "---Student---"
                dt.Rows.InsertAt(placeholderRow, 0)

                cmbStudents.DataSource = dt
                cmbStudents.DisplayMember = "FullName"
                cmbStudents.ValueMember = "StudentID"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database Error: {ex.Message}")
        End Try
    End Sub


    Private Sub cmbYearSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYearSection.SelectedIndexChanged
        Dim selectedYearLevel As String = cmbYearSection.SelectedValue.ToString()

        PopulateStudentsComboBox(selectedYearLevel)
    End Sub

    Private Sub RetrieveExamData(studentID As String, yearID As Integer, subjectCode As String)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim cmd As New MySqlCommand("SELECT Score, Percentage, TotalItems FROM activities 
                                      WHERE StudentID = @StudentID AND YearID = @YearID 
                                      AND SubjectCode = @SubjectCode AND Type = 'Exam'", connection)
            cmd.Parameters.AddWithValue("@StudentID", studentID)
            cmd.Parameters.AddWithValue("@YearID", yearID)
            cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtExamScore.Text = reader("Score").ToString()
                txtPercantageforExam.Text = reader("Percentage").ToString()
                txtExamTotalItems.Text = reader("TotalItems").ToString()
            Else
                txtExamScore.Text = ""
                txtPercantageforExam.Text = ""
                txtExamTotalItems.Text = ""
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}")
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub RetrieveQuizAndExerciseData(studentID As String, yearID As Integer, subjectCode As String)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim cmd As New MySqlCommand("
            SELECT 
                CASE WHEN Type = 'Quiz' THEN Percentage END AS QuizPercentage,
                CASE WHEN Type = 'Exercise' THEN Percentage END AS ExercisePercentage
            FROM activities
            WHERE StudentID = @StudentID AND YearID = @YearID AND SubjectCode = @SubjectCode", connection)

            cmd.Parameters.AddWithValue("@StudentID", studentID)
            cmd.Parameters.AddWithValue("@YearID", yearID)
            cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                While reader.Read()
                    If Not IsDBNull(reader("QuizPercentage")) Then
                        txtPercentageforquiz.Text = reader("QuizPercentage").ToString()
                    End If

                    If Not IsDBNull(reader("ExercisePercentage")) Then
                        txtPercentageforExercise.Text = reader("ExercisePercentage").ToString()
                    End If
                End While
            Else
                txtPercentageforquiz.Text = ""
                txtPercentageforExercise.Text = ""
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}")
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Function GetQuizData(studentID As String, subjectCode As String) As List(Of Dictionary(Of String, Object))
        Dim quizData As New List(Of Dictionary(Of String, Object))

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT ActivityName, Score, TotalItems FROM activities WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode AND Type = 'Quiz'"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@StudentID", studentID)
            cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim data As New Dictionary(Of String, Object)
                data("ActivityName") = reader("ActivityName").ToString()
                data("Score") = Convert.ToDecimal(reader("Score"))
                data("TotalItems") = Convert.ToDecimal(reader("TotalItems"))
                quizData.Add(data)
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show($"Database Error: {ex.Message}")
        End Try

        Return quizData
    End Function

    Private Function GetExerciseData(studentID As String, subjectCode As String) As List(Of Dictionary(Of String, Object))

        Dim exerciseData As New List(Of Dictionary(Of String, Object))

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT ActivityName, Score, TotalItems FROM activities 
                                   WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode AND Type = 'Exercise'"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@StudentID", studentID)
            cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim data As New Dictionary(Of String, Object)
                If Not IsDBNull(reader("ActivityName")) Then
                    data("ActivityName") = reader("ActivityName").ToString()
                Else
                    data("ActivityName") = "Unknown"
                End If
                data("Score") = If(reader("Score") IsNot DBNull.Value, Convert.ToDecimal(reader("Score")), 0)
                data("TotalItems") = If(reader("TotalItems") IsNot DBNull.Value, Convert.ToDecimal(reader("TotalItems")), 0)
                exerciseData.Add(data)
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show($"Database Error: {ex.Message}")
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try

        Return exerciseData
    End Function

    Private Sub cmbSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubject.SelectedIndexChanged
        Try
            Dim drv As DataRowView = TryCast(cmbSubject.SelectedItem, DataRowView)

            If drv IsNot Nothing Then
                Dim subjectCode As String = drv("SubjectCode").ToString()
                txtSubjectCode.Text = subjectCode

                ClearQuizPanel()
                ClearExercisePanel()

                LoadSemesterComboBox(subjectCode)

                Dim studentID As String = "2"
                Dim yearID As Integer = 25

                RetrieveExamData(studentID, yearID, subjectCode)
                RetrieveQuizAndExerciseData(studentID, yearID, subjectCode)
            End If
        Catch ex As Exception
            MessageBox.Show("Error handling subject selection: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearQuizPanel()
        pnlquiz.Controls.Clear()
    End Sub

    ' Method to clear the Exercise Panel
    Private Sub ClearExercisePanel()
        pnlExercise.Controls.Clear()
        txtGrade.Clear()
    End Sub

    Private previousSelectedStudentID As String = String.Empty

    Private Sub cmbStudents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStudents.SelectedIndexChanged
        Dim selectedStudentID As String = cmbStudents.SelectedValue?.ToString()
        Dim selectedYearLevel As String = cmbYearSection.SelectedValue?.ToString()
        Dim selectedSubjectCode As String = cmbSubject.SelectedValue?.ToString()
        Dim yearID As Integer = GetYearIDFromYearLevel(selectedYearLevel)

        If String.IsNullOrEmpty(selectedStudentID) Then Return
        pnlquiz.Controls.Clear()
        pnlExercise.Controls.Clear()

        Dim quizData As List(Of Dictionary(Of String, Object)) = GetQuizData(selectedStudentID, selectedSubjectCode)

        Dim quizNumber As Integer = 1
        For Each quiz As Dictionary(Of String, Object) In quizData
            Dim lblQuiz As New Label With {
            .Text = $"Quiz {quizNumber}",
            .AutoSize = True,
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .Location = New Point(10, 5 + quizNumber * 30)
        }
            Dim txtScore As New TextBox With {
            .Name = $"txtScore{quizNumber}",
            .Text = quiz("Score").ToString(),
            .Width = 100,
            .Location = New Point(100, 5 + quizNumber * 30)
        }
            Dim lblSeparator As New Label With {
            .Text = "/",
            .AutoSize = True,
            .Location = New Point(210, 5 + quizNumber * 30)
        }
            Dim txtTotalItems As New TextBox With {
            .Name = $"txtTotalItems{quizNumber}",
            .Text = quiz("TotalItems").ToString(),
            .Width = 100,
            .Location = New Point(230, 5 + quizNumber * 30)
        }

            pnlquiz.Controls.Add(lblQuiz)
            pnlquiz.Controls.Add(txtScore)
            pnlquiz.Controls.Add(lblSeparator)
            pnlquiz.Controls.Add(txtTotalItems)

            quizNumber += 1
        Next

        Dim exerciseData As List(Of Dictionary(Of String, Object)) = GetExerciseData(selectedStudentID, selectedSubjectCode)

        Dim exerciseNumber As Integer = 1
        For Each exercise As Dictionary(Of String, Object) In exerciseData
            Dim lblExercise As New Label With {
            .Text = $"Exercise {exerciseNumber}",
            .AutoSize = True,
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .Location = New Point(10, 5 + exerciseNumber * 30)
        }
            Dim txtExerciseScore As New TextBox With {
            .Name = $"txtExerciseScore{exerciseNumber}",
            .Text = exercise("Score").ToString(),
            .Width = 100,
            .Location = New Point(120, 5 + exerciseNumber * 30)
        }
            Dim lblExerciseSeparator As New Label With {
            .Text = "/",
            .AutoSize = True,
            .Location = New Point(220, 5 + exerciseNumber * 30)
        }
            Dim txtExerciseTotalItems As New TextBox With {
            .Name = $"txtExerciseTotalItems{exerciseNumber}",
            .Text = exercise("TotalItems").ToString(),
            .Width = 100,
            .Location = New Point(240, 5 + exerciseNumber * 30)
        }
            pnlExercise.Controls.Add(lblExercise)
            pnlExercise.Controls.Add(txtExerciseScore)
            pnlExercise.Controls.Add(lblExerciseSeparator)
            pnlExercise.Controls.Add(txtExerciseTotalItems)

            exerciseNumber += 1
        Next

        If Not String.IsNullOrEmpty(selectedStudentID) Then
            Dim cmdExamScore As New MySqlCommand("SELECT Score, Percentage, TotalItems FROM activities WHERE StudentID = @StudentID AND Type = 'Exam' AND SubjectCode = @SubjectCode", connection)
            cmdExamScore.Parameters.AddWithValue("@StudentID", selectedStudentID)
            cmdExamScore.Parameters.AddWithValue("@SubjectCode", cmbSubject.SelectedValue?.ToString())

            If connection.State = ConnectionState.Closed Then connection.Open()

            Dim reader As MySqlDataReader = cmdExamScore.ExecuteReader()
            If reader.Read() Then
                txtExamScore.Text = reader("Score").ToString()
                txtExamTotalItems.Text = reader("TotalItems").ToString()
                txtPercantageforExam.Text = reader("Percentage").ToString()
            Else
                txtExamScore.Clear()
                txtExamTotalItems.Clear()
                txtPercantageforExam.Clear()
            End If
            reader.Close()

            ' Retrieve Quiz Percentage
            Dim cmdQuizPercentage As New MySqlCommand("SELECT Percentage FROM activities WHERE StudentID = @StudentID AND Type = 'Quiz' AND SubjectCode = @SubjectCode", connection)
            cmdQuizPercentage.Parameters.AddWithValue("@StudentID", selectedStudentID)
            cmdQuizPercentage.Parameters.AddWithValue("@SubjectCode", cmbSubject.SelectedValue?.ToString())

            Dim readerQuizPercentage As MySqlDataReader = cmdQuizPercentage.ExecuteReader()
            If readerQuizPercentage.Read() Then
                txtPercentageforquiz.Text = readerQuizPercentage("Percentage").ToString()
            Else
                txtPercentageforquiz.Clear()
            End If
            readerQuizPercentage.Close()

            ' Retrieve Exercise Percentage
            Dim cmdExercisePercentage As New MySqlCommand("SELECT Percentage FROM activities WHERE StudentID = @StudentID AND Type = 'Exercise' AND SubjectCode = @SubjectCode", connection)
            cmdExercisePercentage.Parameters.AddWithValue("@StudentID", selectedStudentID)
            cmdExercisePercentage.Parameters.AddWithValue("@SubjectCode", cmbSubject.SelectedValue?.ToString())

            Dim readerExercisePercentage As MySqlDataReader = cmdExercisePercentage.ExecuteReader()
            If readerExercisePercentage.Read() Then
                txtPercentageforExercise.Text = readerExercisePercentage("Percentage").ToString()
            Else
                txtPercentageforExercise.Clear()
            End If
            readerExercisePercentage.Close()

            ' Retrieve Final Grade
            Dim cmdFinalGrade As New MySqlCommand("SELECT FinalGrade FROM finalgrades WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode", connection)
            cmdFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
            cmdFinalGrade.Parameters.AddWithValue("@SubjectCode", cmbSubject.SelectedValue?.ToString())

            Dim readerFinalGrade As MySqlDataReader = cmdFinalGrade.ExecuteReader()
            If readerFinalGrade.Read() Then
                txtGrade.Text = readerFinalGrade("FinalGrade").ToString()
            Else
                txtGrade.Clear()
            End If
            readerFinalGrade.Close()
        End If

        previousSelectedStudentID = selectedStudentID
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim selectedStudentID As Object = cmbStudents.SelectedValue

            If selectedStudentID Is Nothing Then
                MessageBox.Show("No student selected.")
                Return
            End If

            Dim selectedYearLevel As String = cmbYearSection.SelectedValue?.ToString()
            If String.IsNullOrEmpty(selectedYearLevel) Then
                MessageBox.Show("Please select a Year Level.")
                Return
            End If

            Dim yearID As Integer = GetYearIDFromYearLevel(selectedYearLevel)
            If yearID = -1 Then
                MessageBox.Show("Year Level not found in the database.")
                Return
            End If

            If connection.State = ConnectionState.Closed Then connection.Open()
            Dim transaction As MySqlTransaction = connection.BeginTransaction()

            Try
                For Each ctrl As Control In pnlquiz.Controls
                    If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtScore") Then
                        Dim quizNumber As String = ctrl.Name.Substring("txtScore".Length)
                        Dim txtTotalItems As TextBox = pnlquiz.Controls.OfType(Of TextBox)().FirstOrDefault(Function(x) x.Name = $"txtTotalItems{quizNumber}")

                        If txtTotalItems IsNot Nothing Then
                            Dim score As Decimal
                            Dim totalItems As Decimal

                            If Decimal.TryParse(ctrl.Text, score) AndAlso Decimal.TryParse(txtTotalItems.Text, totalItems) Then
                                Dim activityName = $"Quiz {quizNumber}"
                                UpdateOrInsertActivity(selectedStudentID, yearID, txtSubjectCode.Text, "Quiz", activityName, score, txtPercentageforquiz.Text, totalItems, transaction)
                            End If
                        End If
                    End If
                Next

                For Each ctrl As Control In pnlExercise.Controls
                    If TypeOf ctrl Is TextBox AndAlso ctrl.Name.StartsWith("txtExerciseScore") Then
                        Dim exerciseNumber As String = ctrl.Name.Substring("txtExerciseScore".Length)
                        Dim txtTotalItems As TextBox = pnlExercise.Controls.OfType(Of TextBox)().FirstOrDefault(Function(x) x.Name = $"txtExerciseTotalItems{exerciseNumber}")

                        If txtTotalItems IsNot Nothing Then
                            Dim score As Decimal
                            Dim totalItems As Decimal

                            If Decimal.TryParse(ctrl.Text, score) AndAlso Decimal.TryParse(txtTotalItems.Text, totalItems) Then
                                Dim activityName = $"Exercise {exerciseNumber}"
                                UpdateOrInsertActivity(selectedStudentID, yearID, txtSubjectCode.Text, "Exercise", activityName, score, txtPercentageforExercise.Text, totalItems, transaction)
                            End If
                        End If
                    End If
                Next

                Dim examScore As Decimal
                Dim examTotalItems As Decimal
                If Decimal.TryParse(txtExamScore.Text, examScore) AndAlso Decimal.TryParse(txtExamTotalItems.Text, examTotalItems) Then
                    UpdateOrInsertActivity(selectedStudentID, yearID, txtSubjectCode.Text, "Exam", "Exam", examScore, txtPercantageforExam.Text, examTotalItems, transaction)
                End If

                Dim finalGrade As Decimal
                If Decimal.TryParse(txtGrade.Text, finalGrade) Then
                    Dim cmdCheckFinalGrade As New MySqlCommand("SELECT COUNT(*) FROM finalgrades WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode", connection, transaction)
                    cmdCheckFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmdCheckFinalGrade.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)

                    Dim recordExists As Boolean = Convert.ToInt32(cmdCheckFinalGrade.ExecuteScalar()) > 0

                    If recordExists Then
                        Dim cmdUpdateFinalGrade As New MySqlCommand("UPDATE finalgrades SET FinalGrade = @FinalGrade WHERE StudentID = @StudentID AND SubjectCode = @SubjectCode", connection, transaction)
                        cmdUpdateFinalGrade.Parameters.AddWithValue("@FinalGrade", finalGrade)
                        cmdUpdateFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
                        cmdUpdateFinalGrade.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)
                        cmdUpdateFinalGrade.ExecuteNonQuery()
                    Else
                        Dim cmdInsertFinalGrade As New MySqlCommand("INSERT INTO finalgrades (StudentID, SubjectCode, FinalGrade) VALUES (@StudentID, @SubjectCode, @FinalGrade)", connection, transaction)
                        cmdInsertFinalGrade.Parameters.AddWithValue("@StudentID", selectedStudentID)
                        cmdInsertFinalGrade.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)
                        cmdInsertFinalGrade.Parameters.AddWithValue("@FinalGrade", finalGrade)
                        cmdInsertFinalGrade.ExecuteNonQuery()
                    End If
                Else
                    MessageBox.Show("Invalid Final Grade. Please ensure the grade is a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                transaction.Commit()
                MessageBox.Show("Records updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                If transaction IsNot Nothing Then transaction.Rollback()
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show($"Database Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    Private Sub UpdateOrInsertActivity(studentID As Object, yearID As Integer, subjectCode As String, activityType As String, activityName As String, score As Decimal, percentage As String, totalItems As Decimal, transaction As MySqlTransaction)
        Dim cmdCheck As New MySqlCommand("SELECT COUNT(*) FROM activities WHERE StudentID = @StudentID AND YearID = @YearID AND SubjectCode = @SubjectCode AND Type = @Type AND ActivityName = @ActivityName", connection, transaction)
        cmdCheck.Parameters.AddWithValue("@StudentID", studentID)
        cmdCheck.Parameters.AddWithValue("@YearID", yearID)
        cmdCheck.Parameters.AddWithValue("@SubjectCode", subjectCode)
        cmdCheck.Parameters.AddWithValue("@Type", activityType)
        cmdCheck.Parameters.AddWithValue("@ActivityName", activityName)

        Dim recordExists As Boolean = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0
        If recordExists Then
            Dim cmdUpdate As New MySqlCommand("UPDATE activities SET Score = @Score, Percentage = @Percentage, TotalItems = @TotalItems WHERE StudentID = @StudentID AND YearID = @YearID AND SubjectCode = @SubjectCode AND Type = @Type AND ActivityName = @ActivityName", connection, transaction)
            cmdUpdate.Parameters.AddWithValue("@StudentID", studentID)
            cmdUpdate.Parameters.AddWithValue("@YearID", yearID)
            cmdUpdate.Parameters.AddWithValue("@SubjectCode", subjectCode)
            cmdUpdate.Parameters.AddWithValue("@Type", activityType)
            cmdUpdate.Parameters.AddWithValue("@ActivityName", activityName)
            cmdUpdate.Parameters.AddWithValue("@Score", score)
            cmdUpdate.Parameters.AddWithValue("@Percentage", percentage)
            cmdUpdate.Parameters.AddWithValue("@TotalItems", totalItems)
            cmdUpdate.ExecuteNonQuery()
        Else
            Dim cmdInsert As New MySqlCommand("INSERT INTO activities (StudentID, YearID, SubjectCode, Type, ActivityName, Score, Percentage, TotalItems) VALUES (@StudentID, @YearID, @SubjectCode, @Type, @ActivityName, @Score, @Percentage, @TotalItems)", connection, transaction)
            cmdInsert.Parameters.AddWithValue("@StudentID", studentID)
            cmdInsert.Parameters.AddWithValue("@YearID", yearID)
            cmdInsert.Parameters.AddWithValue("@SubjectCode", subjectCode)
            cmdInsert.Parameters.AddWithValue("@Type", activityType)
            cmdInsert.Parameters.AddWithValue("@ActivityName", activityName)
            cmdInsert.Parameters.AddWithValue("@Score", score)
            cmdInsert.Parameters.AddWithValue("@Percentage", percentage)
            cmdInsert.Parameters.AddWithValue("@TotalItems", totalItems)
            cmdInsert.ExecuteNonQuery()
        End If
    End Sub

    Private Sub AddNewQuizControls()
        pnlquiz.Controls.Clear()

        Dim selectedStudentID As String = cmbStudents.SelectedValue?.ToString()
        Dim selectedSubjectCode As String = cmbSubject.SelectedValue?.ToString()

        ' Pass both selectedStudentID and selectedSubjectCode to the method
        Dim quizData As List(Of Dictionary(Of String, Object)) = GetQuizData(selectedStudentID, selectedSubjectCode)

        Dim quizNumber As Integer = 1

        For Each quiz As Dictionary(Of String, Object) In quizData
            Dim lblQuiz As New Label With {
            .Text = $"Quiz {quizNumber}",
            .AutoSize = True,
            .Location = New Point(10, 5 + quizNumber * 30)
        }

            Dim txtScore As New TextBox With {
            .Name = $"txtScore{quizNumber}",
            .Text = quiz("Score").ToString(),
            .Width = 100,
            .Location = New Point(100, 5 + quizNumber * 30)
        }

            Dim lblSeparator As New Label With {
            .Text = "/",
            .AutoSize = True,
            .Location = New Point(210, 5 + quizNumber * 30)
        }

            Dim txtTotalItems As New TextBox With {
            .Name = $"txtTotalItems{quizNumber}",
            .Text = quiz("TotalItems").ToString(),
            .Width = 100,
            .Location = New Point(230, 5 + quizNumber * 30)
        }

            pnlquiz.Controls.Add(lblQuiz)
            pnlquiz.Controls.Add(txtScore)
            pnlquiz.Controls.Add(lblSeparator)
            pnlquiz.Controls.Add(txtTotalItems)

            quizNumber += 1
        Next
    End Sub

    Private Sub AddNewActivityControls()
        pnlExercise.Controls.Clear()

        Dim selectedStudentID As String = cmbStudents.SelectedValue?.ToString()
        Dim selectedSubjectCode As String = cmbSubject.SelectedValue?.ToString()

        ' Pass both arguments to the method
        Dim exerciseData As List(Of Dictionary(Of String, Object)) = GetExerciseData(selectedStudentID, selectedSubjectCode)

        Dim exerciseNumber As Integer = 1

        For Each exercise As Dictionary(Of String, Object) In exerciseData
            Dim lblExercise As New Label With {
            .Text = $"Exercise {exerciseNumber}",
            .AutoSize = True,
            .Location = New Point(10, 5 + exerciseNumber * 30)
        }

            Dim txtExerciseScore As New TextBox With {
            .Name = $"txtExerciseScore{exerciseNumber}",
            .Text = exercise("Score").ToString(),
            .Width = 100,
            .Location = New Point(120, 5 + exerciseNumber * 30)
        }

            Dim lblExerciseSeparator As New Label With {
            .Text = "/",
            .AutoSize = True,
            .Location = New Point(220, 5 + exerciseNumber * 30)
        }

            Dim txtExerciseTotalItems As New TextBox With {
            .Name = $"txtExerciseTotalItems{exerciseNumber}",
            .Text = exercise("TotalItems").ToString(),
            .Width = 100,
            .Location = New Point(240, 5 + exerciseNumber * 30)
        }

            pnlExercise.Controls.Add(lblExercise)
            pnlExercise.Controls.Add(txtExerciseScore)
            pnlExercise.Controls.Add(lblExerciseSeparator)
            pnlExercise.Controls.Add(txtExerciseTotalItems)

            exerciseNumber += 1
        Next
    End Sub

    Private Sub lkLogout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkLogout.LinkClicked
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim Assign As New Form1()
            Assign.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub txtPercentageforquiz_TextChanged(sender As Object, e As EventArgs) Handles txtPercentageforquiz.TextChanged

    End Sub

    Private Sub txtPercentageforquiz_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPercentageforquiz.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPercentageforExercise.Focus()
        End If
    End Sub

    Private Sub txtPercentageforExercise_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPercentageforExercise.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPercantageforExam.Focus()
        End If
    End Sub

    Private Sub txtPercantageforExam_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPercantageforExam.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtExamTotalItems.Focus()
        End If
    End Sub

    Private Sub txtExamTotalItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExamTotalItems.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtExamScore.Focus()
        End If
    End Sub
End Class
