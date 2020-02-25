IF NOT EXISTS ( SELECT 1 
	FROM information_schema.tables 
	WHERE table_name = 'Reservations')
BEGIN
	CREATE TABLE Reservations
	(
		[reservation_id]	int				NOT NULL	IDENTITY(1,1) PRIMARY KEY,
		[occupants]			int				NOT NULL,
		[checked_in]		bit,			
		[date_id]		    int		NOT NULL	FOREIGN KEY REFERENCES AvailableDates(date_id),
		CONSTRAINT UC_ReservationDate UNIQUE (date_id)
	)
END