' File: EditWeightRecord.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
'When a record is selected in the DataGridView control, this EditWeightRecord form is loaded to allow the user to modify certain values.
'Record ID, entry date, and target weight values are locked and cannot be modified since they are the fields that either make the record unique or are static to the username.
'
'THe user can freely modify the remaining values and click Update Record button to commit the changes.  All of the input is validated with calls to DataValidation.vb module.
'If the data is all valid, a stored procedure to update the record is called.  The procedure will perform the update and then do a check to ensure the update was successful.
'Error message are displayed for any invalid input or database connectivity errors.
'
'If the updated weight meets or exceeds the current target weight of the user, a congratulatory message is displayed.
'
'The Cancel button can be clicked at any time to return to the MainDisplay form without any changes being made to the database.
'

Public Class EditWeightRecord

    'Procedure executes when user clicks the Cancel button
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        'Clear all text boxes to prepare for next weight to edit
        txtRecordID.Text = ""
        txtCurrentWeight.Text = ""
        txtExerciseMinutes.Text = ""
        txtDate.Text = ""
        txtCurrentTarget.Text = ""

        'Close Edit Weight Record form and return to the MainDisplay form without making any database changes
        Me.Close()

    End Sub

    'Procedure executes when user clicks the Update Record button
    Private Sub cmdUpdateRecord_Click(sender As Object, e As EventArgs) Handles cmdUpdateRecord.Click

        'First, the weight is validated with function call in DataValidation.vb module
        If IsValidWeight(txtCurrentWeight.Text) Then

            'Next the exercise minutes input is validated with function call in DataValidation.vb module
            If IsValidExerciseMinutes(txtExerciseMinutes.Text) Then

                'Since the date is stored in MySQL as YYYY-MM-DD, the format if the user input is converted to send to the stored procedure
                Dim DateToSend As String = Format(CDate(txtDate.Text), "yyyy-MM-dd")

                'Call the stored procedure to update the specified weight record with the given input as parameters.
                Dim iRetVal As Integer = UpdateWeightRecord(Int32.Parse(txtRecordID.Text), MainDisplay.currentUser, DateToSend, Single.Parse(txtCurrentWeight.Text), Single.Parse(txtExerciseMinutes.Text), Single.Parse(txtCurrentTarget.Text))

                'Returns zero if record was successfully added
                If iRetVal = 0 Then

                    'Once the new record is added, a check is made to see if target weight has been met or exceeded in new record
                    If Single.Parse(txtCurrentWeight.Text) <= GetTargetWeight(MainDisplay.currentUser) Then

                        'Display congratulatory message to user and remind them of the ability to change their target if they wish
                        Call MsgBox("Congratulations, you have reached your target weight!  You can set a new target weight from the main display if you would like work toward a new goal.", vbOKOnly, "Target Weight Achieved")

                    End If

                    'Before returning to the MainDisplay form, a call is made to the function that updates the DataGridView control (This in turn updates the chart control data)
                    'This ensures the record update changes are reflected immediately on the MainDisplay
                    Call MainDisplay.UpdateDataList()

                    'Clear all text boxes to prepare for next weight to edit
                    txtRecordID.Text = ""
                    txtCurrentWeight.Text = ""
                    txtExerciseMinutes.Text = ""
                    txtDate.Text = ""
                    txtCurrentTarget.Text = ""

                    'Close Edit Weight form and return to MainDisplay form
                    Me.Close()

                Else

                    'Inform the user that the stored procedure did not complete successfully
                    Call MsgBox("A MySQL database error occured trying to update record.", vbOKOnly, "MySQL Update Record Error")

                End If

            Else

                'Inform user of invalid exercise minutes input
                Call MsgBox("An invalid value has been entered for Exercise Minutes.  This must be a numeric value in the range of 0 to 1440.", vbOKOnly, "Invalid Exercise Minutes")

            End If
        Else

            'Inform user of invalid weight input
            Call MsgBox("An invalid value has been entered for Current Weight.  This must be a numeric value greater than 0 and less than or equal to 2000.", vbOKOnly, "Invalid Weight")

        End If

    End Sub

    'Procedure executes when EditWeightRecord form first loads
    Private Sub EditWeightRecord_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Select weight textbox for convenience so user can immediately begin entering data without selecting the textbox first
        txtCurrentWeight.Select()

    End Sub

End Class