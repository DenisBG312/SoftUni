using System.Threading.Channels;

namespace _02.CustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(1);
            stack.Push(22);
            stack.Push(23);
            stack.Push(233);
            stack.Push(213);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());

            stack.ForEach(item => Console.Write(item + " "));
        }
    }
}
