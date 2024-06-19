CREATE OR ALTER FUNCTION udf_RoomsWithTourists (@roomType VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @totalCount INT

	SELECT @totalCount = SUM(b.AdultsCount + b.ChildrenCount)
	  FROM Bookings
	    AS b
	JOIN Rooms AS r ON b.RoomId = r.Id
	WHERE r.[Type] = @roomType

	RETURN @totalCount
END
