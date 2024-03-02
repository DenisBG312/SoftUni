namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> people = new List<IBuyer>();
            int totalFood = 0;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                if (input.Length == 4)
                {
                    people.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                else if (input.Length == 3)
                {
                    people.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
            }

            string inputWhile;
            while ((inputWhile = Console.ReadLine()) != "End")
            {
                IBuyer person = people.FirstOrDefault(x => x.Name == inputWhile);

                if (person != null)
                {
                    totalFood += person.BuyFood();
                }
            }

            Console.WriteLine(totalFood);

        }
    }
}
