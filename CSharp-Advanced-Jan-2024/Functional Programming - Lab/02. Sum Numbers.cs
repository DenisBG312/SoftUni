namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int count = input.Count();
            int sum = input.Sum();

            Console.WriteLine(count);
            Console.WriteLine(sum);

        }
    }
}
