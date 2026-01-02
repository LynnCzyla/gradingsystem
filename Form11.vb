Imports MySql.Data.MySqlClient


Public Class Form11

    Dim connection As MySqlConnection = database.GetConnection()


    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartments()
        LoadSchoolDetails()

        ToggleButtonState(btnYear)

    End Sub

    Private Sub btnProf_Click(sender As Object, e As EventArgs) Handles btnProf.Click
        Dim profEncode As New Form8()
        profEncode.Show()
        Me.Hide()
    End Sub

    Private Sub btnSubjects_Click(sender As Object, e As EventArgs) Handles btnSubjects.Click
        Dim profEncode As New Form7()
        profEncode.Show()
        Me.Hide()
    End Sub

    Private Sub btnProg_Click(sender As Object, e As EventArgs) Handles btnProg.Click
        Dim Prog As New Form9()
        Prog.Show()
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

    Private Sub btn_MouseHover(sender As Object, e As EventArgs) Handles btnProg.MouseHover, btnProf.MouseHover, btnSubjects.MouseHover, btnStudent.MouseHover, btnYear.MouseHover
        Dim btn = CType(sender, Button)
        If activeButton IsNot btn Then
            btn.BackColor = hoverColor
        End If
    End Sub

    Private Sub btn_MouseLeave(sender As Object, e As EventArgs) Handles btnProg.MouseLeave, btnProf.MouseLeave, btnSubjects.MouseLeave, btnStudent.MouseLeave, btnYear.MouseLeave
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

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        Dim selectedDepartmentID = 0

        If cmbDepartment.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbDepartment.SelectedValue) Then
            Dim selectedRow = CType(cmbDepartment.SelectedItem, DataRowView)

            If selectedRow("DepartmentID") IsNot DBNull.Value Then
                selectedDepartmentID = Convert.ToInt32(selectedRow("DepartmentID"))
            End If
        End If

        If selectedDepartmentID > 0 Then
            LoadPrograms(selectedDepartmentID)
        Else
            cmbProgram.DataSource = Nothing
            cmbProgram.Items.Clear
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
            cmbDepartment.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadPrograms(departmentID As Integer)
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT ProgramID, ProgramName FROM Program WHERE DepartmentID = @DepartmentID"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DepartmentID", departmentID)

            Dim dt As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dt)

            cmbProgram.DataSource = Nothing

            Dim selectRow As DataRow = dt.NewRow()
            selectRow("ProgramID") = DBNull.Value
            selectRow("ProgramName") = "-- Select Program --"
            dt.Rows.InsertAt(selectRow, 0)

            cmbProgram.DataSource = dt
            cmbProgram.DisplayMember = "ProgramName"
            cmbProgram.ValueMember = "ProgramID"
            cmbProgram.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading programs: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim schoolYear As String = txtSchoolYear.Text
            Dim department As String = If(cmbDepartment.SelectedValue?.ToString(), "")
            Dim program As String = If(cmbProgram.SelectedValue?.ToString(), "")

            Dim yearLevel As String = txtYear.Text
            If String.IsNullOrWhiteSpace(yearLevel) Then
                MessageBox.Show("Year level cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If String.IsNullOrWhiteSpace(schoolYear) OrElse String.IsNullOrWhiteSpace(department) _
           OrElse String.IsNullOrWhiteSpace(program) Then
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim noOfStudents As Integer
            If Not Integer.TryParse(txtNumberOfStudent.Text, noOfStudents) Then
                MessageBox.Show("Please enter a valid number for the number of students.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim query As String = "INSERT INTO SchoolDetails (SchoolYear, Department, Program, YearLevel, NoOfStudents) 
                               VALUES (@SchoolYear, @Department, @Program, @YearLevel, @NoOfStudents)"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SchoolYear", schoolYear)
                cmd.Parameters.AddWithValue("@Department", department)
                cmd.Parameters.AddWithValue("@Program", program)
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel)
                cmd.Parameters.AddWithValue("@NoOfStudents", noOfStudents)

                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                cmd.ExecuteNonQuery()
            End Using

            LoadSchoolDetails()

            MessageBox.Show("Data submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtSchoolYear.Clear()
            txtNumberOfStudent.Clear()
            cmbDepartment.SelectedIndex = 0
            cmbProgram.SelectedIndex = 0
            txtYear.Clear()

        Catch ex As Exception
            MessageBox.Show("Error submitting data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    Private Sub LoadSchoolDetails()
        Try
            Dim query As String = "SELECT YearID, SchoolYear, d.DepartmentName, p.ProgramName, YearLevel, NoOfStudents 
                               FROM SchoolDetails s 
                               JOIN Department d ON s.Department = d.DepartmentID 
                               JOIN Program p ON s.Program = p.ProgramID"
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            DataGridView1.DataSource = dt

            DataGridView1.Columns("YearID").Visible = False

            DataGridView1.Columns("SchoolYear").Width = 150
            DataGridView1.Columns("DepartmentName").Width = 450
            DataGridView1.Columns("ProgramName").Width = 450
            DataGridView1.Columns("YearLevel").Width = 200
            DataGridView1.Columns("NoOfStudents").Width = 150

        Catch ex As Exception
            MessageBox.Show("Error loading school details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim yearID As Integer
            Try
                yearID = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("YearID").Value)
            Catch ex As Exception
                MessageBox.Show("Error retrieving YearID from the selected row: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                DeleteFromDatabase(yearID)

                DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(0).Index)

                MessageBox.Show("Record deleted successfully.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DeleteFromDatabase(yearID As Integer)
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        Dim query As String = "DELETE FROM SchoolDetails WHERE YearID = @YearID"

        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@YearID", yearID)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error deleting record from database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtSchoolYear.Text = selectedRow.Cells("SchoolYear").Value.ToString()
            cmbDepartment.Text = selectedRow.Cells("DepartmentName").Value.ToString()
            cmbProgram.Text = selectedRow.Cells("ProgramName").Value
            txtYear.Text = selectedRow.Cells("YearLevel").Value.ToString()
            txtNumberOfStudent.Text = selectedRow.Cells("NoOfStudents").Value.ToString()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a school year to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim yearID As Integer = Convert.ToInt32(selectedRow.Cells("YearID").Value)

            Dim schoolYear As String = txtSchoolYear.Text
            Dim department As String = cmbDepartment.SelectedValue.ToString()
            Dim program As String = cmbProgram.SelectedValue.ToString()
            Dim YearLevel As String = txtYear.Text
            Dim noOfStudents As Integer = Convert.ToInt32(txtNumberOfStudent.Text)

            If String.IsNullOrWhiteSpace(schoolYear) OrElse String.IsNullOrWhiteSpace(department) _
               OrElse String.IsNullOrWhiteSpace(program) Then
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim query As String = "UPDATE SchoolDetails SET SchoolYear = @SchoolYear, Department = @Department, Program = @Program, " &
                                  "YearLevel = @YearLevel, NoOfStudents = @NoOfStudents WHERE YearID = @YearID"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SchoolYear", schoolYear)
                cmd.Parameters.AddWithValue("@Department", department)
                cmd.Parameters.AddWithValue("@Program", program)
                cmd.Parameters.AddWithValue("@YearLevel", YearLevel)
                cmd.Parameters.AddWithValue("@NoOfStudents", noOfStudents)
                cmd.Parameters.AddWithValue("@YearID", yearID)

                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                cmd.ExecuteNonQuery()
            End Using

            LoadSchoolDetails()

            MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtSchoolYear.Clear()
            txtNumberOfStudent.Clear()
            cmbDepartment.SelectedIndex = 0
            cmbProgram.SelectedIndex = 0
            txtYear.Clear()


        Catch ex As Exception
            MessageBox.Show("Error updating data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        txtSchoolYear.Clear()
        txtYear.Clear()
        txtNumberOfStudent.Clear()
        cmbDepartment.SelectedIndex = 0
        cmbProgram.SelectedIndex = 0
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Back As New Form4()
        Back.Show()
        Me.Hide()
    End Sub


    Private Sub txtSchoolYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSchoolYear.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtYear.Focus()
        End If
    End Sub

    Private Sub txtYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYear.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtNumberOfStudent.Focus()
        End If
    End Sub

    Private Sub txtNumberOfStudent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumberOfStudent.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSubmit.Focus()
        End If
    End Sub
End Class
