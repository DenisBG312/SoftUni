namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine()
                .Split().Reverse());

            int result = int.Parse(stack.Pop());

            while (stack.Count > 1)
            {
                string operation = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    result += num2;
                }
                else if (operation == "-")
                {
                    result -= num2;
                }
            }

            Console.WriteLine(result);
        }
    }
}
