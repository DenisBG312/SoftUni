using System;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numList = Console.ReadLine()
                .Split()
                .ToList();

            int movesCount = 0;

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] sequence = input.Split();

                int firstIndex = int.Parse(sequence[0]);
                int secondIndex = int.Parse(sequence[1]);

                movesCount++;
                if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < numList.Count && secondIndex < numList.Count && firstIndex != secondIndex)
                {
                    if (numList[firstIndex] == numList[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {numList[firstIndex]}!");
                        if (firstIndex > secondIndex)
                        {
                            numList.RemoveAt(firstIndex);
                            numList.RemoveAt(secondIndex);
                        }
                        else
                        {
                            numList.RemoveAt(secondIndex);
                            numList.RemoveAt(firstIndex);
                        }

                        if (numList.Count == 0)
                        {
                            Console.WriteLine($"You have won in {movesCount} turns!");
                            return;
                        }
                    }
                    else if (numList[firstIndex] != numList[secondIndex])
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    numList.Insert(numList.Count / 2, $"-{movesCount}a");
                    numList.Insert(numList.Count / 2, $"-{movesCount}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                input = Console.ReadLine();
            }


            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", numList));
        }

    }
}
