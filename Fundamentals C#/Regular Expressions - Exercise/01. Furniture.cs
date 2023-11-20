using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Furniture
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(?<Price>\d+\.\d+|\d+)!(?<Quantity>\d+)";
            List<Furniture> furnitures = new List<Furniture>();

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    decimal price = decimal.Parse(match.Groups["Price"].Value);
                    int quantity = int.Parse(match.Groups["Quantity"].Value);

                    Furniture furniture = new Furniture(name, price, quantity);
                    furnitures.Add(furniture);
                }
            }

            decimal totalPrice = 0;
            Console.WriteLine("Bought furniture:");
            foreach (Furniture furniture in furnitures)
            {
                Console.WriteLine($"{furniture.Name}");
                totalPrice += furniture.Total();
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
