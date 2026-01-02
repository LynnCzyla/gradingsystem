Imports MySql.Data.MySqlClient

Public Class Form8

    Dim connection As MySqlConnection = database.GetConnection()


    Private originalColor As Color = Color.FromArgb(227, 219, 36)
    Private hoverColor As Color = Color.FromArgb(207, 159, 39)
    Private activeButton As Button = Nothing

    Private Sub btnSubjects_Click(sender As Object, e As EventArgs) Handles btnSubjects.Click
        Dim Subject As New Form7()
        Subject.Show()
        Me.Hide()
    End Sub

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

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ToggleButtonState(btnProf)

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        cmDepart.DropDownStyle = ComboBoxStyle.DropDownList

        LoadProfessors()
        LoadDepartments()
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

            cmDepart.DataSource = dt
            cmDepart.DisplayMember = "DepartmentName"
            cmDepart.ValueMember = "DepartmentID"
            cmDepart.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim transaction As MySqlTransaction = Nothing
        Try
            If String.IsNullOrEmpty(txtEmail.Text) Then
                MessageBox.Show("Please enter a valid email.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text) Then
                MessageBox.Show("Please enter a password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(cboType.Text) Then
                MessageBox.Show("Please select a type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtLastName.Text) Then
                MessageBox.Show("Please enter the last name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtProfID.Text) Then
                MessageBox.Show("Please enter a valid Professor ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            transaction = connection.BeginTransaction()

            Dim userQuery As String = "INSERT INTO user (Email, Password, Role) VALUES (@Email, @Password, 'Professor')"
            Dim userCmd As New MySqlCommand(userQuery, connection)
            userCmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            userCmd.Parameters.AddWithValue("@Password", txtPassword.Text)
            userCmd.Transaction = transaction
            userCmd.ExecuteNonQuery()

            Dim getUserIdQuery As String = "SELECT UserID FROM user WHERE Email = @Email"
            Dim getUserIdCmd As New MySqlCommand(getUserIdQuery, connection)
            getUserIdCmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            getUserIdCmd.Transaction = transaction
            Dim userId As Integer = Convert.ToInt32(getUserIdCmd.ExecuteScalar())

            If cmDepart.SelectedIndex = 0 Then
                MessageBox.Show("Please select a department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim departmentID As Integer = Convert.ToInt32(cmDepart.SelectedValue)

            Dim professorQuery As String = "INSERT INTO professor (ProfessorID, UserID, Type, LastName, FirstName, MiddleName, DepartmentID, ContactNo) VALUES (@ProfessorID, @UserID, @Type, @LastName, @FirstName, @MiddleName, @DepartmentID, @ContactNo)"
            Dim professorCmd As New MySqlCommand(professorQuery, connection)
            professorCmd.Parameters.AddWithValue("@ProfessorID", txtProfID.Text)
            professorCmd.Parameters.AddWithValue("@UserID", userId)
            professorCmd.Parameters.AddWithValue("@Type", cboType.Text)
            professorCmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
            professorCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
            professorCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text)
            professorCmd.Parameters.AddWithValue("@DepartmentID", cmDepart.SelectedValue)
            professorCmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text)
            getUserIdCmd.Transaction = transaction
            professorCmd.ExecuteNonQuery()


            transaction.Commit()

            MessageBox.Show("Professor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()

            LoadProfessors()

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    Private Function GetNextProfessorID() As Integer
        Dim query As String = "SELECT MAX(ProfessorID) + 1 FROM Professor"
        Using cmd As New MySqlCommand(query, connection)
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim result As Object = cmd.ExecuteScalar()
            If result Is DBNull.Value Then
                Return 1
            Else
                Return Convert.ToInt32(result)
            End If
        End Using
    End Function

    Private Function GetDepartmentID(departmentName As String) As Integer
        Try
            Dim query As String = "SELECT DepartmentID FROM Department WHERE DepartmentName = @DepartmentName"
            Using cmd As New MySqlCommand(query, connection)
                If connection.State = ConnectionState.Closed Then connection.Open()
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName)
                Dim result = cmd.ExecuteScalar()
                If result Is DBNull.Value OrElse result Is Nothing Then
                    Return 0
                Else
                    Return Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching department ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Private Sub ClearFields()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtMiddleName.Clear()
        txtContactNo.Clear()
        txtEmail.Clear()
        txtPassword.Clear()
        cboType.SelectedIndex = -1
        cmDepart.SelectedIndex = 0
    End Sub

    Private Sub LoadProfessors(Optional searchQuery As String = "")
        Try
            Dim query As String = "
        SELECT 
            p.ProfessorID, 
            p.Type, 
             COALESCE(d.DepartmentName, 'No Department') AS Department,
            p.LastName, 
            p.FirstName, 
            p.MiddleName, 
            u.Email, 
            u.Password, 
            p.ContactNo
        FROM 
            Professor p
        LEFT JOIN 
            Department d ON p.DepartmentID = d.DepartmentID
        LEFT JOIN 
            User u ON p.UserID = u.UserID
        WHERE 
            p.IsArchived = 0"

            If Not String.IsNullOrEmpty(searchQuery) Then
                query &= " AND (p.ProfessorID LIKE @SearchQuery OR p.LastName LIKE @SearchQuery OR p.FirstName LIKE @SearchQuery OR d.DepartmentName LIKE @SearchQuery)"
            End If

            query &= " ORDER BY p.ProfessorID"

            Dim adapter As New MySqlDataAdapter(query, connection)

            If Not String.IsNullOrEmpty(searchQuery) Then
                adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", "%" & searchQuery & "%")
            End If

            Dim dt As New DataTable()

            adapter.Fill(dt)

            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Error loading professor data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim professorID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ProfessorID").Value)

            Dim confirmArchive As DialogResult = MessageBox.Show("Are you sure you want to delete this professor?", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmArchive = DialogResult.Yes Then
                Try
                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                    End If

                    Dim archiveQuery As String = "UPDATE Professor SET IsArchived = 1, DateArchived = NOW() WHERE ProfessorID = @ProfessorID"
                    Using cmd As New MySqlCommand(archiveQuery, connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim userArchiveQuery As String = "UPDATE User SET IsArchived = 1, DateArchived = NOW() WHERE UserID = (SELECT UserID FROM Professor WHERE ProfessorID = @ProfessorID)"
                    Using cmd As New MySqlCommand(userArchiveQuery, connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim deleteProfessorQuery As String = "DELETE FROM Professor WHERE IsArchived = 1 AND DATEDIFF(NOW(), DateArchived) > 30 AND ProfessorID = @ProfessorID"
                    Using cmd As New MySqlCommand(deleteProfessorQuery, connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        Dim professorRowsAffected As Integer = cmd.ExecuteNonQuery()
                    End Using

                    Dim deleteUserQuery As String = "DELETE FROM User WHERE IsArchived = 1 AND DATEDIFF(NOW(), DateArchived) > 30 AND UserID = (SELECT UserID FROM Professor WHERE ProfessorID = @ProfessorID)"
                    Using userCmd As New MySqlCommand(deleteUserQuery, connection)
                        userCmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        Dim userRowsAffected As Integer = userCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Professor archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearFields()
                    LoadProfessors()

                Catch ex As Exception
                    MessageBox.Show("Error archiving professor: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a professor to archive.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub likArchive_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles likArchive.LinkClicked
        Dim archive As New Form12()
        archive.Show()
        Me.Hide()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a professor to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim professorID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ProfessorID").Value)

            If String.IsNullOrEmpty(txtEmail.Text) Then
                MessageBox.Show("Please enter a valid email.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text) Then
                MessageBox.Show("Please enter a password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(cboType.Text) Then
                MessageBox.Show("Please select a type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtLastName.Text) Then
                MessageBox.Show("Please enter the last name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(txtProfID.Text) Then
                MessageBox.Show("Please enter a valid Professor ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim userQuery As String = "UPDATE user SET Email = @Email, Password = @Password WHERE Email = @Email"
            Dim userCmd As New MySqlCommand(userQuery, connection)
            userCmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            userCmd.Parameters.AddWithValue("@Password", txtPassword.Text)
            userCmd.ExecuteNonQuery()

            Dim professorQuery As String = "UPDATE professor SET ProfessorID = @ProfessorID, Type = @Type, LastName = @LastName, FirstName = @FirstName, " &
                                           "MiddleName = @MiddleName, DepartmentID = @DepartmentID, ContactNo = @ContactNo WHERE ProfessorID = @ProfessorID"
            Dim professorCmd As New MySqlCommand(professorQuery, connection)
            professorCmd.Parameters.AddWithValue("@ProfessorID", txtProfID.Text)
            professorCmd.Parameters.AddWithValue("@Type", cboType.Text)
            professorCmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
            professorCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
            professorCmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text)
            professorCmd.Parameters.AddWithValue("@DepartmentID", cmDepart.SelectedValue)
            professorCmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text)
            professorCmd.ExecuteNonQuery()


            MessageBox.Show("Professor details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadProfessors()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error updating professor: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            txtProfID.Text = selectedRow.Cells("ProfessorID").Value.ToString()
            txtEmail.Text = selectedRow.Cells("Email").Value.ToString()
            txtPassword.Text = selectedRow.Cells("Password").Value.ToString()
            txtFirstName.Text = selectedRow.Cells("FirstName").Value.ToString()
            txtLastName.Text = selectedRow.Cells("LastName").Value.ToString()
            txtMiddleName.Text = selectedRow.Cells("MiddleName").Value.ToString()
            cboType.Text = selectedRow.Cells("Type").Value.ToString()
            cmDepart.Text = selectedRow.Cells("Department").Value.ToString()
            txtContactNo.Text = selectedRow.Cells("ContactNo").Value.ToString()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Back As New Form4()
        Back.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ClearFields()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadProfessors(txtSearch.Text)
    End Sub


    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        UpdateEmail()
        UpdatePassword()
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        UpdateEmail()
    End Sub
    Private Sub UpdateEmail()
        If Not String.IsNullOrEmpty(txtLastName.Text) AndAlso Not String.IsNullOrEmpty(txtFirstName.Text) Then
            Dim lastName As String = txtLastName.Text.Trim().ToLower()
            Dim firstName As String = txtFirstName.Text.Trim().Replace(" ", "").ToLower()
            txtEmail.Text = $"{lastName}_{firstName}@plpasig.edu.ph"
        Else
            txtEmail.Clear()
        End If
    End Sub

    Private Sub UpdatePassword()
        If Not String.IsNullOrEmpty(txtProfID.Text) AndAlso Not String.IsNullOrEmpty(txtLastName.Text) Then
            Dim professorID As String = txtProfID.Text.Trim()
            Dim lastName As String = txtLastName.Text.Trim().ToLower()

            txtPassword.Text = $"{professorID}_{lastName}"
        Else
            txtPassword.Clear()
        End If
    End Sub

    Private Sub txtProfID_TextChanged(sender As Object, e As EventArgs) Handles txtProfID.TextChanged
        UpdatePassword()
    End Sub

    Private Sub txtProfID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProfID.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtLastName.Focus()
        End If
    End Sub

    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtFirstName.Focus()
        End If
    End Sub

    Private Sub txtMiddleName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMiddleName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtContactNo.Focus()
        End If
    End Sub

    Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub btnAdd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnAdd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnDelete.Focus()
        End If
    End Sub

    Private Sub btnDelete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnDelete.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnUpdate.Focus()
        End If
    End Sub
End Class

