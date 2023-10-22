namespace _02._Friend_List_Maintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input;
            bool isBlackListed = false;
            int blackListedCount = 0;
            int lostNamesCount = 0;
            while ((input = Console.ReadLine()) != "Report")
            {
                string[] token = input.Split();
                string command = token[0];
                if (command == "Blacklist")
                {
                    bool isFound = false;
                    string name = token[1];
                    int index = 0;
                    if (friendsList.Contains(name))
                    {
                        isFound = true;
                        index = friendsList.IndexOf(name);
                    }

                    if (isFound)
                    {
                        Console.WriteLine($"{name} was blacklisted.");
                        friendsList[index] = "Blacklisted";
                        isBlackListed = true;
                        blackListedCount++;
                    }
                    else if (!isFound)
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (command == "Error")
                {
                    int index = int.Parse(token[1]);
                    if (index >= 0 
                        && index < friendsList.Count 
                        && friendsList[index] != "Blacklisted"
                        && friendsList[index] != "Lost")
                    {
                        string lostName = friendsList[index];
                        friendsList[index] = "Lost";
                        Console.WriteLine($"{lostName} was lost due to an error.");
                        lostNamesCount++;
                    }
                }
                else if (command == "Change")
                {
                    int index = int.Parse(token[1]);
                    string newName = token[2];
                    if (index >= 0 && index < friendsList.Count)
                    {
                        string currentName = friendsList[index];
                        friendsList.RemoveAt(index);
                        friendsList.Insert(index, newName);
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }
            }

            Console.WriteLine($"Blacklisted names: {blackListedCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(string.Join(" ", friendsList));
            
            
        }
    }
}
