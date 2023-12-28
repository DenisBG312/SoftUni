using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace AnimalFeedingProgram
{
    class Car
    {
        public string Model { get; set; }
        public double Mileage { get; set; }
        public double Fuel { get; set; }
        public Car(string model, double mileage, double fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }
        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split("|");
                string model = inputs[0];
                double mileage = double.Parse(inputs[1]);
                double fuel = double.Parse(inputs[2]);
                Car car = new Car(model, mileage, fuel);
                cars.Add(model, car);
            }

            string input;
            while((input = Console.ReadLine()) != "Stop")
            {
                string[] arguments = input.Split(" : ");
                if (arguments[0] == "Drive")
                {
                    string model = arguments[1];
                    double distance = double.Parse(arguments[2]);
                    double fuel = double.Parse(arguments[3]);
                    if (cars[model].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                        continue;
                    }
                    cars[model].Mileage += distance;
                    cars[model].Fuel -= fuel;
                    Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    if (cars[model].Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {model}!");
                        cars.Remove(model);
                    }
                }
                else if (arguments[0] == "Refuel")
                {
                    string model = arguments[1];
                    double fuel = double.Parse(arguments[2]);
                    double toBeAdded = Math.Min(fuel, 75 - cars[model].Fuel);
                    cars[model].Fuel += toBeAdded;
                    Console.WriteLine($"{model} refueled with {toBeAdded} liters");
                }
                else if (arguments[0] == "Revert")
                {
                    string model = arguments[1];
                    double kilometres = double.Parse(arguments[2]);
                    cars[model].Mileage -= kilometres;
                    if (cars[model].Mileage < 10000)
                    {
                        cars[model].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{model} mileage decreased by {kilometres} kilometers");
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}

