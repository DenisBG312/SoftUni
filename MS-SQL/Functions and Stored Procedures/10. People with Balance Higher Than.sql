
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan @amount MONEY
			  AS
		   BEGIN
					SELECT FirstName
					    AS [First Name],
						   LastName
						AS [Last Name]
					  FROM AccountHolders
					  AS ah
					JOIN Accounts
					  AS a
					  ON ah.Id = a.AccountHolderId
					GROUP BY FirstName, LastName
					HAVING SUM(a.Balance) > @amount
					ORDER BY FirstName, LastName
		     END

EXEC usp_GetHoldersWithBalanceHigherThan 500000
