using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> models;

        public CampaignRepository()
        {
            models = new List<ICampaign>();
        }
        public IReadOnlyCollection<ICampaign> Models => models.AsReadOnly();
        public void AddModel(ICampaign model)
        {
            models.Add(model);
        }

        public bool RemoveModel(ICampaign model)
        {
            return models.Remove(model);
        }

        public ICampaign FindByName(string name)
        {
            return models.FirstOrDefault(c => c.Brand == name);
        }
    }
}
