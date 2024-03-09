using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IDrivable, IRefueable
{
    private double _fuelQuantity;
    private double _fuelConsumptionPerKm;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelConsumptionPerKm
    {
        get => _fuelConsumptionPerKm;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Consumption must be positive number");
            }
            _fuelConsumptionPerKm = value;
        }
    }


    public double FuelQuantity
    {
        get => _fuelQuantity;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Fuel must be positive number");
            }

            _fuelQuantity = value;
        }
    }

    public virtual void Drive(double distance)
    {
        var totalConsumptionPerTravel = distance * FuelConsumptionPerKm;

        if (totalConsumptionPerTravel > FuelQuantity)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        FuelQuantity -= totalConsumptionPerTravel;
        Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
    }

    public virtual void Refuel(double fuelAmount)
    {
        if (fuelAmount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        FuelQuantity += fuelAmount;
    }
}