namespace _01._Password_Reset
{
    internal class Program
    {
        static string password;
        static void Main(string[] args)
        {
            password = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] arguments = input.Split();
                if (arguments[0] == "TakeOdd")
                {
                    TakeOdd();
                }

                else if (arguments[0] == "Cut")
                {
                    Cut( int.Parse(arguments[1]), int.Parse(arguments[2]));
                }
                else if (arguments[0] == "Substitute")
                {
                    string substring = arguments[1];
                    string substitute = arguments[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                }

                Console.WriteLine(password);
            }

            Console.WriteLine($"Your password is: {password}");
        }
        private static void Cut(int index, int length)
        {
            password = password.Remove(index, length);
        }

        private static void TakeOdd()
        {
            string oddMessage = "";
            for (int i = 0; i < password.Length; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                oddMessage += password[i];
            }

            password = oddMessage;
        }
    }
}
