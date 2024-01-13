namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> numbersDictionary = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersDictionary.ContainsKey(numbers[i]))
                {
                    numbersDictionary[numbers[i]]++;
                }
                else
                {
                    numbersDictionary[numbers[i]] = 1;
                }
            }

            foreach (KeyValuePair<int, int> number in numbersDictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
