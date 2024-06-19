USE SoftUni
  
SELECT TOP (10)
       FirstName,
       LastName,
	   DepartmentID
  FROM Employees
    AS eMain
 WHERE Salary >	(
					SELECT AVG(Salary)
						 AS AverageSalary
					 FROM Employees
					   AS eSub
					WHERE eSub.DepartmentID = eMain.DepartmentID
					GROUP BY DepartmentID
				)
	ORDER BY DepartmentID
