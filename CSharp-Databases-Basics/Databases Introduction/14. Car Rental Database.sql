CREATE DATABASE CarRental
USE CarRental
GO

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(150),
	DailyRate DECIMAL(5,2),
	WeeklyRate DECIMAL(5,2),
	MonthlyRate DECIMAL(5,2),
	WeekendRate DECIMAL (5,2)
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	PlateNumber VARCHAR(150),
	Manufacturer VARCHAR(150),
	Model VARCHAR(150),
	CarYear DATETIME2,
	CategoryId INT,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(150),
	Available BIT,
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(150),
	LastName VARCHAR(150),
	Title VARCHAR(150),
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DriverLicenseNumber VARCHAR(150),
	FullName VARCHAR(150),
	[Address] VARCHAR(150),
	City VARCHAR(150),
	ZIPCode VARCHAR(20),
	Notes VARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT,
	CustomerId INT,
	CarId INT,
	TankLevel DECIMAL(3,2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT,
	RateApplied DECIMAL(5,2),
    TaxRate DECIMAL(3,2),
    OrderStatus VARCHAR(50),
    Notes VARCHAR(MAX),
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	FOREIGN KEY (CarId) REFERENCES Cars(Id)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Economy', 30, 180.00, 720.00, 50.00),
('SUV', 50.00, 300.00, 120.00, 80.00),
('Luxury', 100.00, 600.00, 240.00, 150.00);

SELECT * FROM Categories

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('ABC123', 'Toyota', 'Corolla', '2020-02-01', 1, 4, NULL, 'Good', 1),
('DEF456', 'Ford', 'Explorer', '2019-03-02', 2, 4, NULL, 'Excellent', 1),
('GHI789', 'BMW', '5 Series', '2021-01-01', 3, 4, NULL, 'Excellent', 1);

SELECT * FROM Cars

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('John', 'Doe', 'Manager', 'Has been with the company for 5 years'),
('Jane', 'Smith', 'Sales Associate', 'Excellent customer service skills'),
('Emily', 'Johnson', 'Mechanic', 'Specializes in SUVs');

SELECT * FROM Employees

INSERT INTO Customers (DriverLicenseNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('D1234567', 'Alice Johnson', '123 Elm St', 'Springfield', '12345', 'Preferred customer'),
('D2345678', 'Bob Smith', '456 Oak St', 'Shelbyville', '23456', 'Frequent renter'),
('D3456789', 'Charlie Brown', '789 Pine St', 'Capital City', '34567', 'New customer');

SELECT * FROM Customers

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 0.75, 10000, 10200, '2023-01-01', '2023-01-03', 30.00, 0.15, 'Completed', 'No issues'),
(2, 2, 2, 0.50, 20000, 20500, '2023-02-01', '2023-02-05', 50.00, 0.15, 'Completed', 'Minor scratches'),
(3, 3, 3, 1.00, 30000, 30100, '2023-03-01', '2023-03-02', 100.00, 0.15, 'Completed', 'Fuel tank full');

SELECT * FROM RentalOrders
