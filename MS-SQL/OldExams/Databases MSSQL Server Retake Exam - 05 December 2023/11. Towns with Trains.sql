CREATE OR ALTER FUNCTION udf_TownsWithTrains (@name VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @count INT;
	SELECT @count = COUNT(*)
	FROM Trains AS tr
	JOIN Towns AS t ON tr.DepartureTownId = t.Id OR tr.ArrivalTownId = t.Id
	WHERE t.Name = @name;
	RETURN @count
END
