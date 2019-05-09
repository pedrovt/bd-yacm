/*******************
 * DROP ALL TABLES *
 *******************/
 
/*DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
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

EXEC sp_MSforeachtable 'DROP TABLE ?'
GO*/

/*****************
 * TYPE CREATION *
 *****************/

CREATE TYPE string FROM varchar(50);
CREATE TYPE bincontent FROM varbinary(MAX);



/************
 * ENTITIES *
 ************/

CREATE TABLE [User] (
	id			int		NOT NULL,
	email		string	NOT NULL,
	name		string	NOT NULL,
	password	string	NOT NULL,
	CONSTRAINT USER_PK PRIMARY KEY (id)
 );

CREATE TABLE Manager (
	id	int	NOT NULL,
	CONSTRAINT MANAGER_PK PRIMARY KEY (id)
 );

CREATE TABLE Sponsor (
	id	int	NOT NULL,
	CONSTRAINT SPONSOR_PK PRIMARY KEY (id)
 );

CREATE TABLE Participant (
	id	int	NOT NULL,
	CONSTRAINT PARTICIPANT_PK PRIMARY KEY (id)
 );

CREATE TABLE [Event] (
	[number]		int		NOT NULL,
	name			string	NOT NULL,
	beginningDate	date	NOT NULL,
	endDate			date,
	visibility		bit		NOT NULL CONSTRAINT VISIBILITY_DEFAULT DEFAULT 1,
	managerID		int		NOT NULL,
	CONSTRAINT EVENT_PK PRIMARY KEY (number)
 );

CREATE TABLE Stage (
	[date]			date	NOT NULL,
	startLocation	string	NOT NULL,
	endLocation		string	NOT NULL,
	eventNumber		int		NOT NULL,
	distance		real	NOT NULL,
	CONSTRAINT STAGE_PK PRIMARY KEY ([date],startLocation,endLocation)
 );

CREATE TABLE Prize (
	id			int		NOT NULL,
	sponsorID	int,
	eventNumber int		NOT NULL,
	receiverID	int,
	value		real,
	CONSTRAINT PRIZE_PK PRIMARY KEY (id)
 );

CREATE TABLE Document (
	id				int	NOT NULL,
	eventNumber		int,
	CONSTRAINT DOCUMENT_PK PRIMARY KEY (id)
 );

CREATE TABLE TextFile (
	id		int			NOT NULL,
	content	bincontent	NOT NULL,
	CONSTRAINT TEXTFILE_PK PRIMARY KEY (id)
 );

CREATE TABLE OtherFile (
	id		int		NOT NULL,
	[path]	string	NOT NULL,
	CONSTRAINT OTHERFILE_PK PRIMARY KEY (id)
 );

CREATE TABLE Team (
	name	string	NOT NULL,
	CONSTRAINT TEAM_PK PRIMARY KEY (name)
 );

CREATE TABLE Equipment (
	id			int		NOT NULL,
	participantID	int	NOT NULL,
	category	string,
	description	string,
	CONSTRAINT EQUIPMENT_PK PRIMARY KEY (id)
 );



/********************
 * N to M RELATIONS *
 ********************/

CREATE TABLE SponsorshipEvent (
	sponsorID		int		NOT NULL,
	eventNumber		int		NOT NULL,
	monetaryValue	real	NOT NULL,
	CONSTRAINT SPONSORSHIPEVENT_PK PRIMARY KEY (sponsorID,eventNumber)
 );

CREATE TABLE SponsorshipTeam (
	sponsorID		int		NOT NULL,
	teamName		string	NOT NULL,
	monetaryValue	real	NOT NULL,
	CONSTRAINT SPONSORSHIPTEAM_PK PRIMARY KEY (sponsorID,teamName)
 );

CREATE TABLE StageParticipation (
	participantID		int		NOT NULL,
	eventNumber			int	NOT NULL,
	stageDate			date	NOT NULL,
	stageStartLocation	string	NOT NULL,
	stageEndLocation	string	NOT NULL,
	result				string,
	CONSTRAINT STAGEPARTICIPATION_PK PRIMARY KEY (participantID,eventNumber,stageDate,stageStartLocation,stageEndLocation)
 );

CREATE TABLE ParticipantOnTeam (
	participantID	int		NOT NULL,
	teamName		string	NOT NULL,
	startDate		date	NOT NULL,
	endDate			date	NOT NULL,
	CONSTRAINT PARTICIPANTONTEAM_PK PRIMARY KEY (participantID,teamName)
 );

CREATE TABLE ParticipantEnrollment (
	participantID	int		NOT NULL,
	eventNumber		int		NOT NULL,
	teamName		string,
	dorsal			int,
	CONSTRAINT PARTICIPANTENROLLMENT_PK PRIMARY KEY (participantID,eventNumber)
 );



/****************
 * FOREIGN KEYS *
 ****************/

ALTER TABLE Manager					ADD FOREIGN KEY (id)					REFERENCES [User](id);
ALTER TABLE Sponsor					ADD FOREIGN KEY (id)					REFERENCES [User](id);
ALTER TABLE Participant				ADD FOREIGN KEY (id)					REFERENCES [User](id);

ALTER TABLE [Event]					ADD FOREIGN KEY (managerID)				REFERENCES Manager(id);

ALTER TABLE Stage					ADD FOREIGN KEY (eventNumber)			REFERENCES [Event]([number]);

ALTER TABLE Prize					ADD FOREIGN KEY (sponsorID)				REFERENCES Sponsor(id);
ALTER TABLE Prize					ADD FOREIGN KEY (eventNumber)			REFERENCES [Event]([number]);
ALTER TABLE Prize					ADD FOREIGN KEY (receiverID)			REFERENCES Participant(id);

ALTER TABLE Document				ADD FOREIGN KEY (eventNumber)			REFERENCES [Event]([number]);

ALTER TABLE TextFile				ADD FOREIGN KEY (id)					REFERENCES Document(id);
ALTER TABLE OtherFile				ADD FOREIGN KEY (id)					REFERENCES Document(id);

ALTER TABLE Equipment				ADD FOREIGN KEY (participantID)			REFERENCES Participant(id);

ALTER TABLE SponsorshipEvent		ADD FOREIGN KEY (sponsorID)				REFERENCES Sponsor(id);
ALTER TABLE SponsorshipEvent		ADD FOREIGN KEY (eventNumber)			REFERENCES [Event]([number]);

ALTER TABLE SponsorshipTeam			ADD FOREIGN KEY (sponsorID)				REFERENCES Sponsor(id);
ALTER TABLE SponsorshipTeam			ADD FOREIGN KEY (teamName)				REFERENCES Team([name]);

ALTER TABLE StageParticipation		ADD FOREIGN KEY (participantID)			REFERENCES Participant(id);
ALTER TABLE StageParticipation		ADD FOREIGN KEY (eventNumber)			REFERENCES [Event]([number]);
ALTER TABLE StageParticipation		ADD FOREIGN KEY (stageDate,stageStartLocation,stageEndLocation)
	REFERENCES Stage([date],startLocation,endLocation);

ALTER TABLE ParticipantOnTeam		ADD FOREIGN KEY (participantID)			REFERENCES Participant(id);
ALTER TABLE ParticipantOnTeam		ADD FOREIGN KEY (teamName)				REFERENCES Team([name]);

ALTER TABLE ParticipantEnrollment	ADD FOREIGN KEY (participantID)			REFERENCES Participant(id);
ALTER TABLE ParticipantEnrollment	ADD FOREIGN KEY (eventNumber)			REFERENCES [Event]([number]);
ALTER TABLE ParticipantEnrollment	ADD FOREIGN KEY (teamName)				REFERENCES Team([name]);