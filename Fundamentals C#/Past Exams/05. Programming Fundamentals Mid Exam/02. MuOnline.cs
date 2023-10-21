namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeonRooms = Console.ReadLine()
                .Split("|")
                .ToList();

            int initialHealth = 100;
            int initialBitcoins = 0;
            int roomCount = 0;
            int totalBitcoins = 0;

            for (int i = 0; i < dungeonRooms.Count; i++)
            {
                roomCount++;
                string[] commandArr = dungeonRooms[i].Split().ToArray();
                string command = commandArr[0];
                int number = int.Parse(commandArr[1]);
                if (command == "potion")
                {
                    initialHealth += number;
                    if (initialHealth > 100)
                    {
                        int overHealth = Math.Abs(initialHealth - 100 - number);
                        initialHealth = 100;
                        Console.WriteLine($"You healed for {overHealth} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {number} hp.");
                    }
                    Console.WriteLine($"Current health: {initialHealth} hp.");
                }
                else if (command == "chest")
                {
                    Console.WriteLine($"You found {number} bitcoins.");
                    initialBitcoins += number;
                }
                else
                {
                    initialHealth -= number;
                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {roomCount}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {initialBitcoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }
    }
}
