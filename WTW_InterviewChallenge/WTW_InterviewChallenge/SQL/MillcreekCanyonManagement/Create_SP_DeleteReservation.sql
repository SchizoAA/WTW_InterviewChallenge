IF EXISTS (SELECT 1 FROM sys.procedures WHERE [name] = N'sp_DeleteReservation' AND [type]='P')
BEGIN
	DROP PROCEDURE sp_DeleteReservation
END
GO

CREATE PROCEDURE sp_DeleteReservation @id int
AS

DECLARE @dateId int = (SELECT date_id FROM Reservations WHERE reservation_id=@id)

IF @dateId>0
BEGIN
	DELETE FROM Reservations WHERE reservation_id = @id
	UPDATE AvailableDates SET isAvailable=1 WHERE date_id=@dateId
END
ELSE
	RAISERROR('Reservation not found.', 1, 1)