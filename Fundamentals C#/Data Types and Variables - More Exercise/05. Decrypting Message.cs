namespace _5._Decrypting_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string decryptWord = "";

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                char fullLetters = (char)(letter + key);
                decryptWord += fullLetters;
            }
            Console.WriteLine(decryptWord);
        }
    }
}
