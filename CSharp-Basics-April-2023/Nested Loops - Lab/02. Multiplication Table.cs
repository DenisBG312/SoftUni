using System;

namespace _02._Multiplication_Table1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int f = 1; f <= 10; f++)
            {
                for (int s = 1; s <= 10; s++)
                {
                    Console.WriteLine($"{f} * {s} = {f * s}");
                }
            }
        }
    }
}
