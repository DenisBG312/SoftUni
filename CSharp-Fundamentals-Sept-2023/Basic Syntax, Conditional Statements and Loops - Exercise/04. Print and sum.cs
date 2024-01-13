namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            double totalSum = 0;
            
            for (int i = startNum; i <= endNum; i++)
            {
                Console.Write($"{i} ");
                totalSum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}
