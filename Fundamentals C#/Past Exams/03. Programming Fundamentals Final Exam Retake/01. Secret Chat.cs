using System;
using System.Data.SqlTypes;

namespace _03._Secret_Chat
{
    internal class Program
    {
        static string message;

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] arguments = input.Split(":|:");
                if (arguments[0] == "InsertSpace")
                {
                    InsertSpace(int.Parse(arguments[1]), message);
                }
                else if (arguments[0] == "Reverse")
                {
                    if (Reverse(arguments)) continue;
                }
                else if (arguments[0] == "ChangeAll")
                {
                    ChangeAll(arguments[1], arguments[2], message);
                }

                Console.WriteLine(message);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }

        private static bool Reverse(string[] arguments)
        {
            string substring = arguments[1];
            bool isSuccess = true;
            int indexOfMessage = Program.message.IndexOf(substring);

            if (indexOfMessage == -1)
            {
                Console.WriteLine("error");
                isSuccess = false;
                return true;
            }

            char[] charArray = substring.ToCharArray();
            Array.Reverse(charArray);
            string reversedMessage = new string(charArray);
            Program.message = Program.message.Remove(indexOfMessage, substring.Length) + reversedMessage;

            if (!isSuccess)
            {
                Console.WriteLine("error");
            }

            return false;
        }
        private static void ChangeAll(string substring, string replacement, string message)
        {
            Program.message = message.Replace(substring, replacement);
        }
        private static void InsertSpace(int index, string message)
        {
            Program.message = message.Insert(index, " ");
        }
    }
}
