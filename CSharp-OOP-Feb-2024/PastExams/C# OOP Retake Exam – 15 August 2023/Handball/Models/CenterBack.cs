using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        public CenterBack(string name) : base(name, 4)
        {
        }

        public override void IncreaseRating()
        {
            Rating += 1;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            Rating -= 1;
            if (Rating < 1)
            {
                Rating = 1;
            }
        }
    }
}
