namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = Console.ReadLine().Split().Select(double.Parse).ToList();

            Dictionary<double, int> numbers = new Dictionary<double, int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                double currNum = numberList[i];

                if (!numbers.ContainsKey(currNum))
                {
                    numbers.Add(currNum, 0);
                }

                numbers[currNum]++;
            }

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}

