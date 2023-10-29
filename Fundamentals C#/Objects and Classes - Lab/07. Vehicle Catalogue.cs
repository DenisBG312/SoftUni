namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            int carCount = 0;
            int truckCont = 0;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] token = input.Split("/");
                string type = token[0];
                string brand = token[1];
                string model = token[2];
                string horsePower = token[3]; //weight
                if (type == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePower
                    };
                    catalog.Cars.Add(car);
                    carCount++;
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = horsePower // TODO: ITS WEIGHT
                    };
                    catalog.Trucks.Add(truck);
                    truckCont++;
                }
            }

            //"Cars:
            // {Brand}: {Model} - {Horse Power}hp
            // Trucks:
            // {Brand}: {Model} - {Weight}kg"

            if (carCount > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (truckCont > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Catalog
    {
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

}
