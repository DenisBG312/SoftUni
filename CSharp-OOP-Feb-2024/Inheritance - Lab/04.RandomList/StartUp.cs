namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            
            randomList.Add("2");
            randomList.Add("3");
            randomList.Add("4");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
