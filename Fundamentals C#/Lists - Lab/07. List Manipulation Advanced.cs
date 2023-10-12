using System;

namespace _07._List_Manipulation_Advanced1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string command;

            bool changed = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandToken = command.Split();
                command = commandToken[0];

                if (command == "Contains")
                {
                    int num = int.Parse(commandToken[1]);
                    if (numbers.Contains(num))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command == "Add")
                {
                    changed = true;
                    int num = int.Parse(commandToken[1]);
                    numbers.Add(num);
                }
                else if (command == "Remove")
                {
                    changed = true;
                    int num = int.Parse(commandToken[1]);
                    numbers.Remove(num);
                }
                else if (command == "RemoveAt")
                {
                    changed = true;
                    int num = int.Parse(commandToken[1]);
                    numbers.RemoveAt(num);
                }
                else if (command == "Insert")
                {
                    changed = true;
                    int num = int.Parse(commandToken[1]);
                    int index = int.Parse(commandToken[2]);
                    numbers.Insert(index, num);
                }
                else if (command == "PrintEven")
                {
                    GetEven(numbers);
                }
                else if (command == "PrintOdd")
                {
                    GetOdd(numbers);
                }
                else if (command == "GetSum")
                {
                    GetSum(numbers);
                }
                else if (command == "Filter")
                {
                    string condition = commandToken[1];
                    int num = int.Parse(commandToken[2]);
                    if (condition == "<")
                    {
                        List<int> filtered = numbers.FindAll(numT => numT < num);
                        Console.WriteLine(string.Join(" ", filtered));
                    }
                    else if (condition == ">")
                    {
                        List<int> filtered = numbers.FindAll(numT => numT > num);
                        Console.WriteLine(string.Join(" ", filtered));
                    }
                    else if (condition == ">=")
                    {
                        List<int> filtered = numbers.FindAll(numT => numT >= num);
                        Console.WriteLine(string.Join(" ", filtered));
                    }
                    else if (condition == "<=")
                    {
                        List<int> filtered = numbers.FindAll(numT => numT <= num);
                        Console.WriteLine(string.Join(" ", filtered));
                    }
                }
            }
            if (command == "end" && changed)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }



        private static void GetSum(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }
        private static void GetEven(List<int> numbers)
        {
            List<int> evenNums = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNums.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenNums));
        }
        private static void GetOdd(List<int> numbers)
        {
            List<int> oddNums = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    oddNums.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", oddNums));
        }
    }
}
