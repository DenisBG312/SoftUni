namespace _01._Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initialFuelArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] additionalConsumptionIndex = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] amountOfFuelNeededArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> fuelQuantity = new Stack<int>(initialFuelArr);
            Queue<int> additionalConsumption = new Queue<int>(additionalConsumptionIndex);
            Queue<int> amountOfFuelNeeded = new Queue<int>(amountOfFuelNeededArr);

            int altitude = 0;
            bool reachedAny = false;
            while (fuelQuantity.Count > 0 && additionalConsumption.Count > 0)
            {
                altitude++;
                if (fuelQuantity.Peek() - additionalConsumption.Peek() >= amountOfFuelNeeded.Peek())
                {
                    fuelQuantity.Pop();
                    additionalConsumption.Dequeue();
                    amountOfFuelNeeded.Dequeue();
                    Console.WriteLine($"John has reached: Altitude {altitude}");
                    reachedAny = true;
                    if (altitude == 4)
                    {
                        Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitude}");
                    Console.WriteLine($"John failed to reach the top.");
                    if (reachedAny)
                    {
                        List<string> altitudesList = new List<string>();
                        for (int i = 1; i < altitude; i++)
                        {
                            altitudesList.Add($"Altitude {i}");
                        }

                        Console.WriteLine($"Reached altitudes: {string.Join(", ", altitudesList)}");
                    }
                    else
                    {
                        Console.WriteLine("John didn't reach any altitude.");
                    }
                    break;
                }
            }
        }

    }
}
