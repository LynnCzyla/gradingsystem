Imports MySql.Data.MySqlClient

Public Class Form12
    Dim connection As MySqlConnection = database.GetConnection()
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadArchivedRecords()
    End Sub

    Private Sub LoadArchivedRecords()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim query As String = "SELECT * FROM Professor WHERE IsArchived = 1"

            Using cmd As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim dt As New DataTable()
                    dt.Load(reader)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading archived records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim professorID = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ProfessorID").Value)

            Dim confirmDelete = MessageBox.Show("Are you sure you want to permanently delete this archived professor?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmDelete = DialogResult.Yes Then
                Try
                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                    End If

                    Dim userID = 0
                    Using cmd As New MySqlCommand("SELECT UserID FROM Professor WHERE ProfessorID = @ProfessorID", connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        Dim result = cmd.ExecuteScalar

                        If result IsNot Nothing Then
                            userID = Convert.ToInt32(result)
                            Debug.WriteLine("UserID for Professor " & professorID & ": " & userID)
                        Else
                            Debug.WriteLine("No UserID found for Professor " & professorID)
                            MessageBox.Show("Error: No UserID associated with this professor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using

                    Dim deleteProfessorQuery = "DELETE FROM Professor WHERE ProfessorID = @ProfessorID"
                    Using cmd As New MySqlCommand(deleteProfessorQuery, connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        cmd.ExecuteNonQuery()
                        Debug.WriteLine("Deleted Professor with ID: " & professorID)
                    End Using

                    If userID > 0 Then
                        Dim deleteUserQuery = "DELETE FROM User WHERE UserID = @UserID"
                        Using cmd As New MySqlCommand(deleteUserQuery, connection)
                            cmd.Parameters.AddWithValue("@UserID", userID)
                            cmd.ExecuteNonQuery()
                            Debug.WriteLine("Deleted User with ID: " & userID)
                        End Using
                    Else
                        Debug.WriteLine("No User associated with Professor " & professorID)
                    End If

                    LoadArchivedRecords()

                    MessageBox.Show("Archived professor and associated user deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Error deleting archived professor: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a professor to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim back As New Form8()
        back.Show()
        Me.Hide()
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim professorID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ProfessorID").Value)

            Dim confirmRestore As DialogResult = MessageBox.Show("Are you sure you want to restore this archived professor?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmRestore = DialogResult.Yes Then
                Try
                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                    End If

                    Dim userID As Integer = 0
                    Using cmd As New MySqlCommand("SELECT UserID FROM Professor WHERE ProfessorID = @ProfessorID", connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        Dim result As Object = cmd.ExecuteScalar()

                        If result IsNot Nothing Then
                            userID = Convert.ToInt32(result)
                        Else
                            MessageBox.Show("Error: No UserID associated with this professor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using

                    Dim restoreProfessorQuery As String = "UPDATE Professor SET IsArchived = 0, DateArchived = NULL WHERE ProfessorID = @ProfessorID"
                    Using cmd As New MySqlCommand(restoreProfessorQuery, connection)
                        cmd.Parameters.AddWithValue("@ProfessorID", professorID)
                        cmd.ExecuteNonQuery()
                    End Using

                    If userID > 0 Then
                        Dim restoreUserQuery As String = "UPDATE User SET IsArchived = 0, DateArchived = NULL WHERE UserID = @UserID"
                        Using cmd As New MySqlCommand(restoreUserQuery, connection)
                            cmd.Parameters.AddWithValue("@UserID", userID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    LoadArchivedRecords()

                    MessageBox.Show("Archived professor and associated user restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Error restoring archived professor: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a professor to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class