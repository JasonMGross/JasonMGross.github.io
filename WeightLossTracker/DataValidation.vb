' File: DataValidation.vb
' Author: Jason Gross
' Date: January 30, 2023
' Class: CS-499 Software Engineering Capstone
' 
' Comments:
'
' This shared module contains public functions to validate all user input.  Each is defined once here and used throughout all of the other
' forms and modules promoting code reusability and eliminating repetitive code.
'
' Username, Date, and Server Address validation take advantage of regular expressions to eliminate the need to perform multiple checks against the same input.  If a match
' is found using the regular expression, then the input is guarenteed to meet all validation criteria.
'
' The weight and exercise minutes are validating by attempting to parse them to a single using the Single.TryParse method.  The method returns a boolean value.  If the parse was successful then a valid decimal
' number was entered and the valid range can be checked.  If the parse was unsuccessful or the range was exceeded, then the input is invalid.
'
' Note that password validation is not in this module.  It occurs once when the password is entered on the UserLogin form eliminating the need to store the plaintext string in memory and pass it to another function
'

Imports System.Text.RegularExpressions

Module DataValidation

    'Returns True if string is a valid username (1 to 15 alphanumeric characters)
    Public Function IsValidUsername(strUsername As String) As Boolean

        'Initialize return value to failure for safety
        IsValidUsername = False

        'Username RegEx Pattern (1 to 15 alphanumeric characters)
        Dim pattern As String = "^[\w]{1,15}$"

        'Declare regular expression object
        Dim rx As New Regex(pattern)

        'Store RegEx matches in MatchCollection
        Dim matches As MatchCollection = rx.Matches(strUsername)

        'If a match is found
        If matches.Count > 0 Then

            'Username is valid
            IsValidUsername = True

        End If

    End Function

    'Returns True if string is a valid date
    Public Function IsValidDate(strDate As String) As Boolean

        'Initialize return value to failure for safety
        IsValidDate = False

        'Date Pattern (Date format of MM/DD/YYYY)
        Dim pattern As String = "^(0[1-9]|1[012])[/](0[1-9]|[12][0-9]|3[01])[/](19|20)\d\d$"

        'Declare regular expression object
        Dim rx As New Regex(pattern)

        'Store RegEx matches in MatchCollection
        Dim matches As MatchCollection = rx.Matches(strDate)

        'If a match is found
        If matches.Count > 0 Then

            'Username is valid
            IsValidDate = True

        End If

    End Function

    'Returns True if string is a valid weight (Decimal number between 0 and 2000)
    Public Function IsValidWeight(strWeight As String) As Boolean

        'Initialize return value to failure for safety
        IsValidWeight = False

        'Declare variable to hold parsed weight
        Dim weight As Single

        'If string can be successfully parsed to a single
        If Single.TryParse(strWeight, weight) Then

            'If weight falls above 0 up to and including 2000 (Weight can represent whatever measure the user wishes since it is just a number)
            If weight > 0 And weight <= 2000 Then

                'Weight is valid
                IsValidWeight = True

            End If

        End If

    End Function

    'Returns True if string is a valid number of exercise minutes (Decimal number between 0 and 1440)
    Public Function IsValidExerciseMinutes(strExerciseMinutes As String) As Boolean

        'Initialize return value to failure for safety
        IsValidExerciseMinutes = False

        'Declare variable to hold parsed exercise minutes
        Dim exerciseMinutes As Single

        'If string can be successfully parsed to a single
        If Single.TryParse(strExerciseMinutes, exerciseMinutes) Then

            'If exercise minutes fall between and including 0 and 1440 minutes (maximum minutes in one day)
            If exerciseMinutes >= 0 And exerciseMinutes <= 1440 Then

                'Exercise Minutes value is valid
                IsValidExerciseMinutes = True

            End If

        End If

    End Function

    'Returns True if string is a valid server IP address
    Public Function IsValidServerAddress(strServerAddress) As Boolean

        'Initialize return value to failure for safety
        IsValidServerAddress = False

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

    End Function

End Module
