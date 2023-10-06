namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTriangle(n);
        }

        private static void PrintTriangle(int n)
        {
            PrintTopPart(n);
            PrintBottomPart(n);
        }

        private static void PrintBottomPart(int n)
        {
            for (int row = n - 1; row >= 0; row--)
            {
                PrintRow(row);
            }
        }

        private static void PrintTopPart(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintRow(row);
            }
        }

        private static void PrintRow(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col + " ");
            }

            Console.WriteLine();
        }
    }
}
