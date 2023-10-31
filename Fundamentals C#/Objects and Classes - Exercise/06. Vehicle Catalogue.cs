using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new Catalog();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                string type = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                if (type == "car")
                {
                    var car = new Car(model, color, horsePower);
                    catalog.Cars.Add(car);

                }
                else if (type == "truck")
                {
                    var truck = new Truck(model, color, horsePower);
                    catalog.Trucks.Add(truck);

                }


            }
            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("Close the Catalogue"))
                {
                    break;
                }

                foreach (var car in catalog.Cars.Where(x => x.Model == command))
                {
                    Console.WriteLine($"Type: Car");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HorsePower}");
                }

                foreach (var car in catalog.Trucks.Where(x => x.Model == command))
                {
                    Console.WriteLine($"Type: Truck");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HorsePower}");
                }

            }

            int totalCars = catalog.Cars.Count;
            int totalTrucks = catalog.Trucks.Count;
            double sumCarkHorsePower = catalog.Cars.Sum(x => x.HorsePower);
            double sumTruckHorsePower = catalog.Trucks.Sum(x => x.HorsePower);

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumCarkHorsePower / totalCars:f2}.");
            }

            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {sumTruckHorsePower / totalTrucks:f2}.");
            }

            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }

        }
    }
    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Car(string model, string color, int horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
    }
    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Truck(string model, string color, int horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;

        }
    }
}
