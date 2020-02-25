IF NOT EXISTS ( SELECT 1 
	FROM information_schema.tables 
	WHERE table_name = 'AvailableDates')
BEGIN
	CREATE TABLE AvailableDates
	(
		[date_id]			int				NOT NULL	IDENTITY(1,1) PRIMARY KEY,				
		[available_date]    DATETIME		NOT NULL,
		[campsite_id]		int				NOT NULL	FOREIGN KEY REFERENCES Campsites(campsite_id),
		[isAvailable]		bit,
		CONSTRAINT UC_AvailableDate UNIQUE (available_date, campsite_id)
	)
END