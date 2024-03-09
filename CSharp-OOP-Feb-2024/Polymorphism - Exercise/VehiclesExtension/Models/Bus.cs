using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double ConsumptionModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public void DriveWithPeople(double distance)
        {
            var totalConsumptionPerTravel = distance * (FuelConsumptionPerKm + ConsumptionModifier); 
            if (FuelQuantity >= totalConsumptionPerTravel)
            {
                FuelQuantity -= totalConsumptionPerTravel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                throw new ArgumentException("Bus needs refueling");
            }
        }
    }
}
