USE SoftUni

    SELECT [e].[EmployeeID],
		   [e].[FirstName],
		   [m].[EmployeeID],
		   [m].[FirstName]
		   AS [ManagerName]
	  FROM [Employees]
	    AS [e]
INNER JOIN [Employees]
        AS [m]
		ON [e].[ManagerID] = [m].[EmployeeID]
	 WHERE [e].[ManagerID] IN (3, 7)
  ORDER BY [e].[EmployeeID]
