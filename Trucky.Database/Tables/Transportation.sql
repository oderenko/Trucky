CREATE TABLE Transportation(
	Transportation_UID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Transportation PRIMARY KEY,
	DeliveryDate datetime NULL,
	StartDate datetime NOT NULL CONSTRAINT DF_Transportation_StartDate DEFAULT getutcdate(),
-- in case it's not comodity
	Truck_FID int NOT NULL CONSTRAINT FK_Transportation_Truck FOREIGN KEY
		REFERENCES Truck (Truck_UID)
)