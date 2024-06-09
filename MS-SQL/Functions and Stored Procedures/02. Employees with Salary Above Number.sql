CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18,4)
              AS
           BEGIN
					SELECT FirstName
					    AS [First Name],
						   LastName
						AS [Last Name]
					  FROM Employees
					  WHERE Salary >= @salary
             END

EXEC usp_GetEmployeesSalaryAboveNumber 48100
