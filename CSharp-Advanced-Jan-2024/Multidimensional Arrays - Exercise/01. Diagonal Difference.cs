namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            int diagonalRightSum = 0;
            int diagonalLeftSum = 0;

            for (int row = 0; row < size; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (row == col)
                    {
                        diagonalRightSum += matrix[row, col];
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                diagonalLeftSum += matrix[row, size - 1 - row];
            }

            Console.WriteLine(Math.Abs(diagonalRightSum - diagonalLeftSum));
        }
    }
}

