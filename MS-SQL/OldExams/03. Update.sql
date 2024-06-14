UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31'
