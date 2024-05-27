USE [SoftUni]
GO;

SELECT 
	   [FirstName],
	   [LastName]
  FROM [Employees]
  WHERE LEN([LastName]) = 5
