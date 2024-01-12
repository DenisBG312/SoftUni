namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLineInts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondLineInts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < firstLineInts[0]; i++)
            {
                stack.Push(secondLineInts[i]);
            }

            for (int i = 0; i < firstLineInts[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(firstLineInts[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

