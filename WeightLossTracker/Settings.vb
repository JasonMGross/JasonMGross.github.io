' File: Settings.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
'Settings form is a dialog form that allows the user to view and change the current server and option port number to connect to the database.
'Since the MySQL server has been moved to a seperate system, the possibility exists that the server address may need to be changed.
'
'Data validation is performed in the IsValidServerAddress function in DataValidation.vb module using regular expressions.
'The server address expects an IP address format with an optional colon and port number if required.
'
'The server address us kept in Settings.xml in the application directory in order to persist between runtimes and be able to be changed without modifying the binary.
'Utilizing an XML file for settings will also allow for additional future settings to be maintained without having to change the binary.
'

Imports System.Xml

Public Class Settings

    'Procedure executes when user clicks the Save Settings button
    Private Sub cmdSaveSettings_Click(sender As Object, e As EventArgs) Handles cmdSaveSettings.Click

        'Validate user input for server address using IsValidServerAddress function call in DataValidation.vb module
        If IsValidServerAddress(txtServerAddress) Then

            'Declare an XMLTextWriter object to use Settings.xml
            Dim writer As New XmlTextWriter("settings.xml", System.Text.Encoding.UTF8)

            'Configure XMLTextWriter object spacing
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2

            'Begin the Settings element
            writer.WriteStartElement("Settings")

            'Begin the ServerAddress element
            writer.WriteStartElement("ServerAddress")

            'Set element value to contents of txtServerAddress textbox
            writer.WriteString(txtServerAddress.Text)

            'Close ServerAddress element
            writer.WriteEndElement()

            'Close Settings element
            writer.WriteEndElement()

            'Close XML document
            writer.WriteEndDocument()
            writer.Close()

            'Update public server address variable with the new validated address
            MySQLServerAddress = txtServerAddress.Text

            'Close the settings form and return to the UserLogin form
            Me.Close()

        Else

            'Inform user of invalid server address
            Call MsgBox("The server IP address you entered is not valid.  Input must be in the format 0.0.0.0(:0000)", vbOKOnly, "Invalid Server IP Address")

            'Reselect the textbox to allow the user to modify their previous input
            txtServerAddress.Select()

        End If

    End Sub

    'Procedure executes when the user clicks the Cancel button
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        'Close Settings form without saving and return to UserLogin form
        Me.Close()

    End Sub

    'Procedure executes when the Setting form first loads
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Populate server address textbox with current server address for convenience
        txtServerAddress.Text = MySQLServerAddress

    End Sub

End Class