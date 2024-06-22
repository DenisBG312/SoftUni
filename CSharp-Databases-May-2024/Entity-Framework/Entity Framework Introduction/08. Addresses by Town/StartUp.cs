using SoftUni.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();
            Console.WriteLine(GetAddressesByTown(context));
        }


        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(e => new
                {
                    e.AddressText,
                    TownName = e.Town.Name,
                    CountOfEmployees = e.Employees.Count
                })
                .OrderByDescending(c => c.CountOfEmployees)
                .ThenBy(t => t.TownName)
                .ThenBy(a => a.AddressText);

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.CountOfEmployees} employees");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
