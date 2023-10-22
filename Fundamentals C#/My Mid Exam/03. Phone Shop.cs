namespace _03._Phone_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phonesList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> commandsList = new List<string>(input.Split(" - "));
                string command = commandsList[0];
                if (command == "Add")
                {
                    string phoneModel = commandsList[1];
                    bool doesExist = phonesList.Contains(phoneModel);

                    if (!doesExist)
                    {
                        phonesList.Add(phoneModel);
                    }
                }
                else if (command == "Remove")
                {
                    string phoneModel = commandsList[1];
                    phonesList.Remove(phoneModel);
                }
                else if (command == "Bonus phone")
                {
                    string phonesToBeChanged = commandsList[1];
                    List<string> phonesToChange = new List<string>(phonesToBeChanged.Split(":"));
                    bool doesExist = phonesList.Contains(phonesToChange[0]);

                    if (doesExist)
                    {
                        int index = phonesList.IndexOf(phonesToChange[0]);
                        phonesList.Insert(index + 1, phonesToChange[1]);
                    }
                }
                else if (command == "Last")
                {
                    string phoneModel = commandsList[1];
                    bool doesExist = phonesList.Contains(phoneModel);
                    if (doesExist)
                    {
                        int index = phonesList.IndexOf(phoneModel);
                        phonesList.RemoveAt(index);
                        phonesList.Add(phoneModel);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", phonesList));
            
        }
    }
}
