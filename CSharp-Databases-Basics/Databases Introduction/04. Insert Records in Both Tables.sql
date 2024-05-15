CREATE DATABASE Minions
-- 2. Create Tables

CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(150),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(150)
)

DROP TABLE Towns

--03. zadacha
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)



--04. 

INSERT INTO Towns
	VALUES (1, 'Sofia'),
			(2, 'Plovdiv'),
			(3, 'Varna')


INSERT INTO Minions (Id, [Name], Age, TownId)
	VALUES (1, 'Kevin', 22, 1),
			(2, 'Bob', 15, 3),
			(3, 'Steward', NULL, 2)



