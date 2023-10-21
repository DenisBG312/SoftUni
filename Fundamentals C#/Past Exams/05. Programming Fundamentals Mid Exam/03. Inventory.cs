namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> itemsList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Craft!")
            {
                List<string> commandsList = new List<string>(input.Split(" - "));
                string command = commandsList[0];
                if (command == "Collect")
                {
                    bool doesExist = false;
                    string item = commandsList[1];
                    for (int i = 0; i < itemsList.Count; i++)
                    {
                        if (itemsList[i] == item)
                        {
                            doesExist = true;
                        }
                    }

                    if (!doesExist)
                    {
                        itemsList.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    string item = commandsList[1];
                    itemsList.Remove(item);
                }
                else if (command == "Combine Items")
                {
                    List<string> combineItemsList = new List<string>(commandsList[1].Split(":"));
                    string oldItem = combineItemsList[0];
                    string newItem = combineItemsList[1];
                    for (int i = 0; i < itemsList.Count; i++)
                    {
                        if (itemsList[i] == oldItem)
                        {
                            itemsList.Insert(i + 1, newItem);
                        }
                    }
                }
                else if (command == "Renew")
                {
                    string item = commandsList[1];
                    for (int i = 0; i < itemsList.Count; i++)
                    {
                        if (itemsList[i] == item)
                        {
                            itemsList.RemoveAt(i);
                            itemsList.Add(item);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", itemsList));

        }
    }
}
