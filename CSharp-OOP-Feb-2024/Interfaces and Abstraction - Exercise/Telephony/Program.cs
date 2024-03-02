namespace Telephony1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbersInput = Console.ReadLine()
                .Split();

            string[] sitesInput = Console.ReadLine()
                .Split();

            ICallable phone;
            foreach (var number in numbersInput)
            {
                if (number.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var siteUrl in sitesInput)
            {
                IBrowsable phoneBrowse = new Smartphone();
                try
                {
                    Console.WriteLine(phoneBrowse.Browse(siteUrl));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
