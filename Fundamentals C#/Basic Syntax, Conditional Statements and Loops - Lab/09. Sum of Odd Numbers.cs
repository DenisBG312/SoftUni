namespace _09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalNum = 0;
            
            for (int i = 1; i <= n; i++)
            {
                int newNum = i * 2 - 1;
                totalNum += newNum;
                Console.WriteLine($"{newNum}");
            }
            Console.WriteLine($"Sum: {totalNum}");
        }
    }
}
