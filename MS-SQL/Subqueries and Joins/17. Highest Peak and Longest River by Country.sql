USE [Geography]

SELECT TOP (5)
  c.CountryName,
  MAX(p.Elevation) AS HighestPeakElevation,
  Max(r.[Length]) AS LongestRiverLength
  FROM Countries
    AS c
  LEFT JOIN MountainsCountries
         AS mc
		 ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains
         AS m
		 ON mc.MountainId = m.Id
  LEFT JOIN Peaks
         AS p
		 ON m.Id = p.MountainId
  LEFT JOIN CountriesRivers
         AS cr
		 ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers
         AS r
		 ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName
