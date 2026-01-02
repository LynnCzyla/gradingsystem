Imports System.Collections.Specialized.BitVector32
Imports System.Transactions
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Mysqlx.XDevAPI.Relational

Public Class Form13

    Dim connection As MySqlConnection = database.GetConnection()

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDepartments()
        LoadYearLevel()
        LoadDataGrid()


    End Sub

    Private selectedProgramID As Integer = 0

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        Dim selectedDepartmentID = 0
        If cmbDepartment.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbDepartment.SelectedValue) Then
            Dim selectedRow = CType(cmbDepartment.SelectedItem, DataRowView)

            If selectedRow("DepartmentID") IsNot DBNull.Value Then
                selectedDepartmentID = Convert.ToInt32(selectedRow("DepartmentID"))
            End If
        End If

        If selectedDepartmentID > 0 Then
            LoadProfessors(selectedDepartmentID)
            LoadPrograms(selectedDepartmentID)
        Else
            cmbProf.DataSource = Nothing
            cmbProf.Items.Clear
            cmbProf.Items.Add("-- Select Professor --")
            cmbProf.SelectedIndex = 0

            cmbProgram.DataSource = Nothing
            cmbProgram.Items.Clear()
            cmbProgram.Items.Add("-- Select Program --")
            cmbProgram.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadDepartments()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT DepartmentID, DepartmentName FROM Department"
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            Dim selectRow As DataRow = dt.NewRow()
            selectRow("DepartmentID") = DBNull.Value
            selectRow("DepartmentName") = "-- Select Department --"
            dt.Rows.InsertAt(selectRow, 0)

            cmbDepartment.DataSource = dt
            cmbDepartment.DisplayMember = "DepartmentName"
            cmbDepartment.ValueMember = "DepartmentID"

            cmbDepartment.SelectedValue = DBNull.Value

        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadSubjects(programID As Integer)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT SubjectCode, SubjectName, Semester FROM Subjects WHERE ProgramID = @ProgramID"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@ProgramID", programID)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            Dim placeholderRow As DataRow = dt.NewRow()
            placeholderRow("SubjectCode") = DBNull.Value
            placeholderRow("SubjectName") = "-- Select Subject --"
            placeholderRow("Semester") = DBNull.Value

            dt.Rows.InsertAt(placeholderRow, 0)

            cmbSubject.DataSource = dt
            cmbSubject.DisplayMember = "SubjectName"
            cmbSubject.ValueMember = "SubjectCode"

        Catch ex As Exception
            MessageBox.Show("Failed to load subjects: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadProfessors(departmentID As Integer)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT ProfessorID, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS FullName FROM Professor WHERE DepartmentID = @DepartmentID AND IsArchived = 0"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID)

            Dim dt As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dt)

            cmbProf.DataSource = Nothing

            Dim selectRow As DataRow = dt.NewRow()
            selectRow("ProfessorID") = DBNull.Value
            selectRow("FullName") = "-- Select Professor --"
            dt.Rows.InsertAt(selectRow, 0)

            cmbProf.DataSource = dt
            cmbProf.DisplayMember = "FullName"
            cmbProf.ValueMember = "ProfessorID"
            cmbProf.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading professors: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadYearLevel()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT DISTINCT YearLevel FROM schooldetails WHERE YearLevel IS NOT NULL"
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No year levels found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim selectRow As DataRow = dt.NewRow()
            selectRow("YearLevel") = "-- Select Year Level --"
            dt.Rows.InsertAt(selectRow, 0)

            cmbYear.DataSource = dt
            cmbYear.DisplayMember = "YearLevel"
            cmbYear.ValueMember = "YearLevel"
            cmbYear.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading year levels: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub cmbSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubject.SelectedIndexChanged
        If cmbSubject.SelectedIndex > 0 Then
            Dim selectedRow As DataRowView = CType(cmbSubject.SelectedItem, DataRowView)

            Dim subjectCode As String = selectedRow("SubjectCode").ToString()
            Dim semester As String = selectedRow("Semester").ToString()

            txtSubjectCode.Text = subjectCode
            txtSemester.Text = semester
        Else
            txtSubjectCode.Clear()
            txtSemester.Clear()
        End If
    End Sub


    Private Sub cmbProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProgram.SelectedIndexChanged
        If cmbProgram.SelectedIndex > 0 Then
            If cmbProgram.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbProgram.SelectedValue) Then
                Try
                    Dim selectedProgramID As Integer

                    If Integer.TryParse(cmbProgram.SelectedValue.ToString(), selectedProgramID) Then
                        LoadSubjects(selectedProgramID)
                    Else
                        MessageBox.Show("Invalid program selection.", "Selection Error")
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error accessing selected program ID: " & ex.Message, "Database Error")
                End Try
            End If
        End If
    End Sub



    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim transaction As MySqlTransaction = Nothing

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            transaction = connection.BeginTransaction()

            Dim subjectCode As String = String.Empty
            If cmbSubject.SelectedIndex > 0 Then
                If cmbSubject.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbSubject.SelectedValue) Then
                    subjectCode = cmbSubject.SelectedValue.ToString()
                Else
                    MessageBox.Show("Invalid subject selection.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Else
                MessageBox.Show("Please select a subject.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim professorID As Integer = Convert.ToInt32(cmbProf.SelectedValue)
            Dim semester As String = txtSemester.Text.Trim()
            Dim departmentID As Integer = Convert.ToInt32(cmbDepartment.SelectedValue)
            Dim programID As Integer = Convert.ToInt32(cmbProgram.SelectedValue)

            Dim GradingP As String = String.Empty
            If cmbGrade.SelectedIndex > -1 Then
                If cmbGrade.SelectedItem IsNot Nothing Then
                    GradingP = cmbGrade.SelectedItem.ToString()
                Else
                    MessageBox.Show("Selected value is invalid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Else
                MessageBox.Show("Please select a grading period.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim yearLevel As String = String.Empty
            If cmbYear.SelectedIndex > 0 Then
                yearLevel = CType(cmbYear.SelectedItem, DataRowView)("YearLevel").ToString()
            End If

            If String.IsNullOrEmpty(semester) Then
                MessageBox.Show("Please enter a semester.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim queryProftoSection As String = "INSERT INTO ProftoSection (YearLevel, ProfessorID) 
                                       VALUES (@YearLevel, @ProfessorID)"

            Dim cmdProftoSection As New MySqlCommand(queryProftoSection, connection, transaction)
            cmdProftoSection.Parameters.AddWithValue("@YearLevel", yearLevel)
            cmdProftoSection.Parameters.AddWithValue("@ProfessorID", professorID)

            cmdProftoSection.ExecuteNonQuery()

            Dim sectionID As Integer = Convert.ToInt32(cmdProftoSection.LastInsertedId)

            Dim queryProftoSubject As String = "INSERT INTO ProftoSubject (SubjectCode, ProfessorID, Semester, DepartmentID, GradingP, SectionID, ProgramID) " &
                                        "VALUES (@SubjectCode, @ProfessorID, @Semester, @DepartmentID, @GradingP, @SectionID, @ProgramID)"

            Dim cmdProftoSubject As New MySqlCommand(queryProftoSubject, connection, transaction)
            cmdProftoSubject.Parameters.AddWithValue("@SubjectCode", subjectCode)
            cmdProftoSubject.Parameters.AddWithValue("@ProfessorID", cmbProf.SelectedValue)
            cmdProftoSubject.Parameters.AddWithValue("@Semester", semester)
            cmdProftoSubject.Parameters.AddWithValue("@DepartmentID", departmentID)
            cmdProftoSubject.Parameters.AddWithValue("@GradingP", GradingP)
            cmdProftoSubject.Parameters.AddWithValue("@SectionID", sectionID)
            cmdProftoSubject.Parameters.AddWithValue("@ProgramID", programID)

            cmdProftoSubject.ExecuteNonQuery()

            transaction.Commit()

            MessageBox.Show("Professor successfully assigned to subject and section.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataGrid()
            ClearFields()

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            MessageBox.Show("Error occurred: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadDataGrid()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
           SELECT 
    ps.AssignmentID,
    ps.SubjectCode, 
    sub.SubjectName, 
    ps.GradingP, 
    ps.Semester, 
    pfs.YearLevel, 
    d.DepartmentName, 
    CONCAT(prof.LastName, ', ', prof.FirstName, ' ', prof.MiddleName) AS FullName, 
    ps.SectionID,
    prog.ProgramName
FROM 
    PROFTOSUBJECT ps
INNER JOIN 
    Subjects sub ON ps.SubjectCode = sub.SubjectCode
INNER JOIN 
    Department d ON ps.DepartmentID = d.DepartmentID
INNER JOIN 
    PROFTOSECTION pfs ON ps.SectionID = pfs.SectionID
INNER JOIN 
    Professor prof ON ps.ProfessorID = prof.ProfessorID
INNER JOIN 
    Program prog ON ps.ProgramID = prog.ProgramID;"

            Dim cmd As New MySqlCommand(query, connection)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            DataGridView1.DataSource = dt

            DataGridView1.Columns("AssignmentID").Visible = False
            DataGridView1.Columns("SectionID").Visible = False
            DataGridView1.Columns("AssignmentID").Width = 100
            DataGridView1.Columns("SubjectCode").Width = 120
            DataGridView1.Columns("SubjectName").Width = 200
            DataGridView1.Columns("GradingP").Width = 150
            DataGridView1.Columns("Semester").Width = 150
            DataGridView1.Columns("YearLevel").Width = 100
            DataGridView1.Columns("DepartmentName").Width = 200
            DataGridView1.Columns("FullName").Width = 300
            DataGridView1.Columns("SectionID").Width = 100
            DataGridView1.Columns("ProgramName").Width = 175
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then

            Dim assignmentID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("AssignmentID").Value)
            Dim sectionID As Integer = 0

            If Not IsDBNull(DataGridView1.SelectedRows(0).Cells("SectionID").Value) Then
                sectionID = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("SectionID").Value)
            Else
                MessageBox.Show("SectionID is missing.")
                Return
            End If

            Dim deleteSubjectQuery As String = "DELETE FROM ProftoSection WHERE SectionID = @SectionID"

            Dim transaction As MySqlTransaction = Nothing

            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                transaction = connection.BeginTransaction()

                Dim cmdSubject As New MySqlCommand(deleteSubjectQuery, connection, transaction)
                cmdSubject.Parameters.AddWithValue("@AssignmentID", assignmentID)
                cmdSubject.Parameters.AddWithValue("@SectionID", sectionID)
                cmdSubject.ExecuteNonQuery()

                transaction.Commit()
                MessageBox.Show("Record deleted successfully!")

                LoadDataGrid()

            Catch ex As Exception
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                MessageBox.Show("Error: " & ex.Message)
            Finally
                connection.Close()
            End Try

        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub ClearFields()
        txtSemester.Clear()
        cmbSubject.SelectedIndex = -1
        cmbGrade.SelectedIndex = -1
        cmbSubject.SelectedIndex = -1
        cmbProf.SelectedIndex = -1
        cmbYear.SelectedIndex = -1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ClearFields()
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cmbDepartment.SelectedValue Is Nothing OrElse cmbDepartment.SelectedIndex = -1 Then
            MessageBox.Show("Please select a valid department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim departmentID As Integer
        If cmbDepartment.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbDepartment.SelectedValue) Then
            departmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
        Else
            departmentID = 0
        End If

        Dim professorID As Integer = If(cmbProf.SelectedValue IsNot Nothing, Convert.ToInt32(cmbProf.SelectedValue), 0)
        Dim subjectCode As String = If(txtSubjectCode.Text IsNot Nothing, txtSubjectCode.Text.Trim(), String.Empty)
        Dim semester As String = If(txtSemester.Text IsNot Nothing, txtSemester.Text.Trim(), String.Empty)
        Dim gradingP As String = If(cmbGrade.SelectedItem IsNot Nothing, cmbGrade.SelectedItem.ToString().Trim(), String.Empty)
        Dim sectionID As String = If(cmbYear.SelectedValue IsNot Nothing, cmbYear.SelectedValue.ToString(), String.Empty)
        Dim yearLevel As String = String.Empty

        If cmbYear.SelectedItem IsNot Nothing Then
            If TypeOf cmbYear.SelectedItem Is DataRowView Then
                Dim selectedItem As DataRowView = CType(cmbYear.SelectedItem, DataRowView)
                If selectedItem("YearLevel") IsNot Nothing Then
                    yearLevel = selectedItem("YearLevel").ToString().Trim()
                End If
            Else
                yearLevel = cmbYear.SelectedItem.ToString().Trim()
            End If
        End If

        If String.IsNullOrEmpty(yearLevel) Then
            MessageBox.Show("YearLevel not selected or invalid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim subjectName As String = If(cmbSubject.SelectedItem IsNot Nothing, cmbSubject.SelectedItem.ToString().Trim(), String.Empty)

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim assignmentID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("AssignmentID").Value)

        Dim sectionIDFromRow As Object = DataGridView1.SelectedRows(0).Cells("SectionID").Value

        If sectionIDFromRow IsNot Nothing Then
            Dim sectionIDFromRowInt As Integer
            If Not Integer.TryParse(sectionIDFromRow.ToString(), sectionIDFromRowInt) Then
                MessageBox.Show("Invalid SectionID value.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim transaction As MySqlTransaction = Nothing

            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                transaction = connection.BeginTransaction()

                Dim updateSectionQuery As String = "UPDATE PROFTOSECTION SET YearLevel = @YearLevel WHERE SectionID = @SectionID"
                Using cmdUpdateSection As New MySqlCommand(updateSectionQuery, connection, transaction)
                    cmdUpdateSection.Parameters.AddWithValue("@YearLevel", yearLevel)
                    cmdUpdateSection.Parameters.AddWithValue("@SectionID", Convert.ToInt32(sectionIDFromRow))

                    Dim rowsAffectedSection As Integer = cmdUpdateSection.ExecuteNonQuery()
                    If rowsAffectedSection = 0 Then
                        Throw New Exception("No matching record found in PROFTOSECTION.")
                    End If
                End Using

                transaction.Commit()

                Dim updateQuerySubject As String = "UPDATE PROFTOSUBJECT SET ProfessorID = @ProfessorID, Semester = @Semester, DepartmentID = @DepartmentID, GradingP = @GradingP, SubjectCode = @SubjectCode WHERE AssignmentID = @AssignmentID"
                Using cmdUpdateSubject As New MySqlCommand(updateQuerySubject, connection, transaction)
                    cmdUpdateSubject.Parameters.AddWithValue("@ProfessorID", professorID)
                    cmdUpdateSubject.Parameters.AddWithValue("@Semester", semester)
                    cmdUpdateSubject.Parameters.AddWithValue("@DepartmentID", departmentID)
                    cmdUpdateSubject.Parameters.AddWithValue("@GradingP", gradingP)
                    cmdUpdateSubject.Parameters.AddWithValue("@SubjectCode", subjectCode)
                    cmdUpdateSubject.Parameters.AddWithValue("@AssignmentID", assignmentID)

                    Dim rowsAffectedSubject As Integer = cmdUpdateSubject.ExecuteNonQuery()

                    If rowsAffectedSubject = 0 Then
                        Throw New Exception("No matching record found in PROFTOSUBJECT.")
                    End If
                End Using

                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataGrid()

            Catch ex As Exception


                MessageBox.Show("Update failed: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try

        Else
            MessageBox.Show("No SectionID found in the selected row.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            Try
                txtSemester.Text = selectedRow.Cells("Semester").Value.ToString()
                cmbDepartment.Text = selectedRow.Cells("DepartmentName").Value.ToString()
                cmbGrade.Text = selectedRow.Cells("GradingP").Value.ToString()
                cmbProf.Text = selectedRow.Cells("FullName").Value.ToString()
                cmbYear.Text = selectedRow.Cells("YearLevel").Value.ToString()
                cmbSubject.Text = selectedRow.Cells("SubjectName").Value.ToString()
                txtSubjectCode.Text = selectedRow.Cells("SubjectCode").Value.ToString()
                cmbProgram.Text = selectedRow.Cells("ProgramName").Value.ToString()

            Catch ex As Exception
                MessageBox.Show("Column Binding Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Back As New Form4()
        Back.Show()
        Me.Hide()
    End Sub

    Private Sub LoadPrograms(departmentID As Integer)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT ProgramID, ProgramName FROM Program WHERE DepartmentID = @DepartmentID"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            Dim selectRow As DataRow = dt.NewRow()
            selectRow("ProgramID") = DBNull.Value
            selectRow("ProgramName") = "-- Select Program --"
            dt.Rows.InsertAt(selectRow, 0)

            cmbProgram.DataSource = dt
            cmbProgram.DisplayMember = "ProgramName"
            cmbProgram.ValueMember = "ProgramID"

            cmbProgram.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Failed to load programs: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
End Class
