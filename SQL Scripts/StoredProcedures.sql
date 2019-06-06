USE YACM;

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
	EXEC dbo.p_CreateDocument @eventNumber=@eventID,@id=@id OUT;
	INSERT INTO YACM.TextFile(id,content) VALUES (@id,@content);
	RETURN 0;
GO

-- Stored Procedure to create a other file
GO
CREATE PROC dbo.p_CreateOtherFile (@eventID int, @path varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateDocument @eventNumber=@eventID,@id=@id OUT;
	INSERT INTO YACM.OtherFile(id,[path]) VALUES (@id,@path);
	RETURN 0;
GO

-- ================
-- ===== USER =====
-- ================
-- Stored Procedure to create a user
GO
CREATE PROC dbo.p_CreateUser (@email varchar(50), @name varchar(50), @password varchar(50), @id int OUT)
AS
	INSERT INTO YACM.[User] (email, name, [password]) VALUES (@email, @name, @password);
	SET	@id = SCOPE_IDENTITY()
GO

-- Stored Procedure to create a Manager
GO
CREATE PROC dbo.p_CreateManager (@email varchar(50), @name varchar(50), @password varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateUser @email=@email, @name=@name, @password=@password, @id=@id OUT;
	INSERT INTO YACM.Manager(id) VALUES (@id);
	RETURN 0;
GO

-- Stored Procedure to create a Participant
GO
CREATE PROC dbo.p_CreateParticipant (@email varchar(50), @name varchar(50), @password varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateUser @email=@email, @name=@name, @password=@password, @id=@id OUT;
	INSERT INTO YACM.Participant(id) VALUES (@id);
	RETURN 0;
GO

-- Stored Procedure to create a sponsor
GO
CREATE PROC dbo.p_CreateSponsor (@email varchar(50), @name varchar(50), @password varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateUser @email=@email, @name=@name, @password=@password, @id=@id OUT;
	INSERT INTO YACM.Sponsor(id) VALUES (@id);
	RETURN 0;
GO
