using System;

namespace _10._Odd_Even_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            double totalOne = 0;
            double totalTwo = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    totalOne += num;
                }
                else
                {
                    totalTwo += num;
                }
            }
            if (totalOne == totalTwo)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {totalTwo}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(totalOne - totalTwo)}");
            }
        }
    }
}
