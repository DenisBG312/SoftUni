CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(100))
AS
BEGIN
	SELECT 
		t.[Name],
		t.PhoneNumber,
		t.Email,
		COUNT(*) AS CountOfBookings
	  FROM Bookings
	    AS b
	JOIN Tourists AS t ON b.TouristId = t.Id
	JOIN Countries AS c ON t.CountryId = c.Id
	WHERE c.[Name] = @country
	GROUP BY t.[Name], t.PhoneNumber, t.Email
	ORDER BY t.[Name], CountOfBookings DESC
END
