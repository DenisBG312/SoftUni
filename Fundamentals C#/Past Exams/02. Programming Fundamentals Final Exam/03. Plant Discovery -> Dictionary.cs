using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalFeedingProgram
{
    class Plant
    {
        public string Name { get; set; }
        public double Rarity { get; set; }
        public List<double> Rating { get; set; }

        public Plant(string name, double rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = new List<double>();
        }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {(Rating.Count == 0 ? 0 : Rating.Average()):f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split("<->");
                string name = inputs[0];
                double rarity = double.Parse(inputs[1]);

                if (!plants.ContainsKey(name))
                {
                    Plant plant = new Plant(name, rarity);
                    plants.Add(name, plant);
                }
                else
                {
                    plants[name].Rarity = rarity;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] command = input.Split(": ");
                if (command[0] == "Rate")
                {
                    string[] arguments = command[1].Split(" - ");
                    string name = arguments[0];
                    double rating = double.Parse(arguments[1]);

                    if (!plants.ContainsKey(name))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    plants[name].Rating.Add(rating);
                }
                else if (command[0] == "Update")
                {
                    string[] arguments = command[1].Split(" - ");
                    string name = arguments[0];
                    double newRarity = double.Parse(arguments[1]);

                    if (!plants.ContainsKey(name))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        plants[name].Rarity = newRarity;
                    }
                }
                else if (command[0] == "Reset")
                {
                    string name = command[1];
                    if (!plants.ContainsKey(name))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        plants[name].Rating.Clear();
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                Console.WriteLine(plant.Value);
            }
        }
    }
}
