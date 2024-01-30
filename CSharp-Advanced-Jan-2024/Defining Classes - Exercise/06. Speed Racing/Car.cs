
namespace _06._Speed_Racing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public void CheckMoveDistance(double amountKm)
        {
            double requiredFuel = amountKm * FuelConsumptionPerKilometer;

            if (FuelAmount >= requiredFuel)
            {
                FuelAmount -= requiredFuel;
                TravelledDistance += amountKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
