' File: UserDelete.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
'User account deletion is a new enhancement added to the desktop version of the application.  It allows a user to remove their user record and all associated weight records from the database.
'
'For security, the user is asked to enter their password to ensure it is really their account.  This way the stored procedure can't be run arbitrarily on any user account without the proper credentials.
'
'The password is validated before being authenticated with the database.  If the password is invalid or incorrect, the user may make another attempt or cancel the operation.
'Additionally, the plaintext password is not stored in a string variable or passed as such to another function for additional security.  Instead, the contents of the textbox are addressed directly.
'
'This form takes advantage of the DialogResult property of the form to let the calling function know whether the user was successfully authenticated.  Only then will the function to delete the account be called.
'

Imports System.Text.RegularExpressions

Public Class UserDelete

    'Procedure executes when user clicks the Cancel button
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        'Clears the password textbox and reselects for the next password attempt
        txtPassword.Clear()
        txtPassword.Select()

        'Return dialog result of Cancel letting the calling function know the operation was cancelled
        Me.DialogResult = DialogResult.Cancel

        'Close UserDelete form and return to MainDisplay without deleting the account
        Me.Close()

    End Sub

    'Procedure executes when the user clicks the Confirm Delete button
    Private Sub cmdConfirmDelete_Click(sender As Object, e As EventArgs) Handles cmdConfirmDelete.Click

        'Password RegEx Pattern (8 to 15 characters including at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character)
        Dim pattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,15}$"

        'Declare regular expression object
        Dim rx As New Regex(pattern)

        'Store RegEx matches in MatchCollection
        Dim matches As MatchCollection = rx.Matches(txtPassword.Text)

        'If a match is found then the password is valid so it can be hashed to be checked against the database
        If matches.Count > 0 Then

            'Create byte array of plaintext password
            Dim pw() As Byte = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text)

            'Declare the SHA256 hash algorithm object
            Dim hash As New Security.Cryptography.SHA256Managed()

            'Computes SHA256 hash of plaintext password byte array and stores in new byte array
            Dim hashBytes() As Byte = hash.ComputeHash(pw)

            'Converts the hashed password byte array into a string to store in database and compare with password checks
            Dim hashedPassword As String = System.Text.ASCIIEncoding.ASCII.GetString(hashBytes)

            'Attempt to delete user account by calling DeleteUser function in MySQLDB.vb module
            'A return value of zero indicates success, while a non-zero value indicates failure of the stored procedure
            Dim iRetVal As Integer = DeleteUser(MainDisplay.currentUser, hashedPassword)

            'Returns zero if the account was successfully deleted
            If iRetVal = 0 Then

                'Return dialog result of OK letting the calling function know the password was correct and the account was deleted
                Me.DialogResult = DialogResult.OK

                'Returns 2 if the passwords did not match so deletion was not performed
            ElseIf iRetVal = 2 Then

                'Inform user of invalid password
                Call MsgBox("The password you entered does not match the account password.", vbOKOnly, "Incorrect Password")

                'Clears the password textbox and reselects for the user's next password attempt
                txtPassword.Clear()
                txtPassword.Select()

                'The stored procedure did not complete successfully
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

    End Sub

End Class