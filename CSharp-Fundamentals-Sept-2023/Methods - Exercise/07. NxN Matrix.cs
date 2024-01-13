namespace _7._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] arr = new int[num];

            FillArray(num, arr);
            PrintMatrix(num, arr);
        }

        private static void PrintMatrix(int num, int[] arr)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        private static void FillArray(int num, int[] arr)
        {
            for (int i = 0; i < num; i++)
            {
                arr[i] = num;
            }
        }
    }
}
