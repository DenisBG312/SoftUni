using System;
using static System.Net.Mime.MediaTypeNames;

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
                string[] commands = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string destination = commands[2];

                    if (IsValidIndex(index, stops.Length))
                    {
                        stops = stops.Insert(index, destination);
                    }


                    Console.WriteLine(stops);
                }
                else if (commands[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(stops);
                }
                else if (commands[0] == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    stops = stops.Replace(oldString, newString);
                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        public static bool IsValidIndex(int index, int length)
        {
            return index >= 0 && index < length;
        }
    }
}
