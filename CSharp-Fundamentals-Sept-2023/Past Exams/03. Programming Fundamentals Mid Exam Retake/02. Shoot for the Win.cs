namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int shotTargets = 0;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);
                if (index < 0 || index >= numbersList.Count)
                {
                    continue;   
                }

                if (numbersList[index] == -1)
                {
                    continue;
                }
                shotTargets++;
                int currentTarget = numbersList[index];
                numbersList.RemoveAt(index);
                numbersList.Insert(index, -1);

                for (int i = 0; i < numbersList.Count; i++)
                {
                    if (numbersList[i] == -1)
                    {
                        continue;
                    }

                    if (numbersList[i] <= currentTarget)
                    {
                        numbersList[i] += currentTarget;
                    }
                    else if (numbersList[i] > currentTarget)
                    {
                        numbersList[i] -= currentTarget;
                    }
                }
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", numbersList)}");
        }
    }
}
