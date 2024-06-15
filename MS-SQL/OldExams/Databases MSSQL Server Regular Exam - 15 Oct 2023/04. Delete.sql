DELETE FROM Bookings
WHERE [TouristId] IN (
		SELECT Id FROM Tourists WHERE [Name] LIKE '%Smith%'
					)

SELECT * FROM Tourists
WHERE [Name] LIKE '%Smith%'
