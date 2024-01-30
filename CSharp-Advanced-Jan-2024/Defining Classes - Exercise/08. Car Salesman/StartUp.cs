

using _06._Speed_Racing;

namespace DefineClasses;
public class StartUp
{
    public static void Main(string[] args)
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] engineProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Engine engine = CreateEngine(engineProperties);

            engines.Add(engine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = CreateCar(carProperties, engines);

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    static Engine CreateEngine(string[] enginePropeties)
    {
        Engine engine = new(enginePropeties[0], int.Parse(enginePropeties[1]));

        if (enginePropeties.Length > 2)
        {
            int displacement;

            bool isDigit = int.TryParse(enginePropeties[2], out displacement);

            if (isDigit)
            {
                engine.Displacement = displacement;
            }
            else
            {
                engine.Efficiency = enginePropeties[2];
            }

            if (enginePropeties.Length > 3)
            {
                engine.Efficiency = enginePropeties[3];
            }
        }

        return engine;
    }

    static Car CreateCar(string[] carPropeties, List<Engine> engines)
    {
        Engine engine = engines.Find(x => x.Model == carPropeties[1]);

        Car car = new(carPropeties[0], engine);

        if (carPropeties.Length > 2)
        {
            int weight;

            bool isDigit = int.TryParse(carPropeties[2], out weight);

            if (isDigit)
            {
                car.Weight = weight;
            }
            else
            {
                car.Color = carPropeties[2];
            }

            if (carPropeties.Length > 3)
            {
                car.Color = carPropeties[3];
            }
        }

        return car;
    }
}