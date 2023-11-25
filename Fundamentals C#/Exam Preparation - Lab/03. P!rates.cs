using System.Linq;

namespace P_rates
{
    class City
    {
        public string Town { get; set; }
        public int Population { get; set; }
        public double Gold { get; set; }

        public City(string town, int population, double gold)
        {
            Town = town;
            Population = population;
            Gold = gold;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<City> cities = new List<City>();
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] tokens = input
                    .Split("||")
                    .ToArray();

                string name = tokens[0];
                int population = int.Parse(tokens[1]);
                double gold = int.Parse(tokens[2]);
                City isValid = cities.FirstOrDefault(x => x.Town == name);
                if (isValid != null)
                {
                    isValid.Population += population;
                    isValid.Gold += gold;
                    continue;
                }
                City town = new City(name, population, gold); 
                cities.Add(town);
            }


            string inputSec;
            while((inputSec = Console.ReadLine()) != "End")
            {
                string[] tokens = inputSec
                    .Split("=>")
                    .ToArray();

                string command = tokens[0];
                string town = tokens[1];

                City city = cities.FirstOrDefault(x => x.Town == town);
                if (command == "Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    double gold = double.Parse(tokens[3]);
                    city.Gold -= gold;
                    city.Population -= people;
                    Console.WriteLine($"{city.Town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (city.Population <= 0 || city.Gold == 0)
                    {
                        Console.WriteLine($"{city.Town} has been wiped off the map!");
                        cities.Remove(city);
                    }
                }
                else if (command == "Prosper")
                {
                    double gold = double.Parse(tokens[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    city.Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {city.Town} now has {city.Gold} gold.");
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Town} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
        }
    }
}
