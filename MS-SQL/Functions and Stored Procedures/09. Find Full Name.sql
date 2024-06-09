CREATE PROCEDURE usp_GetHoldersFullName
			  AS
		   BEGIN
					SELECT 
					CONCAT_WS(' ', FirstName, LastName)
					       AS [Full Name]
					  FROM AccountHolders
		     END


