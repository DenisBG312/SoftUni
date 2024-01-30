namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "Peter";
            p1.Age = 20;

            Person p2 = new Person();
            p2.Name = "George";
            p2.Age = 18;

            Person p3 = new Person();
            p3.Name = "Jose";
            p3.Age = 43;
        }
    }
}
