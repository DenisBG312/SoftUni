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

            Console.WriteLine(AddNewAddressToEmployee(context));
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);
            context.SaveChanges();

            var employee = context.Employees
                .First(e => e.LastName == "Nakov");

            employee.Address = newAddress;
            context.SaveChanges();


            var adresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            var sb = new StringBuilder();

            foreach (var adress in adresses)
            {
                sb.AppendLine(adress);
            }

            return sb.ToString().TrimEnd();
        }


    }
}
