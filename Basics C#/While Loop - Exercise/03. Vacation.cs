using System;

namespace While_Loop___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            double spendDays = 0;
            double days = 0;

            while (availableMoney < neededMoney)
            {
                string input = Console.ReadLine();
                double someNum = double.Parse(Console.ReadLine());
                days++;
                if (input == "spend")
                {
                    availableMoney -= someNum;
                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                    spendDays++;
                    if (spendDays == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{days}");
                        break;
                    }
                }
                else if (input == "save")
                {
                    availableMoney += someNum;
                    spendDays = 0;
                }
            }
            if (availableMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
