using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._Speed_Racing
{
    public class Pokemon
    {
        public Pokemon(string name, string element, double health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public double Health { get; set; }
    }
}
