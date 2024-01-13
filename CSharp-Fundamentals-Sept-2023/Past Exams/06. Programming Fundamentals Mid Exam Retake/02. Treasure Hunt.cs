namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLootList = Console.ReadLine()
                .Split("|")
                .ToList();

            string input;
            double totalTreasure = 0;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] token = input.Split();
                string command = token[0];
                if (command == "Loot")
                {
                    for (int i = 1; i < token.Length; i++)
                    {
                        string lootItem = token[i];
                        if (!initialLootList.Contains(lootItem))
                        {
                            initialLootList.Insert(0, lootItem);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(token[1]);
                    if (index >= 0 && index < initialLootList.Count)
                    {
                        string changedItem = initialLootList[index];
                        initialLootList.RemoveAt(index);
                        initialLootList.Add(changedItem);
                    }
                }
                else if (command == "Steal")
                {
                    int count = int.Parse(token[1]);
                    List<string> stolenItems = new List<string>();

                    if (count >= initialLootList.Count)
                    {
                        stolenItems.AddRange(initialLootList);
                        initialLootList.Clear();
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastIndex = initialLootList.Count - 1;
                            string currentItem = initialLootList[lastIndex];
                            initialLootList.RemoveAt(lastIndex);
                            stolenItems.Insert(0, currentItem);
                        }
                    }
                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }

            foreach (string item in initialLootList)
            {
                totalTreasure += item.Length;
            }

            if (totalTreasure > 0)
            { 
                Console.WriteLine($"Average treasure gain: {totalTreasure / initialLootList.Count:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
