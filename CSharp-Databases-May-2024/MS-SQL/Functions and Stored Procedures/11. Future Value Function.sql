
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(10, 4), @yearlyInterestRate FLOAT, @numOfYears INT)
RETURNS DECIMAL(10, 4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(10,4)
	SET @futureValue = @sum * POWER(1 + @yearlyInterestRate, @numOfYears)

	RETURN @futureValue
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS FutureValue;


