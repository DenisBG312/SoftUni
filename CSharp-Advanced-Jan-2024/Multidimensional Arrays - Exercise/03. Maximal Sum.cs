using System;

class Program
{
    static void Main()
    {
        int[] rowCols = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = rowCols[0];
        int cols = rowCols[1];
        int[,] matrix = new int[rows, cols];
        int maxSum = int.MinValue;
        int maxRow = 0;
        int maxCol = 0;

        ReadArray(matrix, rows, cols);

        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                int currentSum = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        currentSum += matrix[row + i, col + j];
                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");

        for (int row = maxRow; row < maxRow + 3; row++)
        {
            for (int col = maxCol; col < maxCol + 3; col++)
            {
                Console.Write(matrix[row,col] + " ");
            }

            Console.WriteLine();
        }

    }

    private static void ReadArray(int[,] matrix, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            int[] rowInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowInput[col];
            }
        }
    }
}
