using System;

namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int totalTime = pages / pagesPerHour;
            int neededHours = totalTime / days;

            Console.WriteLine(neededHours);
        }
    }
}
