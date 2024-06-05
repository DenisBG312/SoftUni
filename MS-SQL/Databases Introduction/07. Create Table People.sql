CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL (3,2),
	[Weight] DECIMAL (3,2),
	Gender CHAR(1) NOT NULL,
			CHECK(Gender in('m', 'f')),
	Birthdate DATETIME2 NOT NULL,
	Biography VARCHAR(MAX)
)

INSERT INTO People([Name], Gender, Birthdate)
	VALUES('Denis', 'm', '1999-04-03'),
			('Alex', 'm', '1999-02-06'),
			('Maria', 'f', '2005-03-01'),
			('Brian', 'm', '2003-01-05'),
			('Gabriela', 'f', '2007-03-02')
