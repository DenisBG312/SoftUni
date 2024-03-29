using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;

        public TeamRepository()
        {
            models = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();
        public void AddModel(ITeam model)
        {
            models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            ITeam team = models.FirstOrDefault(x => x.Name == name);
            if (team != null)
            {
                models.Remove(team);
                return true;
            }
            return false;
        }

        public bool ExistsModel(string name)
        {
            return models.Any(p => p.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return models.FirstOrDefault(t => t.Name == name);
        }
    }
}
