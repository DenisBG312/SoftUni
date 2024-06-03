SELECT e.EmployeeID,
       e.FirstName,
	   e.LastName,
	   d.[Name]
  FROM Employees
    AS e
  JOIN Departments
    AS d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] IN ('Sales')
	ORDER BY e.EmployeeID ASC
