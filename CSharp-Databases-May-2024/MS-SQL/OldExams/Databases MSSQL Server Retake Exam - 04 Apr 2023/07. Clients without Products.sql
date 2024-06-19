	SELECT 
		c.Id,
		c.[Name] AS Client,
		CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', co.[Name])
	  FROM Clients
	    AS c
	  JOIN Addresses AS a ON c.AddressId = a.Id
	  JOIN Countries AS co ON a.CountryId = co.Id
	  LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
	  WHERE pc.ProductId IS NULL
