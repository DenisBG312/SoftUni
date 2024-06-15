SELECT c.[Name],
	   MAX(p.Price) AS Price,
	   c.NumberVAT AS [VAT Number]
  FROM Clients
    AS c
   JOIN ProductsClients AS pc ON c.Id = pc.ClientId
   JOIN Products AS p ON pc.ProductId = p.Id
  WHERE c.[Name] NOT LIKE '%KG'
  GROUP BY c.[Name], c.NumberVAT
  ORDER BY Price DESC
