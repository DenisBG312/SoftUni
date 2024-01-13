using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> textHistory = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] commandArg = Console.ReadLine().Split();
                if (commandArg[0] == "1")
                {
                    textHistory.Push(sb.ToString());
                    sb.Append(commandArg[1]);
                }
                else if (commandArg[0] == "2")
                {
                    textHistory.Push(sb.ToString());
                    int count = int.Parse(commandArg[1]);
                    sb.Remove(sb.Length - count, count);
                }
                else if (commandArg[0] == "3")
                {
                    int index = int.Parse(commandArg[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if (commandArg[0] == "4")
                {
                    sb = new StringBuilder(textHistory.Pop());
                }
            }
        }
    }
}
