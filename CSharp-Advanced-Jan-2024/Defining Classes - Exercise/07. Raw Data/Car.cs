
namespace _06._Speed_Racing
{
    public class Car
    {
        public Car(string model, 
            double engineSpeed, 
            double enginePower,
            double cargoWeight,
            string cargoType,
            double tire1Pressure,
            int tire1Age,
            double tire2Pressure,
            int tire2Age,
            double tire3Pressure,
            int tire3Age,
            double tire4Pressure,
            int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tires = new Tires[4];
            Tires[0] = new Tires(tire1Pressure, tire1Age);
            Tires[1] = new Tires(tire2Pressure, tire2Age);
            Tires[2] = new Tires(tire3Pressure, tire3Age);
            Tires[3] = new Tires(tire4Pressure, tire4Age);
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires[] Tires { get; set; }
    }
}
