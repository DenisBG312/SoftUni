CREATE DATABASE Hotel
GO;
USE Hotel
GO;

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Title VARCHAR(100),
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	PhoneNumber VARCHAR(20),
	EmergencyName VARCHAR(100),
	EmergencyNumber VARCHAR(20),
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(150) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(150),
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(150),
	Notes VARCHAR(MAX)
)

ALTER TABLE RoomStatus
ALTER COLUMN RoomStatus VARCHAR(150) NOT NULL;

ALTER TABLE RoomStatus
ADD CONSTRAINT PK_RoomStatus PRIMARY KEY (RoomStatus);

ALTER TABLE BedTypes
ALTER COLUMN BedType VARCHAR(150) NOT NULL;

ALTER TABLE RoomTypes
ALTER COLUMN RoomType VARCHAR(150) NOT NULL;

ALTER TABLE RoomTypes
ADD CONSTRAINT PK_RoomTypes PRIMARY KEY (RoomType);

ALTER TABLE BedTypes
ADD CONSTRAINT PK_BedTypes PRIMARY KEY (BedType);


CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY(1,1),
	RoomType VARCHAR(150),
	BedType VARCHAR(150),
	Rate DECIMAL(10, 2),
	RoomStatus VARCHAR(150),
	Notes VARCHAR(150),

	FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
	FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
	FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT REFERENCES Employees(Id),
	PaymentDate DATETIME2,
	AccountNumber INT NOT NULL REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME2,
	LastDateOccupied DATETIME2,
	TotalDays INT,
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(5,2),
	TaxAmount DECIMAL(5,2),
	PaymentTotal DECIMAL(5,2),
	Notes VARCHAR(MAX)
)



INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES 
('John', 'Doe', 'Manager', 'Notes for John Doe'),
('Jane', 'Smith', 'Receptionist', 'Notes for Jane Smith'),
('Emily', 'Jones', 'Housekeeper', 'Notes for Emily Jones');

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES 
('Alice', 'Brown', '555-1234', 'Bob Brown', '555-5678', 'Notes for Alice Brown'),
('David', 'Wilson', '555-2345', 'Carol Wilson', '555-6789', 'Notes for David Wilson'),
('Eve', 'Davis', '555-3456', 'Frank Davis', '555-7890', 'Notes for Eve Davis');

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES 
('Available', 'Room is ready for occupancy'),
('Occupied', 'Room is currently occupied'),
('Maintenance', 'Room is under maintenance');

INSERT INTO RoomTypes (RoomType, Notes)
VALUES 
('Single', 'Single room with one bed'),
('Double', 'Double room with two beds'),
('Suite', 'Suite with multiple rooms and amenities');

INSERT INTO BedTypes (BedType, Notes)
VALUES 
('Single Bed', 'One single bed'),
('Double Bed', 'One double bed'),
('King Bed', 'One king-sized bed');

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES 
('Single', 'Single Bed', 50.00, 'Available', 'Room 101'),
('Double', 'Double Bed', 75.00, 'Occupied', 'Room 102'),
('Suite', 'King Bed', 150.00, 'Maintenance', 'Room 103');


INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES 
(1, '2024-05-01', 1, '2024-04-25', '2024-04-30', 5, 250.00, 0.10, 25.00, 275.00, 'Payment for Alice Brown'),
(2, '2024-05-02', 2, '2024-04-26', '2024-05-01', 6, 450.00, 0.10, 45.00, 495.00, 'Payment for David Wilson'),
(3, '2024-05-03', 3, '2024-04-27', '2024-05-02', 6, 900.00, 0.10, 90.00, 990.00, 'Payment for Eve Davis');

SELECT * FROM Payments
