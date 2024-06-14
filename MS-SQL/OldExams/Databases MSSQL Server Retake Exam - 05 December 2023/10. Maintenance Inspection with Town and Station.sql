SELECT 
		tr.Id AS TrainId,
		t.[Name] AS DepartureTown,
		m.Details
  FROM Trains
    AS tr
  JOIN Towns AS t ON tr.DepartureTownId = t.Id
  JOIN MaintenanceRecords AS m ON tr.Id = m.TrainId
  WHERE Details LIKE '%inspection%'
  ORDER BY tr.Id
