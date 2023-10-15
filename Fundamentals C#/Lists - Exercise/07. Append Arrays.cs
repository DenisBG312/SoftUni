namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            List<string> symbols = ExctractSymbols(numbers);

            Console.WriteLine(string.Join(" ", symbols));
        }

        private static List<string> ExctractSymbols(string[] numbers)
        {
            List<string> result = new List<string>();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                string sequence = numbers[i];
                string[] array = sequence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(array);
            }
            return result;
        }
    }
}
