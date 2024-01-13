namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string operatorSt = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            double result = Calculation(firstNum, operatorSt, secondNum);

            Console.WriteLine(result);
        }

        static double Calculation(int firstNum, string opeartorSt, int secondNum)
        {
            double result = 0;

            switch (opeartorSt)
            {
                case "/":
                    result = firstNum / secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
            }
            return result;
        }
    }
}
