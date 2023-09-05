using System;

namespace _04._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ageLilly = int.Parse(Console.ReadLine());
            double washMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            double savedMoney = 0;
            double startingMoney = 0;
            double toyCount = 0;
            double moneyGet = 0;
            
            for (int i = 1; i <= ageLilly; i++)
            {
                
                if (i % 2 == 0)
                {
                    startingMoney += 10;
                    savedMoney += startingMoney;
                    moneyGet++;
                }
                else
                {
                    toyCount++;
                }
            }
            double toyTotal = toyCount * toyPrice;
            double totalSaved = (savedMoney + toyTotal) - moneyGet;

            if (totalSaved >= washMachinePrice)
            {
                Console.WriteLine($"Yes! {totalSaved - washMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washMachinePrice - totalSaved:f2}");
            }
        }
    }
}
