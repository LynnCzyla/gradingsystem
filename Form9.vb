Imports MySql.Data.MySqlClient

Public Class Form9
    Dim connection As MySqlConnection = database.GetConnection()

    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing

    Private Sub BtnProf_Click(sender As Object, e As EventArgs) Handles btnProf.Click
        Dim profEncode As New Form8()
        profEncode.Show()
        Me.Hide()
    End Sub

    Private Sub BtnSubjects_Click(sender As Object, e As EventArgs) Handles btnSubjects.Click
        Dim profEncode As New Form7()
        profEncode.Show()
        Me.Hide()
    End Sub

    Private Sub BtnProg_Click(sender As Object, e As EventArgs) Handles btnProg.Click
        Dim prog As New Form9()
        prog.Show()
        Me.Hide()
    End Sub

    Private Sub BtnStudent_Click(sender As Object, e As EventArgs) Handles btnStudent.Click
        Dim student As New Form10()
        student.Show()
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


    Private Sub BtnYear_Click(sender As Object, e As EventArgs) Handles btnYear.Click
        Dim year As New Form11()
        year.Show()
        Me.Hide()
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToggleButtonState(btnProg)

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        LoadData()
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        Try
            If String.IsNullOrEmpty(txtDepartmentName.Text) Then
                MessageBox.Show("Please enter a department name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtProgramName.Text) Then
                MessageBox.Show("Please enter a program name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim existingDeptID As Integer = 0
            Dim checkDeptQuery As String = "SELECT DepartmentID FROM Department WHERE DepartmentName = @DepartmentName"
            Using checkDeptCmd As New MySqlCommand(checkDeptQuery, connection)
                checkDeptCmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text)
                Dim result = checkDeptCmd.ExecuteScalar()

                If result IsNot Nothing Then
                    existingDeptID = Convert.ToInt32(result)
                End If
            End Using

            Dim checkProgramQuery As String = "SELECT ProgramID FROM Program WHERE ProgramName = @ProgramName"
            Using checkProgramCmd As New MySqlCommand(checkProgramQuery, connection)
                checkProgramCmd.Parameters.AddWithValue("@ProgramName", txtProgramName.Text)
                Dim programExists = checkProgramCmd.ExecuteScalar()

                If programExists IsNot Nothing Then
                    MessageBox.Show("This program already exists in the database.", "Duplicate Program", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using

            If existingDeptID = 0 Then
                existingDeptID = GetNextID("Department", "DepartmentID")
                Dim deptQuery As String = "INSERT INTO Department (DepartmentID, DepartmentName) VALUES (@DepartmentID, @DepartmentName)"
                Using deptCmd As New MySqlCommand(deptQuery, connection)
                    deptCmd.Parameters.AddWithValue("@DepartmentID", existingDeptID)
                    deptCmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text)
                    deptCmd.ExecuteNonQuery()
                End Using
            End If

            Dim newProgramID As Integer = GetNextID("Program", "ProgramID")
            Dim programQuery As String = "INSERT INTO Program (ProgramID, ProgramName, DepartmentID) VALUES (@ProgramID, @ProgramName, @DepartmentID)"

            Using progCmd As New MySqlCommand(programQuery, connection)
                progCmd.Parameters.AddWithValue("@ProgramID", newProgramID)
                progCmd.Parameters.AddWithValue("@ProgramName", txtProgramName.Text)
                progCmd.Parameters.AddWithValue("@DepartmentID", existingDeptID)
                progCmd.ExecuteNonQuery()
            End Using

            LoadData()
            MessageBox.Show("Program added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtDepartmentName.Clear()
            txtProgramName.Clear()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub



    Private Sub LoadData()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT d.DepartmentID, d.DepartmentName AS Department, p.ProgramID, p.ProgramName AS Program
                        FROM Department d
                        LEFT JOIN Program p ON d.DepartmentID = p.DepartmentID"

            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)

            DataGridView1.DataSource = table

            DataGridView1.Columns(1).Width = 700
            DataGridView1.Columns(3).Width = 700
            DataGridView1.Columns("DepartmentID").Visible = False
            DataGridView1.Columns("ProgramID").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDepartmentName.Clear()
        txtProgramName.Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Try
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

                Dim departmentID As Object = selectedRow.Cells("DepartmentID").Value
                Dim programID As Object = selectedRow.Cells("ProgramID").Value

                If departmentID IsNot DBNull.Value AndAlso programID IsNot DBNull.Value Then
                    Dim departmentIDInt As Integer = Convert.ToInt32(departmentID)
                    Dim programIDInt As Integer = Convert.ToInt32(programID)

                    Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this department and its program?", "Confirm Deletion", MessageBoxButtons.YesNo)

                    If result = DialogResult.Yes Then
                        Dim success As Boolean = DeleteFromDatabase(departmentIDInt, programIDInt)

                        If success Then
                            DataGridView1.Rows.RemoveAt(selectedRow.Index)
                            MessageBox.Show("Department and Program deleted successfully.", "Input Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtDepartmentName.Clear()
                            txtProgramName.Clear()
                        Else
                            MessageBox.Show("Failed to delete department or program. It may be due to foreign key constraints.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("DepartmentID or ProgramID contains an invalid or missing value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Function DeleteFromDatabase(departmentID As Integer, programID As Integer) As Boolean
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "DELETE FROM Program WHERE DepartmentID = @DepartmentID AND ProgramID = @ProgramID; " &
                              "DELETE FROM Department WHERE DepartmentID = @DepartmentID AND NOT EXISTS (SELECT 1 FROM Program WHERE DepartmentID = @DepartmentID)"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID)
                cmd.Parameters.AddWithValue("@ProgramID", programID)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting department: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function



    Private Function GetNextID(tableName As String, columnName As String) As Integer
        Dim query As String = $"SELECT MAX({columnName}) + 1 FROM {tableName}"
        Dim cmd As New MySqlCommand(query, connection)
        Dim result As Object = cmd.ExecuteScalar()
        If IsDBNull(result) Then
            Return 1 ' Start at 1 if no records exist
        Else
            Return Convert.ToInt32(result)
        End If
    End Function

    Dim selectedDepartmentID As Integer

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtDepartmentName.Text = selectedRow.Cells("Department").Value.ToString()
            txtProgramName.Text = selectedRow.Cells("Program").Value.ToString()

            ' Store DepartmentID in a variable
            selectedDepartmentID = Convert.ToInt32(selectedRow.Cells("DepartmentID").Value)
        End If
    End Sub


    ' Declare selectedProgramID
    Dim selectedProgramID As Integer

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Validate input
        If String.IsNullOrEmpty(txtDepartmentName.Text) Then
            MessageBox.Show("Please enter a department name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(txtProgramName.Text) Then
            MessageBox.Show("Please enter a program name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Assuming the selected ProgramID is stored in DataGridView
        ' Example: Get the selected ProgramID from the DataGridView (replace with your own logic)
        If DataGridView1.SelectedRows.Count > 0 Then
            selectedProgramID = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ProgramID").Value)
        Else
            MessageBox.Show("Please select a program to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update the database
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' Prepare the update query
            Dim query As String = "UPDATE Department d
                            JOIN Program p ON d.DepartmentID = p.DepartmentID
                            SET d.DepartmentName = @DepartmentName, p.ProgramName = @ProgramName
                            WHERE d.DepartmentID = @DepartmentID AND p.ProgramID = @ProgramID"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text)
                cmd.Parameters.AddWithValue("@ProgramName", txtProgramName.Text)
                cmd.Parameters.AddWithValue("@DepartmentID", selectedDepartmentID)
                cmd.Parameters.AddWithValue("@ProgramID", selectedProgramID)

                ' Execute the query
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                ' If no rows were affected, inform the user
                If rowsAffected = 0 Then
                    MessageBox.Show("No records were updated. Please check the DepartmentID and ProgramID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ' Refresh the DataGridView
                    LoadData()
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDepartmentName.Clear()
                    txtProgramName.Clear()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub





    Private Sub txtDepartmentName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDepartmentName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtProgramName.Focus()
        End If
    End Sub

    Private Sub txtProgramName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProgramName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSubmit.Focus()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Back As New Form4()
        Back.Show()
        Me.Hide()
    End Sub


End Class
