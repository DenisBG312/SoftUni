namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reverseFunc = nums =>
            {
                List<int> newList = new List<int>();

                for (int i = nums.Count - 1; i >= 0; i--)
                {
                    newList.Add(nums[i]);
                }

                return newList;
            };

            Func<List<int>, Predicate<int>, List<int>> checkMatch = (nums, match) =>
            {
                List<int> newList = new List<int>();

                foreach (var num in nums)
                {
                    if (!match(num))
                    {
                        newList.Add(num);
                    }
                }

                return newList;
            };

            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            nums = reverseFunc(nums);
            Predicate<int> match = n => 
                n % divider == 0;

            nums = checkMatch(nums, match);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
