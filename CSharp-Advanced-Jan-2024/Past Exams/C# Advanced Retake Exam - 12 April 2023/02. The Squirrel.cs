namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowCols, rowCols];

            string[] movement = Console.ReadLine()
                .Split(", ")
                .ToArray();

            int squirrelRow = -1;
            int squirrelCol = -1;

            int hazelNutsCount = 0;

            for (int row = 0; row < rowCols; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rowCols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }
                }
            }


            bool isToBeWritten = true;
            foreach (var move in movement)
            {
                if (move == "left" && squirrelCol == 0 ||
                    move == "right" && squirrelCol == rowCols - 1 ||
                    move == "up" && squirrelRow == 0 ||
                    move == "down" && squirrelRow == rowCols - 1)
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    isToBeWritten = false;
                    break;
                }

                matrix[squirrelRow, squirrelCol] = '*';

                if (move == "left")
                {
                    squirrelCol--;
                }
                else if (move == "right")
                {
                    squirrelCol++;
                }
                else if (move == "down")
                {
                    squirrelRow++;
                }
                else if (move == "up")
                {
                    squirrelRow--;
                }

                if (matrix[squirrelRow, squirrelCol] == 'h')
                {
                    hazelNutsCount++;
                    if (hazelNutsCount == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        isToBeWritten = false;
                        break;
                    }
                }

                if (matrix[squirrelRow, squirrelCol] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    isToBeWritten = false;
                }


                matrix[squirrelRow, squirrelCol] = 's';

            }

            if (isToBeWritten)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }
            Console.WriteLine($"Hazelnuts collected: {hazelNutsCount}");
        }
    }
}
