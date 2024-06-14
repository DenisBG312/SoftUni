CREATE OR ALTER PROCEDURE usp_SearchByTown(@townName VARCHAR(100))
AS
BEGIN
	SELECT 
			p.[Name] AS PassengerName,
			t.DateOfDeparture,
			tr.HourOfDeparture
	  FROM Passengers
	    AS p
	  JOIN Tickets AS t ON p.Id = t.PassengerId
	  JOIN Trains AS tr ON t.TrainId = tr.Id
	  JOIN Towns AS [to] ON tr.ArrivalTownId = [to].Id
	  WHERE [to].[Name] = @townName
	  ORDER BY DateOfDeparture DESC, PassengerName
END
