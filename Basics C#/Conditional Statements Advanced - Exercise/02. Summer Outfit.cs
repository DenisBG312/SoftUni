using System;

namespace _02._Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int degreeces = int.Parse(Console.ReadLine());
            string typeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            if (typeOfDay == "Morning")
            {
                if (degreeces >= 10 &&  degreeces <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (degreeces > 18 && degreeces <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (typeOfDay == "Afternoon")
            {
                if (degreeces >= 10 && degreeces <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (degreeces > 18 && degreeces <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }
            else
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            Console.WriteLine($"It's {degreeces} degrees, get your {outfit} and {shoes}.");
        }
    }
}
