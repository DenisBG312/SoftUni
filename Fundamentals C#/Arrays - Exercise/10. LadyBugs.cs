namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize];
            foreach (int index in ladybugIndexes)
            {
                if (index >= 0 && index < fieldSize)
                {
                    field[index] = 1;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                int bugIndex = int.Parse(tokens[0]);
                string direction = tokens[1];
                int flyLength = int.Parse(tokens[2]);

                if (bugIndex < 0 || bugIndex >= fieldSize || field[bugIndex] == 0)
                {
                    continue;
                }

                field[bugIndex] = 0;

                int newPosition = bugIndex;
                while (true)
                {
                    if (direction == "right")
                    {
                        newPosition += flyLength;
                    }
                    else if (direction == "left")
                    {
                        newPosition -= flyLength;
                    }

                    if (newPosition < 0 || newPosition >= fieldSize)
                    {
                        break;
                    }

                    if (field[newPosition] == 0)
                    {
                        field[newPosition] = 1;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
