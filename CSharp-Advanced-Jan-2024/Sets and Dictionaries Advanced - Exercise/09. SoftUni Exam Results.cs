namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("-");
            Dictionary<string, Dictionary<string, int>> examInfo =
                new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input[0] != "exam finished")
            {
                string user = input[0];
                string language = input[1];
                if (language == "banned")
                {
                    if (examInfo.ContainsKey(user))
                    {
                        examInfo.Remove(user);
                    }
                    input = Console.ReadLine().Split("-");
                    continue;
                }
                int points = int.Parse(input[2]);

                if (!examInfo.ContainsKey(user))
                {
                    examInfo.Add(user, new Dictionary<string, int>());
                }

                if (!examInfo[user].ContainsKey(language))
                {
                    examInfo[user].Add(language, 0);
                }

                if (points > examInfo[user][language])
                {
                    examInfo[user][language] = points;
                }

                if (!submissions.ContainsKey(language))
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;
                input = Console.ReadLine().Split("-");
            }

            Console.WriteLine("Results:");
            foreach (var user in examInfo.OrderByDescending(u => u.Value.Values.Max())
                         .ThenBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value.Values.Max()}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in submissions.OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
