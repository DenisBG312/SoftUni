using System;

namespace _06._Vowels_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double points = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                switch (letter)
                {
                    case 'a':
                        points += 1;
                        break;
                    case 'e':
                        points += 2;
                        break;
                    case 'i':
                        points += 3;
                        break;
                    case 'o':
                        points += 4;
                        break;
                    case 'u':
                        points += 5;
                        break;
                }
            }
            Console.WriteLine(points);
        }
    }
}
