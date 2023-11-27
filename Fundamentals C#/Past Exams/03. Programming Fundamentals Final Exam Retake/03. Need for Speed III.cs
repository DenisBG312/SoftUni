namespace _03._Need_For_Speed_III
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

    internal class Program
    {
        static List<Car> cars = new List<Car>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split("|");
                string model = arguments[0];
                double mileage = double.Parse(arguments[1]);
                double fuel = double.Parse(arguments[2]);
                Car car = new Car(model, mileage, fuel);
                cars.Add(car);
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] arguments = input.Split(" : ");
                if (arguments[0] == "Drive")
                {
                    Drive(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
                }
                else if (arguments[0] == "Refuel")
                {
                    Refuel(arguments[1], double.Parse(arguments[2]));
                }
                else if (arguments[0] == "Revert")
                {
                    Revert(arguments[1], double.Parse(arguments[2]));
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void Revert(string model, double kilometers)
        {
            Car car = cars.FirstOrDefault(c => c.Model == model);
            if (car == null)
            {
                return;
            }

            car.Mileage -= kilometers;
            if (car.Mileage < 10000)
            {
                car.Mileage = 10000;
            }
            else
            {
                Console.WriteLine($"{car.Model} mileage decreased by {kilometers} kilometers");
            }
        }

        private static void Refuel(string model, double fuel)
        {
            Car car = cars.FirstOrDefault(x => x.Model == model);
            if (car == null)
            {
                return;
            }

            double fuelToBeAdded = Math.Min(fuel, 75 - car.Fuel);
            car.Fuel += fuelToBeAdded;
            Console.WriteLine($"{car.Model} refueled with {fuelToBeAdded} liters");

        }

        private static void Drive(string model, double distance, double fuel)
        {
            Car car = cars.FirstOrDefault(x => x.Model == model);
            if (car == null)
            {
                return;
            }

            if (car.Fuel > fuel)
            {
                car.Fuel -= fuel;
                car.Mileage += distance;
                Console.WriteLine($"{car.Model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                if (car.Mileage >= 100000)
                {
                    cars.Remove(car);
                    Console.WriteLine($"Time to sell the {car.Model}!");
                }

            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }

        }
    }
}
