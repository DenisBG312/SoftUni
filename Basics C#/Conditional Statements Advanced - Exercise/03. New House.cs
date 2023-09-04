using System;

namespace _03._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeFlowers = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double price = 0;

            switch (typeFlowers)
            {
                case "Roses":
                    price = 5;
                    break;
                case "Dahlias":
                    price = 3.8;
                    break;
                case "Tulips":
                    price = 2.8;
                    break;
                case "Narcissus":
                    price = 3;
                    break;
                case "Gladiolus":
                    price = 2.5;
                    break;
            }
            double totalPrice = flowersCount * price;
            if (typeFlowers == "Roses" && flowersCount > 80)
            {
                totalPrice *= 0.9;
            }
            else if (typeFlowers == "Dahlias" && flowersCount > 90)
            {
                totalPrice *= 0.85;
            }
            else if (typeFlowers == "Tulips" && flowersCount > 80)
            {
                totalPrice *= 0.85;
            }
            else if (typeFlowers == "Narcissus" && flowersCount < 120)
            {
                totalPrice = totalPrice + totalPrice * 0.15;
            }
            else if (typeFlowers == "Gladiolus" && flowersCount < 80)
            {
                totalPrice = totalPrice + totalPrice * 0.2;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {typeFlowers} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
        }
    }
}
