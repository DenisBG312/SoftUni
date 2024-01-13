using System;

namespace _05._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int statisticsCount = int.Parse(Console.ReadLine());
            double clotheCost = double.Parse(Console.ReadLine());

            double decorPrice = movieBudget * 0.1;
            double clothePrice = clotheCost * statisticsCount;
            if (statisticsCount > 150)
            {
               double clothePriceDisc = clothePrice * 0.1;
               clothePrice -= clothePriceDisc;
            }
            double totalMoviePrice = decorPrice + clothePrice;
            if (movieBudget >= totalMoviePrice)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {movieBudget - totalMoviePrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalMoviePrice - movieBudget:f2} leva more.");

            }
        }
    }
}
