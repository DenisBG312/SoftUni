namespace _03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];

                if (action == "Push")
                {
                    int[] itemsToPush = tokens
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    foreach (var item in itemsToPush)
                    {
                        customStack.Push(item);
                    }
                }
                else
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
