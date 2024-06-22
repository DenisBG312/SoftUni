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
            Console.WriteLine(GetEmployeesInPeriod(context));
        }


        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeFullName = $"{e.FirstName} {e.LastName}",
                    ManagerFullName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep =>
                            ep.Project.StartDate.Year >= 2001
                            && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ep.Project.StartDate,
                            EndDate = ep.Project.EndDate.HasValue ?
                                ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                                "not finished"
                        })
                })
                .Take(10);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

                if (employee.Projects.Any())
                {
                    foreach (var p in employee.Projects)
                    {
                        sb.AppendLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {p.EndDate}");
                    }
                }
            }


            return sb.ToString().TrimEnd();
        }


    }
}
