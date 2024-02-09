
namespace _02._The_Gambler1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int currRow = 0;
            int currCol = 0;

            int currDollars = 100;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string newRow = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (newRow[j].ToString() == "G")
                    {
                        currRow = i;
                        currCol = j;
                        matrix[i, j] = "-";
                        continue;
                    }
                    matrix[i, j] = newRow[j].ToString();
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string direction = input;
                if (GamblerLeftTheBoard(n, currRow, currCol, direction))
                {
                    Console.WriteLine("Game over! You lost everything!");
                    return;
                }

                if (direction == "left")
                {
                    currCol--;
                }
                if (direction == "right")
                {
                    currCol++;
                }
                if (direction == "down")
                {
                    currRow++;
                }
                if (direction == "up")
                {
                    currRow--;
                }


                if (matrix[currRow, currCol] == "W")
                {
                    currDollars += 100;
                }
                else if (matrix[currRow, currCol] == "P")
                {
                    currDollars -= 200;
                }
                else if (matrix[currRow, currCol] == "J")
                {
                    currDollars += 100000;
                    Console.WriteLine("You win the Jackpot!");
                    break;
                }

                if (currDollars <= 0)
                {
                    Console.WriteLine("Game over! You lost everything!");
                    return;
                }

                matrix[currRow, currCol] = "-";
            }

            matrix[currRow, currCol] = "G";
            Console.WriteLine($"End of the game. Total amount: {currDollars}$");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static bool GamblerLeftTheBoard(int size, int currRow, int currCol, string? direction)
        {
            if (direction == "left" && currCol == 0)
            {
                return true;
            }
            if (direction == "right" && currCol == size - 1)
            {
                return true;
            }

            if (direction == "up" && currRow == 0)
            {
                return true;
            }

            if (direction == "down" && currRow == size - 1)
            {
                return true;
            }

            return false;
        }
    }
}
