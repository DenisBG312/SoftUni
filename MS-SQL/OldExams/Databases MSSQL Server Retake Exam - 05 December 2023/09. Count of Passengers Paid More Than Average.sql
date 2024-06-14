SELECT 
    t.[Name] AS TownName,
    COUNT(ti.PassengerId) AS PassengersCount
FROM 
    Tickets AS ti
JOIN 
    Trains AS tr ON ti.TrainId = tr.Id
JOIN 
    Towns AS t ON tr.ArrivalTownId = t.Id
WHERE 
    ti.Price > 76.99
GROUP BY 
    t.[Name]
ORDER BY 
    t.[Name];
