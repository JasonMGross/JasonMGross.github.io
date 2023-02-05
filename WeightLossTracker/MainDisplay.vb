' File: MainDisplay.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
'MainDisplay form is the primary form displayed to the user displaying all of their current weight and exercise minute data
'along with a line chart graphing the two data points over time.

'A DataGridView control is used to display the raw data.  Code was added to select an entire row if any cell within the row is clicked.  This is
'for the convenience of the user since the row must be selected in order to edit or delete a record.

'A chart object displays the daily weights, exercise minutes, and target weights for the current user.  In the interest of flexibility and allowing the user
'to tell their own story, each data series in the chart has a corresponding checkbox below the chart.  The series is displayed only if the user checks
'the checkbox for that data.  This way, they can mix and match what they want to display at any given time.

'The form keeps track of the currently logged in username in a public string variable that can be passed and referenced by the other sub-forms

'Six control buttons in the lower right allow the user to perform the different operations available to them.

'Whenever a data change occurs, functions are called to immediately update the DataGridView and the data chart with the freshest data set.
'The DataTable object is used because it is the most efficient way display the data in both the DataGridView and chart.  The DataGridView control merely needs
'to have the data table assigned as its DataSource and rows can be quickly iterated with the DataRow object to fill the points of the chart data series.
'

Public Class MainDisplay

    'Public variable to track current user
    Public currentUser As String

    'Procedure executes when user clicks the Add New Weight button
    Private Sub cmdAddNewWeight_Click(sender As Object, e As EventArgs) Handles cmdAddNewWeight.Click

        'Display AddNewWeight form
        'ShowDialog method is used so nothing else can happen on the main form until the AddNewWeight form is closed.
        AddNewWeight.ShowDialog()

    End Sub

    'Procedure executes when user clicks the Set Target Weight button
    Private Sub cmdSetTargetWeight_Click(sender As Object, e As EventArgs) Handles cmdSetTargetWeight.Click

        'Display SetTargetWeight form
        'ShowDialog method is used so nothing else can happen on the main form until the SetTargetWeight form is closed.
        SetTargetWeight.ShowDialog()

    End Sub

    'Procedure executes when user clicks the Delete Account button
    Private Sub cmdDeleteAccount_Click(sender As Object, e As EventArgs) Handles cmdDeleteAccount.Click

        'Display UserDelete form with ShowDialog method so UserDelete must be closed before continuing
        'A dialog result of OK indicates success, otherwise it returns cancel and the procedure exits without closing
        If UserDelete.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'Close MainDisplay form and return to UserLogin form
            Me.Close()

        End If

    End Sub

    'Procedure executes when user clicks the Logout button
    Private Sub cmdLogout_Click(sender As Object, e As EventArgs) Handles cmdLogout.Click

        'Close MainDisplay form and return to UserLogin form
        Me.Close()

    End Sub

    'Procedure performs some last-minute clean-up in preparation for the next user
    Private Sub MainDisplay_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'Clear current user for safety
        currentUser = ""

        'Reset form title text to remove currently logged in user
        Me.Text = "Weight Loss Tracker"

        'Display the UserLogin form after MainDisplay form closes
        UserLogin.Show()

        'Automatically select username textbox of the UserLogin form for convenience
        UserLogin.txtUsername.Select()

    End Sub

    'Procedure executes when user clicks the Edit Record button
    Private Sub cmdEditRecord_Click(sender As Object, e As EventArgs) Handles cmdEditRecord.Click

        'Get record ID of currently selected row
        Dim selectedRecordID As Integer = GetSelectedRecordID()

        'If a record is currently selected
        If selectedRecordID > -1 Then

            'Pull selected record from database calling GetWeightRecord from MySQLDB.vb module
            'The results are stored in a DataTable object
            Dim dtData As DataTable = GetWeightRecord(selectedRecordID)

            'Check row count to ensure at least one record was returned
            If dtData.Rows.Count > 0 Then

                'Populate Edit Record form textboxes with current values from DataTable row
                EditWeightRecord.txtRecordID.Text = selectedRecordID
                EditWeightRecord.txtDate.Text = Format(dtData.Rows(0).Item(2), "MM/dd/yyyy")
                EditWeightRecord.txtCurrentWeight.Text = dtData.Rows(0).Item(3)
                EditWeightRecord.txtExerciseMinutes.Text = dtData.Rows(0).Item(4)
                EditWeightRecord.txtCurrentTarget.Text = dtData.Rows(0).Item(5)

                'Display EditWeightRecord form
                'ShowDialog method is used so nothing else can happen on the main form until the EditWeightRecord form is closed.
                EditWeightRecord.ShowDialog()

            End If

        Else

            '-1 was returned so inform user there is no record selected
            Call MsgBox("No record is currently selected.", vbOKOnly, "No Record Selected")

        End If

    End Sub

    'Helper function that determines if a record is currently selected in the datagridview control
    'Returns record ID of currently selected record if one exists, or returns -1 indicating no selected record
    Private Function GetSelectedRecordID() As Integer

        'Initialize return value of no record selected
        GetSelectedRecordID = -1

        'If a row is currently selected, SelectedRows.Count will be greater than zero
        If dgvWeightData.SelectedRows.Count > 0 Then

            'Iterate each row of the DataGridView control looking for selected row
            For Each row As DataGridViewRow In dgvWeightData.Rows

                'If the current row is selected
                If row.Selected = True Then

                    'Return record ID from current row
                    GetSelectedRecordID = row.Cells(0).Value

                    'Stop searching
                    Exit For

                End If

            Next

        End If

    End Function

    'Procedure executes when user clicks the Delete Weight Record button
    Private Sub cmdDeleteWeightRecord_Click(sender As Object, e As EventArgs) Handles cmdDeleteWeightRecord.Click

        'Use helper function to get record ID of currently selected row in DataGridView control
        Dim selectedRecordID As Integer = GetSelectedRecordID()

        'If a value greater than one was returned, a record is currently selected
        If selectedRecordID > -1 Then

            'Pull selected record from database calling GetWeightRecord from MySQLDB.vb module
            'The results are stored in a DataTable object
            Dim dtData As DataTable = GetWeightRecord(selectedRecordID)

            'Check if there is at least one row of data
            If dtData.Rows.Count > 0 Then

                'Verify intention to permanently delete record
                If MsgBox("Are you sure you want to permanently delete the selected record?  This cannot be undone.", vbYesNo, "Confirm Record Delete") = vbYes Then

                    'Execute DeleteWeightRecord function in MySQLDB.vb module
                    Dim iRetVal As Integer = DeleteWeightRecord(selectedRecordID)

                    'If the function executed successfully
                    If iRetVal = 0 Then

                        'Execute function to refresh the DataGridView control contents with updated data for the current user
                        UpdateDataList()

                    Else

                        'Inform user that record deletion failed
                        MsgBox("A MySQL database error occured trying to delete the weight record.", vbYesNo, "MySQL Delete Weight Record Error")

                    End If

                End If

            End If

        Else

            'Inform user no record selected
            Call MsgBox("No record is currently selected.", vbOKOnly, "No Record Selected")

        End If

    End Sub

    'Procedure executes when the MainDisplay form is first loaded
    Private Sub MainDisplay_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Execute function to refresh the DataGridView control contents with updated data for the current user
        Call UpdateDataList()

    End Sub

    'Procedure is called from other procedures when the data displays need to be updated such as after records are added, modified, or deleted.
    'This procedure updates the data in the data table and then passes the data table to the helper procedure that updates the data series points in the chart
    Public Sub UpdateDataList()

        'Get records for current user
        Dim dtData As DataTable = GetWeightData(currentUser)

        'Set data grid view data source to data table
        dgvWeightData.DataSource = dtData

        'If the record ID column is visible
        If dgvWeightData.Columns(0).Visible Then

            'Hide record ID column
            dgvWeightData.Columns(0).Visible = False

        End If

        'Update chart with the new data
        Call UpdateDataChart(dtData)

    End Sub

    'Helper procedure to refresh the weight and exercise minute data series points with latest data for current user
    Public Sub UpdateDataChart(dtUserData As DataTable)

        ' Clear existing weights and exercise minutes series points
        chtDataGraphic.Series(0).Points.Clear()
        chtDataGraphic.Series(1).Points.Clear()
        chtDataGraphic.Series(2).Points.Clear()

        'Iterate through each row of current user data stored in DataTable object passed to procedure
        For Each row As DataRow In dtUserData.Rows

            'Add weights and exercise minutes points to chart using expected date format
            'The date is stored in the database as yyyy-MM-dd.
            chtDataGraphic.Series(0).Points.AddXY(Format(row.Item(1), "MM/dd/yyyy"), Format(row.Item(2), "0.00"))
            chtDataGraphic.Series(1).Points.AddXY(Format(row.Item(1), "MM/dd/yyyy"), row.Item(3))
            chtDataGraphic.Series(2).Points.AddXY(Format(row.Item(1), "MM/dd/yyyy"), row.Item(4))

        Next

    End Sub

    'Procedure executes when user clicks any cell in the DataGridView control
    'Quality-of-life feature so the user does not have to click the left-most column to select an entire row
    Private Sub dgvWeightData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWeightData.CellClick

        'If non data row cell is clicked
        If e.RowIndex >= 0 Then

            'If the row of data is not already selected
            If dgvWeightData.Rows(e.RowIndex).Selected = False Then

                'Select entire row to which the clicked cell belongs
                dgvWeightData.Rows(e.RowIndex).Selected = True

            End If

        End If

    End Sub

    'Procedure executes when user double-clicks a cell in the datagridview control to automatically open the EditWeightRecord form
    'Quality-of-life feature to perform a record selection and edit command in a single physical click operation
    Private Sub dgvWeightData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWeightData.CellDoubleClick

        'If non data row cell is clicked
        If e.RowIndex >= 0 Then

            'Select entire row to which the clicked cell belongs
            dgvWeightData.Rows(e.RowIndex).Selected = True

            'Raise a click event for the Edit Weight Record button
            cmdEditRecord_Click(cmdEditRecord, EventArgs.Empty)

        End If

    End Sub

    'Procedure executes when user right-clicks on a row of data in the datagridview control
    'Quality-of-Life feature to perfom a record select and delete command in a single physical click operation
    Private Sub dgvWeightData_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvWeightData.CellMouseDown

        'If the right mouse button is clicked
        If e.Button = MouseButtons.Right Then

            'This ensures the code only reacts when a data row is clicked
            If e.RowIndex >= 0 Then

                'Select entire row to which the clicked cell belongs
                dgvWeightData.Rows(e.RowIndex).Selected = True

                'Raise a click event for the Edit Weight Record button
                cmdDeleteWeightRecord_Click(cmdDeleteWeightRecord, EventArgs.Empty)

            End If

        End If

    End Sub

    'Procedure executes when the user clicks the chkDisplayWeights checkbox
    Private Sub chkDisplayWeights_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisplayWeights.CheckedChanged

        'The weights data series will be displayed if the checkbox is checked, otherwise it will be hidden
        chtDataGraphic.Series(0).Enabled = chkDisplayWeights.Checked

    End Sub

    'Procedure executes when the user clicks the chkDisplayExerciseMins checkbox
    Private Sub chkDisplayExerciseMins_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisplayExerciseMins.CheckedChanged

        'The exercise minutes data series will be displayed if the checkbox is checked, otherwise it will be hidden
        chtDataGraphic.Series(1).Enabled = chkDisplayExerciseMins.Checked

    End Sub

    'Procedure executes when the user clicks the chkDisplayTargetWeights checkbox
    Private Sub chkDisplayTargetWeights_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisplayTargetWeights.CheckedChanged

        'The target weights data series will be displayed if the checkbox is checked, otherwise it will be hidden
        chtDataGraphic.Series(2).Enabled = chkDisplayTargetWeights.Checked

    End Sub

End Class