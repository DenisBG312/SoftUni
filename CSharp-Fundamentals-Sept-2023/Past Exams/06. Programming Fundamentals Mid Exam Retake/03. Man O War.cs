namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            List<int> warShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            int maxHealthCapacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "Retire") //YOU PLAY AS PIRATE SHIP
            {
                string[] token = input.Split();
                string command = token[0];
                if (command == "Fire") //pirateShip attacks the warShip
                {
                    int index = int.Parse(token[1]);
                    int damage = int.Parse(token[2]);
                    if (index >= 0 && index < warShip.Count && index < pirateShip.Count)
                    {
                        int newHealth = warShip[index] - damage;
                        if (newHealth <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                        warShip.RemoveAt(index);
                        warShip.Insert(index, newHealth);
                    }
                }
                else if (command == "Defend") //warShip attacks the pirateShip
                {
                    int startIndex = int.Parse(token[1]);
                    int endIndex = int.Parse(token[2]);
                    int damage = int.Parse(token[3]);
                    if (startIndex >= 0 && startIndex < pirateShip.Count &&
                        endIndex >= 0 && endIndex < pirateShip.Count)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine($"You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(token[1]);
                    int health = int.Parse(token[2]);
                    if (index >= 0 && index < pirateShip.Count)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maxHealthCapacity)
                        {
                            pirateShip[index] = maxHealthCapacity;
                        }
                    }
                }
                else if (command == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < maxHealthCapacity * 0.2)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");

        }
    }
}
