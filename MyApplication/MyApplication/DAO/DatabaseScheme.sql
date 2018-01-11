CREATE TABLE "User"
(
 Name VARCHAR(32) NOT NULL,
 Surname VARCHAR(32) NOT NULL,
 Username VARCHAR(24) PRIMARY KEY,
 Password VARCHAR(24) NOT NULL,
 UserType TINYINT NOT NULL,
 Deleted BIT NOT NULL DEFAULT 0,
 
 CONSTRAINT Check_UserType CHECK (UserType = 1 OR UserType = 2)
)

CREATE TABLE "FurnitureType"
(
 Id INT PRIMARY KEY IDENTITY,
 Name VARCHAR(48) NOT NULL,
 Deleted BIT NOT NULL DEFAULT 0
)

CREATE TABLE "ActionSale"
(
 Id INT PRIMARY KEY IDENTITY,
 Name VARCHAR(48) NOT NULL,
 Discount REAL NOT NULL,
 StartDate DATETIME2 NOT NULL,
 EndDate DATETIME2 NOT NULL,
 Deleted BIT NOT NULL DEFAULT 0,

 CONSTRAINT Check_Discount CHECK (Discount > 0)
)

CREATE TABLE "AdditionalService"
(
 Id INT PRIMARY KEY IDENTITY,
 Name VARCHAR(48) NOT NULL,
 Price SMALLMONEY NOT NULL,
 Deleted BIT NOT NULL DEFAULT 0,
 Quantity SMALLINT DEFAULT 0,

 CONSTRAINT Check_Price CHECK (Price > 0)
)

CREATE TABLE "Furniture"
(
 Id INT PRIMARY KEY IDENTITY,
 Name VARCHAR(48) NOT NULL,
 Quantity SMALLINT NOT NULL,
 Price SMALLMONEY NOT NULL,
 FurnitureTypeId INT NOT NULL FOREIGN KEY REFERENCES FurnitureType(Id),
 ActionSaleId INT FOREIGN KEY REFERENCES ActionSale(Id),
 Deleted BIT NOT NULL DEFAULT 0,

 CONSTRAINT Check_Furniture_Price CHECK (Price > 0),
 CONSTRAINT	Check_Furniture_Quantity CHECK (Quantity > 0)
)

CREATE TABLE "Sale"
(
 Id INT PRIMARY KEY,
 DateOfSale DATETIME2 NOT NULL,
 FullPrice SMALLMONEY NOT NULL,
 Buyer VARCHAR(48)
)

CREATE TABLE "AdditionalServiceSaleItem"
(
 AdditionalServiceId INT NOT NULL FOREIGN KEY REFERENCES AdditionalService(Id),
 Pieces TINYINT NOT NULL DEFAULT 1,
 SaleId INT NOT NULL FOREIGN KEY REFERENCES Sale(Id)
)

CREATE TABLE "FurnitureSaleItem"
(
 FurnitureId INT NOT NULL FOREIGN KEY REFERENCES Furniture(Id),
 Pieces TINYINT NOT NULL DEFAULT 1,
 SaleId INT NOT NULL FOREIGN KEY REFERENCES Sale(Id),

 CONSTRAINT Check_Pieces CHECK (Pieces >= 1)
)

INSERT INTO ActionSale(Name, Discount, StartDate, EndDate)
VALUES ('Novogodisnja akcija', 0.33,'2017-12-29','2017-12-31'),
	   ('Bozicna akcija', 0.25, '2018-01-05','2018-01-07');

INSERT INTO AdditionalService(Name, Price)
VALUES ('Montaza', 20),
	   ('Prevoz', 120);

INSERT INTO FurnitureType(Name)
VALUES ('Krevet'),
	   ('Stolica'),
	   ('Sto');

INSERT INTO Furniture(Name, Quantity, Price, FurnitureTypeId, ActionSaleId)
VALUES ('Bracni Krevet', 5, 780, 1, NULL),
	   ('Kancelarijska Stolica', 10, 90, 2, 1),
	   ('Porodicni Sto', 5, 150, 3, 2);

INSERT INTO "User"(Name, Surname, Username, Password, UserType)
VALUES ('Pero', 'Peric', 'pero123', '12345', 1),
	   ('Mitar', 'Miric', 'mitar123','12345', 2);

INSERT INTO Sale (Id, DateOfSale, FullPrice, Buyer) VALUES (1, '2017-01-01', 3650, 'Mitar Miric');
INSERT INTO FurnitureSaleItem (FurnitureId, Pieces, SaleId) VALUES (2, 2, 1),(1, 2, 1),(3, 5, 1);
INSERT INTO AdditionalServiceSaleItem (AdditionalServiceId, Pieces, SaleId) VALUES (1,1,1), (2,1,1);
