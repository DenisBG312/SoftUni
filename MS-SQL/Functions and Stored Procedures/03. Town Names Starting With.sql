CREATE PROCEDURE usp_GetTownsStartingWith @inputMask VARCHAR(MAX)
			  AS
		   BEGIN
					SELECT [Name]
					    AS Town
					  FROM Towns
					WHERE [Name] LIKE CONCAT(@inputMask, '%')
			 END

EXEC usp_GetTownsStartingWith 'bell'
