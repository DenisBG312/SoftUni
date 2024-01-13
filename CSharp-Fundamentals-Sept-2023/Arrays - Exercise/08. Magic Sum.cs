namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int toBeEqual = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int currentNum = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentNum + arr[j] == toBeEqual)
                    {
                        Console.WriteLine($"{currentNum} {arr[j]}");
                    }
                }
            }
        }
    }
}
