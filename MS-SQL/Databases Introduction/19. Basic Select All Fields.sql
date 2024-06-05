CREATE DATABASE SoftUni
GO;
USE SoftUni
GO;

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150)
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AddressText NVARCHAR(150),
	TownId INT REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(150)
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(150),
	MiddleName NVARCHAR (150),
	LastName NVARCHAR(150),
	JobTitle NVARCHAR(150),
	DepartmentId INT REFERENCES Departments(Id),
	HireDate DATETIME2,
	Salary DECIMAL(8,2),
	AddressId INT REFERENCES Addresses(Id)
)

INSERT INTO Towns ([Name])
	VALUES ('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')

INSERT INTO Departments
	VALUES ('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees
