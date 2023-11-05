namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> resourceQuantity = new Dictionary<string, int>();
            while (input != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity.Add(resource, 0);
                }

                resourceQuantity[resource] += quantity;

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> kvp in resourceQuantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
