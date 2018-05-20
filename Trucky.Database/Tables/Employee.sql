CREATE TABLE Employee(
	Employee_UID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employee PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	BirthdayDate datetime NULL,
	HireDate datetime NOT NULL,
	Salary int NOT NULL,
	City varchar(30) NULL,
	Position_FID int NOT NULL 
	CONSTRAINT FK_Employee_Position FOREIGN KEY
		REFERENCES lkup_Position (lkup_Position_UID)
)