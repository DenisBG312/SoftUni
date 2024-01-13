namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int addMinutes = 30;
            int totalMins = addMinutes + minutes;
            if (totalMins >= 60)
            {
                totalMins -= 60;
                hours++;
            }
            if (hours >= 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{totalMins:D2}");

        }
    }
}
