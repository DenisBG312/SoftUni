SELECT 
	[Name] AS PassengerName,
	Price AS TicketPrice,
	DateOfDeparture,
	TrainId
  FROM Passengers
	AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
ORDER BY Price DESC, [Name]
