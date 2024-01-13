namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] arguments = input.Split("|");
                if (arguments[0] == "Move")
                {
                    int numberOfLetters = int.Parse(arguments[1]);
                    string firstTwoLetters = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Insert(encryptedMessage.Length, firstTwoLetters);
                }
                else if (arguments[0] == "Insert")
                {
                    int index = int.Parse(arguments[1]);
                    string value = arguments[2];
                    encryptedMessage = encryptedMessage.Insert(index, value);
                }
                else if (arguments[0] == "ChangeAll")
                {
                    string substring = arguments[1];
                    string replacement = arguments[2];
                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
