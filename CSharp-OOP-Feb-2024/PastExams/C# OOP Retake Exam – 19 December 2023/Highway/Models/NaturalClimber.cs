using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        public NaturalClimber(string name) : base(name, 6)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += 2 * daysCount;
        }
    }
}
