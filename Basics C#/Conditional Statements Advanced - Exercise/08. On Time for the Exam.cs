using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivingHour = int.Parse(Console.ReadLine());
            int arrivingMinutes = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinutes;
            int arrivingTime = arrivingHour * 60 + arrivingMinutes;

            int finalHour = 0;
            int finalMinutes = 0;

            if (examTime >= arrivingTime)
            {
                int finalTime = examTime - arrivingTime;
                finalHour = finalTime / 60;
                finalMinutes = finalTime % 60;
                if (finalTime == 0)
                {
                    Console.WriteLine("On time");
                }

                else if (finalTime <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{finalMinutes} minutes before the start");

                }
                else if (finalTime > 30)
                {
                    Console.WriteLine("Early");
                    if (finalHour == 0)
                    {
                        Console.WriteLine($"{finalMinutes} minutes before the start");
                    }
                    else if (finalHour > 0 && finalMinutes >= 10)
                    {
                        Console.WriteLine($"{finalHour}:{finalMinutes} hours before the start");
                    }
                    else if (finalHour > 0 && finalMinutes < 10)
                    {
                        Console.WriteLine($"{finalHour}:0{finalMinutes} hours before the start");
                    }
                }
            }
            else if (examTime < arrivingTime)
            {
                int finalTime = arrivingTime - examTime;
                finalHour = finalTime / 60;
                finalMinutes = finalTime % 60;
                Console.WriteLine("Late");
                if (finalHour == 0)
                {
                    Console.WriteLine($"{finalMinutes} minutes after the start");
                }
                else if (finalHour > 0 && finalMinutes >= 10)
                {
                    Console.WriteLine($"{finalHour}:{finalMinutes} hours after the start");
                }
                else if (finalHour > 0 && finalMinutes < 10)
                {
                    Console.WriteLine($"{finalHour}:0{finalMinutes} hours after the start");
                }
            }

        }
    }
}
