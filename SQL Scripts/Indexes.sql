USE YACM

-- ================
-- ==== INDEXES ===
-- ================
CREATE INDEX i_Event_managerID		ON YACM.[Event](managerID);
CREATE INDEX i_Prize_eventNumber	ON YACM.Prize(eventNumber);
CREATE INDEX i_Stage_eventNumber	ON YACM.Stage(eventNumber);
CREATE INDEX i_User_email			ON YACM.[User](email);