namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] matrix = new long[size][];
            matrix[0] = new long[1] { 1 };

            for (int row = 1; row < size; row++)
            {
                matrix[row] = new long[row + 1];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col < matrix[row - 1].Length)
                    {
                        matrix[row][col] += matrix[row - 1][col];
                    }

                    if (col > 0)
                    {
                        matrix[row][col] += matrix[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
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
