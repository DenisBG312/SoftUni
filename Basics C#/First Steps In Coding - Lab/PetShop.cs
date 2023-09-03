using System;

namespace PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodForDogs = int.Parse(Console.ReadLine()); 
            int foodForCats = int.Parse(Console.ReadLine()); 
            double dogsCosts = foodForDogs * 2.50;
            int catsCosts = foodForCats * 4;
            double finalSum = dogsCosts + catsCosts;
            Console.WriteLine($"{finalSum} lv.");

        }
    }
}
