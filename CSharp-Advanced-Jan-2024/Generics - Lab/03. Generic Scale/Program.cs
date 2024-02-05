namespace GenericScale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EqualityScale<int> notEqualScale = new EqualityScale<int>(5, 6);
            Console.WriteLine(notEqualScale.AreEqual());

            EqualityScale<int> equalScale = new EqualityScale<int>(3, 3);
            Console.WriteLine(equalScale.AreEqual());
        }
    }
}
