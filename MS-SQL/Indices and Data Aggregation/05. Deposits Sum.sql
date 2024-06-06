USE Gringotts
GO

  SELECT DepositGroup,
         SUM(DepositAmount)
		 AS DepositSum
    FROM WizzardDeposits
GROUP BY DepositGroup
