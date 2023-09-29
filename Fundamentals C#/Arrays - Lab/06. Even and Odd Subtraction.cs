namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int evenNumTotal = 0;
            int oddNumTotal = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    int evenNum = nums[i];
                    evenNumTotal += evenNum;
                }
                else
                {
                    int oddNum = nums[i];
                    oddNumTotal += oddNum;
                }
            }

            Console.WriteLine(evenNumTotal - oddNumTotal);

        }
    }
}
