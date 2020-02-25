IF OBJECT_ID(N'MostPopularDays_f') IS NOT NULL
BEGIN
	DROP FUNCTION MostPopularDays_f
END
GO

CREATE FUNCTION MostPopularDays_f()
RETURNS TABLE
AS 
RETURN(	SELECT TOP 1 a.available_date as 'Date', SUM(r.occupants) AS 'Visitors' FROM Reservations r INNER JOIN AvailableDates a on a.date_id=r.date_id GROUP BY a.available_date ORDER BY SUM(r.occupants) DESC )
