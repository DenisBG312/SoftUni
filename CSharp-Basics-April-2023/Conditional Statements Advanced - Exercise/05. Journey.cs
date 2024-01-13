using System;
using System.ComponentModel;

namespace _05._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	При 100лв.или по-малко – някъде в България
                //o   Лято – 30 % от бюджета
                //o   Зима – 70 % от бюджета
            //•	При 1000лв.или по малко – някъде на Балканите
                //o   Лято – 40 % от бюджета
                //o   Зима – 80 % от бюджета
            //•	При повече от 1000лв. – някъде из Европа
                //o   При пътуване из Европа, независимо от сезона ще похарчи 90 % от бюджета.

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            string resting = "";
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    budget *= 0.3;
                    resting = "Camp";
                }
                else if (season == "winter")
                {
                    budget *= 0.7;
                    resting = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    budget *= 0.4;
                    resting = "Camp";
                }
                else if (season == "winter")
                {
                    budget *= 0.8;
                    resting = "Hotel";
                }
            }
            else
            {
                destination = "Europe";
                budget *= 0.9;
                resting = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{resting} - {budget:f2}");
        }
    }
}
