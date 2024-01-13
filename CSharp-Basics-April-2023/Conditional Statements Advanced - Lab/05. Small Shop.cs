using System;

namespace _05._Small_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double cost = 0;
            
            if (town == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        cost = 0.5;
                        break;
                    case "water":
                        cost = 0.8;
                        break;
                    case "beer":
                        cost = 1.2;
                        break;
                    case "sweets":
                        cost = 1.45;
                        break;
                    case "peanuts":
                        cost = 1.6;
                        break;
                }
            }
            else if (town == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        cost = 0.4;
                        break;
                    case "water":
                        cost = 0.7;
                        break;
                    case "beer":
                        cost = 1.15;
                        break;
                    case "sweets":
                        cost = 1.3;
                        break;
                    case "peanuts":
                        cost = 1.5;
                        break;
                }
            }
            else if (town == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        cost = 0.45;
                        break;
                    case "water":
                        cost = 0.7;
                        break;
                    case "beer":
                        cost = 1.1;
                        break;
                    case "sweets":
                        cost = 1.35;
                        break;
                    case "peanuts":
                        cost = 1.55;
                        break;
                }
            }
            double totalPrice = quantity * cost;
            Console.WriteLine($"{totalPrice}");
        }
    }
}
