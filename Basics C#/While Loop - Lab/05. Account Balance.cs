using System;

namespace _05._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalSum = 0;
            while (input != "NoMoreMoney")
            {
                double num = double.Parse(input);
                if (num <= 0)
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {num:f2}");
                totalSum += num;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {totalSum:f2}");
        }
    }
}
