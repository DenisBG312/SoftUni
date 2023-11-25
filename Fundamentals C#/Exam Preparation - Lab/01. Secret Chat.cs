namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] tokens = input.Split(":|:");
                string command = tokens[0];
                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                }

                else if (command == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];

                    message = message.Replace(substring, replacement);
                }

                else if (command == "Reverse")
                {
                    string substring = tokens[1];
                    int index = 0;
                    index = message.IndexOf(substring);
                    if (index < 0)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    char[] charArray = substring.ToCharArray();
                    Array.Reverse(charArray);
                    string reversedMessage = new string(charArray);
                    message = message.Remove(index, substring.Length) + reversedMessage;
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
