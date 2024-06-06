USE Gringotts
GO

SELECT MAX(MagicWandSize)
    AS LongestMagicWand
  FROM WizzardDeposits
