namespace _07._The_V_Logger
{
    internal class Program
    {
        class Vlogger
        {
            public string Name { get; set; }
            public SortedSet<string> Followers { get; set; }
            public SortedSet<string> Following { get; set; }

            public Vlogger(string name, SortedSet<string> followers, SortedSet<string> following)
            {
                Name = name;
                Followers = followers;
                Following = following;
            }
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, Vlogger> vloggerApp = new Dictionary<string, Vlogger>();

            while (input[0] != "Statistics")
            {
                string vloggerName = input[0];
                string action = input[1];
                if (action == "joined")
                {
                    if (!vloggerApp.ContainsKey(vloggerName))
                    {
                        Vlogger vlogger = new Vlogger(vloggerName, new SortedSet<string>(), new SortedSet<string>());
                        vloggerApp.Add(vloggerName, vlogger);
                    }
                }
                else if (action == "followed")
                {
                    string secondVlogger = input[2];
                    if (!vloggerApp.ContainsKey(vloggerName)
                        || !vloggerApp.ContainsKey(secondVlogger)
                        || vloggerName == secondVlogger)
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }
                    vloggerApp[secondVlogger].Followers.Add(vloggerName);
                    vloggerApp[vloggerName].Following.Add(secondVlogger);
                }

                input = Console.ReadLine().Split();
            }

            var mostFamousVlogger = vloggerApp
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .FirstOrDefault();

            Console.WriteLine($"The V-Logger has a total of {vloggerApp.Count} vloggers in its logs.");
            int index = 1;

                Console.WriteLine($"{index}. {mostFamousVlogger.Value.Name} : {mostFamousVlogger.Value.Followers.Count} followers, {mostFamousVlogger.Value.Following.Count} following");
                foreach (var follower in mostFamousVlogger.Value.Followers)
                {
                    Console.WriteLine($"*  {follower}");
                }

            vloggerApp.Remove(mostFamousVlogger.Value.Name);
            foreach (var vlogger in vloggerApp
                         .OrderByDescending(x => x.Value.Followers.Count)
                         .ThenBy(x => x.Value.Following.Count))
            {
                index++;
                Console.WriteLine($"{index}. {vlogger.Value.Name} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            }
        }
    }
}
