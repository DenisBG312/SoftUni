namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> charStack = new Stack<char>();

            foreach (char c in input)
            {
                if ("{[(".Contains(c))
                {
                    charStack.Push(c);
                }
                else if (c == ')' && charStack.Peek() == '(')
                {
                    charStack.Pop();
                }
                else if (c == ']' && charStack.Peek() == '[')
                {
                    charStack.Pop();
                }
                else if (c == '}' && charStack.Peek() == '{')
                {
                    charStack.Pop();
                }
            }

            Console.WriteLine(charStack.Any() ? "NO" : "YES");
        }
    }
}
