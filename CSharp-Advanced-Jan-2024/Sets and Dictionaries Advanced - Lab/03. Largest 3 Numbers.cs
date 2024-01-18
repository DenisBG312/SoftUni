namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sortedArray = array.OrderByDescending(x => x).ToArray();

            if (sortedArray.Length <= 2)
            {
                foreach (var num in sortedArray)
                {
                    Console.Write(num + " ");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sortedArray[i] + " ");
                }
            }
        }
    }
}
