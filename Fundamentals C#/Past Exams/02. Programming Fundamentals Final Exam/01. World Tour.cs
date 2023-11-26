using System.Diagnostics;

namespace _01._World_Tour_
{
    internal class Program
    {
        static string stops;
        static void Main(string[] args)
        {
            stops = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] arguments = input.Split(":");

                if (arguments[0] == "Add Stop")
                {
                    AddStop(int.Parse(arguments[1]), arguments[2]);
                }
                else if (arguments[0] == "Remove Stop")
                {
                    RemoveStop(int.Parse(arguments[1]), int.Parse(arguments[2]), input);
                }
                else if (arguments[0] == "Switch")
                {
                    SwitchPlace(input, arguments[1], arguments[2]);
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        private static void SwitchPlace(string input, string oldString, string newString)
        {
            if (IsStringValid(input, oldString))
            {
                stops = stops.Replace(oldString, newString);
            }
        }

        private static bool IsStringValid(string input, string oldString)
        {
            bool isValid = stops.Contains(oldString);
            return isValid;
        }

        private static void RemoveStop(int startIndex, int endIndex, string input)
        {
            if (IsValidIndex(startIndex, stops) && endIndex < stops.Length)
            {
                stops = stops.Remove(startIndex, endIndex - startIndex + 1);
            }
        }

        private static void AddStop(int index, string input)
        {
            if (IsValidIndex(index, stops))
            {
                stops = stops.Insert(index, input);
            }
        }

        private static bool IsValidIndex(int index, string input)
        {
            bool IsValid = index >= 0 && index < stops.Length;
            return IsValid;
        }
    }
}
