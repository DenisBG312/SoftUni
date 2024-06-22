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
            Console.WriteLine(IncreaseSalaries(context));
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<string> departmentsCheck = new List<string>();
            departmentsCheck.Add("Engineering");
            departmentsCheck.Add("Tool Design");
            departmentsCheck.Add("Marketing");
            departmentsCheck.Add("Information Services");

            var employees = context.Employees
                .Where(e => departmentsCheck.Contains(e.Department.Name))
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees
                         .OrderBy(e => e.FirstName)
                         .ThenBy(e => e.LastName))
            {
                var currentSalary = e.Salary;
                var increasedSalary = currentSalary * 1.12m;
                e.Salary = increasedSalary;
                context.Employees.Update(e);

                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}
