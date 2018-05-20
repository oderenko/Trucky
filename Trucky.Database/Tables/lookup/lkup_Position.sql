CREATE TABLE dbo.lkup_Position(
	lkup_Position_UID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_lkup_Position PRIMARY KEY,
	PositionName varchar(20) NULL,
)