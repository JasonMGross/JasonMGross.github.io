' File: AddNewWeight.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
'The AddNewWeight form allows the user to enter a new weight record into the weights table in the database.
'
'Each field entered by the user is validated with function calls to DataValidation.vb module.
'
'THe user can freely modify the remaining values and click Enter Weight button to commit the changes.  All of the input is validated with calls to DataValidation.vb module.
'If the data is all valid, a stored procedure to add the record is called.  The procedure will perform the insert and then do a check to ensure the insert was successful.
'Error message are displayed for any invalid input or database connectivity errors.
'
'If the new weight meets or exceeds the current target weight of the user, a congratulatory message is displayed.
'
'The Cancel button can be clicked at any time to return to the MainDisplay form without any changes being made to the database.
'

Public Class AddNewWeight

    'Procedure executes when user clicks the Enter Weight button
    Private Sub cmdEnterWeight_Click(sender As Object, e As EventArgs) Handles cmdEnterWeight.Click

        'First, the weight is validated with function call in DataValidation.vb module
        If IsValidWeight(txtCurrentWeight.Text) Then

            'Next the exercise minutes input is validated with function call in DataValidation.vb module
            If IsValidExerciseMinutes(txtExerciseMinutes.Text) Then

                'Finally, the date input is validated with function call in DataValidation.vb module
                If IsValidDate(txtDate.Text) Then

                    'Since the date is stored in MySQL as YYYY-MM-DD, the format if the user input is converted to send to the stored procedure
                    Dim DateToSend As String = Format(CDate(txtDate.Text), "yyyy-MM-dd")

                    'Prior to addig a new record, another stored procedure use called to make sure a record with the given date and username doesn't already exist in the weights table
                    'A return of zero indicates no records were returned so this new record is unique
                    If CheckDuplicateWeightRecord(MainDisplay.currentUser, DateToSend) = 0 Then

                        'Stored procedure is called with the user input as parameters to add the new weight record and verify that it has been added
                        Dim iRetVal As Integer = AddWeightRecord(MainDisplay.currentUser, DateToSend, Single.Parse(txtCurrentWeight.Text), Single.Parse(txtExerciseMinutes.Text), GetTargetWeight(MainDisplay.currentUser))

                        'Returns zero if record was successfully added
                        If iRetVal = 0 Then

                            'Check if target weight has been met or exceeded
                            If Single.Parse(txtCurrentWeight.Text) <= GetTargetWeight(MainDisplay.currentUser) Then

                                'Display congratulatory message to user and remind them of the ability to change their target if they wish
                                Call MsgBox("Congratulations, you have reached your target weight!  You can set a new target weight from the main display if you would like work toward a new goal.", vbOKOnly, "Target Weight Achieved")

                            End If

                            'Before returning to the MainDisplay form, a call is made to the function that updates the DataGridView control (This in turn updates the chart control data)
                            'This ensures the record update changes are reflected immediately on the MainDisplay
                            Call MainDisplay.UpdateDataList()

                            'Clear text boxes to prepare for next new weight record
                            txtCurrentWeight.Text = ""
                            txtExerciseMinutes.Text = ""
                            txtDate.Text = ""

                            'Close Add New Weight form
                            Me.Close()

                        Else

                            'Inform the user that the stored procedure did not complete successfully
                            Call MsgBox("A MySQL database error occured trying to add new record.", vbOKOnly, "MySQL Add Weight Record Error")

                        End If



                    Else

                        'Inform user that a record with the given date and username already exists in the weight table
                        Call MsgBox("A record already exists in the database for the current user and date.  This record can be edited or deleted from the main display.", vbOKOnly, "Duplicate Weight Record")

                    End If

                Else

                    'Inform user of invalid date format and indicate expected format
                    Call MsgBox("An invalid date has been entered.  Dates should be in the format MM/DD/YYYY.", vbOKOnly, "Invalid Date")

                End If

            Else

                'Inform user of invalid exercise minutes and indicate acceptable range
                Call MsgBox("An invalid value has been entered for Exercise Minutes.  This must be a numeric value in the range of 0 to 1440.", vbOKOnly, "Invalid Exercise Minutes")

            End If
        Else

            'Inform user of invalid weight and indicate the acceptable range
            Call MsgBox("An invalid value has been entered for Current Weight.  This must be a numeric value greater than 0 and less than or equal to 2000.", vbOKOnly, "Invalid Weight")

        End If

    End Sub

    'Procedure executes when user clicks the Cancel button
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        'Clear all input fields to prepare for next new record
        txtCurrentWeight.Text = ""
        txtExerciseMinutes.Text = ""
        txtDate.Text = ""

        'Close AddNewWeight form and return to MainDisplay form
        Me.Close()

    End Sub

    'Procedure executes when AddNewWeight form first loads
    Private Sub AddNewWeight_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Auto-populate current date for convenience
        txtDate.Text = Format(Now, "MM/dd/yyyy")

        'Select weight textbox so the user can begin entering input immediately without having to first select a textbox
        txtCurrentWeight.Select()

    End Sub

End Class