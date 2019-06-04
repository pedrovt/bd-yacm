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
	CONTAINMENT = NONE
	ON  PRIMARY 
( NAME = N'YACM', FILENAME = N'C:\Program Files\Microsoft SQL Server\2014\MSSQL12.SQLEXPRESS\MSSQL\DATA\YACM.mdf' , SIZE = 4096KB , FILEGROWTH = 1024KB )
	LOG ON 
( NAME = N'YACM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\2014\MSSQL12.SQLEXPRESS\MSSQL\DATA\YACM_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)
		GO
		ALTER DATABASE [YACM] SET COMPATIBILITY_LEVEL = 120
		GO
		ALTER DATABASE [YACM] SET ANSI_NULL_DEFAULT OFF 
		GO
		ALTER DATABASE [YACM] SET ANSI_NULLS OFF 
		GO
		ALTER DATABASE [YACM] SET ANSI_PADDING OFF 
		GO
		ALTER DATABASE [YACM] SET ANSI_WARNINGS OFF 
		GO
		ALTER DATABASE [YACM] SET ARITHABORT OFF 
		GO
		ALTER DATABASE [YACM] SET AUTO_CLOSE OFF 
		GO
		ALTER DATABASE [YACM] SET AUTO_SHRINK OFF 
		GO
		ALTER DATABASE [YACM] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
		GO
		ALTER DATABASE [YACM] SET AUTO_UPDATE_STATISTICS ON 
		GO
		ALTER DATABASE [YACM] SET CURSOR_CLOSE_ON_COMMIT OFF 
		GO
		ALTER DATABASE [YACM] SET CURSOR_DEFAULT  GLOBAL 
		GO
		ALTER DATABASE [YACM] SET CONCAT_NULL_YIELDS_NULL OFF 
		GO
		ALTER DATABASE [YACM] SET NUMERIC_ROUNDABORT OFF 
		GO
		ALTER DATABASE [YACM] SET QUOTED_IDENTIFIER OFF 
		GO
		ALTER DATABASE [YACM] SET RECURSIVE_TRIGGERS OFF 
		GO
		ALTER DATABASE [YACM] SET  DISABLE_BROKER 
		GO
		ALTER DATABASE [YACM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
		GO
		ALTER DATABASE [YACM] SET DATE_CORRELATION_OPTIMIZATION OFF 
		GO
		ALTER DATABASE [YACM] SET PARAMETERIZATION SIMPLE 
		GO
		ALTER DATABASE [YACM] SET READ_COMMITTED_SNAPSHOT OFF 
		GO
		ALTER DATABASE [YACM] SET  READ_WRITE 
		GO
		ALTER DATABASE [YACM] SET RECOVERY SIMPLE 
		GO
		ALTER DATABASE [YACM] SET  MULTI_USER 
		GO
		ALTER DATABASE [YACM] SET PAGE_VERIFY CHECKSUM  
		GO
		ALTER DATABASE [YACM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
		GO
		ALTER DATABASE [YACM] SET DELAYED_DURABILITY = DISABLED 
		GO
		USE [YACM]
		GO
		IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [YACM] MODIFY FILEGROUP [PRIMARY] DEFAULT
		GO

    SELECT 'New Database is Created'
END




/*****************
 * SCHEMA        *
 *****************/
--CREATE SCHEMA YACM;


/*****************
 * TYPE CREATION *
 *****************/

CREATE TYPE string FROM varchar(50);
CREATE TYPE bincontent FROM varchar(MAX);



/************
 * ENTITIES *
 ************/

CREATE TABLE YACM.[User] (
	id			int		,
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
	[number]		int		,
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
	id			int		,
	sponsorID	int,
	eventNumber int		NOT NULL,
	receiverID	int,
	value		real,
	CONSTRAINT PRIZE_PK PRIMARY KEY (id)
 );

CREATE TABLE YACM.Document (
	id				int,
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
	id				int	,
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