namespace _06._Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km, 0);
                cars.Add(car);
            }

            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "End")
            {
                string[] inputLine = inputCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = inputLine[1];
                double amountKm = double.Parse(inputLine[2]);

                Car currCar = cars.Find(c => c.Model == carModel);
                currCar.CheckMoveDistance(amountKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
