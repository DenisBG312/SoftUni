namespace _02._Delivery_Boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int rows = array[0];
            int cols = array[1];


            int boyRow = 0;
            int boyCol = 0;

            int boyInitialRow = 0;
            int boyInitialCol = 0;

            bool hasBeenOut = false;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'B')
                    {
                        boyRow = row;
                        boyCol = col;
                        boyInitialRow = row;
                        boyInitialCol = col;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "down")
                {
                    if (boyRow == rows - 1)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        hasBeenOut = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[boyRow + 1, boyCol] == '*')
                    {
                        continue;
                    }

                    if (matrix[boyRow, boyCol] != 'R')
                    {
                        matrix[boyRow, boyCol] = '.';
                    }

                    boyRow++;
                }
                else if (input == "up")
                {
                    if (boyRow == 0)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        hasBeenOut = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[boyRow - 1, boyCol] == '*')
                    {
                        continue;
                    }

                    if (matrix[boyRow, boyCol] != 'R')
                    {
                        matrix[boyRow, boyCol] = '.';
                    }

                    boyRow--;
                }
                else if (input == "right")
                {
                    if (boyCol == cols - 1)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        hasBeenOut = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[boyRow, boyCol + 1] == '*')
                    {
                        continue;
                    }

                    if (matrix[boyRow, boyCol] != 'R')
                    {
                        matrix[boyRow, boyCol] = '.';
                    }

                    boyCol++;
                }
                else if (input == "left")
                {
                    if (boyCol == 0)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        hasBeenOut = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[boyRow, boyCol - 1] == '*')
                    {
                        continue;
                    }

                    if (matrix[boyRow, boyCol] != 'R')
                    {
                        matrix[boyRow, boyCol] = '.';
                    }

                    boyCol--;
                }
                if (matrix[boyRow, boyCol] == 'P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");

                    matrix[boyRow, boyCol] = 'R';
                    continue;
                }
                if (matrix[boyRow, boyCol] == 'A')
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");

                    matrix[boyRow, boyCol] = 'P';
                    break;
                }
            }

            if (hasBeenOut)
            {
                matrix[boyInitialRow, boyInitialCol] = ' ';
            }
            else
            {
                matrix[boyInitialRow, boyInitialCol] = 'B';
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
