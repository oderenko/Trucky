CREATE TABLE Customer (
	Customer_UID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Customer PRIMARY KEY,
	FullName varchar(80) NOT NULL,
	PhoneNumber varchar(13) NULL,
	Email varchar(255) NULL,
	IsCorporate bit NOT NULL CONSTRAINT DF_Customer_IsCorporate DEFAULT 1,
	CustomerType_FID int NOT NULL CONSTRAINT FK_Customer_lkup_CustomerType FOREIGN KEY
		REFERENCES lkup_CustomerType (lkup_CustomerType_UID)
)