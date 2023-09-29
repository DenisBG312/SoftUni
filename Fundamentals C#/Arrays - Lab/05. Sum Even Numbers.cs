namespace _5._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenNum;
            int evenTotalSum = 0;

            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] % 2 == 0)
                {
                    evenNum = ints[i];
                    evenTotalSum += evenNum;
                }
            }

            Console.WriteLine($"{evenTotalSum}");
        }
    }
}
