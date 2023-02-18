# Jason Gross - SNHU CS-499 ePortfolio



## Introduction

&emsp; My name is Jason Gross.  I am a senior engineer for a local automotive manufacture where I have worked for the last 21 years developing software and experimenting with integrating new technologies.  I am a life-long programmer and have spent the last six years studying at SNHU as a part-time student to obtain my Bachelor’s degree in Software Engineering in order advance in my career.   This capstone project is the culmination of those years of study with the goal of showcasing the various skills I have obtained during that time.


## Self-Assessment


### Team Collaboration

&emsp; Software engineering is not always a one-person job.  Solutions are often developed by a team of engineers and stakeholders who must work cooperatively on the same code base.  To keep things organized and secure, I studied and learned to use Git.  Git is a popular distributed version control software package designed to allow teams to manage the evolution of their code.  CS-320 Software Testing & Automation taught me the process of creating code repositories wherein students were able to edit our specific parts of the same code file without interfering with each other’s work.  We used it to perform reviews of each other’s code giving feedback and making recommendations for later review.  This e-Portfolio is published on GitHub for others to view or modify the work that I’ve done.  This tool has proven invaluable with team collaboration and my skills continue to improve the more I use it.

The following two links are to my Git and BitBucket repositories where all my projects I developed for SNHU are published.

[GitHub Repositories](https://github.com/JasonMGross?tab=repositories)

[BitBucket Repositories](https://bitbucket.org/DeepLogicArchitect/)


### Communicating To Stakeholders

&emsp; During CS-250 Software Development Life Cycle, I studied all the different roles that comprise a software engineering team including the product owner, developer, and tester utilizing the modern agile project methodology.  Coming from a background of exclusive waterfall methodologies, it was somewhat of a culture shock for me but still crucial to understand one’s role on the team in order to make the most positive contributions.  A primary takeaway from that class was the constant lines of communication that run between the different stakeholders.  I have experimented with that agile methodology with my employer and found the daily meetings, while inconvenient, revealed and resolved issues earlier and more often than with the previous waterfall methods we typically employed.  I prefer to engage stakeholders frequently so for this project, I called upon friends to act as users to provide feedback and perform testing.  This strengthened the application by addressing details that I would not have thought of on my own.


### Software Engineering & Design

&emsp; Software engineering is a process.  I wanted to approach this project using the software development life cycle discussed during the various software courses.  This project began with an idea to improve upon an existing Android software project I completed in a prior course.  The plan was to bring it to a wider audience by recreating it for the Windows operating system.   I chose a language with which I am most comfortable due to the time constraints of recreating an entire client/server application.  The code review video shows my thought processes for the final design using the original application as my roadmap.  I broke the workflow down into screens from the old application and translated and tested each one in isolation.  The testing phase was a combination of my own testing as well as some other people to ensure I didn’t overlook any critical details.  This was an iterative process throughout each category and the final application is published to GitHub to settle into its maintenance period where updates can be made by me and others.  


### Algorithms & Data Structures

&emsp; When programming, there is usually more than one way to complete a task and the goal for me is to find the simplest and most elegant solution.  I showcase this in each of the three categories of this project particularly with form flow, navigation, and data validation.  These characteristics are especially demonstrated in the database where both security and validation are integrated into each stored procedure.   Ultimately, my goal is to develop an evolving set of algorithms that I can confidently use in future projects while still being receptive to ways of improving them.

&emsp; Another best practice that I demonstrate throughout this project is refraining from trying to reinvent the wheel.  This application’s primary function is data storage and retrieval and the design choices for handling data need to be as efficient as possible.  While it is always an option to attempt to develop new data structures and objects, I prefer to use built-in objects wherever possible.  .NET offers a rich library of data structures to use for SQL development that have been tried and tested and will provide stable functionality with the fewest lines of code.


### Databases

&emsp; DAT-220 Introduction to SQL and CS-340 Advanced Programming Concepts taught basic and advanced database development with MySQL and MongoDB.  Over the last 20 years of my professional career, I have worked extensively with SQL Server databases so as an added challenge, I chose to use a fork of MySQL called MariaDB to build upon what I learned in the courses and my own experiences with SQL Server to convert the standalone application from a single user to a multi-user platform.  Over the years, I’ve come to realize that many businesses live and die by their data.  The systems that store that data require careful planning and management to maximize accessibility and security.  There are professionals that focus their proficiencies on either the front-end or back-end of application development, but I wanted instead to demonstrate skills with both sides.  Full-stack developers reduce costs by providing a single resource to handle both sides of the development.


### Security

&emsp; In 2022, the average cost of a data breach was a record 4.4 million dollars (Fowler, 2022).  This far exceeds the cost of designing security into software from the initial planning to the maintenance of the final release.  CS-405 Secure Coding course detailed the philosophy of Defense in Depth which is a unique layering of different security measures designed to adequately protect a given asset in each set of unique circumstances.  During that course, I designed a security policy and presentation video for a fictional business called Green Pace.  Many of those standards, principles, and best practices have been applied to this project with one or more enhancements made for each of the three categories.

[Secure Coding Policy](https://github.com/JasonMGross/Secure_Coding/blob/main/CS%20405%20Security%20Policy.docx)

[Policy Presentation Video](https://youtu.be/jih5KCgDP0Y)


Reference <br>
Fowler, B. (2022, July 27). Average data breach costs hit a record $4.4 million, report says. CNET. Retrieved October 9, 2022, from https://www.cnet.com/tech/services-and-software/average-data-breach-costs-hit-a-record-4-4-million-report-says/


## Code Review - Android Weight Tracking Application
&emsp; The following presentation is a code review of a [mobile weight tracking application](https://github.com/JasonMGross/mobile-weight-tracking-app) for the Android platform.  This review will prepare for the task of translating this code from a stand-alone Java application to a .NET desktop application client and separate MySQL server.
  
  
[![Capstone Code Review - Android Weight Tracking Application](https://img.youtube.com/vi/pcUr7N70PUY/hqdefault.jpg)](https://www.youtube.com/watch?v=pcUr7N70PUY)


## Software Design & Engineering


### Artifact Justification
&emsp; The artifact chosen for software engineering and design is a mobile weight loss tracking application written in Java for the Android platform.  It was originally developed for CS-390 Mobile Architecture and Programming course.  I am translating the code from Java to VB.NET to allow it to run on the Microsoft Windows operating system.  .NET code has the added advantage of being able to target platforms other than Microsoft Windows with few or no code changes.  I chose this artifact to demonstrate my ability to work with multiple platforms and multiple programming languages as well as being able to convert applications from one platform or language to another.   It requires careful analysis of the original code to determine if any improvements can be made to both design and security.  This artifact provides the potential for both types of improvements.


### Overview
&emsp; The following are side-by-side screenshots of the four primary screens from both original Android Java application on the left and the newly translated VB.NET Windows desktop application on the right.  Each of the four primary screens was first designed to resemble the original application’s layout and object placement.  Then the original code behind each screen was translated into the VB.NET language for each new form.  All data validation code and MySQL functions were placed in their own respective modules and can be used in other projects with minor changes promoting code modularity and reusability.


|Original Application| New Application|
|:---:|:---:|
|![Original Login Screen](/images/OriginalUserLogin.jpg "Original Login Screen")<br>User Login Screen|![New Login Screen](/images/UserLogin.jpg "New Login Screen")|
|![Original Target Weight Screen](/images/OriginalSetTargetWeight.jpg "Original Target Weight Screen")<br>Set Target Weight Screen|![New Target Weight Screen](/images/SetTargetWeight.jpg "New Target Weight Screen")|
|![Original Enter Weight Screen](/images/OriginalEnterWeight.jpg "Original Enter Weight Screen")<br>Enter Weight Screen|![New Enter Weight Screen](/images/AddWeightRecord.jpg "New Enter Weight Screen")|
|![Original Main Display Screen](/images/OriginalMainDisplay.jpg "Original Main Display Screen")<br>Main Display Screen|![New Main Display Screen](/images/MainDisplay.jpg "New Main Display Screen")|


### Challenges and Reflections
&emsp; Because different operating environments are involved, there were trade-offs in the translation.  For example, the main data display of the Android app used a custom control that displayed each row of data with its own edit and delete buttons.  This was a good design choice for a small touchscreen app but an unnecessary complexity on a desktop application with mouse functionality.  I chose a simpler DataGridView control in .NET to make working with and displaying data easier in the new application.



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

The following excerpt is from the Settings form.  The code validates a server address with optional port number entered by the user. This example demonstrates the flexibility of validating complex strings with optional parameters using just a few lines of code.


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


&emsp; I have demonstrated my ability to identify and address design flaws related to security by not storing plaint text passwords in any additional variables or passing them to any function in plaintext form.  In the following example, the user input is evaluated directly from the textbox’s text property and hashed before being stored in memory and passed between functions.

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


## Algorithms & Data Structure 

### Artifact Justification

&emsp; The artifact for algorithms and data structures will be a continuation of the weight tracking android application that has been translated to VB.NET.  Now that all of the original functionality is implemented, I will be implementing several value-added enhancements to both functionality and security.  The data tracked by the original application will be expanded to include an additional metric of exercise minutes that the user can track along with their weight.  A data chart will be added demonstrating the ability to manipulate data structures and translate them to visual representations for the user.  Additionally, several security enhancements will bring the application in line with modern standards when dealing with passwords and user privacy.


### Challenges and Reflections

&emsp; The data chart was one of the primary enhancements planned for the algorithms and data structure category.  I wanted both the chart and the DataGridView control to share the same data structure to ensure consistency and eliminate the possibility of having one control display data that the other does not.  I chose to use the DataTable object because it is a very powerful data structure that can be automatically populated with data returned from the database taking on the necessary structure without having to first be defined.  Stored procedures will return all the records for the given user and store the data directly in a DataTable object.  That object can be immediately set as the data source for the DataGridView control with another single line of code.  The DataGridView control can go on to use its internal functionality to allow the user to select records or order the data to their liking but will not affect the DataTable object or the series points in the chart display.


&emsp; The original application had record editing and delete capabilities on each row of data with a single button tap.  By default, each cell in the DataGridView control is clickable.  To select an entire row, the user must click the left-most gutter cell.  However, this would not be immediately apparent to the user.  To compensate, I added additional code in the click event so whenever any cell is clicked, the entire row is automatically selected.  This modification still requires the edit and delete operations to be a two-step process of first selecting a row and then clicking a button.  I added additional code in the mouse event procedures so if a user double-left-clicks on any data row, it immediately opens the editing form with the selected record.  Additionally, a right click of any field initiates the delete operation asking for permission to delete the selected record.  These additions provide single-step functionality to match the original application.


<p align="center">
  <img src="/images/DoubleClickEdit.jpg">
</p>


&emsp; Finally, a new button was added to allow the user to delete their account and all the associated weight records.  This provides peace of mind that the user’s data can be fully controlled by them and completely removed from the system if they wish.  A stored procedure performs the operation, but I quickly realized a security risk existed where the procedure only took the username as a parameter and did not perform any other user authentication.  I closed this gap by requiring the user to re-enter their password before calling the stored procedure and the hashed password is passed and authenticated before carrying out the operation.  This way, if someone had discovered the credentials to execute the stored procedure without the application, they would still not be able to delete an account without first discovering the user’s password.


<p align="center">
  <img src="/images/DeleteAccount.jpg">
</p>


### Objectives Review


&emsp; As more data points are entered during testing, the chart started to become cluttered.  I demonstrated my ability to use innovative skills by implementing a series of checkboxes to allow the user to turn each data series in the chart on or off on demand.  This not only alleviates the clutter when desired but also allows the user to quickly show or hide information giving them the flexibility to specify how their data is displayed.


<p align="center">
  <img src="/images/TrendChart.jpg">
</p>


&emsp; The use of DataTable objects to hold data from the database and share them between the different forms and controls demonstrates the ability to code solutions to a logic problem involving data structures.  The database calls happen only when necessary and few if any coding changes would need to be performed if the source data changed or expanded.  For instance, a new field was added to the weight table to track exercise minutes but the code to pull the data and display it in the DataGridView remained the same.  The DataTable object adapted to the change based on the new data and a new field was also displayed in the DataGridView control with no additional code changes.  The following shows how just two lines of code are needed to import data into the data table object and assign it to the data grid control.  This code will work even if fields are added or removed from the database.


````vb
'Get records for current user
Dim dtData As DataTable = GetWeightData(currentUser)

'Set data grid view data source to data table
dgvWeightData.DataSource = dtData
````


&emsp; I have demonstrated my ability to identify and address design flaws related to security by replacing the MD5 password hashing algorithm in favor of the more secure SHA256 algorithm making password hashes more difficult to compromise if discovered.  Additionally, I strengthened user security by increasing the minimum length and composition requirements of their passwords to align them with modern best practices.


## Databases


### Artifact Justification


&emsp; The original mobile weight tracking application utilized a local MySQL Lite installation.  The database components of the primary artifact will be a recipe for a complete back-end solution to support the weight tracking application.  The result will be a SQL script that creates the database, user account, data tables, and all stored procedures used by the front-end application.  With this modification, the back-end no longer needs to exist on the same PC as the front-end application.  Rather, it will exist on a separate secured server and be shared by multiple client applications.  This facilitates greater security since the data and queries are not stored in the client binary.  It also provides better performance of the client machines since the data processing is performed on the server.  This enhancement will demonstrate many applications of advanced MySQL concepts to expand the software with geographically multi-user capabilities.


### Challenges and Reflections

&emsp; The first challenge in this phase of the project was establishing a MySQL database server on a separate PC.  A complete server installation is beyond the scope of this project but as a brief overview, I used a computer running Arch Linux and installed MariaDB, a modern MySQL fork, using a series of pre-built scripts to get a secure working database server up and running in just a few minutes.


&emsp; I created a user account called WeightAppUser that will be used exclusively by the application.  The account is only granted permission to execute stored procedures contained in the database.  This way, if the account credentials were reverse engineered from the binary, they could not be used to access the tables directly or execute commands that could reveal additional exploitative information about the database.  This strategy follows the security best practice of least privilege which is granting users only enough access to successfully perform their specific tasks.


````sql
DROP USER IF EXISTS 'WeightAppUser'@'%';
CREATE USER 'WeightAppUser'@'%' IDENTIFIED BY 'W3!gh75&M3a5ur35';
GRANT EXECUTE ON WeightDB.* TO 'WeightAppUser'@'%';
````

&emsp; When creating the new data tables, I chose to consolidate the user’s target weight into the users table rather than in a third table.  This reduces complexity and eliminates unnecessary data repetition.  This only required adding a new field to the user table and the original target weight table could be eliminated.  There was a second design challenge involving data types for the fields in the data tables.  The original application exclusively used strings for all fields.  This was likely a design choice to make the application easier to program.    I chose instead to use appropriate numeric data types for each floating point numeric field and implement proper parsing and error handling in the application code.  Storing numerical data properly will eliminate confusion with future troubleshooting and development.


````sql
-- The users table contains the user ID's, hashed passwords, and current target weights
-- for each registered user of the application.

CREATE TABLE IF NOT EXISTS users (
    _id INT PRIMARY KEY AUTO_INCREMENT,
    username TEXT NOT NULL,
    password TEXT NOT NULL,
    targetWeight FLOAT NOT NULL
);

-- The weights table contains each of the individual weight records entered by
-- the users through the application over time.  The username field is shared between
-- the two tables to quickly access each user's current target weight.

CREATE TABLE IF NOT EXISTS weights (
    _id INT PRIMARY KEY AUTO_INCREMENT,
    username TEXT NOT NULL,
    entryDate DATE NOT NULL,
    weight FLOAT NOT NULL,
    exerciseMinutes FLOAT NOT NULL,
    currentTarget FLOAT NOT NULL
);
````

&emsp; The biggest challenge wass implementing the different functions of the application using server-side stored procedures.  I designed them to be intrinsically secure by using prepared statements.  This prevents maliciously crafted parameters from causing unintended SQL code to   execute.  This behavior is known as SQL-Injection attacks and prepared statements ensure the parameters are treated accordingly and not treated as text to be arbitrarily appended to a SQL statement.  Additionally, I designed each procedure to first perform the intended operation and a second set of instructions to validate that the operation completed successfully.  A return value indicates success or failure to the calling application.  In the event of failure on some procedures, the value also indicates which part of the procedure failed to give the user more meaningful error messages and allow the application to react accordingly.


````sql
-- Build prepared statment to insert new user record
	PREPARE stmt1 FROM 'INSERT INTO users (username, password, targetWeight) VALUES (?, ?, 0);';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user, @pass;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- Build prepared statement to verify new user record in users table
	PREPARE stmt2 FROM 'SELECT COUNT(*) INTO @numRecs FROM users WHERE username = ? AND password = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt2 USING @user, @pass;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt2;
  ````
  
  
### Objectives Review


&emsp; The final SQL script can be run on any MySQL database server to create the components necessary to support the application.  Migrating the server to other hardware would be a trivial matter of running this script on the destination server and copying over the data tables from the previous server.  This demonstrates my ability to use innovative skills and techniques to implement a complete database solution for the .NET weight tracking application.


&emsp; The library of secured stored procedures was designed to provide all of the database functionality for the .NET weight tracking application and does so completely independent of the client software.  This makes the client extremely light on resource utilization as the database handles the bulk of the processing.  This solution demonstrates my ability to solve problems in storing/accessing/modifying data in a client/server model.


&emsp; I addressed two potential design flaws related to security.  The first was the user account used by the application.  By restricting access to only execute select stored procedures, the compromised credentials could do far less damage than an account with access to the data tables and permissions to view the stored procedure code.  Additionally, using prepared statements in the stored procedures makes them intrinsically secure and less susceptible to SQL Injection attacks.

&emsp; The database script is logically segmented and fully commented detailing the functionality of each SQL statement and the reasoning behind them.  This demonstrates my ability to clearly articulate my ideas to other developers that will need to evaluate or modify the code in the future.  The following excerpt is a full stored procedure for updating the user’s target weight.  It is presented in its entirety to demonstrate the concise commenting and structure throughout.


````sql
-- The UpdateTargetWeight stored procedure takes a user ID and target weight value as parameters and attempts to update the target weight
-- of the given user in the users table with an update query.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- After the user record update is attempted, a follow-up validation select statement is run to ensure the record was correctly updated.
-- This procedure will return 0 if the target weight was updated and verified, otherwise it returns 1.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS UpdateTargetWeight;

CREATE PROCEDURE UpdateTargetWeight(
	IN strUser TEXT,
	IN fTargetWeight FLOAT
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;	
	DECLARE targetWeight FLOAT;
	DECLARE numRecs INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @user = strUser;	
	SET @targetWeight = fTargetWeight;
	SET @numRecs = 0;
	SET @iRetVal = 1;
	
	-- Build prepared statment to update target weight in users table
	PREPARE stmt1 FROM 'UPDATE users SET targetWeight = ? WHERE username = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @targetWeight, @user;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- Build prepared statment to verify new target weight for user
	PREPARE stmt2 FROM 'SELECT COUNT(*) INTO @numRecs FROM users WHERE username = ? AND targetWeight = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt2 USING @user, @targetWeight;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt2;
	
	-- If a record was returned
	IF @numRecs > 0 THEN
	
		-- Set return value to 0 = target weight updated and verified
		SET @iRetVal = 0;
	
	ELSE
	
		-- Set return value to 1 = target weight update failed
		SET @iRetVal = 1;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END
````
