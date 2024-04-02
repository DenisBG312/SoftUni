using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            IUser user = users.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IUser FindById(string identifier)
        {
            return users.FirstOrDefault(d => d.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll() => users.AsReadOnly();
    }
}
