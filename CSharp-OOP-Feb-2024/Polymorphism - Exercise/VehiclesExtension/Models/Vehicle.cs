using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IDrivable, IRefueable
{
    private double _fuelQuantity;
    private double _fuelConsumptionPerKm;
    private double _tankCapacity; 

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double TankCapacity
    {
        get => _tankCapacity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Tank capacity must be positive number");
            }

            _tankCapacity = value;
        }
    }


    public double FuelConsumptionPerKm
    {
        get => _fuelConsumptionPerKm;
        set
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
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be positive number");
            }

            if (value <= TankCapacity)
            {
                _fuelQuantity = value;
            }
            else
            {
                _fuelQuantity = 0;
            }
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

        var totalFuelAfterRefueling = fuelAmount + FuelQuantity;
        if (totalFuelAfterRefueling > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }

        FuelQuantity += fuelAmount;
    }
}