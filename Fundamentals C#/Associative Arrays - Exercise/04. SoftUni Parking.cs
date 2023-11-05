namespace _04._SoftUni_Parking
{
    internal class User
    {
        public string Username { get; set; }
        public string LicensePlate { get; set; }

        public User(string username, string licenseName)
        {
            Username = username;
            LicensePlate = licenseName;
        }

        public override string ToString()
        {
            return $"{Username} => {LicensePlate}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            Dictionary<string, User> users = new Dictionary<string, User>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string command = arguments[0];
                string username = arguments[1];

                if (command == "register")
                {
                    string licensePlate = arguments[2];
                    User newUser = new User(username, licensePlate);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, newUser);
                        Console.WriteLine($"{newUser.Username} registered {newUser.LicensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {newUser.LicensePlate}");
                    }
                }
                else if (command == "unregister")
                {
                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (KeyValuePair<string, User> kvp in users)
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
}
