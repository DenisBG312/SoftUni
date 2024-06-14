SELECT 
	t.[Name] AS Town,
	r.[Name]
  FROM Towns
    AS t
LEFT JOIN RailwayStations  AS r ON t.Id = r.TownId
LEFT JOIN TrainsRailwayStations AS tr ON r.Id = tr.RailwayStationId
WHERE TrainId IS NULL
ORDER BY t.[Name], r.[Name]
