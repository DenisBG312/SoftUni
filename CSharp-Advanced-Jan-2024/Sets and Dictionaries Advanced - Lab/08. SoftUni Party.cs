namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            HashSet<string> ids = new HashSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                ids.Add(input);
            }

            string secondInput;
            while ((secondInput = Console.ReadLine()) != "END")
            {
                string checkedID = secondInput;
                ids.Remove(checkedID);
            }

            Console.WriteLine(ids.Count);
            foreach (var id in ids
                         .OrderBy(c => !char.IsDigit(c[0]))) 
            {
                Console.WriteLine(id);
            }
        }
    }
}
