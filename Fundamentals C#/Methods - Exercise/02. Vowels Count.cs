namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            CheckNumberVowels(word);
        }

        private static void CheckNumberVowels(string word)
        {
            int counter = 0;
            foreach (char c in word)
            {
                //a, e, i, o, and u
                switch (c)
                {
                    case 'a':
                    case 'A':
                    case 'e':
                    case 'E':
                    case 'i':
                    case 'I':
                    case 'o':
                    case 'O':
                    case 'u':
                    case 'U':
                        counter++;
                        break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
