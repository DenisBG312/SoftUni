using System.Xml.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guestNumber = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int i = 0; i < guestNumber; i++)
            {
                string[] arguments = Console.ReadLine().Split();

                if (arguments[2] == "going!")
                {
                    if (guestList.Exists(e => e == arguments[0]))
                    {
                        Console.WriteLine($"{arguments[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(arguments[0]);
                    }
                }
                else if (arguments[2] == "not")
                {
                    if (guestList.Exists(e => e == arguments[0]))
                    {
                        guestList.Remove(arguments[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{arguments[0]} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", guestList));
        }
    }
}
