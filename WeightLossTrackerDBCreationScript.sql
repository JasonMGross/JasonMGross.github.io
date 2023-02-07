--  ==============================================================
--     File: WeightDBCreationScript.sql
--   Author: Jason Gross
--     Date: 2/5/2023
-- Comments: These SQL commands are designed to be run on
--           a standalone MySQL or MariaDB server installation to 
--           create the database, user account, data tables, and stored
--           procedures necessary to support the .NET Weight Loss Tracking
--           application.
--  ==============================================================

-- ==============================================================
-- CREATE & SELECT DATABASE
-- ==============================================================

-- This initial command creates the application database called WeightDB if
-- it doesn't already exist.

CREATE DATABASE IF NOT EXISTS WeightDB;

-- After the database is created, it must be selected before use

USE WeightDB;

-- ==============================================================
-- CREATE TABLES
-- ==============================================================

-- These next two commands create the two data tables used by the application.
-- Each table has an auto-incremented unique ID as the primary key so that each
-- record can be uniquely identified and accessed.

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

-- ==============================================================
-- CREATE USER
-- ==============================================================

-- The application has a dedicated user account  in the database that only has permission
-- to execute stored procedures written specifically for the application.
-- If this user's credentials were discovered, they would still not have complete
-- unadulterated access to the raw data tables and stored procedure code.

-- This command checks to see if the WeightAppUser already exists and deletes the account if it does.
-- The the user is then with a strong password that would not easily be compromised via brute force.
-- The final line of the command ensures the user can only execute stored procedures in the WeightDB database.

DROP USER IF EXISTS 'WeightAppUser'@'%';
CREATE USER 'WeightAppUser'@'%' IDENTIFIED BY 'W3!gh75&M3a5ur35';
GRANT EXECUTE ON WeightDB.* TO 'WeightAppUser'@'%';

-- ==============================================================
-- CREATE STORED PROCEDURES
-- ==============================================================

-- The AddUser stored procedure takes a username and hashed password string and creates a new record in the users table.
-- The target weight for that user is initialized to zero at this time and forced to be set during subsequent steps in the application.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- After the new record insert is attempted, a follow-up validation select statement is run to ensure the record was correctly added.
-- This procedure will return a value of 0 if the insert was successful or 1 if not successful.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS AddUser;

CREATE PROCEDURE AddUser(
	IN strUser TEXT,
	IN strPassword TEXT
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;
	DECLARE pass TEXT;
	DECLARE numRecs INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @user = strUser;
	SET @pass = strPassword;
	SET @numRecs = 0;
	SET @iRetVal = 1;
	
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
	
	-- If a record was returned
	IF @numRecs > 0 THEN
	
		-- Set return value to 0 = User added and verified
		SET @iRetVal = 0;
	
	ELSE
	
		-- Set return value to 1 = User add failed
		SET @iRetVal = 1;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;
    
END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The AddWeightRecord stored procedure takes as parameters the input from the user including their userID, current date, current weight,
-- number of minutes exercised on the date, and the user's current target weight.  It then inserts a new record in the weights table.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- After the new record insert is attempted, a follow-up validation select statement is run to ensure the record was correctly added.
-- This procedure will return a value of 0 if the insert was successful or 1 if not successful.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS AddWeightRecord;

CREATE PROCEDURE AddWeightRecord(
	IN strUser TEXT,
	IN dDate DATE,
	IN fWeight FLOAT,
	IN fExerciseMinutes FLOAT,
	IN fCurrentTarget FLOAT
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;
	DECLARE entryDate DATE;
	DECLARE entryWeight FLOAT;
	DECLARE exerciseMinutes FLOAT;
	DECLARE currentTarget FLOAT;
	DECLARE numRecs INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @user = strUser;
	SET @entryDate = dDate;
	SET @entryWeight = fWeight;
	SET @exerciseMinutes = fExerciseMinutes;
	SET @currentTarget = fCurrentTarget;
	SET @numRecs = 0;
	SET @iRetVal = 1;
	
	-- Build prepared statment to insert new weight table record
	PREPARE stmt1 FROM 'INSERT INTO weights (username, entryDate, weight, exerciseMinutes, currentTarget) VALUES (?, ?, ?, ?, ?);';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user, @entryDate, @entryWeight, @exerciseMinutes, @currentTarget;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- Build prepared statment to verify new weight record
	PREPARE stmt2 FROM 'SELECT COUNT(*) INTO @numRecs FROM weights WHERE username = ? AND entryDate = ? AND weight = ? AND exerciseMinutes = ? AND currentTarget = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt2 USING @user, @entryDate, @entryWeight, @exerciseMinutes, @currentTarget;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt2;
	
	-- If a record was returned
	IF @numRecs > 0 THEN
	
		-- Set return value to 0 = Weight record added and verified
		SET @iRetVal = 0;
	
	ELSE
	
		-- Set return value to 1 = Weight record add failed
		SET @iRetVal = 1;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The CheckDuplicateWeightRecord stored procedure takes a username and current date and checks for an existing weight
-- in the weights table containing that username and date.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- This procedure will return a value of 0 if no records were found meaning the record is unique, otherwise it returns 1 to 
-- indicate the record already exists.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS CheckDuplicateWeightRecord;

CREATE PROCEDURE CheckDuplicateWeightRecord(
	IN strUser TEXT,
	IN dDate DATE
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;
	DECLARE entryDate DATE;
	DECLARE numRecs INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @user = strUser;
	SET @entryDate = dDate;
	SET @numRecs = 0;
	SET @iRetVal = 1;
	
	-- Build prepared statment to get a count of records for the current user and entry date
	PREPARE stmt1 FROM 'SELECT COUNT(*) INTO @numRecs FROM weights WHERE username = ? AND entryDate = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user, @entryDate;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
		
	-- If no records were returned
	IF @numRecs = 0 THEN
	
		-- Set return value to 0 = Record is unique
		SET @iRetVal = 0;
	
	ELSE
	
		-- Set return value to 1 = Record is a duplicate
		SET @iRetVal = 1;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The DeleteWeightRecord stored procedure takes a record ID as a parameter and attempts to delete that record from the weights table.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- After the record delete is attempted, a follow-up validation select statement is run to ensure the record was properly removed.
-- This procedure will return a value of 0 if the record was successfully deleted, otherwise it returns 1.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS DeleteWeightRecord;

CREATE PROCEDURE DeleteWeightRecord(
	IN iRecID INT
)

BEGIN

	-- Declare Variables
	DECLARE recID INT;
	DECLARE numRecs INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @recID = iRecID;
	SET @numRecs = 0;
	SET @iRetVal = 1;
	
	-- Build prepared statment to delete weight record from weights table
	PREPARE stmt1 FROM 'DELETE FROM weights WHERE _id = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @recID;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- Build prepared statment to verify weight record has been deleted from weights table
	PREPARE stmt2 FROM 'SELECT COUNT(*) INTO @numRecs FROM weights WHERE _id = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt2 USING @recID;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt2;
	
	-- If no records were returned
	IF @numRecs = 0 THEN
	
		-- Set return value to 0 = Weight record deleted and verified
		SET @iRetVal = 0;
		
	ELSE
		
		-- Set return value to 1 = Weight record delete failed
		SET @iRetVal = 1;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The GetTargetWeight stored procedure takes a user ID as a parameter and attempts to retrieve the target weight from the users table with a select query.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- This procedure will return the result of the select query.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS GetTargetWeight;

CREATE PROCEDURE GetTargetWeight(
	IN strUser TEXT
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;	
	
	-- Initialize variables
	SET @user = strUser;	
	
	-- Build prepared statment to query target weight from users table for given user
	PREPARE stmt1 FROM 'SELECT targetWeight FROM users WHERE username = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The GetWeightData stored procedure takes a user ID as a parameter and attempts to retrieve all of the records from the weights table
-- for the given user with a select query.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- This procedure will return the result set of the select query.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS GetWeightData;

CREATE PROCEDURE GetWeightData(
	IN strUser TEXT
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;	
	
	-- Initialize variables
	SET @user = strUser;	
	
	-- Build prepared statment to query all records from weights table for given user
	PREPARE stmt1 FROM 'SELECT _id AS RecID, entryDate, weight, exerciseMinutes, currentTarget FROM weights WHERE username = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The GetWeightRecord stored procedure takes a record ID as a parameter and attempts to retrieve that record from the weights table with a select query.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- This procedure will return the result set of the select query.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS GetWeightRecord;

CREATE PROCEDURE GetWeightRecord(
	IN iRecID INT
)

BEGIN

	-- Declare Variables
	DECLARE recID INT;	
	
	-- Initialize variables
	SET @recID = iRecID;	
	
	-- Build prepared statment to query record from weights table with given record ID
	PREPARE stmt1 FROM 'SELECT * FROM weights WHERE _id = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @recID;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The UpdateWeightRecord stored procedure takes a record ID, user ID, entry date, current weight, current exercise minutes, and current target weight
-- as parameters and attempts to update the given record ID in the weights table with an update query.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- After the weight record update is attempted, a follow-up validation select statement is run to ensure the record was correctly updated.
-- This procedure will return 0 if the weight record was updated and verified, otherwise it returns 1.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS UpdateWeightRecord;

CREATE PROCEDURE UpdateWeightRecord(
	IN recordID INT,
	IN strUser TEXT,
	IN dDate DATE,
	IN fWeight FLOAT,
	IN fExerciseMinutes FLOAT,
	IN fCurrentTarget FLOAT
)

BEGIN

	-- Declare Variables
	DECLARE recID INT;
	DECLARE user TEXT;
	DECLARE entryDate DATE;
	DECLARE entryWeight FLOAT;
	DECLARE exerciseMinutes FLOAT;
	DECLARE currentTarget FLOAT;
	DECLARE numRecs INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @recordID = recID;
	SET @user = strUser;
	SET @entryDate = dDate;
	SET @entryWeight = fWeight;
	SET @exerciseMinutes = fExerciseMinutes;
	SET @currentTarget = fCurrentTarget;
	SET @numRecs = 0;
	SET @iRetVal = 1;
	
	-- Build prepared statment to update weight record for given record ID
	PREPARE stmt1 FROM 'UPDATE weights SET username = ?, entryDate = ?, weight = ?, exerciseMinutes = ?, currentTarget = ? WHERE _id = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user, @entryDate, @entryWeight, @exerciseMinutes, @currentTarget, @recordID;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- Build prepared statment to verify updated weight record
	PREPARE stmt2 FROM 'SELECT COUNT(*) INTO @numRecs FROM weights WHERE _id = ? AND username = ? AND entryDate = ? AND weight = ? AND exerciseMinutes = ? AND currentTarget = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt2 USING @recordID, @user, @entryDate, @entryWeight, @exerciseMinutes, @currentTarget;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt2;
	
	-- If a record was returned
	IF @numRecs > 0 THEN
	
		-- Set return value to 0 = weight record updated and verified
		SET @iRetVal = 0;
	
	ELSE
	
		-- Set return value to 1 = Weight record update failed
		SET @iRetVal = 1;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The VerifyAuthenticateUser stored procedure takes a user ID and hashed password as parameters to determine if user exists and 
-- password matches with a series of select queries.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- This procedure will return 0 if the user exists and password matches, 1 if the user exists but passwords don't match, or 2 if user doesn't exist.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS VerifyAuthenticateUser;

CREATE PROCEDURE VerifyAuthenticateUser(
	IN strUser TEXT,
	IN strPassword TEXT
)

BEGIN

	-- Declare Variables
	DECLARE numRecsUser INT DEFAULT 0;
	DECLARE numRecsUserPass INT DEFAULT 0;
	DECLARE iRetVal INT;
	DECLARE user TEXT;
	DECLARE pass TEXT;
	
	-- Initialize variables
	SET @numRecsUser = 0;
	SET @numRecsUserPass = 0;
	SET @iRetVal = -1;
	SET @user = strUser;
	SET @pass = strPassword;
	
	-- Build prepared statment to check if user exists in users table
	PREPARE stmt1 FROM 'SELECT COUNT(*) INTO @numRecsUser FROM users WHERE username = ?;';    
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- If a record was found
	IF @numRecsUser > 0 THEN
	
		-- Build prepared statement to check if the correct password was passed
		PREPARE stmt2 FROM 'SELECT COUNT(*) INTO @numRecsUserPass FROM users WHERE username = ? AND password = ?;';
		
		-- Execute prepared statement
		EXECUTE stmt2 USING @user, @pass;
		
		-- Deallocate prepared statement
		DEALLOCATE PREPARE stmt2;
		
		-- If a record was returned
		IF @numRecsUserPass > 0 THEN
		
			-- Set return value to 0 = user and password are correct
			SET @iRetVal = 0;
			
		ELSE
		
			-- Set return value to 1 = User exists but password is invalid
			SET @iRetVal = 1;
		
		END IF;
		
	ELSE
		
		-- Set return value to 2 = User doesn't exist
		SET @iRetVal = 2;
	
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END

-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- The DeleteUser stored procedure takes a user ID and hashed password as parameters and first checks to ensure the user is authentic and if so,
-- it deletes the user's record from the users table and all associated records for that user from the weights table with delete statements.
-- Prepared statements are used to prevent SQL-Injection attacks against the database.
-- This procedure will return 0 if the user was deleted and all records were successfully removed.  It returns 1 if password didn't match, and 2 if user wasn't found in the users table.

-- Delete stored procedure if it already exists
DROP PROCEDURE IF EXISTS DeleteUser;

CREATE PROCEDURE DeleteUser(
	IN strUser TEXT,
	IN strPassword TEXT
)

BEGIN

	-- Declare Variables
	DECLARE user TEXT;
	DECLARE pass TEXT;
	DECLARE numRecsUserPass INT;
	DECLARE numRecsUser INT;	
	DECLARE numRecsWeights INT;
	DECLARE iRetVal INT;
	
	-- Initialize variables
	SET @user = strUser;
	SET @pass = strPassword;
	SET @numRecsUserPass = 0;
	SET @numRecsUser = 0;
	SET @numRecsWeights = 0;
	SET @iRetVal = 1;
	
	-- Build prepared statment to authenticate user and password in users table
	PREPARE stmt1 FROM 'SELECT COUNT(*) INTO @numRecsUserPass FROM users WHERE username = ? AND password = ?;';
	
	-- Execute prepared statement
	EXECUTE stmt1 USING @user, @pass;
	
	-- Deallocate prepared statement
	DEALLOCATE PREPARE stmt1;
	
	-- If a record was returned, then the user/password was correct and delete can continue
	IF @numRecsUserPass > 0 THEN
		
		-- Build prepared statment to delete user from users table
		PREPARE stmt2 FROM 'DELETE FROM users WHERE username = ?;';
		
		-- Execute prepared statement
		EXECUTE stmt2 USING @user;
		
		-- Deallocate prepared statement
		DEALLOCATE PREPARE stmt2;
		
		-- Build prepared statment to delete user data from weights table
		PREPARE stmt3 FROM 'DELETE FROM weights WHERE username = ?;';
		
		-- Execute prepared statement
		EXECUTE stmt3 USING @user;
		
		-- Deallocate prepared statement
		DEALLOCATE PREPARE stmt3;
		
		-- Build prepared statement to verify user is deleted from user table
		PREPARE stmt4 FROM 'SELECT COUNT(*) INTO @numRecsUser FROM users WHERE username = ?;';
		
		-- Execute prepared statement
		EXECUTE stmt4 USING @user;
		
		-- Deallocate prepared statement
		DEALLOCATE PREPARE stmt4;
	
		-- Build prepared statement to verify user data is deleted from weights table
		PREPARE stmt5 FROM 'SELECT COUNT(*) INTO @numRecsWeights FROM weights WHERE username = ?;';
		
		-- Execute prepared statement
		EXECUTE stmt5 USING @user;
		
		-- Deallocate prepared statement
		DEALLOCATE PREPARE stmt5;
		
		-- If zero records were returned
		IF @numRecsUser = 0 AND @numRecsWeights = 0 THEN
		
			-- Set return value to 0 = user deleted and verified
			SET @iRetVal = 0;
		
		ELSE
		
			-- Set return value to 1 = User delete failed
			SET @iRetVal = 1;
		
		END IF;
		
	ELSE
	
		-- Set return value to 2 = Authentication Failed
		SET @iRetVal = 2;
		
	END IF;
	
	-- Return value to application
	SELECT @iRetVal;

END