SELECT * FROM YACM.Manager

SELECT * FROM YACM.[User] JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id


-- Stored Procedure to get events managed by a certain user
GO
CREATE PROC dbo.p_GetManagerEvents (@managerEmail varchar(50))
AS
	SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
		JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
		JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
		WHERE YACM.[User].email = @managerEmail
	
	RETURN 0;
GO
EXEC dbo.p_GetManagerEvents @managerEmail='f.alexander@randatmail.com';

-- Stored Procedure to get events not managed by a certain user
GO
CREATE PROC dbo.p_GetOtherEvents (@managerEmail varchar(50))
AS
	SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
		JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
		JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
		WHERE YACM.[User].email != @managerEmail
	
	RETURN 0;
GO
EXEC dbo.p_GetOtherEvents @managerEmail='f.alexander@randatmail.com';


-- Stored Procedure to get events not managed by a certain user that are publicly visible
GO
CREATE PROC dbo.p_GetOtherVisibleEvents (@managerEmail varchar(50))
AS
	SELECT number,YACM.[Event].[name],beginningDate,endDate,visibility FROM YACM.[Event]
		JOIN YACM.[User] ON YACM.[Event].managerID=YACM.[User].id
		JOIN YACM.Manager ON YACM.[User].id=YACM.Manager.id
		WHERE YACM.[User].email != @managerEmail AND YACM.[Event].visibility = 1
	
	RETURN 0;
GO
EXEC dbo.p_GetOtherVisibleEvents @managerEmail='f.alexander@randatmail.com';