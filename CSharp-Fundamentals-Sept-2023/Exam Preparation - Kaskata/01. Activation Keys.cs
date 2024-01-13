namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] arguments = input.Split(">>>");

                if (arguments[0] == "Contains")
                {
                    string substring = arguments[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (arguments[0] == "Flip")
                {
                    if (arguments[1] == "Upper")
                    {
                        int startIndex = int.Parse(arguments[2]);
                        int endIndex = int.Parse(arguments[3]);

                        string prefix = activationKey.Substring(0, startIndex);
                        string middle = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
                        string end = activationKey.Substring(endIndex);

                        activationKey = prefix + middle + end;
                        Console.WriteLine(activationKey);
                    }
                    else if (arguments[1] == "Lower")
                    {
                        int startIndex = int.Parse(arguments[2]);
                        int endIndex = int.Parse(arguments[3]);

                        string prefix = activationKey.Substring(0, startIndex);
                        string middle = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
                        string end = activationKey.Substring(endIndex);

                        activationKey = prefix + middle + end;
                        Console.WriteLine(activationKey);
                    }
                }
                else if (arguments[0] == "Slice")
                {
                    int startIndex = int.Parse(arguments[1]);
                    int endIndex = int.Parse(arguments[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
