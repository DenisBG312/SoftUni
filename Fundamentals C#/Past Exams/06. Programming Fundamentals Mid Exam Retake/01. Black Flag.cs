namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = int.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int day = 1; day <= daysPlunder; day++)
            {
                totalPlunder += dailyPlunder;
                if (day % 3 == 0)
                {
                    totalPlunder += (double)dailyPlunder * 0.5; // TODO {dayliPlunder} should maybe be double?
                }
                if (day % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(totalPlunder / expectedPlunder) * 100:f2}% of the plunder.");
            }
        }
    }
}
