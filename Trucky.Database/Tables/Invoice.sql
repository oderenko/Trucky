CREATE TABLE Invoice(
	Invoice_UID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Invoice PRIMARY KEY,
	DateOFPay datetime NULL,
	Goods_FID int NOT NULL CONSTRAINT FK_Bill_Goods FOREIGN KEY
		REFERENCES Goods (Goods_UID),
	Employee_FID int NOT NULL CONSTRAINT FK_Invoice_Employee FOREIGN KEY
		REFERENCES Employee (Employee_UID),
	Buyer_FID int NOT NULL CONSTRAINT FK_InvoiceBuyer_Customer FOREIGN KEY
		REFERENCES Customer (Customer_UID),
	Seller_FID int NOT NULL CONSTRAINT FK_InvoiceSeller_Customer FOREIGN KEY
		REFERENCES Customer (Customer_UID),
)