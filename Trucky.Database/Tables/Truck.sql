CREATE TABLE Truck(
	Truck_UID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Truck PRIMARY KEY,
	TruckName varchar(80),
	Fuel int NOT NULL,
	Capacity float NOT NULL,
	Volume float NOT NULL,
	Speed int NOT NULL,
	LastInspection datetime NULL,
)