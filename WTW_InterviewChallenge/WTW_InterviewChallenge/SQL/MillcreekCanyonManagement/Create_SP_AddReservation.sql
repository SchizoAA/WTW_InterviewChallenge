IF EXISTS (SELECT 1 FROM sys.procedures WHERE [name] = N'sp_AddReservation' AND [type]='P')
BEGIN
	DROP PROCEDURE sp_AddReservation
END
GO

CREATE PROCEDURE sp_AddReservation @date datetime, @campsite int, @occupants int
AS
DECLARE @reserved bit = 0

--get available date id if exists
DECLARE @dateId int = (SELECT date_id FROM AvailableDates WHERE available_date=@date AND campsite_id=@campsite);

DECLARE @maxOccupants int = (SELECT max_occupancy FROM Campsites WHERE campsite_id=@campsite)

IF @dateId>0 --If date not available for site, skip.
BEGIN
	SET @reserved = ( SELECT CASE WHEN EXISTS (SELECT 1 FROM Reservations WHERE date_id=@dateId) THEN 1 ELSE 0 END )--Check if site is reserved for date.
	IF @reserved = 0
	BEGIN
		IF @occupants<=@maxOccupants
		BEGIN
			INSERT INTO Reservations (occupants, checked_in, date_id) VALUES (@occupants, 0, @dateId)
			UPDATE AvailableDates SET isAvailable=0 WHERE date_id=@dateId
		END
		ELSE
			RAISERROR('Reservation exceeds maximum occupancy for the campsite.', 1, 1)
	END
	ELSE
		RAISERROR('Campsite already reserved for selected date.',1,1)
END
ELSE
	RAISERROR('Campsite not available on selected date.',1,1)