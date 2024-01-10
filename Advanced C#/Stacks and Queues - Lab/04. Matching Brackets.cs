namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int start = stack.Pop();
                    int end = i  + 1;

                    string substring = input.Substring(start, end - start);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
