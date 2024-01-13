using System.Diagnostics;

namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalPrice = 0;
            bool containsNum = false;
            while (input != "special" && input != "regular")
            {
                double singlePrice = double.Parse(input);
                if (singlePrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                else if (singlePrice >= 0 && singlePrice <= double.MaxValue)
                {
                    totalPrice += singlePrice;
                    containsNum = true;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                    return;
                }
                input = Console.ReadLine();
            }

            if (containsNum)
            {
                double taxes = totalPrice * 0.2;

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                if (input == "regular")
                {
                    Console.WriteLine($"Total price: {totalPrice + taxes:f2}$");
                }
                else
                {
                    totalPrice += taxes;
                    Console.WriteLine($"Total price: {totalPrice - totalPrice * 0.1:f2}$");
                }
            }
            else
            {
                Console.WriteLine("Invalid order!");
            }
        }
    }
}
