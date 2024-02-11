using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Capacity > 0)
            {
                Vehicles.Add(vehicle);
                Capacity--;
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicle = Vehicles.FirstOrDefault(x => x.VIN == vin);
            if (vehicle != null)
            {
                Vehicles.Remove(vehicle);
                Capacity++;
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            Vehicle vehicle = Vehicles.MinBy(x => x.Mileage);
            return vehicle;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
