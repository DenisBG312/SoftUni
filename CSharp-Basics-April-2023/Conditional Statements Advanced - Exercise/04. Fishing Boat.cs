using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace _04._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenCount = int.Parse(Console.ReadLine());
            double rent = 0;
            if (season == "Spring")
            {
                rent = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                rent = 4200;
            }
            else
            {
                rent = 2600;
            }

            if (fishermenCount <= 6)
            {
                rent *= 0.9;
            }
            else if (fishermenCount >= 7 && fishermenCount <= 11)
            {
                rent *= 0.85;
            }
            else
            {
                rent *= 0.75;
            }
            if (fishermenCount % 2 == 0 && season != "Autumn")
            {
                rent *= 0.95;
            }
            if (groupBudget >= rent)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(groupBudget - rent):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(rent - groupBudget):f2} leva.");
            }
        }
    }
}
