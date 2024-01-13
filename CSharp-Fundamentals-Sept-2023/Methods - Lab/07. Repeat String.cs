namespace _07._Repeat_String1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringCon = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(stringCon, n));
        }

        static string RepeatString(string stringCon, int n)
        {
            string result = "";

            for (int i = 0; i < n; i++)
            {
                result += stringCon;
            }
            return result;
        }
    }
}
