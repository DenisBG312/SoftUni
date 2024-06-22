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
            Console.WriteLine(DeleteProjectById(context));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            context.Projects.Remove(project);

            var employeeProject = context.EmployeesProjects
                .Where(e => e.ProjectId == 2)
                .ToList();

            foreach (var ep in employeeProject)
            {
                context.EmployeesProjects.Remove(ep);
            }

            var projects = context.Projects
                .Take(10)
                .Select(p => new
                {
                    p.Name
                });

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
