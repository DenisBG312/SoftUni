namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 3;

            int[] arr = new int[n];

            int minNum = int.MaxValue;

            int minNumWritten;

            Console.WriteLine(MinNum(n, arr, minNum));
        }

        static int MinNum(int n, int[] arr, int minNum)
        {
            for (int i = 0; i < n; i++)
            {
                int givenNum = int.Parse(Console.ReadLine());
                arr[i] = givenNum;
                if (arr[i] < minNum)
                {
                    minNum = arr[i];
                }
            }

            return minNum;
        }
    }
}
