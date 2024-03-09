namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double FuelConsumptionModifier = 1.6;
    private const double TruckerFactor = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm + FuelConsumptionModifier, tankCapacity)
    {
    }

    public override void Refuel(double fuelAmount)
    {
        if (FuelQuantity + fuelAmount > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }
        base.Refuel(TruckerFactor * fuelAmount);
    }
}