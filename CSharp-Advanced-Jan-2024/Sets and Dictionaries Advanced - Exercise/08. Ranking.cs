namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(":");

            var contestsKvp = new Dictionary<string, string>();

            var userSubmition = new Dictionary<string, Dictionary<string, int>>();

            while (input[0] != "end of contests")
            {
                string contestName = input[0];
                string password = input[1];

                contestsKvp.Add(contestName, password);
                input = Console.ReadLine().Split(":");
            }

            string[] secondInput = Console.ReadLine().Split("=>");

            while (secondInput[0] != "end of submissions")
            {
                string contestName = secondInput[0];
                string password = secondInput[1];
                string username = secondInput[2];
                int points = int.Parse(secondInput[3]);

                if (contestsKvp.ContainsKey(contestName) && contestsKvp[contestName] == password)
                {
                    if (!userSubmition.ContainsKey(username))
                    {
                        userSubmition.Add(username, new Dictionary<string, int>());
                    }

                    if (!userSubmition[username].ContainsKey(contestName))
                    {
                        userSubmition[username].Add(contestName, 0);
                    }

                    if (points > userSubmition[username][contestName])
                    {
                        userSubmition[username][contestName] = points;
                    }

                }
                secondInput = Console.ReadLine().Split("=>");
            }

            var bestCandidate = userSubmition.OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var submission in userSubmition.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key}");
                foreach (var item in submission.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}"); 
                }
            }
        }
    }
}
