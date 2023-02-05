' File: UserLogin.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
' The UserLogin form is the initial form displayed when the application is first launched.  It takes the user's username and password as input.
' They can then either attempt to login using the credentials or alternatively, create a new account using the credentials.
'
' When the form loads, the MySQL server address is read from Settings.xml in the application directory and stored in a public variable to be used in the connection string.
'
' Password validation uses a regular expression to determine if it meets the composition requirements.  The original application required the passwords
' to be 1 to 15 alphanumeric characters.  To meet modern password guidelines, it must now be a minimum of 8 and maximum of 15 characters.  The password
' must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.  This provides added security to the user's data.
'
' The original password hash used was MD5.  This is no longer considered to be a secure hash so SHA256 is used in its place.
'
' As an enhancement, the password is never stored in a string variable but rather evaluated as the textbox contents.
'

Imports System.Text.RegularExpressions
Imports System.Xml

Public Class UserLogin

    'Procedure executes when user clicks the Login button
    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        'The username is validated by a call to the DataValidation module
        If IsValidUsername(txtUsername.Text) Then

            'Password RegEx Pattern (8 to 15 characters including at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character)
            Dim pattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,15}$"

            'Declare regular expression object
            Dim rx As New Regex(pattern)

            'Store RegEx matches in MatchCollection
            Dim matches As MatchCollection = rx.Matches(txtPassword.Text)

            'If a match is found then the password is valid
            If matches.Count > 0 Then

                'Create byte array of plaintext password
                Dim pw() As Byte = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text)

                'Declare the SHA256 hash algorithm object
                Dim hash As New Security.Cryptography.SHA256Managed()

                'Computes SHA256 hash of plaintext password byte array and stores in new byte array
                Dim hashBytes() As Byte = hash.ComputeHash(pw)

                'Converts the hashed password byte array into a string to store in database and compare with password checks
                Dim hashedPassword As String = System.Text.ASCIIEncoding.ASCII.GetString(hashBytes)

                'Call authentication stored procedure from MySQLDB module using the credentials entered by the user
                Dim retVal As Integer = VerifyAuthenticateUser(txtUsername.Text, hashedPassword)

                'Returns zero if the username was found and the password matched
                If retVal = 0 Then

                    'Set the public variable of MainDisplay to the current logged in user
                    MainDisplay.currentUser = txtUsername.Text

                    'The user name is appended to the MainDisplay form title as a convenience to the user
                    MainDisplay.Text = "Weight Loss Tracker - Logged in as " & MainDisplay.currentUser

                    'Both input textboxes are cleared to prepare for the next login
                    txtUsername.Clear()
                    txtPassword.Clear()

                    'Hide the user login form until the MainDisplay is closed
                    Me.Hide()

                    'Display the main form
                    MainDisplay.Show()

                    'Returns 1 if the username was found but the passwords did not match
                ElseIf retVal = 1 Then

                    'Inform user of invalid password
                    Call MsgBox("The password you entered does not match the account password.", vbOKOnly, "Incorrect Password")

                    'Clears the password textbox and reselects for the user's next password attempt
                    txtPassword.Clear()
                    txtPassword.Select()

                    'Returns 2 if the username was not found
                ElseIf retVal = 2 Then

                    'Inform user of non-existant user
                    Call MsgBox("The username you entered was not found in the database.  You can create a new account using these credentials or enter new credentials.", vbOKOnly, "User Not Found")

                    'Returns -1 if the stored procedure failed to execute
                Else

                    'Inform user of database error
                    Call MsgBox("A MySQL database error has occured trying to authenticate user.", vbOKOnly, "MySQL Authenticate User Error")

                End If

            Else

                'Inform user of invalid password
                Call MsgBox("The password you entered is not valid.  Passwords must be 8 to 15 characters including one uppercase letter, one lowercase letter, one number, and one special character.", vbOKOnly, "Invalid Password")

                'Clears the password textbox and reselects it for the user's next password attempt
                txtPassword.Clear()
                txtPassword.Select()

            End If

        Else

            'Inform user of invalid username
            Call MsgBox("The username you entered is not valid.  Usernames must be 1 to 15 alphanumeric characters.", vbOKOnly, "Invalid Password")

            'Clears the username textbox and reselects for the user's next username attempt
            txtUsername.Clear()
            txtUsername.Select()

        End If

    End Sub

    'Procedure executes if user clicks the Create New User button
    Private Sub cmdCreateNewUser_Click(sender As Object, e As EventArgs) Handles cmdCreateNewUser.Click

        'The username is validated by a call to the DataValidation module
        If IsValidUsername(txtUsername.Text) Then

            'Password RegEx Pattern (8 to 15 characters including at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character)
            Dim pattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,15}$"

            'Declare regular expression object
            Dim rx As New Regex(pattern)

            'Store RegEx matches in MatchCollection
            Dim matches As MatchCollection = rx.Matches(txtPassword.Text)

            'If a match is found then password is valid
            If matches.Count > 0 Then

                'Create byte array of plaintext password
                Dim pw() As Byte = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text)

                'Declare the SHA256 hash algorithm object
                Dim hash As New Security.Cryptography.SHA256Managed()

                'Computes SHA256 hash of plaintext password byte array and stores in new byte array
                Dim hashBytes() As Byte = hash.ComputeHash(pw)

                'Converts the hashed password byte array into a string to store in database and compare with password checks
                Dim hashedPassword As String = System.Text.ASCIIEncoding.ASCII.GetString(hashBytes)

                'Call authentication stored procedure from MySQLDB module using the credentials entered by the user
                Dim retValVerifyUser As Integer = VerifyAuthenticateUser(txtUsername.Text, hashedPassword)

                'Returns 2 if the username was not found
                If retValVerifyUser = 2 Then

                    'Call AddUser stored procedure from MySQLDB module using the credentials entered by the user
                    Dim retValAddUser As Integer = AddUser(txtUsername.Text, hashedPassword)

                    'Returns 0 if AddUser was successful
                    If retValAddUser = 0 Then

                        'Set the public variable of MainDisplay to the current logged in user
                        MainDisplay.currentUser = txtUsername.Text

                        'The user name is appended to the MainDisplay form title as a convenience to the user
                        MainDisplay.Text = "Weight Loss Tracker - Logged in as " & MainDisplay.currentUser

                        'Both input textboxes are cleared to prepare for the next login
                        txtUsername.Clear()
                        txtPassword.Clear()

                        'Hide the user login form until the MainDisplay is closed
                        Me.Hide()

                        'Display the main form
                        MainDisplay.Show()

                        'Immediately load the Set Target Weight form to get initial target weight
                        'ShowDialog is used to ensure nothing can be done on the MainDisplay form until SetTargetWeight form is closed
                        SetTargetWeight.ShowDialog()

                        'AddUser failed
                    Else

                        'Inform user that add user failed
                        Call MsgBox("A MySQL database error has occured trying to add new user.", vbOKOnly, "MySQL Add User Error")

                    End If

                    'Returns 0 or 1 if the user exists
                ElseIf retValVerifyUser = 0 Or retValVerifyUser = 1 Then

                    'Inform user that the account already exists
                    Call MsgBox("This account already exists.  Please use the login button to use these credentials", vbOKOnly, "User Account Exists")

                    'VerifyAuthenticateUser failed
                Else

                    'Inform user that verification failed
                    Call MsgBox("A MySQL database error has occured trying to verify new user.", vbOKOnly, "MySQL Verify User Error")

                End If

            Else

                'Inform user of invalid password
                Call MsgBox("The password you entered is not valid.  Passwords must be 8 to 15 characters including one uppercase letter, one lowercase letter, one number, and one special character.", vbOKOnly, "Invalid Password")

                'Reset password textbox
                txtPassword.Clear()
                txtPassword.Select()

            End If

        Else

            'Inform user of invalid username
            Call MsgBox("The username you entered is not valid.  Usernames must be 1 to 15 alphanumeric characters.", vbOKOnly, "Invalid Password")

            'Clears the username textbox and reselects it for the user's next username attempt
            txtUsername.Clear()
            txtUsername.Select()

        End If

    End Sub

    'Procedure executes if user clicks the Exit button
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        'Close application
        Me.Close()

    End Sub

    'Procedure executes when UserLogin form is first loaded
    Private Sub UserLogin_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Declare an XMLTextReader object bound to Settings.xml located in the application directory
        Dim reader As New XmlTextReader("Settings.xml")

        'Continue reading lines of Settings.xml until there are no more
        While reader.Read()

            'Evaluate the type of node for the current line
            Select Case reader.NodeType

                'If node is an Element
                Case XmlNodeType.Element

                    'If current element is the server address
                    If reader.Name = "ServerAddress" Then

                        'Populate the server address on the Settings form from Settings.xml
                        MySQLServerAddress = reader.ReadString

                        'Move on to the next line of the XML file
                        Exit Select

                    End If

            End Select

        End While

        'Close the XmlTextReader object
        reader.Close()

        'Set focus to the user name textbox for convenience
        txtUsername.Select()

        'Temporary code to auto-populate credentials to reduce typing during testing
        'txtUsername.Text = ""
        'txtPassword.Text = ""

    End Sub

    'Procedure executes when user clicks the Settings button
    Private Sub cmdSettings_Click(sender As Object, e As EventArgs) Handles cmdSettings.Click

        'Display Settings form using ShowDialog method so UserLogin cannot be used again until Settings form is closed.
        Settings.ShowDialog()

    End Sub

End Class
