namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double pricePackFlour = double.Parse(Console.ReadLine());
            double priceSingleEgg = double.Parse(Console.ReadLine());
            double priceSingleApron = double.Parse(Console.ReadLine());
            int freePackages = students / 5;


            double totalPrice = priceSingleApron * (Math.Ceiling(students * 1.2)) + priceSingleEgg * 10 * (students) +
                                pricePackFlour * (students - freePackages);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                Console.WriteLine($"{totalPrice - budget:f2}$ more needed.");
            }
        }
    }
}
