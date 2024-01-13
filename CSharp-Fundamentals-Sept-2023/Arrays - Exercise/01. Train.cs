namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] people = new int[wagons];
            int totalPassengers = 0;

            for (int i = 0; i < wagons; i++)
            {
                int singlePeople = int.Parse(Console.ReadLine());
                people[i] = singlePeople;
                totalPassengers += people[i];
            }

            Console.Write(string.Join(" ", people));
            Console.WriteLine();
            Console.WriteLine(totalPassengers);
        }
    }
}
