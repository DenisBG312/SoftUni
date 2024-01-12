namespace BalancedSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] sequence = Console.ReadLine().ToCharArray();

            if (sequence.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> characterStack = new Stack<char>();

            foreach (var c in sequence)
            {
                if ("{[(".Contains(c))
                {
                    characterStack.Push(c);
                }           
                else if (c == ')' && characterStack.Peek() == '(')
                {
                    characterStack.Pop();
                }
                else if (c == ']' && characterStack.Peek() == '[')
                {
                    characterStack.Pop();
                }
                else if (c == '}' && characterStack.Peek() == '{')
                {
                    characterStack.Pop();
                }
            }

            Console.WriteLine(characterStack.Any() ? "NO" : "YES");
        }
    }
}
