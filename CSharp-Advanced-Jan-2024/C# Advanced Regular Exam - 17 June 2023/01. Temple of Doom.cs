namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] toolsArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] substancesArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> challenges = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Queue<int> tools = new Queue<int>(toolsArr);
            Stack<int> substances = new Stack<int>(substancesArr);

            while (true)
            {
                int tool = tools.Peek();
                int substance = substances.Peek();

                if (challenges.Contains(tool * substance))
                {
                    challenges.Remove(tool * substance);
                    tools.Dequeue();
                    substances.Pop();

                    if (challenges.Count == 0)
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                        break;
                    }
                }

                else
                {
                    tools.Enqueue(tools.Dequeue() + 1);
                    substances.Push(substances.Pop() - 1);

                    if (substances.Peek() == 0)
                    {
                        substances.Pop();
                    }

                    if (substances.Count == 0)
                    {
                        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                        break;
                    }
                }
            }

            if (substances.Count != 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (tools.Count != 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (challenges.Count != 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}

