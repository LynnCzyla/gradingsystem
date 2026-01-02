Imports MySql.Data.MySqlClient

Module database
    ' Define your MySQL connection string here
    Private connectionString As String = "Server=127.0.0.1;Port=3307;Database=gradingsystem;Uid=root;Pwd=ALPUERTO_1905;SslMode=None;"

    ' Function to get a new open connection
    Public Function GetConnection() As MySqlConnection
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to database: " & ex.Message)
        End Try
        Return connection
    End Function

    ' Function to close a given connection
    Public Sub CloseConnection(connection As MySqlConnection)
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    ' Function to get the next ID from the specified table and column
    Public Function GetNextID(tableName As String, columnName As String) As Integer
        Dim connection As MySqlConnection = GetConnection()
        Dim query As String = $"SELECT MAX({columnName}) FROM {tableName}"
        Dim command As New MySqlCommand(query, connection)

        Try
            Dim result As Object = command.ExecuteScalar()

            If IsDBNull(result) Then
                Return 1
            Else
                Return Convert.ToInt32(result) + 1
            End If
            Return 1
        Catch ex As Exception
            MessageBox.Show("Error fetching next ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1
        Finally
            CloseConnection(connection)
        End Try
    End Function

    ' Function to get subjects assigned to a professor
    Public Function GetSubjectsForProfessor(professorID As Integer) As DataTable
        Dim dt As New DataTable()

        Try
            Using connection As MySqlConnection = GetConnection()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Dim query As String = "SELECT SubjectCode, SubjectName FROM ProftoSubject WHERE ProfessorID = @ProfessorID"
                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@ProfessorID", professorID)

                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load subjects: " & ex.Message)
        End Try

        Return dt
    End Function

    ' Function to dynamically store logged-in professor's ID
    Public Sub SetLoggedInProfessorID(profID As Integer)
        Globals.LoggedInProfessorID = profID
    End Sub

    ' Function to get a connection safely
    Public Function GetProfessorDetails(profID As Integer) As String
        Dim connection As MySqlConnection = GetConnection()

        Dim query As String = $"SELECT Name FROM USER WHERE UserID = {profID}"
        Dim command As New MySqlCommand(query, connection)
        Dim profName As String = ""

        Try
            connection.Open()

            profName = Convert.ToString(command.ExecuteScalar())

        Catch ex As MySqlException
            MessageBox.Show("Failed to access the database: " & ex.Message)
        Finally
            CloseConnection(connection)
        End Try

        Return profName
    End Function
End Module
