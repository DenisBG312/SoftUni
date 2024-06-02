USE SoftUni

    SELECT 
   TOP (5) [e].[EmployeeID],
		   [e].[FirstName],
		   [p].[Name]
		   AS [ProjectName]
      FROM [EmployeesProjects]
	  AS [ep]
INNER JOIN [Employees]
	  AS [e]
	  ON [ep].[EmployeeID] = [e].[EmployeeID]
INNER JOIN [Projects]
	  AS [p]
	  ON [ep].[ProjectID] = [p].[ProjectID]
   WHERE [p].[StartDate] > '08/13/2002' AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID]
