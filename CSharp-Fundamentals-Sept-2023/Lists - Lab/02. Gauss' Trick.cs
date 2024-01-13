namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int leftNum = numbers[i];
                int rightNum = numbers[numbers.Count - i - 1];
                result.Add(leftNum + rightNum);
            }

            if (numbers.Count % 2 != 0)
            {
                int middleNum = numbers.Count / 2;
                result.Add(numbers[middleNum]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
