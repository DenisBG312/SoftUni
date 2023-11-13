using System;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string input;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] commands = input.Split(':');

                if (commands[0] == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string destination = commands[2];

                    if (IsValidIndex(index, stops.Length))
                    {
                        stops = stops.Insert(index, destination);
                    }
                }
                else if (commands[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (IsValidIndex(startIndex, stops.Length) &&
                        IsValidIndex(endIndex, stops.Length))
                    {
                        int countToRemove = endIndex - startIndex + 1;
                        stops = stops.Substring(0, startIndex) + stops.Substring(endIndex + 1);
                    }
                }
                else if (commands[0] == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    stops = stops.Replace(oldString, newString);
                }

                Console.WriteLine(stops);
            }

            Console.Write("Ready for world tour! Planned stops: ");
            Console.Write(stops);
        }

        public static bool IsValidIndex(int index, int length)
        {
            return index >= 0 && index < length;
        }
    }
}
