namespace _04._Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                string isValid = "true";
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isValid = "false";
                        break;
                    }
                }
                isValid.ToString().ToLower();
                Console.WriteLine($"{i} -> {isValid}");
            }
        }
    }
}
