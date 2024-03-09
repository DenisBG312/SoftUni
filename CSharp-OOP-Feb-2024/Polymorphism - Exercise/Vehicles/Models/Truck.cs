namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double FuelConsumptionModifier = 1.6;
    private const double TruckerFactor = 0.95;
    public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm + FuelConsumptionModifier)
    {
    }

    public override void Refuel(double fuelAmount)
    {
        base.Refuel(TruckerFactor * fuelAmount);
    }
}