namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //((daysInMonth * capsulesCount) * pricePerCapsule)

            int ordersCount = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            
            for (int i = 0; i < ordersCount; i++)
            {
                double priceCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int countCapsule = int.Parse(Console.ReadLine());
                double totalProductPrice = priceCapsule * days * countCapsule;
                totalPrice += totalProductPrice;
                Console.WriteLine($"The price for the coffee is: ${totalProductPrice:f2}");
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
