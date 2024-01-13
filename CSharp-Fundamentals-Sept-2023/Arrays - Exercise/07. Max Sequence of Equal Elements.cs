using System;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int maxCount = 0;
            int digit = 0;
            int counter = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    counter++;

                    if (counter > maxCount)
                    {
                        maxCount = counter;
                        digit = numbers[i];
                    }
                }
                else
                    counter = 1;
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(digit + " ");
            }
        }
    }
}
