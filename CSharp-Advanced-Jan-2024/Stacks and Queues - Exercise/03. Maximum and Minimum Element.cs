namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbersStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (arguments[0] == 1)
                {
                    numbersStack.Push(arguments[1]);
                }
                else if (arguments[0] == 2)
                {
                    numbersStack.Pop();
                }
                else if (arguments[0] == 3 && numbersStack.Any())
                {
                    Console.WriteLine(numbersStack.Max());
                }
                else if (arguments[0] == 4 && numbersStack.Any())
                {
                    Console.WriteLine(numbersStack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", numbersStack));
        }
    }
}
