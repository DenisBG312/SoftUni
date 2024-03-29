using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();
        public void AddModel(IPlayer model)
        {
            models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            IPlayer playerToRemove = models.FirstOrDefault(p => p.Name == name);
            if (playerToRemove != null)
            {
                models.Remove(playerToRemove);
                return true;
            }
            return false;
        }

        public bool ExistsModel(string name)
        {
            return models.Any(p => p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }
    }
}
