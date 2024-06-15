   CREATE OR ALTER FUNCTION udf_ProductWithClients(@productName VARCHAR(100))
   RETURNS INT
   AS
   BEGIN
		DECLARE @totalAmount INT

		SELECT @totalamount = COUNT(DISTINCT c.Id)
		  FROM Invoices
			AS i
		 JOIN Clients as c ON i.ClientId = c.Id
		 JOIN ProductsClients as pc ON c.Id = pc.ClientId
		 JOIN Products as p ON pc.ProductId = p.Id
		 WHERE p.[Name] = @productName
		RETURN @totalAmount
   END
