USE YACM;

-- ================
-- === DOCUMENT ===
-- ================
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
