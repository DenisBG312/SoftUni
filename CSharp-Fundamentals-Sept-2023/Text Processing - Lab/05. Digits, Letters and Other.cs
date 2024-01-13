namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> numbers = new List<string>();
            List<string> letters = new List<string>();
            List<string> symbols = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 65 && text[i] <= 90 
                    || text[i] >= 97 && text[i] <= 122)
                {
                    letters.Add(text[i].ToString());
                }
                else if (text[i] >= 48 && text[i] <= 57)
                {
                    numbers.Add(text[i].ToString());
                }
                else
                {
                    symbols.Add(text[i].ToString());
                }
            }

            Console.WriteLine(string.Join("", numbers));
            Console.WriteLine(string.Join("", letters));
            Console.WriteLine(string.Join("", symbols));
        }
    }
}
