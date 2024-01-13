namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sign = Console.ReadLine();
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            
            int result = 0;
            if (sign == "add")
            {
                result = Add(numOne, numTwo);
            }
            else if (sign == "multiply")
            {
                result = Multiply(numOne, numTwo);
            }
            else if (sign == "subtract")
            {
                result = Subtract(numOne, numTwo);
            }
            else if (sign == "divide")
            {
                result = Divide(numOne, numTwo);
            }
            Console.WriteLine(result);
        }

        static int Add(int numOne, int numTwo)
        {
            int result = numOne + numTwo;
            return result;
        }

        static int Multiply(int numOne, int numTwo)
        {
            int result = numOne * numTwo;
            return result;
        }

        static int Subtract(int numOne, int numTwo)
        {
            int result = numOne - numTwo;
            return result;
        }

        static int Divide(int numOne, int numTwo)
        {
            int result = numOne / numTwo;
            return result;
        }


    }
}
