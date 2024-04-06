using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        public BloggerInfluencer(string username, int followers) : base(username, followers, 2)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double fee = Followers * EngagementRate * 0.2;
            return (int)Math.Floor(fee);
        }
    }
}
