namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> greaterNumbers = new List<int>();

            int count = 0;

            double avgNum = FindAverageNum(numbers);
            foreach (int num in numbers)
            {
                if (num > avgNum)
                {
                    greaterNumbers.Add(num);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            greaterNumbers = greaterNumbers.OrderByDescending(x => x)
                .Take(5)
                .ToList();

            Console.WriteLine(string.Join(" ", greaterNumbers));
        }

        private static double FindAverageNum(List<int> numbers)
        {
            double result = numbers.Sum();
            result /= numbers.Count;
            return result;
        }
    }
}
