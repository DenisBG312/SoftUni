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
            Console.WriteLine(GetEmployee147(context));
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var searchedEmployee = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    ProjectNames = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name
                        })
                })
                .Where(e => e.EmployeeId == 147);

            var sb = new StringBuilder();
            foreach (var e in searchedEmployee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var p in e.ProjectNames.OrderBy(p => p.Name))
                {
                    sb.AppendLine(p.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
