USE [master]
GO
/****** Object:  Database [YACM]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE DATABASE [YACM]
GO
ALTER DATABASE [YACM] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YACM].[dbo].[sp_fulltext_database] @action = 'enable'
end
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
ALTER DATABASE [YACM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [YACM] SET AUTO_SHRINK OFF 
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
ALTER DATABASE [YACM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [YACM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YACM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YACM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YACM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YACM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YACM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YACM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YACM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [YACM] SET  MULTI_USER 
GO
ALTER DATABASE [YACM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YACM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YACM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YACM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [YACM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [YACM]
GO
/****** Object:  Schema [YACM]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE SCHEMA [YACM]
GO
/****** Object:  UserDefinedDataType [dbo].[bincontent]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE TYPE [dbo].[bincontent] FROM [varchar](max) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[string]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE TYPE [dbo].[string] FROM [varchar](50) NULL
GO
/****** Object:  UserDefinedFunction [dbo].[Authenticate]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Authenticate](@userEmail varchar(50), @userPassword varchar(50)) RETURNS @RetVal TABLE (id int, email varchar(50), [name] varchar(50), [password] varchar(50), [type] varchar(50))
AS
	BEGIN
		INSERT @RetVal SELECT P.id, email, name, [password], 'Manager' as 'type' FROM YACM.[User] AS U JOIN YACM.Manager AS P ON U.id = P.id WHERE email=@userEmail AND [password]=@userPassword
		INSERT @RetVal SELECT P.id, email, name, [password], 'Sponsor' as 'type' FROM YACM.[User] AS U JOIN YACM.Sponsor AS P ON U.id = P.id WHERE email=@userEmail AND [password]=@userPassword
		INSERT @RetVal SELECT P.id, email, name, [password], 'Participant' as 'type' FROM YACM.[User] AS U JOIN YACM.Participant AS P ON U.id = P.id WHERE email=@userEmail AND [password]=@userPassword
		RETURN;
	END;

GO
/****** Object:  UserDefinedFunction [dbo].[GetEventDocuments]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetEventDocuments](@eventID int) RETURNS @RetVal TABLE (id int, eventNumber int, content varbinary(MAX), [path] varchar(50))
AS
	BEGIN
		INSERT @RetVal SELECT * FROM YACM.Document JOIN YACM.TextFile ON YACM.Document.id=YACM.TextFile.id WHERE eventNumber=@eventID;
		INSERT @RetVal SELECT * FROM YACM.Document JOIN YACM.OtherFile ON YACM.Document.id=YACM.OtherFile.id WHERE eventNumber=@eventID;
		RETURN;
	END;

GO
/****** Object:  UserDefinedFunction [dbo].[GetEventPrizes]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetEventPrizes](@eventID int) RETURNS @RetVal TABLE (id int, sponsorID int, eventNumber int, receiverID int, [value] real)
AS
	BEGIN
		INSERT @RetVal SELECT * FROM YACM.Prize WHERE eventNumber=@eventID;
		RETURN;
	END;

GO
/****** Object:  UserDefinedFunction [dbo].[GetManagerEvents]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetManagerEvents] (@managerEmail varchar(50)) RETURNS @RetVal TABLE (number int, [name] varchar(50), beginningDate date, endDate date, visibility bit)
AS
	BEGIN
		INSERT @RetVal SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
			JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
			JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
			WHERE YACM.[User].email = @managerEmail
		RETURN;
	END

GO
/****** Object:  UserDefinedFunction [dbo].[GetOtherEvents]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetOtherEvents] (@managerEmail varchar(50)) RETURNS @RetVal TABLE (number int, [name] varchar(50), beginningDate date, endDate date, visibility bit)
AS
	BEGIN
		INSERT @RetVal SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
			JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
			JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
			WHERE YACM.[User].email != @managerEmail
		RETURN;
	END

GO
/****** Object:  UserDefinedFunction [dbo].[GetOtherVisibleEvents]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetOtherVisibleEvents](@managerEmail varchar(50)) RETURNS @RetVal TABLE (number int, [name] varchar(50), beginningDate date, endDate date, visibility bit)
AS
	BEGIN
		INSERT @RetVal SELECT YACM.[Event].number,YACM.[Event].[name],YACM.[Event].beginningDate,YACM.[Event].endDate,YACM.[Event].visibility FROM YACM.[Event]
			JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
			JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
			WHERE YACM.[User].email != @managerEmail AND YACM.[Event].visibility = 1
		RETURN;
	END

GO
/****** Object:  UserDefinedFunction [dbo].[GetTeamsStatus]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetTeamsStatus](@eventID int) RETURNS @RetVal TABLE (eventID int, teamName varchar(50), teamBudget int, numberOfAthletes int)
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
/****** Object:  Table [YACM].[Document]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[Document](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eventNumber] [int] NULL,
 CONSTRAINT [DOCUMENT_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[Equipment]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[Equipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[participantID] [int] NOT NULL,
	[category] [dbo].[string] NULL,
	[description] [dbo].[string] NULL,
 CONSTRAINT [EQUIPMENT_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[Event]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[Event](
	[number] [int] IDENTITY(1,1) NOT NULL,
	[name] [dbo].[string] NOT NULL,
	[beginningDate] [date] NOT NULL,
	[endDate] [date] NULL,
	[visibility] [bit] NOT NULL,
	[managerID] [int] NOT NULL,
 CONSTRAINT [EVENT_PK] PRIMARY KEY CLUSTERED 
(
	[number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[Manager]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[Manager](
	[id] [int] NOT NULL,
 CONSTRAINT [MANAGER_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[OtherFile]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[OtherFile](
	[id] [int] NOT NULL,
	[path] [dbo].[string] NOT NULL,
 CONSTRAINT [OTHERFILE_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[Participant]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[Participant](
	[id] [int] NOT NULL,
 CONSTRAINT [PARTICIPANT_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[ParticipantDropOut]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[ParticipantDropOut](
	[participantID] [int] NOT NULL,
	[eventNumber] [int] NOT NULL,
 CONSTRAINT [PARTICIPANTDROPOUT_PK] PRIMARY KEY CLUSTERED 
(
	[participantID] ASC,
	[eventNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[ParticipantEnrollment]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[ParticipantEnrollment](
	[participantID] [int] NOT NULL,
	[eventNumber] [int] NOT NULL,
	[teamName] [dbo].[string] NULL,
	[dorsal] [int] NULL,
 CONSTRAINT [PARTICIPANTENROLLMENT_PK] PRIMARY KEY CLUSTERED 
(
	[participantID] ASC,
	[eventNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[ParticipantOnTeam]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[ParticipantOnTeam](
	[participantID] [int] NOT NULL,
	[teamName] [dbo].[string] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
 CONSTRAINT [PARTICIPANTONTEAM_PK] PRIMARY KEY CLUSTERED 
(
	[participantID] ASC,
	[teamName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[Prize]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[Prize](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sponsorID] [int] NULL,
	[eventNumber] [int] NOT NULL,
	[receiverID] [int] NULL,
	[value] [real] NULL,
 CONSTRAINT [PRIZE_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[Sponsor]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[Sponsor](
	[id] [int] NOT NULL,
 CONSTRAINT [SPONSOR_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[SponsorshipEvent]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [YACM].[SponsorshipEvent](
	[sponsorID] [int] NOT NULL,
	[eventNumber] [int] NOT NULL,
	[monetaryValue] [real] NOT NULL,
 CONSTRAINT [SPONSORSHIPEVENT_PK] PRIMARY KEY CLUSTERED 
(
	[sponsorID] ASC,
	[eventNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [YACM].[SponsorshipTeam]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[SponsorshipTeam](
	[sponsorID] [int] NOT NULL,
	[teamName] [dbo].[string] NOT NULL,
	[monetaryValue] [real] NOT NULL,
 CONSTRAINT [SPONSORSHIPTEAM_PK] PRIMARY KEY CLUSTERED 
(
	[sponsorID] ASC,
	[teamName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[Stage]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[Stage](
	[date] [date] NOT NULL,
	[startLocation] [dbo].[string] NOT NULL,
	[endLocation] [dbo].[string] NOT NULL,
	[eventNumber] [int] NOT NULL,
	[distance] [real] NOT NULL,
 CONSTRAINT [STAGE_PK] PRIMARY KEY CLUSTERED 
(
	[date] ASC,
	[startLocation] ASC,
	[endLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[StageParticipation]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[StageParticipation](
	[participantID] [int] NOT NULL,
	[eventNumber] [int] NOT NULL,
	[stageDate] [date] NOT NULL,
	[stageStartLocation] [dbo].[string] NOT NULL,
	[stageEndLocation] [dbo].[string] NOT NULL,
	[result] [dbo].[string] NULL,
 CONSTRAINT [STAGEPARTICIPATION_PK] PRIMARY KEY CLUSTERED 
(
	[participantID] ASC,
	[eventNumber] ASC,
	[stageDate] ASC,
	[stageStartLocation] ASC,
	[stageEndLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[Team]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[Team](
	[name] [dbo].[string] NOT NULL,
 CONSTRAINT [TEAM_PK] PRIMARY KEY CLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[TextFile]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[TextFile](
	[id] [int] NOT NULL,
	[content] [dbo].[bincontent] NOT NULL,
 CONSTRAINT [TEXTFILE_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [YACM].[User]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [YACM].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [dbo].[string] NOT NULL,
	[name] [dbo].[string] NOT NULL,
	[password] [dbo].[string] NOT NULL,
 CONSTRAINT [USER_PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [YACM].[Equipment] ON 

INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (1, 122, N'Bike', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (2, 122, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (3, 122, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (4, 122, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (5, 122, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (6, 23, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (7, 23, N'Bike', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (8, 19, N'Bike', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (9, 71, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (10, 139, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (11, 24, N'Bike', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (12, 132, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (13, 150, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (14, 149, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (15, 135, N'Bike', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (16, 25, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (17, 25, N'Shorts', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (18, 139, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (19, 13, N'Others', N'To be provided')
INSERT [YACM].[Equipment] ([id], [participantID], [category], [description]) VALUES (20, 68, N'Others', N'To be provided')
SET IDENTITY_INSERT [YACM].[Equipment] OFF
SET IDENTITY_INSERT [YACM].[Event] ON 

INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (1, N'Milan–San Remo', CAST(N'2019-08-09' AS Date), CAST(N'2019-08-14' AS Date), 0, 159)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (2, N'Tour of Flanders', CAST(N'2019-01-11' AS Date), CAST(N'2019-01-20' AS Date), 1, 159)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (3, N'Paris–Roubaix', CAST(N'2019-03-19' AS Date), CAST(N'2019-03-24' AS Date), 0, 159)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (4, N'Liège–Bastogne–Liège', CAST(N'2017-06-22' AS Date), CAST(N'2017-06-25' AS Date), 0, 159)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (5, N'Giro di Lombardia', CAST(N'2017-05-29' AS Date), CAST(N'2017-06-14' AS Date), 0, 169)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (6, N'Cadel Evans Great Ocean Road Race', CAST(N'2018-04-14' AS Date), CAST(N'2018-04-28' AS Date), 1, 170)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (7, N'E3 Harelbeke', CAST(N'2019-04-20' AS Date), CAST(N'2019-04-28' AS Date), 1, 166)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (8, N'Gent–Wevelgem', CAST(N'2019-06-10' AS Date), CAST(N'2019-06-30' AS Date), 1, 165)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (9, N'La Flèche Wallonne', CAST(N'2018-03-15' AS Date), CAST(N'2018-03-26' AS Date), 0, 171)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (10, N'Amstel Gold Race', CAST(N'2017-10-18' AS Date), CAST(N'2017-10-29' AS Date), 1, 160)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (11, N'Clásica de San Sebastián', CAST(N'2018-11-01' AS Date), CAST(N'2018-11-06' AS Date), 1, 170)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (12, N'Bretagne Classic', CAST(N'2018-08-11' AS Date), CAST(N'2018-08-16' AS Date), 0, 170)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (13, N'Vattenfall Cyclassics', CAST(N'2019-02-04' AS Date), CAST(N'2019-02-09' AS Date), 0, 162)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (14, N'GP de Quebec.  Canada', CAST(N'2019-12-19' AS Date), CAST(N'2019-12-28' AS Date), 1, 167)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (15, N'GP de Montréal', CAST(N'2017-05-23' AS Date), CAST(N'2017-05-31' AS Date), 0, 171)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (16, N'Tour of Britain', CAST(N'2019-05-29' AS Date), CAST(N'2019-06-01' AS Date), 0, 165)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (17, N'Tour of Alberta', CAST(N'2018-12-29' AS Date), CAST(N'2018-12-31' AS Date), 1, 170)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (18, N'Tour de France', CAST(N'2018-11-11' AS Date), CAST(N'2018-11-21' AS Date), 0, 163)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (19, N'Volta de Portugal', CAST(N'2017-06-24' AS Date), CAST(N'2017-07-01' AS Date), 0, 160)
INSERT [YACM].[Event] ([number], [name], [beginningDate], [endDate], [visibility], [managerID]) VALUES (20, N'Vuelta a Galicia ', CAST(N'2019-08-10' AS Date), CAST(N'2019-08-21' AS Date), 0, 165)
SET IDENTITY_INSERT [YACM].[Event] OFF
INSERT [YACM].[Manager] ([id]) VALUES (159)
INSERT [YACM].[Manager] ([id]) VALUES (160)
INSERT [YACM].[Manager] ([id]) VALUES (161)
INSERT [YACM].[Manager] ([id]) VALUES (162)
INSERT [YACM].[Manager] ([id]) VALUES (163)
INSERT [YACM].[Manager] ([id]) VALUES (164)
INSERT [YACM].[Manager] ([id]) VALUES (165)
INSERT [YACM].[Manager] ([id]) VALUES (166)
INSERT [YACM].[Manager] ([id]) VALUES (167)
INSERT [YACM].[Manager] ([id]) VALUES (168)
INSERT [YACM].[Manager] ([id]) VALUES (169)
INSERT [YACM].[Manager] ([id]) VALUES (170)
INSERT [YACM].[Manager] ([id]) VALUES (171)
INSERT [YACM].[Manager] ([id]) VALUES (173)
INSERT [YACM].[Participant] ([id]) VALUES (1)
INSERT [YACM].[Participant] ([id]) VALUES (2)
INSERT [YACM].[Participant] ([id]) VALUES (3)
INSERT [YACM].[Participant] ([id]) VALUES (4)
INSERT [YACM].[Participant] ([id]) VALUES (5)
INSERT [YACM].[Participant] ([id]) VALUES (6)
INSERT [YACM].[Participant] ([id]) VALUES (7)
INSERT [YACM].[Participant] ([id]) VALUES (8)
INSERT [YACM].[Participant] ([id]) VALUES (9)
INSERT [YACM].[Participant] ([id]) VALUES (10)
INSERT [YACM].[Participant] ([id]) VALUES (11)
INSERT [YACM].[Participant] ([id]) VALUES (12)
INSERT [YACM].[Participant] ([id]) VALUES (13)
INSERT [YACM].[Participant] ([id]) VALUES (14)
INSERT [YACM].[Participant] ([id]) VALUES (15)
INSERT [YACM].[Participant] ([id]) VALUES (16)
INSERT [YACM].[Participant] ([id]) VALUES (17)
INSERT [YACM].[Participant] ([id]) VALUES (18)
INSERT [YACM].[Participant] ([id]) VALUES (19)
INSERT [YACM].[Participant] ([id]) VALUES (20)
INSERT [YACM].[Participant] ([id]) VALUES (21)
INSERT [YACM].[Participant] ([id]) VALUES (22)
INSERT [YACM].[Participant] ([id]) VALUES (23)
INSERT [YACM].[Participant] ([id]) VALUES (24)
INSERT [YACM].[Participant] ([id]) VALUES (25)
INSERT [YACM].[Participant] ([id]) VALUES (26)
INSERT [YACM].[Participant] ([id]) VALUES (27)
INSERT [YACM].[Participant] ([id]) VALUES (28)
INSERT [YACM].[Participant] ([id]) VALUES (29)
INSERT [YACM].[Participant] ([id]) VALUES (30)
INSERT [YACM].[Participant] ([id]) VALUES (31)
INSERT [YACM].[Participant] ([id]) VALUES (32)
INSERT [YACM].[Participant] ([id]) VALUES (33)
INSERT [YACM].[Participant] ([id]) VALUES (34)
INSERT [YACM].[Participant] ([id]) VALUES (35)
INSERT [YACM].[Participant] ([id]) VALUES (36)
INSERT [YACM].[Participant] ([id]) VALUES (37)
INSERT [YACM].[Participant] ([id]) VALUES (38)
INSERT [YACM].[Participant] ([id]) VALUES (39)
INSERT [YACM].[Participant] ([id]) VALUES (40)
INSERT [YACM].[Participant] ([id]) VALUES (41)
INSERT [YACM].[Participant] ([id]) VALUES (42)
INSERT [YACM].[Participant] ([id]) VALUES (43)
INSERT [YACM].[Participant] ([id]) VALUES (44)
INSERT [YACM].[Participant] ([id]) VALUES (45)
INSERT [YACM].[Participant] ([id]) VALUES (46)
INSERT [YACM].[Participant] ([id]) VALUES (47)
INSERT [YACM].[Participant] ([id]) VALUES (48)
INSERT [YACM].[Participant] ([id]) VALUES (49)
INSERT [YACM].[Participant] ([id]) VALUES (50)
INSERT [YACM].[Participant] ([id]) VALUES (51)
INSERT [YACM].[Participant] ([id]) VALUES (52)
INSERT [YACM].[Participant] ([id]) VALUES (53)
INSERT [YACM].[Participant] ([id]) VALUES (54)
INSERT [YACM].[Participant] ([id]) VALUES (55)
INSERT [YACM].[Participant] ([id]) VALUES (57)
INSERT [YACM].[Participant] ([id]) VALUES (58)
INSERT [YACM].[Participant] ([id]) VALUES (59)
INSERT [YACM].[Participant] ([id]) VALUES (60)
INSERT [YACM].[Participant] ([id]) VALUES (61)
INSERT [YACM].[Participant] ([id]) VALUES (62)
INSERT [YACM].[Participant] ([id]) VALUES (63)
INSERT [YACM].[Participant] ([id]) VALUES (64)
INSERT [YACM].[Participant] ([id]) VALUES (65)
INSERT [YACM].[Participant] ([id]) VALUES (66)
INSERT [YACM].[Participant] ([id]) VALUES (67)
INSERT [YACM].[Participant] ([id]) VALUES (68)
INSERT [YACM].[Participant] ([id]) VALUES (69)
INSERT [YACM].[Participant] ([id]) VALUES (70)
INSERT [YACM].[Participant] ([id]) VALUES (71)
INSERT [YACM].[Participant] ([id]) VALUES (72)
INSERT [YACM].[Participant] ([id]) VALUES (73)
INSERT [YACM].[Participant] ([id]) VALUES (74)
INSERT [YACM].[Participant] ([id]) VALUES (75)
INSERT [YACM].[Participant] ([id]) VALUES (76)
INSERT [YACM].[Participant] ([id]) VALUES (77)
INSERT [YACM].[Participant] ([id]) VALUES (78)
INSERT [YACM].[Participant] ([id]) VALUES (79)
INSERT [YACM].[Participant] ([id]) VALUES (80)
INSERT [YACM].[Participant] ([id]) VALUES (82)
INSERT [YACM].[Participant] ([id]) VALUES (83)
INSERT [YACM].[Participant] ([id]) VALUES (84)
INSERT [YACM].[Participant] ([id]) VALUES (85)
INSERT [YACM].[Participant] ([id]) VALUES (86)
INSERT [YACM].[Participant] ([id]) VALUES (87)
INSERT [YACM].[Participant] ([id]) VALUES (88)
INSERT [YACM].[Participant] ([id]) VALUES (89)
INSERT [YACM].[Participant] ([id]) VALUES (90)
INSERT [YACM].[Participant] ([id]) VALUES (91)
INSERT [YACM].[Participant] ([id]) VALUES (92)
INSERT [YACM].[Participant] ([id]) VALUES (93)
INSERT [YACM].[Participant] ([id]) VALUES (94)
INSERT [YACM].[Participant] ([id]) VALUES (95)
INSERT [YACM].[Participant] ([id]) VALUES (96)
INSERT [YACM].[Participant] ([id]) VALUES (97)
INSERT [YACM].[Participant] ([id]) VALUES (98)
INSERT [YACM].[Participant] ([id]) VALUES (99)
INSERT [YACM].[Participant] ([id]) VALUES (101)
INSERT [YACM].[Participant] ([id]) VALUES (102)
INSERT [YACM].[Participant] ([id]) VALUES (103)
GO
INSERT [YACM].[Participant] ([id]) VALUES (104)
INSERT [YACM].[Participant] ([id]) VALUES (105)
INSERT [YACM].[Participant] ([id]) VALUES (106)
INSERT [YACM].[Participant] ([id]) VALUES (108)
INSERT [YACM].[Participant] ([id]) VALUES (110)
INSERT [YACM].[Participant] ([id]) VALUES (111)
INSERT [YACM].[Participant] ([id]) VALUES (112)
INSERT [YACM].[Participant] ([id]) VALUES (113)
INSERT [YACM].[Participant] ([id]) VALUES (114)
INSERT [YACM].[Participant] ([id]) VALUES (115)
INSERT [YACM].[Participant] ([id]) VALUES (116)
INSERT [YACM].[Participant] ([id]) VALUES (117)
INSERT [YACM].[Participant] ([id]) VALUES (118)
INSERT [YACM].[Participant] ([id]) VALUES (119)
INSERT [YACM].[Participant] ([id]) VALUES (120)
INSERT [YACM].[Participant] ([id]) VALUES (121)
INSERT [YACM].[Participant] ([id]) VALUES (122)
INSERT [YACM].[Participant] ([id]) VALUES (123)
INSERT [YACM].[Participant] ([id]) VALUES (124)
INSERT [YACM].[Participant] ([id]) VALUES (126)
INSERT [YACM].[Participant] ([id]) VALUES (128)
INSERT [YACM].[Participant] ([id]) VALUES (129)
INSERT [YACM].[Participant] ([id]) VALUES (130)
INSERT [YACM].[Participant] ([id]) VALUES (131)
INSERT [YACM].[Participant] ([id]) VALUES (133)
INSERT [YACM].[Participant] ([id]) VALUES (134)
INSERT [YACM].[Participant] ([id]) VALUES (135)
INSERT [YACM].[Participant] ([id]) VALUES (136)
INSERT [YACM].[Participant] ([id]) VALUES (137)
INSERT [YACM].[Participant] ([id]) VALUES (138)
INSERT [YACM].[Participant] ([id]) VALUES (139)
INSERT [YACM].[Participant] ([id]) VALUES (140)
INSERT [YACM].[Participant] ([id]) VALUES (142)
INSERT [YACM].[Participant] ([id]) VALUES (144)
INSERT [YACM].[Participant] ([id]) VALUES (145)
INSERT [YACM].[Participant] ([id]) VALUES (146)
INSERT [YACM].[Participant] ([id]) VALUES (147)
INSERT [YACM].[Participant] ([id]) VALUES (148)
INSERT [YACM].[Participant] ([id]) VALUES (149)
INSERT [YACM].[Participant] ([id]) VALUES (150)
INSERT [YACM].[Participant] ([id]) VALUES (151)
INSERT [YACM].[Participant] ([id]) VALUES (152)
INSERT [YACM].[Participant] ([id]) VALUES (153)
INSERT [YACM].[Participant] ([id]) VALUES (154)
INSERT [YACM].[Participant] ([id]) VALUES (155)
INSERT [YACM].[Participant] ([id]) VALUES (156)
INSERT [YACM].[Participant] ([id]) VALUES (157)
INSERT [YACM].[Participant] ([id]) VALUES (158)
INSERT [YACM].[Participant] ([id]) VALUES (174)
INSERT [YACM].[Participant] ([id]) VALUES (175)
INSERT [YACM].[Participant] ([id]) VALUES (177)
INSERT [YACM].[Participant] ([id]) VALUES (178)
INSERT [YACM].[Participant] ([id]) VALUES (179)
INSERT [YACM].[Participant] ([id]) VALUES (180)
INSERT [YACM].[Participant] ([id]) VALUES (181)
INSERT [YACM].[Participant] ([id]) VALUES (182)
INSERT [YACM].[Participant] ([id]) VALUES (183)
INSERT [YACM].[Participant] ([id]) VALUES (184)
INSERT [YACM].[Participant] ([id]) VALUES (185)
INSERT [YACM].[Participant] ([id]) VALUES (186)
INSERT [YACM].[Participant] ([id]) VALUES (187)
INSERT [YACM].[Participant] ([id]) VALUES (188)
INSERT [YACM].[Participant] ([id]) VALUES (189)
INSERT [YACM].[Participant] ([id]) VALUES (190)
INSERT [YACM].[Participant] ([id]) VALUES (191)
INSERT [YACM].[Participant] ([id]) VALUES (192)
INSERT [YACM].[Participant] ([id]) VALUES (193)
INSERT [YACM].[Participant] ([id]) VALUES (194)
INSERT [YACM].[Participant] ([id]) VALUES (195)
INSERT [YACM].[Participant] ([id]) VALUES (196)
INSERT [YACM].[Participant] ([id]) VALUES (197)
INSERT [YACM].[Participant] ([id]) VALUES (198)
INSERT [YACM].[Participant] ([id]) VALUES (199)
INSERT [YACM].[Participant] ([id]) VALUES (200)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (177, 11)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (183, 13)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (185, 18)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (186, 8)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (189, 2)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (189, 12)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (195, 2)
INSERT [YACM].[ParticipantDropOut] ([participantID], [eventNumber]) VALUES (199, 16)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (10, 7, N'Groupama - FDJ ', 5)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (20, 3, N'BORA - hansgrohe ', 10)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (20, 13, N'Team Jumbo-Visma ', 8)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (27, 11, N'Team Dimension Data ', 8)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (27, 16, N'Trek - Segafredo ', 4)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (38, 10, N'Movistar Team ', 6)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (47, 2, N'Bahrain Merida ', 6)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (52, 6, N'EF Education First ', 6)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (73, 5, N'Deceuninck - Quick Step ', 1)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (83, 14, N'Team Katusha - Alpecin ', 9)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (87, 12, N'Team INEOS ', 8)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (122, 1, N'Astana Pro Team ', 1)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (126, 4, N'CCC Team ', 2)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (128, 15, N'Team Sunweb ', 8)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (148, 9, N'Mitchelton-Scott ', 6)
INSERT [YACM].[ParticipantEnrollment] ([participantID], [eventNumber], [teamName], [dorsal]) VALUES (158, 8, N'Lotto Soudal ', 7)
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (10, N'Groupama - FDJ ', CAST(N'2017-09-22' AS Date), CAST(N'2017-10-05' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (20, N'BORA - hansgrohe ', CAST(N'2019-04-30' AS Date), CAST(N'2019-05-06' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (20, N'Team Jumbo-Visma ', CAST(N'2017-12-31' AS Date), CAST(N'2018-01-02' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (27, N'Team Dimension Data ', CAST(N'2019-11-04' AS Date), CAST(N'2019-11-14' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (27, N'Trek - Segafredo ', CAST(N'2018-12-26' AS Date), CAST(N'2018-12-30' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (38, N'Movistar Team ', CAST(N'2017-04-02' AS Date), CAST(N'2017-04-15' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (47, N'Bahrain Merida ', CAST(N'2018-01-02' AS Date), CAST(N'2018-01-19' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (52, N'EF Education First ', CAST(N'2017-03-15' AS Date), CAST(N'2017-04-01' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (73, N'Deceuninck - Quick Step ', CAST(N'2017-01-05' AS Date), CAST(N'2017-01-20' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (83, N'Team Katusha - Alpecin ', CAST(N'2018-03-20' AS Date), CAST(N'2018-03-31' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (87, N'Team INEOS ', CAST(N'2019-11-29' AS Date), CAST(N'2019-12-04' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (122, N'Astana Pro Team ', CAST(N'2019-05-24' AS Date), CAST(N'2019-06-05' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (126, N'CCC Team ', CAST(N'2017-11-02' AS Date), CAST(N'2017-11-11' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (128, N'Team Sunweb ', CAST(N'2019-10-11' AS Date), CAST(N'2019-10-31' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (148, N'Mitchelton-Scott ', CAST(N'2019-04-25' AS Date), CAST(N'2019-04-28' AS Date))
INSERT [YACM].[ParticipantOnTeam] ([participantID], [teamName], [startDate], [endDate]) VALUES (158, N'Lotto Soudal ', CAST(N'2019-01-04' AS Date), CAST(N'2019-01-15' AS Date))
SET IDENTITY_INSERT [YACM].[Prize] ON 

INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (1, 210, 1, 122, 1370)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (2, 203, 2, 47, 2834)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (3, 207, 3, 20, 9154)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (4, 202, 4, 126, 3385)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (5, 207, 5, 73, 7426)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (6, 204, 6, 52, 6286)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (7, 208, 7, 10, 2592)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (8, 207, 8, 158, 2893)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (9, 201, 9, 148, 6973)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (10, 202, 10, 38, 2096)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (11, 202, 11, 27, 4188)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (12, 207, 12, 87, 4930)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (13, 202, 13, 20, 6145)
INSERT [YACM].[Prize] ([id], [sponsorID], [eventNumber], [receiverID], [value]) VALUES (14, 208, 14, 83, 7247)
SET IDENTITY_INSERT [YACM].[Prize] OFF
INSERT [YACM].[Sponsor] ([id]) VALUES (201)
INSERT [YACM].[Sponsor] ([id]) VALUES (202)
INSERT [YACM].[Sponsor] ([id]) VALUES (203)
INSERT [YACM].[Sponsor] ([id]) VALUES (204)
INSERT [YACM].[Sponsor] ([id]) VALUES (205)
INSERT [YACM].[Sponsor] ([id]) VALUES (206)
INSERT [YACM].[Sponsor] ([id]) VALUES (207)
INSERT [YACM].[Sponsor] ([id]) VALUES (208)
INSERT [YACM].[Sponsor] ([id]) VALUES (209)
INSERT [YACM].[Sponsor] ([id]) VALUES (210)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (201, 9, 57552)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (202, 4, 65366)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (202, 10, 1193)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (202, 11, 3602)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (202, 13, 64986)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (203, 1, 7531)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (204, 6, 74981)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (207, 1, 63000)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (207, 5, 76165)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (207, 8, 71112)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (207, 12, 44125)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (208, 7, 63693)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (208, 14, 61869)
INSERT [YACM].[SponsorshipEvent] ([sponsorID], [eventNumber], [monetaryValue]) VALUES (210, 1, 67029)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (202, N'Astana Pro Team ', 12410)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (202, N'EF Education First ', 31622)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (202, N'Groupama - FDJ ', 42558)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (202, N'Movistar Team ', 29160)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (203, N'Deceuninck - Quick Step ', 66771)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (203, N'Mitchelton-Scott ', 42563)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (203, N'Team Katusha - Alpecin ', 29526)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (204, N'CCC Team ', 48152)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (206, N'BORA - hansgrohe ', 26893)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (208, N'Bahrain Merida ', 85666)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (209, N'Team Dimension Data ', 10765)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (209, N'Team Jumbo-Visma ', 4314)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (210, N'Lotto Soudal ', 48851)
INSERT [YACM].[SponsorshipTeam] ([sponsorID], [teamName], [monetaryValue]) VALUES (210, N'Team INEOS ', 57220)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2017-06-10' AS Date), N'Paris', N'Paris', 7, 2424)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2017-06-23' AS Date), N'Paris', N'Paris', 4, 126)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2017-10-16' AS Date), N'Lisboa', N'New York City', 2, 5906)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2017-12-09' AS Date), N'New York City', N'New York City', 3, 6331)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2018-01-09' AS Date), N'Aveiro', N'Aveiro', 10, 660)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2018-02-24' AS Date), N'Lisboa', N'Lisboa', 13, 4330)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2018-03-06' AS Date), N'Paris', N'New York City', 9, 4290)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2018-03-18' AS Date), N'New York City', N'New York City', 8, 5894)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2018-10-31' AS Date), N'Lisboa', N'New York City', 16, 3137)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-03-10' AS Date), N'New York City', N'Lisboa', 12, 664)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-08-10' AS Date), N'Aveiro', N'Lisboa', 11, 6446)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-08-15' AS Date), N'Aveiro', N'Paris', 6, 2620)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-08-15' AS Date), N'New York City', N'Lisboa', 15, 6722)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-08-29' AS Date), N'Lisboa', N'Aveiro', 14, 669)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-09-25' AS Date), N'New York City', N'Aveiro', 1, 3983)
INSERT [YACM].[Stage] ([date], [startLocation], [endLocation], [eventNumber], [distance]) VALUES (CAST(N'2019-09-29' AS Date), N'Paris', N'Aveiro', 5, 1490)
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (10, 7, CAST(N'2017-06-10' AS Date), N'Paris', N'Paris', N'3.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (20, 3, CAST(N'2017-12-09' AS Date), N'New York City', N'New York City', N'1.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (20, 13, CAST(N'2018-02-24' AS Date), N'Lisboa', N'Lisboa', N'9.8 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (27, 11, CAST(N'2019-08-10' AS Date), N'Aveiro', N'Lisboa', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (27, 16, CAST(N'2018-10-31' AS Date), N'Lisboa', N'New York City', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (38, 10, CAST(N'2018-01-09' AS Date), N'Aveiro', N'Aveiro', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (47, 2, CAST(N'2017-10-16' AS Date), N'Lisboa', N'New York City', N'9.8 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (52, 6, CAST(N'2019-08-15' AS Date), N'Aveiro', N'Paris', N'1.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (73, 5, CAST(N'2019-09-29' AS Date), N'Paris', N'Aveiro', N'9.8 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (83, 14, CAST(N'2019-08-29' AS Date), N'Lisboa', N'Aveiro', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (87, 12, CAST(N'2019-03-10' AS Date), N'New York City', N'Lisboa', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (122, 1, CAST(N'2019-09-25' AS Date), N'New York City', N'Aveiro', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (126, 4, CAST(N'2017-06-23' AS Date), N'Paris', N'Paris', N'1.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (128, 15, CAST(N'2019-08-15' AS Date), N'New York City', N'Lisboa', N'1.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (148, 9, CAST(N'2018-03-06' AS Date), N'Paris', N'New York City', N'4.5 hours')
INSERT [YACM].[StageParticipation] ([participantID], [eventNumber], [stageDate], [stageStartLocation], [stageEndLocation], [result]) VALUES (158, 8, CAST(N'2018-03-18' AS Date), N'New York City', N'New York City', N'9.8 hours')
INSERT [YACM].[Team] ([name]) VALUES (N'AG2R La Mondiale ')
INSERT [YACM].[Team] ([name]) VALUES (N'Astana Pro Team ')
INSERT [YACM].[Team] ([name]) VALUES (N'Bahrain Merida ')
INSERT [YACM].[Team] ([name]) VALUES (N'BORA - hansgrohe ')
INSERT [YACM].[Team] ([name]) VALUES (N'CCC Team ')
INSERT [YACM].[Team] ([name]) VALUES (N'Deceuninck - Quick Step ')
INSERT [YACM].[Team] ([name]) VALUES (N'EF Education First ')
INSERT [YACM].[Team] ([name]) VALUES (N'Groupama - FDJ ')
INSERT [YACM].[Team] ([name]) VALUES (N'Lotto Soudal ')
INSERT [YACM].[Team] ([name]) VALUES (N'Mitchelton-Scott ')
INSERT [YACM].[Team] ([name]) VALUES (N'Movistar Team ')
INSERT [YACM].[Team] ([name]) VALUES (N'Team Dimension Data ')
INSERT [YACM].[Team] ([name]) VALUES (N'Team INEOS ')
INSERT [YACM].[Team] ([name]) VALUES (N'Team Jumbo-Visma ')
INSERT [YACM].[Team] ([name]) VALUES (N'Team Katusha - Alpecin ')
INSERT [YACM].[Team] ([name]) VALUES (N'Team Sunweb ')
INSERT [YACM].[Team] ([name]) VALUES (N'Trek - Segafredo ')
INSERT [YACM].[Team] ([name]) VALUES (N'UAE-Team Emirates ')
SET IDENTITY_INSERT [YACM].[User] ON 

INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (1, N'ora69@harvey.net', N'Nicholas Mason', N'jsktujlqqn')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (2, N'n.mason@randatmail.com', N'Eric Dixon', N'mmkr3ib91a')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (3, N'e.dixon@randatmail.com', N'Kevin Howard', N'jf6hh0xv8s')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (4, N'k.howard@randatmail.com', N'Samantha Martin', N'd19snq1kcd')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (5, N's.martin@randatmail.com', N'Sabrina Andrews', N'8k4qzyglbt')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (6, N's.andrews@randatmail.com', N'Mary Allen', N'pfrfp26en7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (7, N'm.allen@randatmail.com', N'Brianna Sullivan', N'veqdav3g8q')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (8, N'b.sullivan@randatmail.com', N'Elian Cunningham', N'l1w7gqo011')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (9, N'e.cunningham@randatmail.com', N'Martin Davis', N'c8rymetmsp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (10, N'm.davis@randatmail.com', N'James Ferguson', N'vzrc3u3jim')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (11, N'j.ferguson@randatmail.com', N'Kristian Morrison', N'zutgufbwvk')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (12, N'k.morrison@randatmail.com', N'Jordan Douglas', N'471qrgptll')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (13, N'j.douglas@randatmail.com', N'Haris Johnson', N'3zzmsv5xue')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (14, N'h.johnson@randatmail.com', N'Frederick Douglas', N'9u435zod2p')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (15, N'f.douglas@randatmail.com', N'Roman Barrett', N'96emb13xht')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (16, N'r.barrett@randatmail.com', N'Edwin Armstrong', N'3clv14448e')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (17, N'e.armstrong@randatmail.com', N'Henry Cooper', N'dx8066fhwm')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (18, N'h.cooper@randatmail.com', N'David Barrett', N'ohnho7xxyj')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (19, N'd.barrett@randatmail.com', N'Amelia Perry', N'hzhwue3t0x')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (20, N'a.perry@randatmail.com', N'Stuart Nelson', N'jgz5vi09sm')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (21, N's.nelson@randatmail.com', N'Lucy Richardson', N'pu5e8qfovv')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (22, N'l.richardson@randatmail.com', N'Lilianna Hamilton', N'pjzxlmcjyx')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (23, N'l.hamilton@randatmail.com', N'Frederick Turner', N'jhi1xufgz4')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (24, N'f.turner@randatmail.com', N'Elian Mitchell', N'lf5kioilym')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (25, N'e.mitchell@randatmail.com', N'Penelope Walker', N'wxdglk694n')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (26, N'p.walker@randatmail.com', N'Dominik Wells', N'3t55xnr1dv')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (27, N'd.wells@randatmail.com', N'Brad Cooper', N'9y327wog5y')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (28, N'b.cooper@randatmail.com', N'Jacob Tucker', N'c6icwaamdn')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (29, N'j.tucker@randatmail.com', N'Eric Cooper', N'be41zo64gi')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (30, N'e.cooper@randatmail.com', N'Victoria Crawford', N'61kbzpfazy')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (31, N'v.crawford@randatmail.com', N'David Andrews', N'qai9d6qua5')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (32, N'd.andrews@randatmail.com', N'Stuart Ross', N'vfl73lq124')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (33, N's.ross@randatmail.com', N'Max Casey', N'izxbhgb755')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (34, N'm.casey@randatmail.com', N'Lilianna Kelly', N'6u34ut43vw')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (35, N'l.kelly@randatmail.com', N'Alissa Edwards', N'uj86yt64ma')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (36, N'a.edwards@randatmail.com', N'Dominik Richards', N'l0pmt1gbr7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (37, N'd.richards@randatmail.com', N'Tara Gray', N'6fr9zrljuu')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (38, N't.gray@randatmail.com', N'Mike Taylor', N'5t9rld0k6d')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (39, N'm.taylor@randatmail.com', N'Michael Barrett', N'q9zeu2h4n7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (40, N'm.barrett@randatmail.com', N'Fiona Baker', N'z2ju89ojbg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (41, N'f.baker@randatmail.com', N'Lucy Crawford', N'k2eqgepsb4')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (42, N'l.crawford@randatmail.com', N'Honey Howard', N'3kfzisjz4f')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (43, N'h.howard@randatmail.com', N'Darcy Kelly', N'tohd4i0l40')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (44, N'd.kelly@randatmail.com', N'Emily Barnes', N'82yp5ijyqv')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (45, N'e.barnes@randatmail.com', N'Julia Carter', N'5kj3x5kwx3')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (46, N'j.carter@randatmail.com', N'Lucas Thompson', N'eayl70iagy')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (47, N'l.thompson@randatmail.com', N'Leonardo Hawkins', N'7ggk9rsql8')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (48, N'l.hawkins@randatmail.com', N'Harold Cunningham', N'z7yky300zu')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (49, N'h.cunningham@randatmail.com', N'Edith Riley', N'ingt98hw36')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (50, N'e.riley@randatmail.com', N'Alissa Scott', N'u0ig8161h1')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (51, N'a.scott@randatmail.com', N'Alford Warren', N'7i3z4zpd7k')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (52, N'a.warren@randatmail.com', N'Alissa Reed', N'm1oz8s9vb7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (53, N'a.reed@randatmail.com', N'Rubie Henderson', N'ngn7y7sc26')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (54, N'r.henderson@randatmail.com', N'Frederick Stevens', N'g0v30m7dj1')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (55, N'f.stevens@randatmail.com', N'Eleanor Dixon', N'pomocqh0my')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (57, N'a.campbell@randatmail.com', N'Brad Davis', N'cd3d82c71v')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (58, N'b.davis@randatmail.com', N'Kelsey Harper', N'pz0rhlja7r')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (59, N'k.harper@randatmail.com', N'Sabrina Farrell', N'pulal9kw7s')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (60, N's.farrell@randatmail.com', N'Charlie Phillips', N'f7mun6l79k')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (61, N'c.phillips@randatmail.com', N'Blake Stewart', N'd0fgswuzp3')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (62, N'b.stewart@randatmail.com', N'Roman Payne', N'8b27lo0ys0')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (63, N'r.payne@randatmail.com', N'Sam Henderson', N'iftxw6i5h5')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (64, N's.henderson@randatmail.com', N'Florrie Wilson', N'mayxs276wh')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (65, N'f.wilson@randatmail.com', N'Richard Elliott', N'9a28dmn49n')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (66, N'r.elliott@randatmail.com', N'Victoria Smith', N'b8w5flle0n')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (67, N'v.smith@randatmail.com', N'Harold Harper', N'gz8jd3748y')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (68, N'h.harper@randatmail.com', N'Aiden Harrison', N'kp9pqwnraw')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (69, N'a.harrison@randatmail.com', N'Rubie Cooper', N'qhmj0bhxrp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (70, N'r.cooper@randatmail.com', N'Alissa Mason', N'mpympite4d')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (71, N'a.mason@randatmail.com', N'Annabella Cole', N'b89zel10f9')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (72, N'a.cole@randatmail.com', N'Amanda Richards', N'prnre0worh')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (73, N'a.richards@randatmail.com', N'Edith Johnson', N'pjcehqaruv')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (74, N'e.johnson@randatmail.com', N'Maddie Wright', N'ua3nko6jgl')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (75, N'm.wright@randatmail.com', N'Roland Crawford', N'ewhg8cywt8')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (76, N'r.crawford@randatmail.com', N'Lana Jones', N'hd81gbda84')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (77, N'l.jones@randatmail.com', N'Roman Taylor', N'l2y29wo625')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (78, N'r.taylor@randatmail.com', N'Roman Ellis', N'i4dnujrgvg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (79, N'r.ellis@randatmail.com', N'Jared Harper', N'o6ln2whdvg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (80, N'j.harper@randatmail.com', N'Annabella Campbell', N'06sgw9pt6n')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (82, N'r.wilson@randatmail.com', N'Audrey Kelly', N's4586vy17m')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (83, N'a.kelly@randatmail.com', N'Carlos Moore', N'2t8q0ijovo')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (84, N'c.moore@randatmail.com', N'Blake Adams', N'fvbyhwfcow')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (85, N'b.adams@randatmail.com', N'Paige Smith', N'wiq7gr364c')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (86, N'p.smith@randatmail.com', N'Michael Carter', N'7da1dahjxe')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (87, N'm.carter@randatmail.com', N'Audrey Wilson', N'q5259qwa2e')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (88, N'a.wilson@randatmail.com', N'Ned Hawkins', N'j4ula0o4ey')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (89, N'n.hawkins@randatmail.com', N'April Stewart', N'4dsfdhu9wg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (90, N'a.stewart@randatmail.com', N'Brad Foster', N'85szj7aer4')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (91, N'b.foster@randatmail.com', N'Jacob Johnston', N'1bdugfhn0z')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (92, N'j.johnston@randatmail.com', N'Dainton Wilson', N'h7k8mkeckr')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (93, N'd.wilson@randatmail.com', N'Alissa Morrison', N'anq7buvuic')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (94, N'a.morrison@randatmail.com', N'Aldus Thompson', N'ntyzl6zzhg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (95, N'a.thompson@randatmail.com', N'Roland Chapman', N'g84wqczbx7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (96, N'r.chapman@randatmail.com', N'Vanessa Richards', N'1m8iicr7da')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (97, N'v.richards@randatmail.com', N'Chloe Ryan', N'pb7kcao3ze')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (98, N'c.ryan@randatmail.com', N'Melanie Brown', N'1j20k3qftg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (99, N'm.brown@randatmail.com', N'Adele Scott', N'00003qrsma')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (101, N's.baker@randatmail.com', N'Belinda Brown', N'izs1j29tyv')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (102, N'b.brown@randatmail.com', N'Derek Holmes', N'r7wzvt0l95')
GO
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (103, N'd.holmes@randatmail.com', N'Victor Higgins', N'ibsrkiuvv8')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (104, N'v.higgins@randatmail.com', N'Michelle Wilson', N'e7rj9atw60')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (105, N'm.wilson@randatmail.com', N'Penelope Stewart', N'htcafm3jkz')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (106, N'p.stewart@randatmail.com', N'Daisy Kelly', N'w2b6slxaea')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (108, N'c.chapman@randatmail.com', N'Ellia Barnes', N'yi969uugur')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (110, N'f.hall@randatmail.com', N'Rafael Lloyd', N'rryqiqp4o7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (111, N'r.lloyd@randatmail.com', N'Ellia Holmes', N'gdab5al8am')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (112, N'e.holmes@randatmail.com', N'Lily Perkins', N'fd73pq0xqc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (113, N'l.perkins@randatmail.com', N'Nicole Richardson', N'c5ovp9pc9p')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (114, N'n.richardson@randatmail.com', N'Victoria Robinson', N'vyxm03bc3g')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (115, N'v.robinson@randatmail.com', N'Kimberly Johnston', N'ae5qrja4nm')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (116, N'k.johnston@randatmail.com', N'Kevin Cameron', N'zh82boqcja')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (117, N'k.cameron@randatmail.com', N'Lydia Miller', N'wg29z88ta1')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (118, N'l.miller@randatmail.com', N'Isabella Miller', N'5notifyp3h')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (119, N'i.miller@randatmail.com', N'Kevin West', N'wwt6bqj6gi')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (120, N'k.west@randatmail.com', N'Miley Alexander', N'2bldx8qavc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (121, N'm.alexander@randatmail.com', N'Sofia Watson', N'63sm4aaxwy')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (122, N's.watson@randatmail.com', N'Madaline Hamilton', N'ybc7nw1lap')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (123, N'm.hamilton@randatmail.com', N'Walter Higgins', N'96uukc87s4')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (124, N'w.higgins@randatmail.com', N'Amelia Reed', N'xcumji451w')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (126, N'd.riley@randatmail.com', N'Amber Richards', N'wvul25rxzz')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (128, N'j.crawford@randatmail.com', N'Sydney Holmes', N'4zwdun95rp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (129, N's.holmes@randatmail.com', N'Valeria Thomas', N'9t56kv1pyc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (130, N'v.thomas@randatmail.com', N'Nicole Stewart', N'z0aeo67mh7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (131, N'n.stewart@randatmail.com', N'Richard Lloyd', N'53qdao939f')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (133, N't.williams@randatmail.com', N'Lenny Smith', N'rketpi3v4l')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (134, N'l.smith@randatmail.com', N'Martin Gibson', N'pxpiobh1wa')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (135, N'm.gibson@randatmail.com', N'Brad Hawkins', N'2nco1mxnun')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (136, N'b.hawkins@randatmail.com', N'Amelia Brooks', N'j9vkqpyeij')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (137, N'a.brooks@randatmail.com', N'James Anderson', N'b3e5pzw84l')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (138, N'j.anderson@randatmail.com', N'Henry Payne', N'm1f8nqae0v')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (139, N'h.payne@randatmail.com', N'Daisy Mason', N'svz2vjajg8')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (140, N'd.mason@randatmail.com', N'Adrian Campbell', N'j1vwd6ai5c')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (142, N'l.nelson@randatmail.com', N'Aston Harrison', N'ss1f4zk95s')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (144, N'j.mason@randatmail.com', N'Eric Taylor', N'n8m3gt564n')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (145, N'e.taylor@randatmail.com', N'Adam Casey', N'okm97ebe1u')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (146, N'a.casey@randatmail.com', N'Olivia Reed', N'8uom57d7v1')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (147, N'o.reed@randatmail.com', N'Mary Perry', N'bppytnqbd5')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (148, N'm.perry@randatmail.com', N'Miranda Sullivan', N'45acdhar5u')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (149, N'm.sullivan@randatmail.com', N'Lilianna Russell', N'nu9sm4aec0')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (150, N'l.russell@randatmail.com', N'Eleanor Crawford', N'waye654118')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (151, N'e.crawford@randatmail.com', N'Leonardo Robinson', N'vg953ojcg1')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (152, N'l.robinson@randatmail.com', N'Harold Morris', N'w08kib03h5')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (153, N'h.morris@randatmail.com', N'Rebecca Evans', N'g98cqjh37v')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (154, N'r.evans@randatmail.com', N'Rebecca Russell', N'1hsbubigmp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (155, N'r.russell@randatmail.com', N'Blake Morgan', N'uhkjl259pd')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (156, N'b.morgan@randatmail.com', N'Isabella Ferguson', N'r2opjy8l5f')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (157, N'i.ferguson@randatmail.com', N'Adam Henderson', N'jgs3kiysnf')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (158, N'a.henderson@randatmail.com', N'Frederick Alexander', N'ldvu4p3yqc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (159, N'user@ua.pt', N'User', N'user')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (160, N'd.walker@randatmail.com', N'Miley Chapman', N'zbcyl3uqrx')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (161, N'm.chapman@randatmail.com', N'Ted Ross', N'jnkz44xhs3')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (162, N't.ross@randatmail.com', N'Miley Evans', N'wtn4k5gm7e')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (163, N'm.evans@randatmail.com', N'Isabella Parker', N'gpfcxd28tc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (164, N'i.parker@randatmail.com', N'Madaline Crawford', N'uwtpsei4hs')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (165, N'm.crawford@randatmail.com', N'Sawyer Moore', N'q2lys16lmd')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (166, N's.moore@randatmail.com', N'Ryan Bennett', N'ozoexr3hok')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (167, N'r.bennett@randatmail.com', N'Oscar Hamilton', N'4sgmo5icp6')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (168, N'o.hamilton@randatmail.com', N'Ryan Anderson', N'ts8zhrm9nu')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (169, N'r.anderson@randatmail.com', N'David Alexander', N'einvnoj96e')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (170, N'd.alexander@randatmail.com', N'Frederick Morris', N'bbigqnszzs')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (171, N'f.morris@randatmail.com', N'Lilianna Nelson', N'3g8hi142ii')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (173, N'h.thompson@randatmail.com', N'Rebecca Campbell', N'0xn69ml6nr')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (174, N'r.campbell@randatmail.com', N'Penelope Payne', N'gw7oof5nsg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (175, N'p.payne@randatmail.com', N'Ashton Thompson', N'fxuyip9q1g')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (177, N'j.riley@randatmail.com', N'Vanessa West', N'5i6618bnkp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (178, N'v.west@randatmail.com', N'Adison Evans', N'1869xud5b2')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (179, N'a.evans@randatmail.com', N'Ryan Howard', N'9svcdiyi3z')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (180, N'r.howard@randatmail.com', N'Savana Perkins', N'mn53exgz1d')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (181, N's.perkins@randatmail.com', N'Connie Murray', N'wk8gonx7u9')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (182, N'c.murray@randatmail.com', N'Nicole Riley', N'50kmwrkbvc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (183, N'n.riley@randatmail.com', N'Heather Mason', N'06zh7bx2l1')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (184, N'h.mason@randatmail.com', N'Lana Holmes', N'lgw9r6chqn')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (185, N'l.holmes@randatmail.com', N'Oliver Gibson', N'mf4o215ov7')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (186, N'o.gibson@randatmail.com', N'Connie Grant', N'clvautcmgp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (187, N'c.grant@randatmail.com', N'Camila Roberts', N'1z5x9fnhq8')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (188, N'c.roberts@randatmail.com', N'Antony Johnson', N'k681kj5cgp')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (189, N'a.johnson@randatmail.com', N'Dainton Richardson', N'oj833t7pat')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (190, N'd.richardson@randatmail.com', N'Alan Williams', N'ou8g88ckuc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (191, N'a.williams@randatmail.com', N'Tess Chapman', N'i2j7lmcn8w')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (192, N't.chapman@randatmail.com', N'Jacob Sullivan', N'4g2yn2lbda')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (193, N'j.sullivan@randatmail.com', N'Brianna Murphy', N'a7ltcznyo6')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (194, N'b.murphy@randatmail.com', N'Victoria Harrison', N'8yuzbzd9qy')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (195, N'v.harrison@randatmail.com', N'Vivian Armstrong', N'wlha5yg6lk')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (196, N'v.armstrong@randatmail.com', N'Kevin Thomas', N'ojwjgji1lg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (197, N'k.thomas@randatmail.com', N'Sophia Murray', N'1y4h1ap0a4')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (198, N's.murray@randatmail.com', N'Max Owens', N'9ed2lster6')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (199, N'm.owens@randatmail.com', N'Belinda Kelly', N'xfpmns2a43')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (200, N'b.kelly@randatmail.com', N'Owen Warren', N'uoka58g2w0')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (201, N'o.warren@randatmail.com', N'Nader, Hoppe and Rempel', N'a7ltcznyo6')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (202, N'bailey.fernando@purdy.net', N'Kshlerin Inc', N'8yuzbzd9qy')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (203, N'wwaters@anderson.com', N'Koelpin Group', N'wlha5yg6lk')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (204, N'weimann.cathryn@cartwright.com', N'Kautzer Inc', N'ojwjgji1lg')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (205, N'auer.cristal@murray.com', N'Grimes Inc', N'1y4h1ap0a4')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (206, N'pturner@grady.com', N'Conn Ltd', N'9svcdiyi3z')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (207, N'peggie.cummerata@cruickshank.com', N'Gutmann-Dooley', N'mn53exgz1d')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (208, N'vschaefer@heller.com', N'Gerhold-Schaden', N'wk8gonx7u9')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (209, N'eve.davis@rippin.info', N'Blanda-O''Keefe', N'50kmwrkbvc')
INSERT [YACM].[User] ([id], [email], [name], [password]) VALUES (210, N'oconn@bailey.com', N'Thompson-Ondricka', N'06zh7bx2l1')
SET IDENTITY_INSERT [YACM].[User] OFF
GO
/****** Object:  Index [i_Event_managerID]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE NONCLUSTERED INDEX [i_Event_managerID] ON [YACM].[Event]
(
	[managerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [i_Prize_eventNumber]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE NONCLUSTERED INDEX [i_Prize_eventNumber] ON [YACM].[Prize]
(
	[eventNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [i_Stage_eventNumber]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE NONCLUSTERED INDEX [i_Stage_eventNumber] ON [YACM].[Stage]
(
	[eventNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__User__AB6E6164E49C4B49]    Script Date: 05-Jun-19 9:31:21 PM ******/
ALTER TABLE [YACM].[User] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [i_User_email]    Script Date: 05-Jun-19 9:31:21 PM ******/
CREATE NONCLUSTERED INDEX [i_User_email] ON [YACM].[User]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [YACM].[Event] ADD  CONSTRAINT [VISIBILITY_DEFAULT]  DEFAULT ((1)) FOR [visibility]
GO
ALTER TABLE [YACM].[Event]  WITH CHECK ADD FOREIGN KEY([managerID])
REFERENCES [YACM].[Manager] ([id])
GO
ALTER TABLE [YACM].[Manager]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [YACM].[User] ([id])
GO
ALTER TABLE [YACM].[Participant]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [YACM].[User] ([id])
GO
ALTER TABLE [YACM].[ParticipantDropOut]  WITH CHECK ADD FOREIGN KEY([eventNumber])
REFERENCES [YACM].[Event] ([number])
GO
ALTER TABLE [YACM].[ParticipantDropOut]  WITH CHECK ADD FOREIGN KEY([participantID])
REFERENCES [YACM].[Participant] ([id])
GO
ALTER TABLE [YACM].[ParticipantEnrollment]  WITH CHECK ADD FOREIGN KEY([eventNumber])
REFERENCES [YACM].[Event] ([number])
GO
ALTER TABLE [YACM].[ParticipantEnrollment]  WITH CHECK ADD FOREIGN KEY([participantID])
REFERENCES [YACM].[Participant] ([id])
GO
ALTER TABLE [YACM].[ParticipantEnrollment]  WITH CHECK ADD FOREIGN KEY([teamName])
REFERENCES [YACM].[Team] ([name])
GO
ALTER TABLE [YACM].[ParticipantOnTeam]  WITH CHECK ADD FOREIGN KEY([participantID])
REFERENCES [YACM].[Participant] ([id])
GO
ALTER TABLE [YACM].[ParticipantOnTeam]  WITH CHECK ADD FOREIGN KEY([teamName])
REFERENCES [YACM].[Team] ([name])
GO
ALTER TABLE [YACM].[Sponsor]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [YACM].[User] ([id])
GO
ALTER TABLE [YACM].[SponsorshipEvent]  WITH CHECK ADD FOREIGN KEY([eventNumber])
REFERENCES [YACM].[Event] ([number])
GO
ALTER TABLE [YACM].[SponsorshipEvent]  WITH CHECK ADD FOREIGN KEY([sponsorID])
REFERENCES [YACM].[Sponsor] ([id])
GO
ALTER TABLE [YACM].[SponsorshipTeam]  WITH CHECK ADD FOREIGN KEY([sponsorID])
REFERENCES [YACM].[Sponsor] ([id])
GO
ALTER TABLE [YACM].[SponsorshipTeam]  WITH CHECK ADD FOREIGN KEY([teamName])
REFERENCES [YACM].[Team] ([name])
GO
ALTER TABLE [YACM].[Stage]  WITH CHECK ADD FOREIGN KEY([eventNumber])
REFERENCES [YACM].[Event] ([number])
GO
ALTER TABLE [YACM].[StageParticipation]  WITH CHECK ADD FOREIGN KEY([eventNumber])
REFERENCES [YACM].[Event] ([number])
GO
ALTER TABLE [YACM].[StageParticipation]  WITH CHECK ADD FOREIGN KEY([participantID])
REFERENCES [YACM].[Participant] ([id])
GO
ALTER TABLE [YACM].[StageParticipation]  WITH CHECK ADD FOREIGN KEY([stageDate], [stageStartLocation], [stageEndLocation])
REFERENCES [YACM].[Stage] ([date], [startLocation], [endLocation])
GO
/****** Object:  StoredProcedure [dbo].[p_CreateDocument]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateDocument] (@eventNumber int, @id int OUT)
AS
	INSERT INTO YACM.Document (eventNumber) VALUES (@eventNumber);
	SET	@id = SCOPE_IDENTITY()

GO
/****** Object:  StoredProcedure [dbo].[p_CreateManager]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateManager] (@email varchar(50), @name varchar(50), @password varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateUser @email=@email, @name=@name, @password=@password, @id=@id OUT;
	INSERT INTO YACM.Manager(id) VALUES (@id);
	RETURN 0;

GO
/****** Object:  StoredProcedure [dbo].[p_CreateOtherFile]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateOtherFile] (@eventID int, @path varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateDocument @eventNumber=@eventID,@id=@id OUT;
	INSERT INTO YACM.OtherFile(id,[path]) VALUES (@id,@path);
	RETURN 0;

GO
/****** Object:  StoredProcedure [dbo].[p_CreateParticipant]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateParticipant] (@email varchar(50), @name varchar(50), @password varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateUser @email=@email, @name=@name, @password=@password, @id=@id OUT;
	INSERT INTO YACM.Participant(id) VALUES (@id);
	RETURN 0;

GO
/****** Object:  StoredProcedure [dbo].[p_CreateSponsor]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateSponsor] (@email varchar(50), @name varchar(50), @password varchar(50))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateUser @email=@email, @name=@name, @password=@password, @id=@id OUT;
	INSERT INTO YACM.Sponsor(id) VALUES (@id);
	RETURN 0;

GO
/****** Object:  StoredProcedure [dbo].[p_CreateTextFile]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateTextFile] (@eventID int, @content varchar(MAX))
AS
	DECLARE @id AS INT;
	EXEC dbo.p_CreateDocument @eventNumber=@eventID,@id=@id OUT;
	INSERT INTO YACM.TextFile(id,content) VALUES (@id,@content);
	RETURN 0;

GO
/****** Object:  StoredProcedure [dbo].[p_CreateUser]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[p_CreateUser] (@email varchar(50), @name varchar(50), @password varchar(50), @id int OUT)
AS
	INSERT INTO YACM.[User] (email, name, [password]) VALUES (@email, @name, @password);
	SET	@id = SCOPE_IDENTITY()

GO
/****** Object:  Trigger [YACM].[DocumentRekt]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [YACM].[DocumentRekt] ON [YACM].[Document] AFTER DELETE
AS
	DECLARE @id AS INT;
	SELECT @id=id FROM deleted;
	DELETE YACM.TextFile	WHERE YACM.TextFile.id=@id;
	DELETE YACM.OtherFile	WHERE YACM.OtherFile.id=@id;

GO
/****** Object:  Trigger [YACM].[ValarMorghulis]    Script Date: 05-Jun-19 9:31:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [YACM].[ValarMorghulis] ON [YACM].[User] AFTER DELETE
AS
	DECLARE @id AS INT;
	SELECT @id=id FROM deleted;
	DELETE YACM.Manager		WHERE YACM.Manager.id=@id;
	DELETE YACM.Participant	WHERE YACM.Participant.id=@id;
	DELETE YACM.Sponsor		WHERE YACM.Sponsor.id=@id;

GO
USE [master]
GO
ALTER DATABASE [YACM] SET  READ_WRITE 
GO
