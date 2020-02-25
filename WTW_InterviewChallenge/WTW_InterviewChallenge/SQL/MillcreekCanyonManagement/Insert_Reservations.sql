IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-25' AND campsite_id=1 )) BEGIN EXEC sp_AddReservation '2020-05-25', 1, 2 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-29' AND campsite_id=1 )) BEGIN EXEC sp_AddReservation '2020-05-29', 1, 5 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-25' AND campsite_id=2 )) BEGIN EXEC sp_AddReservation '2020-05-25', 2, 4 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-27' AND campsite_id=3 )) BEGIN EXEC sp_AddReservation '2020-05-27', 3, 7 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-06-01' AND campsite_id=4 )) BEGIN EXEC sp_AddReservation '2020-06-01', 4, 4 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-06-02' AND campsite_id=4 )) BEGIN EXEC sp_AddReservation '2020-06-02', 4, 4 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-29' AND campsite_id=5 )) BEGIN EXEC sp_AddReservation '2020-05-29', 5, 10 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-30' AND campsite_id=5 )) BEGIN EXEC sp_AddReservation '2020-05-30', 5, 10 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-31' AND campsite_id=5 )) BEGIN EXEC sp_AddReservation '2020-05-31', 5, 10 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-26' AND campsite_id=6 )) BEGIN EXEC sp_AddReservation '2020-05-26', 6, 15 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-27' AND campsite_id=6 )) BEGIN EXEC sp_AddReservation '2020-05-27', 6, 15 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-25' AND campsite_id=7 )) BEGIN EXEC sp_AddReservation '2020-05-25', 7, 16 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-26' AND campsite_id=7 )) BEGIN EXEC sp_AddReservation '2020-05-26', 7, 16 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-27' AND campsite_id=7 )) BEGIN EXEC sp_AddReservation '2020-05-27', 7, 16 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-28' AND campsite_id=7 )) BEGIN EXEC sp_AddReservation '2020-05-28', 7, 16 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-29' AND campsite_id=7 )) BEGIN EXEC sp_AddReservation '2020-05-29', 7, 16 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-28' AND campsite_id=9 )) BEGIN EXEC sp_AddReservation '2020-05-28', 9, 4 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-29' AND campsite_id=9 )) BEGIN EXEC sp_AddReservation '2020-05-29', 9, 4 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-05-30' AND campsite_id=9 )) BEGIN EXEC sp_AddReservation '2020-05-30', 9, 4 END

IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-06-02' AND campsite_id=10 )) BEGIN EXEC sp_AddReservation '2020-06-02', 10, 6 END
IF NOT EXISTS ( SELECT 1 FROM Reservations WHERE date_id=( SELECT date_id FROM AvailableDates WHERE available_date='2020-06-03' AND campsite_id=10 )) BEGIN EXEC sp_AddReservation '2020-06-03', 10, 6 END
