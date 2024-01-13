using System;

namespace _04._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Пъзел - 2.60 лв.
            //•	Говореща кукла -3 лв.
            //•	Плюшено мече -4.10 лв.
            //•	Миньон - 8.20 лв.
            //•	Камионче - 2 лв.

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double totalPrice = puzzlesCount * 2.6 + talkingDolls * 3 + bearsCount * 4.1 + minionsCount * 8.2 + trucksCount * 2;
            double totalToys = puzzlesCount + talkingDolls + bearsCount + minionsCount + trucksCount;
            if (totalToys >= 50)
            {
                double totalPriceDisc = totalPrice * 0.25;
                totalPrice -= totalPriceDisc;
            }
            double rent = totalPrice * 0.1;
            double profit = totalPrice - rent;
            if (profit >= tripPrice)
            {
                Console.WriteLine($"Yes! {profit - tripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice - profit:f2} lv needed.");
            }

        }
    }
}
