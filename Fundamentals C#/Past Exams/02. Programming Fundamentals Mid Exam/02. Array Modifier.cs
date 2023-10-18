using System;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commandToken = input.Split();
                string command = commandToken[0];
                if (command == "swap")
                {
                    int firstIndex = int.Parse(commandToken[1]);
                    int secondIndex = int.Parse(commandToken[2]);
                    SwapNumbers(numbers, firstIndex, secondIndex);
                }
                else if (command == "multiply")
                {
                    int firstIndex = int.Parse(commandToken[1]);
                    int secondIndex = int.Parse(commandToken[2]);
                    MultiplyNumbers(numbers, firstIndex, secondIndex);
                }
                else if (command == "decrease")
                {
                    DecreaseAllNumbers(numbers);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void DecreaseAllNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int result = numbers[i] - 1;
                numbers.RemoveAt(i);
                numbers.Insert(i, result);
            }
        }

        private static int MultiplyNumbers(List<int> numbers, int firstIndex, int secondIndex)
        {
            int result = numbers[firstIndex] * numbers[secondIndex];
            numbers.RemoveAt(firstIndex);
            numbers.Insert(firstIndex, result);
            return result;
        }

        private static void SwapNumbers(List<int> numbers, int firstIndex, int secondIndex)
        {
            int temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }
    }
}
