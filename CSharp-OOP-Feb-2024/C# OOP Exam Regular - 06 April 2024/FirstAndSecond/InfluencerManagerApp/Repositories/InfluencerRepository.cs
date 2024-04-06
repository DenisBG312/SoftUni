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
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private List<IInfluencer> models;

        public InfluencerRepository()
        {
            models = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => models.AsReadOnly();
        public void AddModel(IInfluencer model)
        {
            models.Add(model);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return models.Remove(model);
        }

        public IInfluencer FindByName(string name)
        {
            return models.FirstOrDefault(i => i.Username == name);
        }
    }
}
