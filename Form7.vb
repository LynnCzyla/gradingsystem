Imports System.Runtime.Intrinsics.X86
Imports MySql.Data.MySqlClient

Public Class Form7
    Dim connection As MySqlConnection = database.GetConnection()

    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToggleButtonState(btnSub)

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        LoadSubjects()
        LoadDepartments()
    End Sub

    Private Sub btnProg_Click(sender As Object, e As EventArgs) Handles btnProg.Click
        Dim Prog As New Form9()
        Prog.Show()
        Me.Hide()
    End Sub

    Private Sub btnProfEncode_Click(sender As Object, e As EventArgs) Handles btnProfEncode.Click
        Dim Prog As New Form8()
        Prog.Show()
        Me.Hide()
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        Dim Subject As New Form7()
        Subject.Show()
        Me.Hide()
    End Sub

    Private Sub btnStudent_Click(sender As Object, e As EventArgs) Handles btnStudent.Click
        Dim Student As New Form10()
        Student.Show()
        Me.Hide()
    End Sub

    Private Sub btnYear_Click(sender As Object, e As EventArgs) Handles btnYear.Click
        Dim year As New Form11()
        year.Show()
        Me.Hide()
    End Sub

    Private Sub btn_MouseHover(sender As Object, e As EventArgs) Handles btnProg.MouseHover, btnProfEncode.MouseHover, btnSub.MouseHover, btnStudent.MouseHover, btnYear.MouseHover
        Dim btn = CType(sender, Button)
        If activeButton IsNot btn Then
            btn.BackColor = hoverColor
        End If
    End Sub

    Private Sub btn_MouseLeave(sender As Object, e As EventArgs) Handles btnProg.MouseLeave, btnProfEncode.MouseLeave, btnSub.MouseLeave, btnStudent.MouseLeave, btnYear.MouseLeave
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


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtSubjectCode.Text = "" Or txtSubjectName.Text = "" Or cmbType.SelectedItem Is Nothing Or cmbSemester.SelectedItem Is Nothing Or cmbLecLab.SelectedItem Is Nothing Or cmbUnits.Text = "" Then
                MessageBox.Show("Please fill in all fields.")
                Exit Sub
            End If

            If cmbDepartment.SelectedValue IsNot Nothing AndAlso Not cmbDepartment.SelectedValue.Equals(DBNull.Value) Then
                Dim departmentID As Integer
                Dim programID As Integer

                If Integer.TryParse(cmbDepartment.SelectedValue.ToString(), departmentID) Then
                    If cmbProgram.SelectedValue IsNot Nothing Then
                        programID = cmbProgram.SelectedValue

                        If connection.State = ConnectionState.Closed Then
                            connection.Open()
                        End If

                        Dim query As String = "INSERT INTO subjects (SubjectCode, SubjectName, Type, DepartmentID, ProgramID, Semester, LectureLab, Units) " &
                                           "VALUES (@SubjectCode, @SubjectName, @Type, @DepartmentID, @ProgramID, @Semester, @LectureLab, @Units)"

                        Using cmd As New MySqlCommand(query, connection)
                            cmd.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text)
                            cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text)
                            cmd.Parameters.AddWithValue("@Type", cmbType.SelectedItem.ToString())
                            cmd.Parameters.AddWithValue("@DepartmentID", departmentID)
                            cmd.Parameters.AddWithValue("@ProgramID", programID)
                            cmd.Parameters.AddWithValue("@Semester", cmbSemester.SelectedItem.ToString())
                            cmd.Parameters.AddWithValue("@LectureLab", cmbLecLab.SelectedItem.ToString())
                            cmd.Parameters.AddWithValue("@Units", Integer.Parse(cmbUnits.Text))

                            cmd.ExecuteNonQuery()

                            MessageBox.Show("Subject added successfully.")
                            LoadSubjects()
                            ClearFields()
                        End Using

                    Else
                        MessageBox.Show("Please select a program.")
                    End If
                Else
                    MessageBox.Show("Invalid department selection.")
                End If
            Else
                MessageBox.Show("Please select a valid department.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
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

            If dt.Rows.Count > 0 Then
                Dim selectRow As DataRow = dt.NewRow()
                selectRow("DepartmentID") = DBNull.Value
                selectRow("DepartmentName") = "-- Select Department --"
                dt.Rows.InsertAt(selectRow, 0)

                cmbDepartment.DataSource = dt
                cmbDepartment.DisplayMember = "DepartmentName"
                cmbDepartment.ValueMember = "DepartmentID"

                cmbDepartment.SelectedIndex = 0
            Else
                MessageBox.Show("No departments found in the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadSubjects(Optional searchQuery As String = "")
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "
            SELECT DISTINCT 
                s.SubjectCode,
                s.SubjectName,
                s.Type, 
                d.DepartmentName AS Department, 
                p.ProgramName AS Program,
                s.Semester, 
                s.LectureLab, 
                s.Units
            FROM subjects s
            INNER JOIN department d ON s.DepartmentID = d.DepartmentID
            LEFT JOIN Program p ON s.ProgramID = p.ProgramID
        "

            If Not String.IsNullOrEmpty(searchQuery) Then
                query &= " WHERE (s.SubjectCode LIKE @SearchTerm OR s.SubjectName LIKE @SearchTerm)"
            End If

            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()

            If Not String.IsNullOrEmpty(searchQuery) Then
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" & searchQuery & "%")
            End If

            adapter.Fill(dt)

            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Error loading subjects: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a subject to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim subjectCode As String = DataGridView1.SelectedRows(0).Cells("SubjectCode").Value.ToString()

            Dim confirmResult As DialogResult = MessageBox.Show(
                "Are you sure you want to delete this subject?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If confirmResult = DialogResult.Yes Then
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Dim query As String = "DELETE FROM subjects WHERE SubjectCode = @SubjectCode"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Subject deleted successfully.", "Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()

                LoadSubjects()
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting subject: " & ex.Message, "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try

            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a subject to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim subjectCode As String = DataGridView1.SelectedRows(0).Cells("SubjectCode").Value.ToString()

            If txtSubjectCode.Text = "" Or txtSubjectName.Text = "" Or cmbType.SelectedItem Is Nothing Or cmbSemester.SelectedItem Is Nothing Or cmbLecLab.SelectedItem Is Nothing Or cmbUnits.Text = "" Then
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim confirmResult As DialogResult = MessageBox.Show(
            "Are you sure you want to update this subject?",
            "Confirm Update",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

            If confirmResult = DialogResult.Yes Then
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Dim query As String = "UPDATE subjects " &
                   "SET SubjectName = @SubjectName, " &
                   "Type = @Type, " &
                   "DepartmentID = @DepartmentID, " &
                   "ProgramID = @ProgramID, " &
                   "Semester = @Semester, " &
                   "LectureLab = @LectureLab, " &
                   "Units = @Units " &
                   "WHERE SubjectCode = @SubjectCode"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@SubjectCode", subjectCode)
                    cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text)
                    cmd.Parameters.AddWithValue("@Type", cmbType.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@DepartmentID", cmbDepartment.SelectedValue)
                    cmd.Parameters.AddWithValue("@ProgramID", cmbProgram.SelectedValue)
                    cmd.Parameters.AddWithValue("@Semester", cmbSemester.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@LectureLab", cmbLecLab.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@Units", Integer.Parse(cmbUnits.Text))
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Subject updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                End Using

                LoadSubjects()
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating subject: " & ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtSubjectCode.Text = selectedRow.Cells("SubjectCode").Value.ToString()
            txtSubjectName.Text = selectedRow.Cells("SubjectName").Value.ToString()
            cmbType.Text = selectedRow.Cells("Type").Value.ToString()
            cmbDepartment.Text = selectedRow.Cells("Department").Value.ToString()
            cmbSemester.Text = selectedRow.Cells("Semester").Value.ToString()
            cmbLecLab.Text = selectedRow.Cells("LectureLab").Value.ToString()
            cmbUnits.Text = selectedRow.Cells("Units").Value.ToString()
        End If
    End Sub



    Private Sub ClearFields()
        txtSubjectCode.Clear()
        txtSubjectName.Clear()
        cmbDepartment.SelectedIndex = 0
        cmbUnits.SelectedIndex = -1
        cmbLecLab.SelectedIndex = -1
        cmbSemester.SelectedIndex = -1
        cmbType.SelectedIndex = -1
    End Sub

    Private Sub lkbBack_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkbBack.LinkClicked
        Dim Back As New Form4()
        Back.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClearFields()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadSubjects(txtSearch.Text.Trim())
    End Sub



    Private Sub txtSubjectCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubjectCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtSubjectName.Focus()
        End If
    End Sub

    Private Sub txtSubjectName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubjectName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmbUnits.Focus()
        End If
    End Sub


    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        Try
            If cmbDepartment.SelectedValue IsNot Nothing AndAlso Not cmbDepartment.SelectedValue.Equals(DBNull.Value) Then
                Dim departmentID As Integer
                If Integer.TryParse(cmbDepartment.SelectedValue.ToString(), departmentID) Then
                    LoadPrograms(departmentID)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Selection Error: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadPrograms(departmentID As Integer)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT ProgramID, ProgramName FROM Program WHERE DepartmentID = @DepartmentID"
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()

            adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", departmentID)
            adapter.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbProgram.DataSource = dt
                cmbProgram.DisplayMember = "ProgramName"
                cmbProgram.ValueMember = "ProgramID"
            Else
                cmbProgram.DataSource = Nothing
                MessageBox.Show("No programs found for the selected department.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading programs: " & ex.Message, "Load Programs Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub



End Class