USE SoftUni

SELECT MIN(avg_salary)
    AS MinAverageSalary
  FROM (
     SELECT DepartmentID, 
	    AVG(Salary) 
	     AS avg_salary
       FROM Employees
   GROUP BY DepartmentID
  ) AS MinAverageSalary
