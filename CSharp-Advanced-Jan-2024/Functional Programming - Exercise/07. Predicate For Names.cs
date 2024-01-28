namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<string>, List<string>> checkNames = (names, match) =>
            {
                List<string> newList = new List<string>();
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        newList.Add(name);
                    }
                }


                return newList;
            };


            int nameLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            Predicate<string> match = name =>
                name.Length <= nameLength;

            names = checkNames(names, match);

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
