# SNHU ePortfolio


## Capstone Code Review - Android Weight Tracking Application
  The following presentation is a code review of a mobile weight tracking application for the Android platform.  This review will prepare for the task of translating this code from a stand-alone Java application to a .NET desktop application client and separate MySQL server.
  
  
[![Capstone Code Review - Android Weight Tracking Application](https://img.youtube.com/vi/pcUr7N70PUY/hqdefault.jpg)](https://www.youtube.com/watch?v=pcUr7N70PUY)


## Software Design & Engineering


### Artifact Justification
&emsp; The artifact chosen for software engineering and design is a mobile weight loss tracking application written in Java for the Android platform.  It was originally developed for CS-390 Mobile Architecture and Programming course.  I am translating the code from Java to VB.NET to allow it to run on the Microsoft Windows operating system.  .NET code has the added advantage of being able to target platforms other than Microsoft Windows with few or no code changes.  I chose this artifact to demonstrate my ability to work with multiple platforms and multiple programming languages as well as being able to convert applications from one platform or language to another.   It requires careful analysis of the original code to determine if any improvements can be made to both design and security.  This artifact provides the potential for both types of improvements.


### Challenges and Reflections
&emsp; Because different operating environments are involved, there were trade-offs in the translation.  For example, the main data display of the Android app used a custom control that displayed each row of data with its own edit and delete buttons.  This was a good design choice for a small touchscreen app but an unnecessary complexity on a desktop application with mouse functionality.  I chose a simpler data grid view control in .NET to make working with and displaying data easier in the new application.



&emsp; I am familiar with Microsoft SQL Server and working with those databases in .NET applications but as an added challenge, I chose to use MariaDB as the database platform for this project instead.  MariaDB is a free and open-source fork of MySQL and has its own .NET objects for database interaction.  I had to take some time to go through the documentation and example code to familiarize myself with how to implement the .NET MySQL data objects.  I created a separate test application to experiment with the new objects until I felt comfortable implementing them in the project application. 



&emsp; I added a chart control on the very first iteration of the software with the intention of adding functionality in future iterations.  It turned out to be a fortunate decision because the latest .NET core does not support that chart control anymore.  Rather than try to recreate a chart object manually or use an untested third-party control, I recreated the project using an earlier version of .NET that still supports the chart objects.  If this had been discovered later, it would have involved significantly more work to migrate the project to a different version of .NET.  This also illustrates the importance of researching availability and compatibility of objects that will be used when developing .NET applications.


### Objectives Review
&emsp; I have added detailed comments throughout each of the forms and modules to explain exactly what is happening in the code and why various design choices were made.  This demonstrates the ability to articulate my ideas behind the code to other programmers.  They should be able to open the code and immediately follow what is happening and be able to make changes with confidence.  

The following is an example header from the User Login form giving an overview of the functionality and design choices.  Each statement of code is equally commented to be as informative as possible to the readers.

````vb

' File: UserLogin.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
' The UserLogin form is the initial form displayed when the application is first launched.  It takes the user's 
' username and password as input. They can then either attempt to login using the credentials or alternatively, 
' create a new account using the credentials.
'
' When the form loads, the MySQL server address is read from Settings.xml in the application directory and stored in
' a public variable to be used in the connection string.
'
' Password validation uses a regular expression to determine if it meets the composition requirements.  The original 
' application required the passwords to be 1 to 15 alphanumeric characters.  To meet modern password guidelines, 
' it must now be a minimum of 8 and maximum of 15 characters.  The password must contain at least one uppercase letter, 
' one lowercase letter, one digit, and one special character.  This provides added security to the user's data.
'
' The original password hash used was MD5.  This is no longer considered to be a secure hash so SHA256 is used in its place.
'
' As an enhancement, the password is never stored in a string variable but rather evaluated as the textbox contents.
'

````

&emsp; I have demonstrated the ability to program solutions to logic problems by implementing more complex regular expressions for data validation rather than using multiple logic conditions in a nested conditional structure.  This provides more robust input validation using fewer conditions and lines of code.

The following excerpt from the Settings form is quickly able to validate a server address with optional port number.  This is a very robust example of the ability to validate complex strings with just a few lines of code.

````vb

    'Server IP Address Pattern includes optional port after colon if the server requires the port to be specified
    Dim pattern As String = "\b(?:(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d\d?)(?::\d{0,4})?\b"

    'Declare regular expression object
    Dim rx As New Regex(pattern)

    'Store RegEx matches in MatchCollection
    Dim matches As MatchCollection = rx.Matches(strServerAddress.text)

    'If a match is found
    If matches.Count > 0 Then

        'Server address is valid
        IsValidServerAddress = True

    End If

````

&emsp; I have demonstrated innovative skills in form navigation design by taking advantage of various language features including the ShowDialog() method, style properties, and the loading and closing events of the forms to control form navigation and ensure the user is unable to circumvent the intended flow by clicking an unexpected button.

The following procedure demonstrates this technique in the FormClosing event of the SetTargetWeight form by disallowing them to close the form without first setting the appropriate data.

````vb

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

````


&emsp; I have demonstrated my ability to identify and address design flaws related to security by not storing plaint text passwords in any additional variables or passing them to any function in plaintext form.  The user input is evaluated directly from the textbox’s text property and hashed before being stored in memory and passed between functions.  The following excerpt from the User Login form demonstrates how this happens in the code.

````vb
  'Password RegEx Pattern 
  '(8 to 15 characters including at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character)
  Dim pattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,15}$"
  
  'Declare regular expression object
  Dim rx As New Regex(pattern)
  
  'Store RegEx matches in MatchCollection
  Dim matches As MatchCollection = rx.Matches(txtPassword.Text)
  
  'If a match is found then the password is valid
  If matches.Count > 0 Then
````
