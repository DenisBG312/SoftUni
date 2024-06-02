USE [Geography]

	SELECT [CountryCode],
		   COUNT([MountainId])
	    AS [MountainRanges]
	  FROM [MountainsCountries]
	 WHERE [CountryCode] IN (
					SELECT [CountryCode]
					  FROM [Countries]
					 WHERE [CountryName] IN ('United States', 'Russia', 'Bulgaria')
							)
  GROUP BY [CountryCode]
         
