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
        string[,] matrix = new string[rows, cols];

        ReadArray(matrix, rows, cols);

        string input = Console.ReadLine();

        while (input != "END")
        {

            if (!ValidateCommand(input, rows, cols))
            {
                Console.WriteLine("Invalid input!");
                input = Console.ReadLine();
                continue;
            }
            string[] commandParts = input.Split();
            int row1 = int.Parse(commandParts[1]);
            int col1 = int.Parse(commandParts[2]);
            int row2 = int.Parse(commandParts[3]);
            int col2 = int.Parse(commandParts[4]);

            string oldElement = matrix[row1, col1];
            string newElement = matrix[row2, col2];

            matrix[row1, col1] = newElement;
            matrix[row2, col2] = oldElement;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            input = Console.ReadLine();
        }
    }

    private static bool ValidateCommand(string input, int rows, int cols)
    {
        string[] commandParts = input.Split();
        if (commandParts[0] == "swap" && commandParts.Length == 5)
        {
            int row1 = int.Parse(commandParts[1]);
            int col1 = int.Parse(commandParts[2]);
            int row2 = int.Parse(commandParts[3]);
            int col2 = int.Parse(commandParts[4]);

            if (row1 >= 0 && row1 < rows
                          && col1 >= 0 && col1 < cols
                          && row2 >= 0 && row2 < rows
                          && col2 >= 0 && col2 < cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private static void ReadArray(string[,] matrix, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            string[] rowInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowInput[col];
            }
        }
    }
}
