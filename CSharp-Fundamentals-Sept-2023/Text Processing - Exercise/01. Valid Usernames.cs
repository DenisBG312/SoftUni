namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (string username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    if (isValidUsername(username))
                    {
                        Console.WriteLine(username);
                    }
                }
            }
        }

        private static bool isValidUsername(string username)
        {
            return username
                .All(ch => char.IsLetterOrDigit(ch)
                           || ch == '_'
                           || ch == '-');
        }
    }
}
