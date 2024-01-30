using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static void CalculateDifference(string startDate, string endDate)
        {
            DateTime startDateTime = DateTime.Parse(startDate);
            DateTime endDateTime = DateTime.Parse(endDate);

            TimeSpan difference = startDateTime - endDateTime;

            double differenceDouble = Math.Abs(difference.TotalDays);

            Console.WriteLine(differenceDouble);
        } 
    }
}
