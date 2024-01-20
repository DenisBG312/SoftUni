namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalsInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string chemical in chemicalsInput)
                {
                    chemicals.Add(chemical);
                }
            }

            Console.WriteLine(string.Join(' ', chemicals));
        }
    }
}
