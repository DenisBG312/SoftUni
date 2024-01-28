namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<string, List<int>, List<int>> arrModificator = (command, numArr) =>
            {
                List<int> arr = new List<int>();
                foreach (var num in numArr)
                {
                    switch (command)
                    {
                        case "add":
                            arr.Add(num + 1);
                            break;
                        case "multiply":
                            arr.Add(num * 2);
                            break;
                        case "subtract":
                            arr.Add(num - 1);
                            break;

                        default:
                            break;
                    }
                }

                return arr;
            };

            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
                else
                {
                    nums = arrModificator(command, nums);
                }
            }
        }
    }
}
