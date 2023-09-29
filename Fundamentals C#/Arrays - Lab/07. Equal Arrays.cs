namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numsRowOne = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numsRowTwo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rowTotal = 0;

            for (int i = 0; i < numsRowOne.Length; i++)
            {
                if (numsRowOne[i] != numsRowTwo[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            int sum = numsRowOne.Sum();
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
