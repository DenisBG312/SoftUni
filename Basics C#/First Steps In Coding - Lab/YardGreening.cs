using System;

namespace YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double yardsToBeGreened = double.Parse(Console.ReadLine());
            double totalPrice = yardsToBeGreened * 7.61;
            double discount = totalPrice * 0.18;
            double finalPrice = totalPrice - discount;
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
