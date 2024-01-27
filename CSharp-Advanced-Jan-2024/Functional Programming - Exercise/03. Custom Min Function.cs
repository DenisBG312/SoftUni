namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int> customMinFunction = nums =>
            {
                int min = int.MaxValue;
                foreach (var num in nums)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }

                return min;
            };

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(customMinFunction(input));
        }
    }
}
