using System;

namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();

            int counter = 0;
            string input = string.Empty;

            while (input != "No More Books")
            {
                input = Console.ReadLine();
                if (input == favouriteBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                if (input != "No More Books")
                {
                    counter++;
                }
                if (input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                }
            }
        }
    }
}
