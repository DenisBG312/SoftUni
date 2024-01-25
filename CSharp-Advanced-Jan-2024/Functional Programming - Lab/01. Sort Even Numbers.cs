namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parseIt = s => int.Parse(s);
            Func<int, bool> isEven = x => x % 2 == 0;

            string input = Console.ReadLine();
            string[] splitted = input.Split(", ");
            int[] nums = splitted.Select(parseIt).ToArray();
            int[] evenNums = nums.Where(isEven).ToArray();
            int[] orderedNums = evenNums.OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(", ", orderedNums));
        }
    }
}

