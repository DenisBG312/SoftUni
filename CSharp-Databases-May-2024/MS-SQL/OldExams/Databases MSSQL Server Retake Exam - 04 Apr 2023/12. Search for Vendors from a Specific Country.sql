   CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(100))
   AS
   BEGIN
		SELECT 
			v.[Name] AS Vendor,
			v.NumberVAT AS VAT,
			CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info],
			CONCAT_WS(' ', a.City, a.PostCode)
		  FROM Vendors 
		    AS v
		  JOIN Addresses AS a ON v.AddressId = a.Id
		  JOIN Countries AS c ON a.CountryId = c.Id
		  WHERE c.[Name] = @country
		  ORDER BY v.[Name], a.City
   END
