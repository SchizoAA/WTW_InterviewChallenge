IF NOT EXISTS ( SELECT 1 
	FROM information_schema.tables 
	WHERE table_name = 'Campsites')
BEGIN
	CREATE TABLE Campsites
	(
		[campsite_id]		int				NOT NULL	PRIMARY KEY,
		[campsite_type]		varchar(20),
		[max_occupancy]		int,
	)
END