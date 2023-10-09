namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            double result = SumMethod(firstInt, secondInt);
            Console.WriteLine(SubtractMethod(thirdInt, result));
        }

        static int SumMethod(int firstInt, int secondInt)
        {
            int result = firstInt + secondInt;
            return result;
        }

        static double SubtractMethod(int thirdInt, double result)
        {
            result -= thirdInt;
            return result;
        }
    }
}
