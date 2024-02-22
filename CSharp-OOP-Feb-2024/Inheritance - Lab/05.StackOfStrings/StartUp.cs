namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();

            stackOfStrings.Push("2");
            stackOfStrings.Push("3");
            stackOfStrings.Push("4");

            Console.WriteLine(stackOfStrings.IsEmpty());

            stackOfStrings.AddRange(new List<string>{"2", "2", "10"});

            foreach (var stackOfString in stackOfStrings)
            {
                Console.WriteLine(stackOfString);
            }
        }
    }
}
