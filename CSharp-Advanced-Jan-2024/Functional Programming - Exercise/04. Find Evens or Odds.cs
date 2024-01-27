namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, List<int>> genrateRange = (start, end) =>
            {
                List<int> range = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }

                return range;
            };

            Func<string, int, bool> checkMatch = (condition, num) =>
            {
                if (condition == "even")
                {
                    return num % 2 == 0;
                }
                else
                {
                    return num % 2 != 0;
                }
            };

            int[] argsRange = Console.ReadLine()
                .Split(" ", StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            string filter = Console.ReadLine();

            List<int> generatedRange = genrateRange(argsRange[0], argsRange[1]);

            foreach (var num in generatedRange)
            {
                if (checkMatch(filter, num))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
