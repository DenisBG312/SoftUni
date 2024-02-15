using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public bool AddChild(Child child)
        {
            if (Capacity > Registry.Count)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            Child search = Registry.FirstOrDefault(x => x.FirstName + " " + x.LastName == childFullName);
            if (search != null)
            {
                Registry.Remove(search);
                return true;
            }

            return false;
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            Child search = Registry.FirstOrDefault(x => x.FirstName + " " + x.LastName == childFullName);
            return search;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry
                         .OrderByDescending(x => x.Age)
                         .ThenBy(x => x.LastName)
                         .ThenBy(x => x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
