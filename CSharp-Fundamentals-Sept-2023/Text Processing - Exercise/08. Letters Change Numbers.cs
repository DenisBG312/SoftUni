namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0;

            foreach (string str in input)
            {
                char letterBefore = str[0];
                char letterAfter = str[str.Length - 1];
                decimal number = decimal.Parse(str.Substring(1, str.Length - 2));

                decimal position = 0;
                decimal result = 0;

                if (char.IsUpper(letterBefore))
                {
                    position = (letterBefore - 'A' + 1);
                    result = number / position;
                }
                else if (char.IsLower(letterBefore))
                {
                    position = letterBefore - 'a' + 1;
                    result = number * position;
                }

                if (char.IsUpper(letterAfter))
                {
                    position = letterAfter - 'A' + 1;
                    result -= position;
                }
                else if (char.IsLower(letterAfter))
                {
                    position = letterAfter - 'a' + 1;
                    result += position;
                }

                totalSum += result;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
