namespace _05._Excursion_Sale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seaCount = int.Parse(Console.ReadLine());
            int mountainCount = int.Parse(Console.ReadLine());
            double price = 0;
            string input = Console.ReadLine();

            while (input != "Stop")
            {
                if (input == "sea")
                {
                    seaCount--;
                    if (seaCount >= 0)
                    {
                        price += 680;
                    }
                    else
                    {
                        seaCount = 0;
                    }
                }
                else if (input == "mountain")
                {
                    mountainCount--;
                    if (mountainCount >= 0)
                    {
                        price += 499;
                    }
                    else
                    {
                        mountainCount = 0;
                    }
                }
                if (seaCount == 0 && mountainCount == 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");
                    Console.WriteLine($"Profit: {price} leva.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Stop")
            {
                Console.WriteLine($"Profit: {price} leva.");
            }
        }
    }
}
