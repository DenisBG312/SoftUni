namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowCols[0];
            int cols = rowCols[1];

            int currRow = -1;
            int currCol = -1;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = Convert.ToChar(input[col]);

                    if (matrix[row, col] == 'B')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            string inputWhile;
            int touchedPeople = 0;
            int moves = 0;

            while ((inputWhile = Console.ReadLine()) != "Finish")
            {
                string direction = inputWhile;

                if (direction == "up" && currRow == 0 ||
                    direction == "down" && currRow == rows - 1 ||
                    direction == "right" && currCol == cols - 1 ||
                    direction == "left" && currCol == 0)
                {
                    continue;
                }

                if (direction == "up" && matrix[currRow - 1, currCol] == 'O' ||
                    direction == "down" && matrix[currRow + 1, currCol] == 'O' ||
                    direction == "right" && matrix[currRow, currCol + 1] == 'O' ||
                    direction == "left" && matrix[currRow, currCol - 1] == 'O')
                {
                    continue;
                }

                if (touchedPeople == 3)
                {
                    break;
                }
                moves++;

                if (direction == "up")
                {
                    currRow--;
                }
                else if (direction == "down")
                {
                    currRow++;
                }
                else if (direction == "right")
                {
                    currCol++;
                }
                else if (direction == "left")
                {
                    currCol--;
                }

                if (matrix[currRow, currCol] == 'P')
                {
                    touchedPeople++;
                }

                matrix[currRow, currCol] = '-';
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedPeople} Moves made: {moves}");
        }
    }
}
