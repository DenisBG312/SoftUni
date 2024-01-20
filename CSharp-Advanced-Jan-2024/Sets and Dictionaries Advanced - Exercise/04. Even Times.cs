namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(num))
                {
                    nums.Add(num, 1);
                }
                else
                {
                    nums[num]++;
                }
            }

            foreach (var num in nums)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
