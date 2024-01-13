namespace _01._String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();
                if (arguments[0] == "Translate")
                {
                    char character = char.Parse(arguments[1]);
                    char replacement = char.Parse(arguments[2]);
                    text = text.Replace(character, replacement);
                    Console.WriteLine(text);
                }
                else if (arguments[0] == "Includes")
                {
                    string substring = arguments[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (arguments[0] == "Start")
                {
                    string substring = arguments[1];
                    if (text.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (arguments[0] == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (arguments[0] == "FindIndex")
                {
                    char character = char.Parse(arguments[1]);
                    int index = text.LastIndexOf(character);
                    Console.WriteLine(index);
                }
                else if (arguments[0] == "Remove")
                {
                    int startIndex = int.Parse(arguments[1]);
                    int count = int.Parse(arguments[2]);
                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
