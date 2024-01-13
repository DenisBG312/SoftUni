using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace AnimalFeedingProgram
{
    class Target
    {
        public string City { get; set; }
        public double Population { get; set; }
        public double Gold { get; set; }
        public Target(string city, double population, double gold)
        {
            City = city;
            Population = population;
            Gold = gold;
        }
        public override string ToString()
        {
            return $"{City} -> Population: {Population} citizens, Gold: {Gold} kg";
        }

        class Program
        {
            static void Main(string[] args)
            {
                string input;
                Dictionary<string, Target> targets = new Dictionary<string, Target>();
                while ((input = Console.ReadLine()) != "Sail")
                {
                    string[] arguments = input.Split("||");
                    string city = arguments[0];
                    double population = double.Parse(arguments[1]);
                    double gold = double.Parse(arguments[2]);
                    if (!targets.ContainsKey(city))
                    {
                        Target target = new Target(city, population, gold);
                        targets.Add(city, target);
                    }
                    else
                    {
                        targets[city].Population += population;
                        targets[city].Gold += gold;
                    }
                }

                string inputS;
                while ((inputS = Console.ReadLine()) != "End")
                {
                    string[] arguments = inputS.Split("=>");
                    if (arguments[0] == "Plunder")
                    {
                        string town = arguments[1];
                        double people = double.Parse(arguments[2]);
                        double gold = double.Parse(arguments[3]);
                        targets[town].Population -= people;
                        targets[town].Gold -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (targets[town].Gold <= 0 || targets[town].Population <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            targets.Remove(town);
                        }
                    }
                    else if (arguments[0] == "Prosper")
                    {
                        string town = arguments[1];
                        double gold = double.Parse(arguments[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        else
                        {
                            targets[town].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {targets[town].Gold} gold.");
                        }
                    }
                }
                if (targets.Count > 0)
                {
                    Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");
                    foreach ( var target in targets )
                    {
                        Console.WriteLine(target.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                }
            }
        }
    }
}
