IF EXISTS(SELECT 1 FROM sys.views
	WHERE object_id = OBJECT_ID('v_AvailableCampsites'))
BEGIN
	DROP VIEW v_AvailableCampsites
END
GO

CREATE VIEW v_AvailableCampsites
AS 

SELECT campsite_id AS Campsite, available_date AS 'Date' FROM AvailableDates WHERE isAvailable=1
GO