namespace GenericArrayCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", ArrayCreator.Create(5, "Denis")));
        }
    }
}
