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


&emsp; I have demonstrated the ability to program solutions to logic problems by implementing more complex regular expressions for data validation rather than using multiple logic conditions in a nested conditional structure.  This provides more robust input validation using fewer conditions and lines of code.



&emsp; I have demonstrated innovative skills in form navigation design by taking advantage of various language features including the ShowDialog() method, style properties, and the loading and closing events of the forms to control form navigation and ensure the user is unable to circumvent the intended flow by clicking an unexpected button.


&emsp; I have demonstrated my ability to identify and address design flaws related to security by not storing plaint text passwords in any additional variables or passing them to any function in plaintext form.  The user input is evaluated directly from the textbox’s text property and hashed before being stored in memory and passed between functions.
