	  SELECT TOP(7)
			i.Number,
			i.Amount,
			c.[Name]
	    FROM Invoices
		  AS i
		JOIN Clients AS c ON i.ClientId = c.Id
	   WHERE IssueDate < '2023-01-01' 
	   AND Currency = 'EUR' 
	   OR Amount > 500.00 
	   AND c.NumberVAT LIKE 'DE%'
	   ORDER BY i.Number, i.Amount DESC
