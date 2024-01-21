namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(":");
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> user = new Dictionary<string, Dictionary<string, int>>();

            while (input[0] != "end of contests")
            {
                string contest = input[0];
                string password = input[1];
                contests.Add(contest, password);
                input = Console.ReadLine().Split(":");
            }

            string[] secondInput = Console.ReadLine().Split("=>");

            while (secondInput[0] != "end of submissions")
            {
                string contest = secondInput[0];
                string password = secondInput[1];
                string username = secondInput[2];
                int points = int.Parse(secondInput[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!user.ContainsKey(username))
                    {
                        user.Add(username, new Dictionary<string, int>());
                    }

                    if (!user[username].ContainsKey(contest))
                    {
                        user[username].Add(contest, 0);
                    }

                    if (points > user[username][contest])
                    {
                        user[username][contest] = points;
                    }
                }


                secondInput = Console.ReadLine().Split("=>");
            }

            var bestCandidate = user
                .OrderByDescending(u => u.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Sum(x => x.Value)} points.");
            Console.WriteLine("Ranking:");
            foreach (var userName in user.OrderBy(x => x.Key))
            {
                Console.WriteLine(userName.Key);
                foreach (var points in userName.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {points.Key} -> {points.Value}");
                }
            }
        }
    }
}
