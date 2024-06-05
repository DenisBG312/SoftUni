USE [Geography]

    SELECT [mc].[CountryCode],
		   [m].[MountainRange],
		   [p].[PeakName],
		   [p].[Elevation]
      FROM [MountainsCountries]
        AS [mc]
INNER JOIN [Countries]
	    AS [c]
		ON [mc].[CountryCode] = [c].CountryCode
INNER JOIN [Mountains] 
        AS [m]
		ON [mc].[MountainId] = [m].[Id]
INNER JOIN [Peaks]
        AS [p]
		ON [p].[MountainId] = [m].[Id]
		WHERE [c].[CountryName] = 'Bulgaria' AND
			  [p].[Elevation] > 2835
	 ORDER BY [p].[Elevation] DESC
         
