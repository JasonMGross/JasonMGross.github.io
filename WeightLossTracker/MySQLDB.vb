' File: MySQLDB.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
' This module contains all of the MySQL database connectivity functions.  The functions utilize the MySql.Data.MySqlClient .NET Core Class Library.
' All functions call secured stored procedures on a seperate MySQL server.  Each stored procedure uses prepared statements internally
' and each one validates that its functions were successful before returning a value indicating success, failure, or another predefined condition.
' Stored procedures are executed using the MySQLCommand object. The prepared statements within the stored procedures will prevent
' SQL injection attacks by ensuring input isn't simply appended to a command string.
'
' The server address is stored in a public variable and is set when the user form loads and reads the value from Settings.xml in the application directory.
' This value can be changed if necessary by clicking the Settings button in UserLogin form.
'

Imports MySql.Data.MySqlClient

Module MySQLDB

    Public MySQLServerAddress As String = ""

    ' Execute SP to add new user to users table
    ' Returns 0 if successful, 1 if unsuccessful, -1 if SP fails to complete
    Public Function AddUser(strUser As String, strPassword As String) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        AddUser = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to AddUser
            strSQLCommand.CommandText = "AddUser"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Hashed Password
            strSQLCommand.Parameters.AddWithValue("@strPassword", strPassword)
            strSQLCommand.Parameters("@strPassword").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to add new weight record to weights table
    ' Returns 0 if successful, 1 if unsuccessful, -1 if SP fails to complete
    Public Function AddWeightRecord(strUser As String, strDate As String, sWeight As Single, sExerciseMinutes As Single, sCurrentTarget As Single) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        AddWeightRecord = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to AddWeightRecord
            strSQLCommand.CommandText = "AddWeightRecord"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - EntryDate
            strSQLCommand.Parameters.AddWithValue("@dDate", strDate)
            strSQLCommand.Parameters("@dDate").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Entry Weight
            strSQLCommand.Parameters.AddWithValue("@fWeight", sWeight)
            strSQLCommand.Parameters("@fWeight").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Exercise Minutes
            strSQLCommand.Parameters.AddWithValue("@fExerciseMinutes", sExerciseMinutes)
            strSQLCommand.Parameters("@fExerciseMinutes").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Current Target Weight
            strSQLCommand.Parameters.AddWithValue("@fCurrentTarget", sCurrentTarget)
            strSQLCommand.Parameters("@fCurrentTarget").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to check weights table for duplicate record
    ' Returns 0 if record is unique, 1 if duplicate, -1 if SP fails to complete
    Public Function CheckDuplicateWeightRecord(strUser As String, strDate As String) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        CheckDuplicateWeightRecord = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to CheckDuplicateWeightRecord
            strSQLCommand.CommandText = "CheckDuplicateWeightRecord"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Entry Date
            strSQLCommand.Parameters.AddWithValue("@dDate", strDate)
            strSQLCommand.Parameters("@dDate").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to delete weight record from weights table
    ' Returns 0 if successful, 1 if unsuccessful, -1 if SP fails to complete
    Public Function DeleteWeightRecord(iRecID As Integer) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        DeleteWeightRecord = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to DeleteWeightRecord
            strSQLCommand.CommandText = "DeleteWeightRecord"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Record ID
            strSQLCommand.Parameters.AddWithValue("@iRecID", iRecID)
            strSQLCommand.Parameters("@iRecID").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to get target weight for user
    ' Returns target weight, -1 if SP fails to complete
    Public Function GetTargetWeight(strUser As String) As Single

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        GetTargetWeight = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to GetTargetWeight
            strSQLCommand.CommandText = "GetTargetWeight"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Single = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to get all data from weights table for user
    ' Returns DataTable containing the returned records
    Public Function GetWeightData(strUser As String) As DataTable

        Dim dtData As New DataTable

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to GetWeightData
            strSQLCommand.CommandText = "GetWeightData"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Create new MySqlDataAdapter using command
            Dim dataAdapter As New MySqlDataAdapter(strSQLCommand)

            'Fill data table with data returned by the adapter
            dataAdapter.Fill(dtData)

            'Close connection
            connection.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

        'Return data table containing all of the weight records for the specified user
        Return dtData

    End Function

    ' Execute SP to get one record from weights table based on record ID
    ' Returns MySqlDataReader containing the returned records
    Public Function GetWeightRecord(iRecID As Integer) As DataTable

        Dim dtData As New DataTable

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to GetWeightRecord
            strSQLCommand.CommandText = "GetWeightRecord"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Record ID
            strSQLCommand.Parameters.AddWithValue("@iRecID", iRecID)
            strSQLCommand.Parameters("@iRecID").Direction = ParameterDirection.Input

            'Create new MySqlDataAdapter using command
            Dim dataAdapter As New MySqlDataAdapter(strSQLCommand)

            'Fill data table from adapter
            dataAdapter.Fill(dtData)

            'Close connection
            connection.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

        'Return data table containing the specified weight record
        Return dtData

    End Function

    ' Execute SP to update target weight for user
    ' Returns 0 if successful, 1 if unsuccessful, -1 if SP fails to complete
    Public Function UpdateTargetWeight(strUser As String, sTargetWeight As Single) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        UpdateTargetWeight = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to UpdateTargetWeight
            strSQLCommand.CommandText = "UpdateTargetWeight"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Target Weight
            strSQLCommand.Parameters.AddWithValue("@fTargetWeight", sTargetWeight)
            strSQLCommand.Parameters("@fTargetWeight").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to update weight record for user
    ' Returns 0 if successful, 1 if unsuccessful, -1 if SP fails to complete
    Public Function UpdateWeightRecord(iRecID As Integer, strUser As String, strDate As String, sWeight As Single, sExerciseMinutes As Single, sCurrentTarget As Single) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        UpdateWeightRecord = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to UpdateWeightRecord
            strSQLCommand.CommandText = "UpdateWeightRecord"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Record ID
            strSQLCommand.Parameters.AddWithValue("@recID", iRecID)
            strSQLCommand.Parameters("@recID").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Entry Date
            strSQLCommand.Parameters.AddWithValue("@dDate", strDate)
            strSQLCommand.Parameters("@dDate").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Entry Weight
            strSQLCommand.Parameters.AddWithValue("@fWeight", sWeight)
            strSQLCommand.Parameters("@fWeight").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Exercise Minutes
            strSQLCommand.Parameters.AddWithValue("@fExerciseMinutes", sExerciseMinutes)
            strSQLCommand.Parameters("@fExerciseMinutes").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Current Target Weight
            strSQLCommand.Parameters.AddWithValue("@fCurrentTarget", sCurrentTarget)
            strSQLCommand.Parameters("@fCurrentTarget").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to verify and authenticate user crendentials username and hashed password
    ' Returns 0 if successful, 1 if user exists but password is wrong, 2 if user is not found, -1 if SP fails to complete
    Public Function VerifyAuthenticateUser(strUser As String, strPassword As String) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        VerifyAuthenticateUser = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to VerifyAuthenticateUser
            strSQLCommand.CommandText = "VerifyAuthenticateUser"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Hashed Password
            strSQLCommand.Parameters.AddWithValue("@strPassword", strPassword)
            strSQLCommand.Parameters("@strPassword").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

    ' Execute SP to delete user from users table
    ' Returns 0 if successful, 1 if unsuccessful, 2, if passwords didn't match, -1 if SP fails to complete
    Public Function DeleteUser(strUser As String, strPassword As String) As Integer

        Dim strSQLCommand As New MySqlCommand

        'The connection string is built from two strings in the application resources and the public server address variable
        Dim connection As New MySqlConnection With {
            .ConnectionString = My.Resources.connectionStringPrefix & MySQLServerAddress & My.Resources.connectionStringPostfix
        }

        'Initialize return value to failure code
        DeleteUser = -1

        'Connection and command are wrapped in Try/Catch block
        ' so connectivity won't crash the application.
        Try

            'Open connection to MySQL Database
            connection.Open()

            'Bind connection to command
            strSQLCommand.Connection = connection

            'Set Stored Procedure to execute to DeleteUser
            strSQLCommand.CommandText = "DeleteUser"
            strSQLCommand.CommandType = CommandType.StoredProcedure

            'Set stored procedure parameter - Username
            strSQLCommand.Parameters.AddWithValue("@strUser", strUser)
            strSQLCommand.Parameters("@strUser").Direction = ParameterDirection.Input

            'Set stored procedure parameter - Hashed Password
            strSQLCommand.Parameters.AddWithValue("@strPassword", strPassword)
            strSQLCommand.Parameters("@strPassword").Direction = ParameterDirection.Input

            'Execute stored procedure and store return value for evaluation by the caller
            Dim iRetVal As Integer = strSQLCommand.ExecuteScalar

            'Close connection
            connection.Close()

            'Return the value returned by the stored procedure
            Return iRetVal

        Catch ex As MySql.Data.MySqlClient.MySqlException

            'MySQL errors will be caught and the inital value of -1 will be returned to the caller to be handled

        End Try

    End Function

End Module
