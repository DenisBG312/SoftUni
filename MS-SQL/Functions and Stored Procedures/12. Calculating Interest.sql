CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
	DECLARE @term INT = 5

	SELECT a.Id AS [Account Id],FirstName AS [First Name], LastName AS [Last Name], Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(Balance, @interestRate, @term) AS [Balance in 5 years]
	FROM AccountHolders 
	  AS ah
	JOIN Accounts
	  AS a
	  ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1
