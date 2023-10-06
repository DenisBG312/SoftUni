namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (type == "string") //type string
            {
                string result = GetMax(a, b);
                Console.WriteLine(result);
            }
            else if (type == "int") //type int
            {
                int result = GetMax(int.Parse(a), int.Parse(b));
                Console.WriteLine(result);
            }
            else //type char
            {
                char result = GetMax(char.Parse(a), char.Parse(b));
                Console.WriteLine(result);
            }
        }

        static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }

        static char GetMax(char a, char b)
        {
            return a > b ? a : b;
        }

        static string GetMax(string a, string b)
        {
            return (string.Compare(a, b) > 0) ? a : b;
        }
    }
}
