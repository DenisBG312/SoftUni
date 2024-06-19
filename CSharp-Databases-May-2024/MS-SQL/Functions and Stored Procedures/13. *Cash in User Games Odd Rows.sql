CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(MAX))
RETURNS TABLE
RETURN(
SELECT SUM(Cash) AS SumCash
FROM (
SELECT 
	g.Id, g.[Name], ug.Cash,
	ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowRank
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
	WHERE g.[Name] = @gameName) AS NestedQuery
	WHERE RowRank % 2 = 1
	)

SELECT * FROM ufn_CashInUsersGames('Love in a mist')
