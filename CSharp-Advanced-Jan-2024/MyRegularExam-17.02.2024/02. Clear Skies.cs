namespace _02._SecondExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowCols, rowCols];

            int jetRow = -1;
            int jetCol = -1;

            int enemyCount = 0;
            int initialArmor = 300;

            for (int row = 0; row < rowCols; row++)
            {
                string inputLine = Console.ReadLine();
                for (int col = 0; col < rowCols; col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'J')
                    {
                        jetRow = row;
                        jetCol = col;
                    }

                    if (matrix[row, col] == 'E')
                    {
                        enemyCount++;
                    }
                }
            }

            while (enemyCount != 0 && initialArmor != 0)
            {
                string direction = Console.ReadLine();

                matrix[jetRow, jetCol] = '-';

                if (direction == "up")
                {
                    jetRow--;
                }
                else if (direction == "down")
                {
                    jetRow++;
                }
                else if (direction == "left")
                {
                    jetCol--;
                }
                else if (direction == "right")
                {
                    jetCol++;
                }

                if (matrix[jetRow, jetCol] == 'E')
                {
                    enemyCount--;
                    matrix[jetRow, jetCol] = '-';
                    if (enemyCount == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                    }
                    else
                    {
                        initialArmor -= 100;
                        if (initialArmor == 0)
                        {
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
                        }
                    }
                }

                if (matrix[jetRow, jetCol] == 'R')
                {
                    initialArmor = 300;
                }

                matrix[jetRow, jetCol] = 'J';
            }

            for (int row = 0; row < rowCols; row++)
            {
                for (int col = 0; col < rowCols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
