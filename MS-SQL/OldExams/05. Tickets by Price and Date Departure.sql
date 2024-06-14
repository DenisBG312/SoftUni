  SELECT 
		DateOfDeparture, 
		Price AS TicketPrice
    FROM Tickets
ORDER BY Price, DateOfDeparture DESC
