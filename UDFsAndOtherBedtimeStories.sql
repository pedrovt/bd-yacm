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




-- ================
-- === DOCUMENT ===
-- ================
-- Stored Procedure to create a document
GO
CREATE PROC dbo.p_CreateDocument (@eventNumber int, @id int OUT)
AS
	INSERT INTO YACM.Document (eventNumber) VALUES (@eventNumber);
	SET	@id = SCOPE_IDENTITY()
GO

-- Stored Procedure to create a text file
GO
CREATE PROC dbo.p_CreateTextFile (@eventID int, @content varchar(MAX))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateDocument @eventNumber=@eventID,@id=@id;
	INSERT INTO YACM.TextFile(id,content) VALUES (@id,@content);
	RETURN 0;
GO

-- Stored Procedure to create a other file
GO
CREATE PROC dbo.p_CreateOtherFile (@eventID int, @path varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateDocument @eventNumber=@eventID,@id=@id;
	INSERT INTO YACM.OtherFile(id,[path]) VALUES (@id,@path);
	RETURN 0;
GO

-- Trigger on Delete
GO
CREATE TRIGGER DocumentRekt ON YACM.Document AFTER DELETE
AS
	DECLARE @id AS INT;
	SELECT @id=id FROM deleted;
	DELETE YACM.TextFile	WHERE YACM.TextFile.id=@id;
	DELETE YACM.OtherFile	WHERE YACM.OtherFile.id=@id;
GO




-- ============
-- === USER ===
-- ============
-- Trigger on Delete
GO
CREATE TRIGGER ValarMorghulis ON YACM.[User] AFTER DELETE
AS
	DECLARE @id AS INT;
	SELECT @id=id FROM deleted;
	DELETE YACM.Manager		WHERE YACM.Manager.id=@id;
	DELETE YACM.Participant	WHERE YACM.Participant.id=@id;
	DELETE YACM.Sponsor		WHERE YACM.Sponsor.id=@id;
GO