SELECT TOP (3)
	tr.Id AS TrainId,
	tr.HourOfDeparture,
	t.Price AS TicketPrice,
	[to].[Name] AS Destination

  FROM Tickets
    AS t
  JOIN Trains AS tr ON t.TrainId = tr.Id
  JOIN Towns AS [to] ON tr.ArrivalTownId = [to].Id
 WHERE 
	CAST(tr.HourOfDeparture AS TIME) BETWEEN '8:00' AND '8:59'
	AND t.Price > 50
	ORDER BY TicketPrice
