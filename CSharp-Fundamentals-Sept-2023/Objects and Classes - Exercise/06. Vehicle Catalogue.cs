using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalog
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string HorsePower { get; set; }

        public Vehicle(string type, string model, string color, string horsePower)
        {
            Type = type; 
            Model = model; 
            Color = color; 
            HorsePower = horsePower;
        }
        public override string ToString()
        {
            return $"Model: {Model}\n" +
                   $"Color: {Color}\n" +
                   $"Horsepower: {HorsePower}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            CreateListOfVehicles(vehicles);

            PrintDataForEachVehicle(vehicles);

            CalculateAverageHP(vehicles);
        }



        private static void CalculateAverageHP(List<Vehicle> vehicles)
        {
            double carAvg = 0;
            double truckAvg = 0;
            double carCount = 0;
            double truckCount = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Type == "car")
                {
                    carAvg += double.Parse(vehicle.HorsePower);
                    carCount++;
                }
                else if (vehicle.Type == "truck")
                {
                    truckAvg += double.Parse(vehicle.HorsePower);
                    truckCount++;
                }
            }
            if (carCount > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carAvg / carCount:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (truckCount > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {truckAvg / truckCount:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }

        private static void PrintDataForEachVehicle(List<Vehicle> vehicles)
        {
            string vehicleModel = Console.ReadLine();
            while (vehicleModel != "Close the Catalogue")
            {
                foreach (Vehicle vehicle in vehicles.Where(x => x.Model == vehicleModel))
                {
                        if (vehicle.Type == "car")
                        {
                            Console.WriteLine($"Type: {vehicle.Type.Replace('c', 'C')}");
                        }
                        else
                        {
                            Console.WriteLine($"Type: {vehicle.Type.Replace('t', 'T')}");
                        }

                        Console.WriteLine(vehicle);
                }
                vehicleModel = Console.ReadLine();
            }
        }

        private static void CreateListOfVehicles(List<Vehicle> vehicles)
        {
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                Vehicle vehicle = new Vehicle(input[0], input[1], input[2], input[3]);
                vehicles.Add(vehicle);
                input = Console.ReadLine().Split();
            }
        }
    }
}
