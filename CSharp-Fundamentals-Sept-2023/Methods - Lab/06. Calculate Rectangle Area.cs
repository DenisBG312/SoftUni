namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            
            double result = RecArea(width, height);
            Console.WriteLine(result);
        }

        static int RecArea(int width, int height)
        {
            return width * height;
        }
    }
}
