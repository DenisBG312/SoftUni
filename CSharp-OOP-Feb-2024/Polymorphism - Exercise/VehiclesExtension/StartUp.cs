using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));

            var truckData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));

            var busData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

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
                            case "Bus":
                                bus.DriveWithPeople(double.Parse(data[2]));
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
                            case "Bus":
                                bus.Refuel(double.Parse(data[2]));
                                break;
                        }
                    }
                    else if (data[0] == "DriveEmpty")
                    {
                        bus.Drive(double.Parse(data[2]));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
