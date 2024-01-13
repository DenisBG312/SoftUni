namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string usernameReversed = string.Empty;
            string password = Console.ReadLine();
            int passwordsCount = 0;

            for (int i = username.Length - 1;  i >= 0; i--)
            {
                usernameReversed += username[i];
            }
            
            while (password != usernameReversed)
            {
                passwordsCount++;
                if (passwordsCount == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
            }
            if (password == usernameReversed)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
