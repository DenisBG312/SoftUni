namespace _03._Courier_Express
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var weightShipment = double.Parse(Console.ReadLine());
            var service = Console.ReadLine();
            var length = double.Parse(Console.ReadLine());
            var allPrice = 0.0;

            if (weightShipment < 1)
            {
                allPrice = length * 0.03;
            }
            else if (weightShipment >= 1 && weightShipment <= 10)
            {
                allPrice = length * 0.05;
            }
            else if (weightShipment >= 11 && weightShipment <= 40)
            {
                allPrice = length * 0.10;
            }
            else if (weightShipment >= 41 && weightShipment <= 90)
            {
                allPrice = length * 0.15;
            }
            else if (weightShipment >= 91 && weightShipment <= 150)
            {
                allPrice = length * 0.20;
            }


            if (service == "express")
            {
                if (weightShipment < 1)
                {
                    allPrice = allPrice + 0.8 * 0.03 * length * weightShipment;
                }
                else if (weightShipment >= 1 && weightShipment <= 10)
                {
                    allPrice = allPrice + 0.4 * 0.05 * length * weightShipment;
                }

                else if (weightShipment >= 11 && weightShipment <= 40)
                {
                    allPrice = allPrice + 0.05 * 0.10 * length * weightShipment;
                }

                else if (weightShipment >= 41 && weightShipment <= 90)
                {
                    allPrice = allPrice + 0.02 * 0.15 * length * weightShipment;
                }

                else if (weightShipment >= 91 && weightShipment <= 150)
                {
                    allPrice = allPrice + 0.01 * 0.20 * length * weightShipment;
                }
            }

            Console.WriteLine("The delivery of your shipment with weight of {0:f3} kg. would cost {1:f2} lv.", weightShipment, allPrice);
        }
    }
}
