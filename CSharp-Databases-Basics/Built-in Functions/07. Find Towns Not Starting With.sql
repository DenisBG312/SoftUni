USE [SoftUni]

 SELECT *
   FROM [Towns]
   WHERE LEFT([Name], 1) NOT LIKE '[RBD]%'
   ORDER BY [Name] 
