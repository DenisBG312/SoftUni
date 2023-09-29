namespace _4._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < text.Length / 2; i++)
            {
                string firstElement = text[i];
                string lastElement = text[text.Length - 1 - i];

                text[i] = lastElement;
                text[text.Length - 1 - i] = firstElement;
            }

            Console.WriteLine(string.Join(" ", text));
        }
    }
}
