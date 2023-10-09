namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            ValidPassword(password);
        }

        static void ValidPassword(string password)
        {
            //•It should contain 6 – 10 characters(inclusive)
            //• It should contain only letters and digits
            //• It should contain at least 2 digits

            bool characters = false;
            bool lettersDigits = false;
            bool digitsTwo = false;
            int currentDigs = 0;

            if (password.Length >= 6 && password.Length <= 10)
            {
                characters = true;
            }
            else
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];

                if ((int)currentChar >= 48 && (int)currentChar <= 57
                    || (int)currentChar >= 65 && (int)currentChar <= 90
                    || (int)currentChar >= 97 && (int)currentChar <= 122)
                {
                    lettersDigits = true;
                }
                else
                {
                    lettersDigits = false;
                    break;
                }
            }

            if (lettersDigits == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];

                if ((int)currentChar >= 48 && (int)currentChar <= 57)
                {
                    currentDigs++;
                }
            }

            if (currentDigs >= 2)
            {
                digitsTwo = true;
            }
            else
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (digitsTwo && characters && lettersDigits)
            {
                Console.WriteLine("Password is valid");
            }

        }
    }
}
