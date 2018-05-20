CREATE TABLE Cargo (
	Cargo_UID int IDENTITY(1,1) NOT NULL
		CONSTRAINT PK_Cargo PRIMARY KEY,
	Name varchar (80) NOT NULL,
	Volume int NOT NULL,
	Price int NOT NULL,
	IsComodity bit NOT NULL CONSTRAINT DF_Cargo_IsComodity DEFAULT 1,
	IsFragile bit NOT NULL CONSTRAINT DF_Cargo_IsFragile DEFAULT 0
)