namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            HashSet<string> set = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitted = input.Split(", ");
                string command = splitted[0];
                string carNum = splitted[1];

                if (command == "IN")
                {
                    set.Add(carNum);
                }
                else if (command == "OUT")
                {
                    set.Remove(carNum);
                }
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var num in set)
            {
                Console.WriteLine(num);
            }
        }
    }
}
