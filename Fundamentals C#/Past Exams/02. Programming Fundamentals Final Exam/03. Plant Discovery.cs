using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Plant
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }

        public Plant(string name, string rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = 0;
            RatingCount = 0;
        }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {(RatingCount == 0 ? 0 : Rating / RatingCount):f2}";
        }
    }

    internal class Program
    {
        static List<Plant> plants = new List<Plant>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split("<->");
                string name = arguments[0];
                string rarity = arguments[1];

                Plant existingPlant = plants.FirstOrDefault(x => x.Name == name);

                if (existingPlant == null)
                {
                    plants.Add(new Plant(name, rarity));
                }
                else
                {
                    existingPlant.Rarity = rarity;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] arguments = input.Split(":");
                if (arguments[0] == "Rate")
                {
                    string[] commandArgs = arguments[1].Split(" - ");
                    string plantName = commandArgs[0].Trim();
                    double rating = double.Parse(commandArgs[1].Trim());

                    Rate(plantName, rating);
                }
                else if (arguments[0] == "Update")
                {
                    string[] commandArgs = arguments[1].Split(" - ");
                    string plantName = commandArgs[0].Trim();
                    string newRarity = commandArgs[1].Trim();

                    Update(plantName, newRarity);
                }
                else if (arguments[0] == "Reset")
                {
                    string plantName = arguments[1].Trim();
                    Reset(plantName);
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants)
            {
                Console.WriteLine(plant);
            }
        }

        private static void Reset(string plantName)
        {
            Plant plant = plants.FirstOrDefault(x => x.Name == plantName);

            if (plant == null)
            {
                Console.WriteLine("error");
                return;
            }

            plant.Rating = 0;
            plant.RatingCount = 0;
        }

        private static void Update(string plantName, string newRarity)
        {
            Plant plant = plants.FirstOrDefault(x => x.Name == plantName);

            if (plant == null)
            {
                Console.WriteLine("error");
                return;
            }

            plant.Rarity = newRarity;
        }

        private static void Rate(string plantName, double rating)
        {
            Plant plant = plants.FirstOrDefault(x => x.Name == plantName);

            if (plant == null)
            {
                Console.WriteLine("error");
                return;
            }

            plant.Rating += rating;
            plant.RatingCount++;
        }
    }
}
