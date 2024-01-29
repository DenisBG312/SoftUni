using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int tire1Year = int.Parse(args[0]);
                double tire1Pressure = double.Parse(args[1]);
                int tire2Year = int.Parse(args[2]);
                double tire2Pressure = double.Parse(args[3]);
                int tire3Year = int.Parse(args[4]);
                double tire3Pressure = double.Parse(args[5]);
                int tire4Year = int.Parse(args[6]);
                double tire4Pressure = double.Parse(args[7]);

                Tire tireOne = new Tire(tire1Year, tire1Pressure);
                Tire tireTwo = new Tire(tire2Year, tire2Pressure);
                Tire tireThree = new Tire(tire3Year, tire3Pressure);
                Tire tireFour = new Tire(tire4Year, tire4Pressure);

                Tire[] tire = new Tire[4]
                {
                    tireOne,
                    tireTwo,
                    tireThree,
                    tireFour,
                };

                tires.Add(tire);
            }

            string input2;
            while ((input2 = Console.ReadLine()) != "Engines done")
            {
                string[] args = input2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(args[0]);
                double cubicCapacity = double.Parse(args[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }

            string output;
            while ((output = Console.ReadLine()) != "Show special")
            {
                string[] args = output.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = args[0];
                string model = args[1];
                int year = int.Parse(args[2]);
                double fuelQuantity = double.Parse(args[3]);
                double fuelConsumption = double.Parse(args[4]);
                int engineIndex = int.Parse(args[5]);
                int tiresIndex = int.Parse(args[6]);

                Engine currEngine = engines[engineIndex];
                Tire[] currentTires = tires[tiresIndex];

                Car carCreate = new Car(make, model, year, fuelQuantity, fuelConsumption, currEngine, currentTires);
                cars.Add(carCreate);
            }

            List<Car> specialCars = cars.Where(c => c.Year >= 2017 
                                    && c.Engine.HorsePower > 330 
                                    && c.Tires.Sum(c => c.Pressure) >= 9
                                    && c.Tires.Sum(c => c.Pressure) <= 10).ToList();

            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine(specialCar.WhoAmI());
            }
        }
    }
}
