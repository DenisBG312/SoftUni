using System.Text;

namespace GenericSwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> stringList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                stringList.Add(input);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(stringList, indexes[0], indexes[1]);

            foreach (var str in stringList)
            {
                Console.WriteLine($"{typeof(string)}: {str}");
            }
        }

        public static void Swap<T>(List<T> items, int firstIndex, int secondIndex)
        {
            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }
    }
}
