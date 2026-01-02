Imports MySql.Data.MySqlClient
Public Class Form10
    Dim connection As MySqlConnection = database.GetConnection()

    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing
    Private Sub btnProg_Click(sender As Object, e As EventArgs) Handles btnProg.Click
        Dim Prog As New Form9()
        Prog.Show()
        Me.Hide()
    End Sub
    Private Sub btnProf_Click(sender As Object, e As EventArgs) Handles btnProf.Click
        Dim Prof As New Form8()
        Prof.Show()
        Me.Hide()
    End Sub
    Private Sub btnSubjects_Click(sender As Object, e As EventArgs) Handles btnSubjects.Click
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtStudentID.Text) Then
                MessageBox.Show("Please enter a student ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtEmailAddress.Text) Then
                MessageBox.Show("Please enter an email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtFirstName.Text) Then
                MessageBox.Show("Please enter the first name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtLastName.Text) Then
                MessageBox.Show("Please enter the last name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtMiddleName.Text) Then
                MessageBox.Show("Please enter the middle name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If cmbYear.SelectedIndex = -1 Then
                MessageBox.Show("Please select a valid Year Level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If cmbProgram.SelectedIndex = -1 Then
                MessageBox.Show("Please select a program.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim yearLevel As String = cmbYear.SelectedItem.ToString()

            If IsSectionFull(yearLevel) Then
                MessageBox.Show("This section is already full. Please select another section.", "Section Full", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim query As String = "INSERT INTO Student (StudentID, FirstName, LastName, MiddleName, Program, Email,YearLevel) 
                               VALUES (@StudentID, @FirstName, @LastName, @MiddleName, @Program, @EmailAddress, @YearLevel)"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text)
                cmd.Parameters.AddWithValue("@Program", cmbProgram.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text)
                cmd.Parameters.AddWithValue("@YearLevel", cmbYear.SelectedItem.ToString())

                cmd.ExecuteNonQuery()
                UpdateStudentCount(yearLevel)

                MessageBox.Show("Student information added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStudents()

                txtStudentID.Clear()
                txtFirstName.Clear()
                txtLastName.Clear()
                txtMiddleName.Clear()
                txtEmailAddress.Clear()
                cmbProgram.SelectedIndex = -1
                cmbYear.SelectedIndex = -1

            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Function IsSectionFull(yearLevel As String) As Boolean
        Dim query As String = "SELECT NoOfStudents, CurrentStudents FROM SchoolDetails WHERE YearLevel = @YearLevel"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@YearLevel", yearLevel)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim maxStudents As Integer = reader.GetInt32("NoOfStudents")
                    Dim currentStudents As Integer = reader.GetInt32("CurrentStudents")
                    Return currentStudents >= maxStudents
                End If
            End Using
        End Using
        Return False
    End Function

    Private Sub UpdateStudentCount(yearLevel As String)
        Dim updateQuery As String = "UPDATE SchoolDetails SET CurrentStudents = CurrentStudents + 1 WHERE YearLevel = @YearLevel"
        Using cmd As New MySqlCommand(updateQuery, connection)
            cmd.Parameters.AddWithValue("@YearLevel", yearLevel)
            cmd.ExecuteNonQuery()
        End Using
    End Sub



    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToggleButtonState(btnStudent)

        Dim query As String = "SELECT DISTINCT YearLevel FROM SchoolDetails"
        Dim programQuery As String = "SELECT DISTINCT ProgramName FROM Program"

        Dim cmd As New MySqlCommand(query, connection)
        Dim cmdProgram As New MySqlCommand(programQuery, connection)

        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            cmbYear.Items.Clear()
            cmbProgram.Items.Clear()

            Dim yearLevels As New HashSet(Of String)()
            Dim programs As New HashSet(Of String)()

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim yearLevel As String = reader("YearLevel").ToString()

                If Not yearLevels.Contains(yearLevel) Then
                    cmbYear.Items.Add(yearLevel)
                    yearLevels.Add(yearLevel)
                End If

            End While
            reader.Close()

            Dim readerProgram As MySqlDataReader = cmdProgram.ExecuteReader()

            While readerProgram.Read()
                Dim program As String = readerProgram("ProgramName").ToString()
                If Not programs.Contains(program) Then
                    cmbProgram.Items.Add(program)
                    programs.Add(program)
                End If
            End While

            readerProgram.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)

        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try


        LoadStudents()
    End Sub

    Private Sub LoadStudents(Optional searchQuery As String = "")
        Try
            Dim query As String = "
        SELECT 
            s.StudentID, 
            s.FirstName, 
            s.LastName, 
            s.MiddleName, 
            s.Email,
            s.Program, 
            s.YearLevel
        FROM 
            Student s"

            If Not String.IsNullOrEmpty(searchQuery) Then
                query &= " AND (s.StudentID LIKE @SearchQuery OR s.LastName LIKE @SearchQuery OR s.FirstName LIKE @SearchQuery OR s.Section LIKE @SearchQuery)"
            End If

            query &= " ORDER BY s.StudentID"

            Dim adapter As New MySqlDataAdapter(query, connection)

            If Not String.IsNullOrEmpty(searchQuery) Then
                adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", "%" & searchQuery & "%")
            End If

            Dim dt As New DataTable()

            adapter.Fill(dt)

            DataGridView1.DataSource = dt

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If DataGridView1.SelectedRows.Count > 0 Then
            Dim studentID As String = DataGridView1.SelectedRows(0).Cells("StudentID").Value.ToString()
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim transaction As MySqlTransaction = Nothing
                Try
                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                    End If

                    transaction = connection.BeginTransaction()

                    Dim getYearLevelQuery As String = "SELECT YearLevel FROM Student WHERE StudentID = @StudentID"
                    Dim getYearLevelCmd As New MySqlCommand(getYearLevelQuery, connection)
                    getYearLevelCmd.Parameters.AddWithValue("@StudentID", studentID)
                    getYearLevelCmd.Transaction = transaction
                    Dim yearLevel As String = Convert.ToString(getYearLevelCmd.ExecuteScalar())

                    Dim updateStudentsQuery As String = "UPDATE SchoolDetails SET CurrentStudents = CurrentStudents - 1 WHERE YearLevel = @YearLevel"
                    Dim updateStudentsCmd As New MySqlCommand(updateStudentsQuery, connection)
                    updateStudentsCmd.Parameters.AddWithValue("@YearLevel", yearLevel)
                    updateStudentsCmd.Transaction = transaction
                    updateStudentsCmd.ExecuteNonQuery()

                    Dim deleteStudentQuery As String = "DELETE FROM Student WHERE StudentID = @StudentID"
                    Dim deleteStudentCmd As New MySqlCommand(deleteStudentQuery, connection)
                    deleteStudentCmd.Parameters.AddWithValue("@StudentID", studentID)
                    deleteStudentCmd.Transaction = transaction
                    deleteStudentCmd.ExecuteNonQuery()

                    transaction.Commit()

                    MessageBox.Show("Student record deleted successfully.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LoadStudents()

                Catch ex As Exception
                    MessageBox.Show("Error deleting student data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a student to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim studentID As String = DataGridView1.SelectedRows(0).Cells("StudentID").Value.ToString()

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this student's information?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Try
                    Dim query As String = "
                UPDATE Student 
                SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    MiddleName = @MiddleName, 
                    Email = @Email,  
                    Program = @Program,
                    YearLevel = @YearLevel 
                WHERE StudentID = @StudentID"

                    Dim cmd As New MySqlCommand(query, connection)

                    cmd.Parameters.AddWithValue("@StudentID", studentID)
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text)
                    cmd.Parameters.AddWithValue("@Email", txtEmailAddress.Text)
                    cmd.Parameters.AddWithValue("@Program", cmbProgram.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@YearLevel", cmbYear.SelectedItem.ToString())

                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                    End If

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Student record updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LoadStudents()

                Catch ex As Exception
                    MessageBox.Show("Error updating student data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a student to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            txtStudentID.Text = DataGridView1.SelectedRows(0).Cells("StudentID").Value.ToString()
            txtFirstName.Text = DataGridView1.SelectedRows(0).Cells("FirstName").Value.ToString()
            txtLastName.Text = DataGridView1.SelectedRows(0).Cells("LastName").Value.ToString()
            txtMiddleName.Text = DataGridView1.SelectedRows(0).Cells("MiddleName").Value.ToString()
            txtEmailAddress.Text = DataGridView1.SelectedRows(0).Cells("Email").Value.ToString()
            cmbProgram.SelectedItem = DataGridView1.SelectedRows(0).Cells("Program").Value.ToString()
            cmbYear.SelectedItem = DataGridView1.SelectedRows(0).Cells("YearLevel").Value.ToString()
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Back As New Form4()
        Back.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateEmail()
        ' Ensure both TextBoxes have text before generating the email
        If Not String.IsNullOrEmpty(txtLastName.Text) AndAlso Not String.IsNullOrEmpty(txtFirstName.Text) Then
            Dim lastName As String = txtLastName.Text.Trim().ToLower()
            Dim firstName As String = txtFirstName.Text.Trim().Replace(" ", "").ToLower() ' Remove spaces in the first name
            txtEmailAddress.Text = $"{lastName}_{firstName}@plpasig.edu.ph"
        Else
            ' Clear the email TextBox if either name field is empty
            txtEmailAddress.Clear()
        End If
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        UpdateEmail()
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        UpdateEmail()
    End Sub

    Private Sub txtStudentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStudentID.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtLastName.Focus()
        End If
    End Sub

    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtMiddleName.Focus()
        End If
    End Sub

    Private Sub txtMiddleName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMiddleName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnAdd.Focus()
        End If
    End Sub
End Class