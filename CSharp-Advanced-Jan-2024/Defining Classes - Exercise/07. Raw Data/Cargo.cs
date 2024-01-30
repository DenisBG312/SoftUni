using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._Speed_Racing
{
    public class Cargo
    {
        public Cargo(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
        public string Type { get; set; }
        public double Weight { get; set; }
    }
}
