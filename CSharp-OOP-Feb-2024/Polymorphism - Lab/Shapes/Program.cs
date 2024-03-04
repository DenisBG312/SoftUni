namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rec = new Rectangle(5, 10);

            Console.WriteLine(rec.CalculateArea());
            Console.WriteLine(rec.CalculatePerimeter());
            Console.WriteLine(rec.Draw());

            Shape cir = new Circle(7);
            Console.WriteLine(cir.CalculateArea());
            Console.WriteLine(cir.CalculatePerimeter());
            Console.WriteLine(cir.Draw());
        }
    }
}
