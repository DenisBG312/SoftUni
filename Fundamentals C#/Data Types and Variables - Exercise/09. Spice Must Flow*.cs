namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int consumed = startingYield;
            int days = 0;
            double totalConsumed = 0;

            while (startingYield >= 100)
            {
                consumed = startingYield - 26;
                totalConsumed += consumed;
                startingYield -= 10;
                days++;
            }
            totalConsumed -= 26;
            if (totalConsumed < 0)
            {
                totalConsumed = 0;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalConsumed);
        }
    }
}
