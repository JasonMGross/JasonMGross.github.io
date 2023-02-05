' File: SetTargetWeight.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
'When a user account is first created or after a user achieves their existing target weight, they have the option of opening this form to change their target weight.
'
'When this form first loads, a stored procedure is called to get the current user's target weight.  It is set automatically to zero when the account is created.
'The user may then input their desired target weight and click the SetTargetWeight button.
'
'The input is first validated to be greater than zero and less than or equal to 2000.  If the data is valid, another stored procedure is called to update
'the target weight in the user table.  If user tries to cancel or exit out of the form without setting a valid target weight, the form will continue to remain open forcing
'them to enter a valid target weight before continuing.
'

Public Class SetTargetWeight

    'Procedure executes when user clicks the Set Target Weight button
    Private Sub cmdSetTargetWeight_Click(sender As Object, e As EventArgs) Handles cmdSetTargetWeight.Click

        'If entered target weight is valid
        If IsValidWeight(txtTargetWeight.Text) Then

            'Call stored procedure in MySQLDB.vb module to update target weight in the user table
            Dim iRetVal As Integer = UpdateTargetWeight(MainDisplay.currentUser, Single.Parse(txtTargetWeight.Text))

            'Check to make sure the update was successful
            If iRetVal = 0 Then

                'Close Set Target Weight form
                Me.Close()

            Else

                'Inform user that the stored procedure failed to complete
                Call MsgBox("A MySQL database error occured trying to set the target weight.", vbOKOnly, "MySQL Set Target Weight Error")

            End If

        Else

            'Inform user of invalid target weight
            Call MsgBox("The target weight you entered is invalid.  It must be a numeric value between 0 and 2000.", vbOKOnly, "Invalid Target Weight")

        End If

    End Sub

    'Procedure executes when  user clicks the Cancel button
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        'Close Set Target Weight form returning to MainDisplay form
        Me.Close()

    End Sub

    'Procedure executes when the SetTargetWeight form first loads
    Private Sub SetTargetWeight_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Get current target weight of user to display when the form first loads
        Dim retVal As Single = GetTargetWeight(MainDisplay.currentUser)

        'Populate current target weight value in the input field for convenience
        txtTargetWeight.Text = retVal.ToString

        'Auto select the text so the user can begin entering data immediately without having to first select the textbox
        txtTargetWeight.Select()

    End Sub

    'Procedure executes when the SetTargetWeight form is closing
    'This ensures that the user can't circumvent the validation by means other than the command button
    Private Sub SetTargetWeight_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'Checks to see if the existing target weight is not valid
        If Not IsValidWeight(GetTargetWeight(MainDisplay.currentUser)) Then

            'Inform the user they must first enter a valid target weight
            Call MsgBox("A valid target weight has not yet been saved.  A valid numeric value between 0 and 2000 must be entered to continue.", vbOKOnly, "Invalid Target Weight")

            'Reselect textbox so they can immediately begin typing a revised weight
            txtTargetWeight.Select()

            'Stops the form from closing
            e.Cancel = True

        Else

            'If a valid target weight is set then clear input textbox to prepare for the next operation
            txtTargetWeight.Text = ""

        End If

    End Sub

End Class