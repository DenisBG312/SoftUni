namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkEqualOrLargerNameSum = (name, sum) =>
            {
                int charSum = name.Sum(c => c);

                return charSum >= sum;
            };

            Func<string[], int, Func<string, int, bool>, string> getFirstName =
                (names, sum, match) =>

                {
                    foreach (var name in names)
                    {
                        if (match(name, sum))
                        {
                            return name;
                        }
                    }

                    return null;
                };

            int sum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            string foundName = getFirstName(names, sum, checkEqualOrLargerNameSum);
            Console.WriteLine(foundName);
        }
    }
}
