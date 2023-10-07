namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
                /*  • coffee – 1.50
                    • water – 1.00
                    • coke – 1.40
                    • snacks – 2.00 */

                string product = Console.ReadLine();
                int quantity = int.Parse(Console.ReadLine());

                double totalPrice = ProductCalculation(product, quantity);
                Console.WriteLine($"{totalPrice:f2}");
        }
        static double ProductCalculation(string product, int quantity)
        {
            double totalPrice = 0;
            if (product == "coffee")
            {
                totalPrice = quantity * 1.5;
            }
            else if (product == "water")
            {
                totalPrice = quantity * 1;
            }
            else if (product == "coke")
            {
                totalPrice = quantity * 1.4;
            }
            else if (product == "snacks")
            {
                totalPrice = quantity * 2;
            }
            return totalPrice;
        }
    }
}
