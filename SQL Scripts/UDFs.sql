USE YACM;

-- ===============
-- === MANAGER ===
-- ===============
-- UDF to get events managed by a certain user
GO
CREATE FUNCTION dbo.GetManagerEvents (@managerEmail varchar(50)) RETURNS @RetVal TABLE (number int, [name] varchar(50), beginningDate date, endDate date, visibility bit)
AS
	BEGIN
		INSERT @RetVal SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
			JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
			JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
			WHERE YACM.[User].email = @managerEmail
		RETURN;
	END
GO
SELECT * FROM dbo.GetManagerEvents('f.alexander@randatmail.com');

-- UDF to get events not managed by a certain user
GO
CREATE FUNCTION dbo.GetOtherEvents (@managerEmail varchar(50)) RETURNS @RetVal TABLE (number int, [name] varchar(50), beginningDate date, endDate date, visibility bit)
AS
	BEGIN
		INSERT @RetVal SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
			JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
			JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
			WHERE YACM.[User].email != @managerEmail
		RETURN;
	END
GO
SELECT * FROM dbo.GetOtherEvents('f.alexander@randatmail.com');


-- UDF to get events not managed by a certain user that are publicly visible
GO
CREATE FUNCTION dbo.GetOtherVisibleEvents(@managerEmail varchar(50)) RETURNS @RetVal TABLE (number int, [name] varchar(50), beginningDate date, endDate date, visibility bit)
AS
	BEGIN
		INSERT @RetVal SELECT YACM.[Event].number,YACM.[Event].[name],YACM.[Event].beginningDate,YACM.[Event].endDate,YACM.[Event].visibility FROM YACM.[Event]
			JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
			JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
			WHERE YACM.[User].email != @managerEmail AND YACM.[Event].visibility = 1
		RETURN;
	END
GO
SELECT * FROM dbo.GetOtherVisibleEvents('f.alexander@randatmail.com');




-- =============
-- === EVENT ===
-- =============
-- UDF to get prizes of an event
GO
CREATE FUNCTION dbo.GetEventPrizes(@eventID int) RETURNS @RetVal TABLE (id int, sponsorID int, eventNumber int, receiverID int, [value] real)
AS
	BEGIN
		INSERT @RetVal SELECT * FROM YACM.Prize WHERE eventNumber=@eventID;
		RETURN;
	END;
GO
SELECT * FROM dbo.GetEventPrizes(0);

-- UDF to get Teams stats
GO
CREATE FUNCTION dbo.GetTeamsStatus(@eventID int) RETURNS @RetVal TABLE (eventID int, teamName varchar(50), teamBudget int, numberOfAthletes int)
AS
	BEGIN
		INSERT @RetVal SELECT YACM.ParticipantEnrollment.eventNumber,YACM.ParticipantEnrollment.teamName,SUM(YACM.SponsorshipTeam.monetaryValue),COUNT(YACM.ParticipantEnrollment.participantID)
			FROM YACM.ParticipantEnrollment
			JOIN YACM.SponsorshipTeam ON YACM.ParticipantEnrollment.teamName=YACM.SponsorshipTeam.teamName
			WHERE YACM.ParticipantEnrollment.eventNumber=@eventID
			GROUP BY YACM.ParticipantEnrollment.eventNumber,YACM.ParticipantEnrollment.teamName;
		RETURN;
	END;
GO
SELECT * FROM dbo.GetTeamsStatus(0);

-- UDF to get documents of an event
GO
CREATE FUNCTION dbo.GetEventDocuments(@eventID int) RETURNS @RetVal TABLE (id int, eventNumber int, content varbinary(MAX), [path] varchar(50))
AS
	BEGIN
		INSERT @RetVal SELECT * FROM YACM.Document JOIN YACM.TextFile ON YACM.Document.id=YACM.TextFile.id WHERE eventNumber=@eventID;
		INSERT @RetVal SELECT * FROM YACM.Document JOIN YACM.OtherFile ON YACM.Document.id=YACM.OtherFile.id WHERE eventNumber=@eventID;
		RETURN;
	END;
GO
SELECT * FROM dbo.GetEventDocuments(0);


-- ============
-- === USER ===
-- ============
-- UDF to login
GO
CREATE FUNCTION dbo.Authenticate(@userEmail varchar(50), @userPassword varchar(50)) RETURNS @RetVal TABLE (id int, email varchar(50), [name] varchar(50), [password] varchar(50), [type] varchar(50))
AS
	BEGIN
		INSERT @RetVal SELECT P.id, email, name, [password], 'Manager' as 'type' FROM YACM.[User] AS U JOIN YACM.Manager AS P ON U.id = P.id WHERE email=@userEmail AND [password]=@userPassword
		INSERT @RetVal SELECT P.id, email, name, [password], 'Sponsor' as 'type' FROM YACM.[User] AS U JOIN YACM.Sponsor AS P ON U.id = P.id WHERE email=@userEmail AND [password]=@userPassword
		INSERT @RetVal SELECT P.id, email, name, [password], 'Participant' as 'type' FROM YACM.[User] AS U JOIN YACM.Participant AS P ON U.id = P.id WHERE email=@userEmail AND [password]=@userPassword
		RETURN;
	END;
GO
SELECT * FROM dbo.Authenticate('paulobvasconcelos@gmail.com','ImTired');
