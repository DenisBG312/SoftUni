using System.Diagnostics;
using System.Net.Http.Headers;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //valid coints: 0.1, 0.2, 0.5, 1 and 2

            //"Nuts" with a price of 2.0
            //• "Water" with a price of 0.7
            //• "Crisps" with a price of 1.5
            //• "Soda" with a price of 0.8
            //• "Coke" with a price of 1.0
            string inputCoins = Console.ReadLine();
            double totalCoins = 0;
            double productPrice = 0;

            while (inputCoins != "Start")
            {
                double coins = double.Parse(inputCoins);
                if (coins == 0.2 || coins == 0.1 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    totalCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                inputCoins = Console.ReadLine();
            }
            string inputProducts = Console.ReadLine();

            while (inputProducts != "End")
            {
                if (inputProducts == "Nuts" || inputProducts == "Water" || inputProducts == "Crisps" || inputProducts == "Soda" || inputProducts == "Coke")
                {
                    productPrice = 0;
                    switch (inputProducts)
                    {
                        case "Nuts":
                            productPrice += 2;
                            break;
                        case "Water":
                            productPrice += 0.7;
                            break;
                        case "Crisps":
                            productPrice += 1.5;
                            break;
                        case "Soda":
                            productPrice += 0.8;
                            break;
                        case "Coke":
                            productPrice += 1;
                            break;
                    }
                    if (totalCoins >= productPrice)
                    {
                        string lowerProduct = inputProducts.ToLower();
                        Console.WriteLine($"Purchased {lowerProduct}");
                        totalCoins -= productPrice;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                inputProducts = Console.ReadLine();
            }
            if (inputProducts == "End")
            {
                Console.WriteLine($"Change: {totalCoins:f2}");
            }
        }
    }
}
