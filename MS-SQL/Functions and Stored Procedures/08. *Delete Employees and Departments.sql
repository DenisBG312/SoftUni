CREATE PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
              AS
		   BEGIN
					DECLARE @employeesToDelete TABLE (Id INT);
					INSERT INTO @employeesToDelete
					     SELECT EmployeeID 
						   FROM Employees
						  WHERE DepartmentID = @departmentId


				DELETE
				  FROM EmployeesProjects
				 WHERE EmployeeID IN (
										SELECT * 
										  FROM @employeesToDelete
									 )
				ALTER TABLE Departments
				ALTER COLUMN ManagerID INT

				UPDATE Departments
				   SET ManagerID  = NULL 
				 WHERE ManagerID IN (
				                            SELECT * FROM @employeesToDelete
									)


				UPDATE Employees
				   SET ManagerID = NULL
				 WHERE ManagerID IN (
				                            SELECT * FROM @employeesToDelete
									)

			    DELETE 
				  FROM Employees
				 WHERE DepartmentID = @departmentId
				 
				 DELETE
				   FROM Departments
				  WHERE DepartmentID = @departmentId

				  SELECT COUNT(*)
				    FROM Employees
				   WHERE DepartmentID = @departmentId

				  END

EXEC dbo.usp_DeleteEmployeesFromDepartment 7


SELECT * FROM Employees WHERE DepartmentID = 7
