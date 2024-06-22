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
            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townsToDelete = context.Towns
                .Where(t => t.Name == "Seattle")
                .ToList();

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            var employeesAddressesToSetNull = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var townToDelete in townsToDelete)
            {
                context.Towns.Remove(townToDelete);
            }

            int addressesRemoved = 0;

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
                addressesRemoved++;
            }

            foreach (var e in employeesAddressesToSetNull)
            {
                e.AddressId = null;
            }

            context.SaveChanges();

            return $"{addressesRemoved} addresses in Seattle were deleted";
        }
    }
}
