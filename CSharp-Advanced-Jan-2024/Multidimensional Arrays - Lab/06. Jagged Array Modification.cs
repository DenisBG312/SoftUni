namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitted = input.Split();
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (row < 0 || row >= rows || col < 0 || col >= rows)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (splitted[0] == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (splitted[0] == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
