namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier.CalculateDifference(startDate, endDate);

        }
    }
}
