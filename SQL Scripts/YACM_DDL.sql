/* Yet Another Cycling Manager (YACM)
 * Databases Final Project
 * Paulo Vasconcelos <paulobvasconcelos@ua.pt>
 * Pedro Teixeira <pedro.teix@ua.pt>
 * 23-April-2019
 */

/*******************
 * DROP ALL TABLES *
 *******************/
 
/*DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE YACM.[' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE YACM.?'
GO*/


/*****************
 * CREATE DB	 *
 *****************/

IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
    WHERE name = N'YACM'
    )
BEGIN
    SELECT 'Database YACM already Exists' AS Message
END
ELSE
BEGIN
   IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [YACM] MODIFY FILEGROUP [PRIMARY] DEFAULT
	CREATE DATABASE [YACM]
END


USE YACM;

/*****************
 * SCHEMA        *
 *****************/
GO
CREATE SCHEMA YACM;
GO

/*****************
 * TYPE CREATION *
 *****************/

CREATE TYPE string FROM varchar(50);
CREATE TYPE bincontent FROM varchar(MAX);



/************
 * ENTITIES *
 ************/

CREATE TABLE YACM.[User] (
	id			int		IDENTITY(1,1),
	email		string	UNIQUE NOT NULL,
	name		string	NOT NULL,
	password	string	NOT NULL,
	CONSTRAINT USER_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.Manager (
	id	int,
	CONSTRAINT MANAGER_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.Sponsor (
	id	int,
	CONSTRAINT SPONSOR_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.Participant (
	id	int,
	CONSTRAINT PARTICIPANT_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.[Event] (
	[number]		int		IDENTITY(1,1),
	name			string	NOT NULL,
	beginningDate	date	NOT NULL,
	endDate			date,
	visibility		bit		NOT NULL CONSTRAINT VISIBILITY_DEFAULT DEFAULT 1,
	managerID		int		NOT NULL,
	CONSTRAINT EVENT_PK PRIMARY KEY (number)
 );

CREATE TABLE YACM.Stage (
	[date]			date	,
	startLocation	string	,
	endLocation		string	,
	eventNumber		int		NOT NULL,
	distance		real	NOT NULL,
	CONSTRAINT STAGE_PK PRIMARY KEY ([date],startLocation,endLocation)
 );

CREATE TABLE YACM.Prize (
	id			int		IDENTITY(1,1),
	sponsorID	int,
	eventNumber int		NOT NULL,
	receiverID	int,
	value		real,
	CONSTRAINT PRIZE_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.Document (
	id				int	IDENTITY(1,1),
	eventNumber		int,
	CONSTRAINT DOCUMENT_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.TextFile (
	id		int			,
	content	bincontent	NOT NULL,
	CONSTRAINT TEXTFILE_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.OtherFile (
	id		int		,
	[path]	string	NOT NULL,
	CONSTRAINT OTHERFILE_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.Team (
	name	string	,
	CONSTRAINT TEAM_PK PRIMARY KEY (name)
 );

CREATE TABLE YACM.Equipment (
	id				int	IDENTITY(1,1),
	participantID	int	NOT NULL,
	category		string,
	description		string,
	CONSTRAINT EQUIPMENT_PK PRIMARY KEY (id)
 );



/********************
 * N to M RELATIONS *
 ********************/

CREATE TABLE YACM.SponsorshipEvent (
	sponsorID		int		,
	eventNumber		int		,
	monetaryValue	real	NOT NULL,
	CONSTRAINT SPONSORSHIPEVENT_PK PRIMARY KEY (sponsorID,eventNumber)
 );

CREATE TABLE YACM.SponsorshipTeam (
	sponsorID		int		,
	teamName		string	,
	monetaryValue	real	NOT NULL,
	CONSTRAINT SPONSORSHIPTEAM_PK PRIMARY KEY (sponsorID,teamName)
 );

CREATE TABLE YACM.StageParticipation (
	participantID		int		,
	eventNumber			int		,
	stageDate			date	,
	stageStartLocation	string	,
	stageEndLocation	string	,
	result				string	,
	CONSTRAINT STAGEPARTICIPATION_PK PRIMARY KEY (participantID,eventNumber,stageDate,stageStartLocation,stageEndLocation)
 );

CREATE TABLE YACM.ParticipantOnTeam (
	participantID	int		,
	teamName		string	,
	startDate		date	NOT NULL,
	endDate			date	NOT NULL,
	CONSTRAINT PARTICIPANTONTEAM_PK PRIMARY KEY (participantID,teamName)
 );

CREATE TABLE YACM.ParticipantEnrollment (
	participantID	int		,
	eventNumber		int		,
	teamName		string,
	dorsal			int,
	CONSTRAINT PARTICIPANTENROLLMENT_PK PRIMARY KEY (participantID,eventNumber)
 );

 CREATE TABLE YACM.ParticipantDropOut (
	participantID	int		,
	eventNumber		int		,
	CONSTRAINT PARTICIPANTDROPOUT_PK PRIMARY KEY (participantID,eventNumber)
 );

/****************
 * FOREIGN KEYS *
 ****************/

ALTER TABLE YACM.Manager					ADD FOREIGN KEY (id)					REFERENCES YACM.[User](id);
ALTER TABLE YACM.Sponsor					ADD FOREIGN KEY (id)					REFERENCES YACM.[User](id);
ALTER TABLE YACM.Participant				ADD FOREIGN KEY (id)					REFERENCES YACM.[User](id);

ALTER TABLE YACM.[Event]					ADD FOREIGN KEY (managerID)				REFERENCES YACM.Manager(id);

ALTER TABLE YACM.Stage					ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);

ALTER TABLE YACM.Prize					ADD FOREIGN KEY (sponsorID)				REFERENCES YACM.Sponsor(id);
ALTER TABLE YACM.Prize					ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);
ALTER TABLE YACM.Prize					ADD FOREIGN KEY (receiverID)			REFERENCES YACM.Participant(id);

ALTER TABLE YACM.Document				ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);

ALTER TABLE YACM.TextFile				ADD FOREIGN KEY (id)					REFERENCES YACM.Document(id);
ALTER TABLE YACM.OtherFile				ADD FOREIGN KEY (id)					REFERENCES YACM.Document(id);

ALTER TABLE YACM.Equipment				ADD FOREIGN KEY (participantID)			REFERENCES YACM.Participant(id);

ALTER TABLE YACM.SponsorshipEvent		ADD FOREIGN KEY (sponsorID)				REFERENCES YACM.Sponsor(id);
ALTER TABLE YACM.SponsorshipEvent		ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);

ALTER TABLE YACM.SponsorshipTeam			ADD FOREIGN KEY (sponsorID)				REFERENCES YACM.Sponsor(id);
ALTER TABLE YACM.SponsorshipTeam			ADD FOREIGN KEY (teamName)				REFERENCES YACM.Team([name]);

ALTER TABLE YACM.StageParticipation		ADD FOREIGN KEY (participantID)			REFERENCES YACM.Participant(id);
ALTER TABLE YACM.StageParticipation		ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);
ALTER TABLE YACM.StageParticipation		ADD FOREIGN KEY (stageDate,stageStartLocation,stageEndLocation)
	REFERENCES YACM.Stage([date],startLocation,endLocation);

ALTER TABLE YACM.ParticipantOnTeam		ADD FOREIGN KEY (participantID)			REFERENCES YACM.Participant(id);
ALTER TABLE YACM.ParticipantOnTeam		ADD FOREIGN KEY (teamName)				REFERENCES YACM.Team([name]);

ALTER TABLE YACM.ParticipantEnrollment	ADD FOREIGN KEY (participantID)			REFERENCES YACM.Participant(id);
ALTER TABLE YACM.ParticipantEnrollment	ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);
ALTER TABLE YACM.ParticipantEnrollment	ADD FOREIGN KEY (teamName)				REFERENCES YACM.Team([name]);

ALTER TABLE YACM.ParticipantDropOut	ADD FOREIGN KEY (participantID)			REFERENCES YACM.Participant(id);
ALTER TABLE YACM.ParticipantDropOut	ADD FOREIGN KEY (eventNumber)			REFERENCES YACM.[Event]([number]);

CREATE INDEX i_Event_managerID		ON YACM.[Event](managerID);
CREATE INDEX i_Prize_eventNumber	ON YACM.Prize(eventNumber);
CREATE INDEX i_Stage_eventNumber	ON YACM.Stage(eventNumber);
CREATE INDEX i_User_email			ON YACM.[User](email);