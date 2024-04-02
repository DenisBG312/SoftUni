using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            IRoute route = routes.FirstOrDefault(x => x.RouteId == int.Parse(identifier));
            if (route != null)
            {
                routes.Remove(route);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IRoute FindById(string identifier)
        {
            return routes.FirstOrDefault(x => x.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll() => routes.AsReadOnly();
    }
}
