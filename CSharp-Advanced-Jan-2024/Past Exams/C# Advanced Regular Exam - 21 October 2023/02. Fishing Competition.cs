namespace _02._Fishing_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            char[,] area = new char[rowsCols, rowsCols];

            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0; row < area.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    area[row, col] = input[col];
                }
            }

            for (int row = 0; row < area.GetLength(0); row++)
            {
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    if (area[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                        break;
                    }
                }
            }

            string inputWhile;
            int caughtFish = 0;

            while ((inputWhile = Console.ReadLine()) != "collect the nets")
            {
                area[currentRow, currentCol] = '-';
                string direction = inputWhile;
                if (direction == "up")
                {
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow = rowsCols - 1;
                    }
                }
                else if (direction == "down")
                {
                    currentRow++;
                    if (currentRow >= rowsCols)
                    {
                        currentRow = 0;
                    }
                }
                else if (direction == "left")
                {
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol = rowsCols - 1;
                    }
                }
                else if (direction == "right")
                {
                    currentCol++;
                    if (currentCol >= rowsCols)
                    {
                        currentCol = 0;
                    }
                }

                if (area[currentRow, currentCol] != '-')
                {
                    if (area[currentRow, currentCol] == 'W')
                    {
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");
                        return;
                    }
                    else
                    {
                        caughtFish += int.Parse(area[currentRow, currentCol].ToString());
                    }
                }

                area[currentRow, currentCol] = 'S';
            }

            if (caughtFish < 20)
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - caughtFish} tons of fish more.");
            }
            else
            {
                Console.WriteLine($"Success! You managed to reach the quota!");
            }

            if (caughtFish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {caughtFish} tons.");
            }

            for (int row = 0; row < area.GetLength(0); row++)
            {
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    Console.Write(area[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
