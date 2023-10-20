using System.Numerics;
using System.Reflection;
using System;

namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();

            int currentPosition = 0;

            string input;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] token = input.Split();
                int length = int.Parse(token[1]);
                currentPosition += length;
                if (currentPosition >= numbersList.Count)
                {
                    currentPosition = 0;
                }

                if (numbersList[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    numbersList[currentPosition] -= 2;
                    if (numbersList[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }
            }

            Console.WriteLine($"Cupid's last position was {currentPosition}.");

            bool isSuccess = true;
            int count = 0;

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i] != 0)
                {
                    isSuccess = false;
                    count++;
                }
            }
            if (isSuccess)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }
}
