using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));

            var truckData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                try
                {
                    var data = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (data[0] == "Drive")
                    {
                        switch (data[1])
                        {
                            case "Car":
                                car.Drive(double.Parse(data[2]));
                                break;
                            case "Truck":
                                truck.Drive(double.Parse(data[2]));
                                break;
                        }
                    }
                    else if (data[0] == "Refuel")
                    {
                        switch (data[1])
                        {
                            case "Car":
                                car.Refuel(double.Parse(data[2]));
                                break;
                            case "Truck":
                                truck.Refuel(double.Parse(data[2]));
                                break;
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
