using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Wild_Zoo
{
    class Zoo
    {
        public string Name { get; set; }
        public double DailyFoodLimit { get; set; }
        public string Area { get; set; }

        public Zoo(string name, double dailyFoodLimit, string area)
        {
            Name = name;
            DailyFoodLimit = dailyFoodLimit;
            Area = area;
        }

        public override string ToString()
        {
            return $" {Name} -> {DailyFoodLimit}g";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Zoo> animals = new List<Zoo>();
            List<string> areasWithHungryAnimals = new List<string>();

            while ((input = Console.ReadLine()) != "EndDay")
            {
                string[] command = input.Split(": ");
                if (command[0] == "Add")
                {
                    string[] arguments = command[1].Split("-");
                    string name = arguments[0];
                    double dailyFoodLimit = double.Parse(arguments[1]);
                    string area = arguments[2];
                    Zoo animal = animals.FirstOrDefault(x => x.Name == name);

                    if (animal == null)
                    {
                        animals.Add(new Zoo(name, dailyFoodLimit, area));
                        if (dailyFoodLimit > 0 && !areasWithHungryAnimals.Contains(area))
                        {
                            areasWithHungryAnimals.Add(area);
                        }
                    }
                    else
                    {
                        animal.DailyFoodLimit += dailyFoodLimit;
                    }
                }
                else if (command[0] == "Feed")
                {
                    string[] arguments = command[1].Split("-");
                    string name = arguments[0];
                    double food = double.Parse(arguments[1]);
                    Zoo animal = animals.FirstOrDefault(x => x.Name == name);
                    if (animal != null)
                    {
                        animal.DailyFoodLimit -= food;
                        if (animal.DailyFoodLimit <= 0)
                        {
                            animals.Remove(animal);
                            Console.WriteLine($"{animal.Name} was successfully fed");
                            if (animal.DailyFoodLimit > 0 && !areasWithHungryAnimals.Contains(animal.Area))
                            {
                                areasWithHungryAnimals.Add(animal.Area);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Animals:");
            foreach (Zoo animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach (string area in areasWithHungryAnimals)
            {
                int count = 0;

                foreach (var animal in animals)
                {
                    if (animal.Area == area && animal.DailyFoodLimit > 0)
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    Console.WriteLine($" {area}: {count}");
                }
            }
        }
    }
}
