using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar car = new SportCar(200, 300);
            car.Drive(20);
            Console.WriteLine(car.Fuel);
        }
    }
}
