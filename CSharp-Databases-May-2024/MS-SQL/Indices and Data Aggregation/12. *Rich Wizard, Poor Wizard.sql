  USE Gringotts
  

  SELECT SUM([Difference])
      AS SumDifference
    FROM (
		SELECT FirstName
		    AS [Host Wizard],
			DepositAmount
			AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY (Id))
			AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY (Id))
			AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY (Id))
			AS [Difference]
		  FROM WizzardDeposits

		  ) AS DifferenceSubQuery
