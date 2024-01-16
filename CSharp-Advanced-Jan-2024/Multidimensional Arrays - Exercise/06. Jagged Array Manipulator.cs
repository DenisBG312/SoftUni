namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < size - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int upperCol = 0; upperCol < matrix[row].Length; upperCol++)
                    {
                        matrix[row][upperCol] /= 2;
                    }
                    for (int secondCol = 0; secondCol < matrix[row + 1].Length; secondCol++)
                    {
                        matrix[row + 1][secondCol] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitted = input.Split();
                string command = splitted[0];
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);
                if (row < 0 || row >= matrix.Length
                            || col < 0 
                            || col >= matrix[row].Length)
                {
                    continue;
                }

                if (command == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }



            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
