using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return $"{string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber)}";
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return $"{string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber)}";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != nameof(CargoVan) && vehicleType != nameof(PassengerCar))
            {
                return $"{string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType)}";
            }

            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return $"{string.Format(OutputMessages.LicensePlateExists, licensePlateNumber)}";
            }

            IVehicle vehicle = null;
            if (vehicleType == nameof(CargoVan))
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else if (vehicleType == nameof(PassengerCar))
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);
            return $"{string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber)}";
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            foreach (var route in routes.GetAll())
            {
                if (route.StartPoint == startPoint && route.EndPoint == endPoint && route.Length == length)
                {
                    return $"{string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length)}";
                }
                else if (route.StartPoint == startPoint && route.EndPoint == endPoint && route.Length < length)
                {
                    return $"{string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint)}";
                }
                else if (route.StartPoint == startPoint && route.EndPoint == endPoint && route.Length > length)
                {
                    route.LockRoute();
                }
            }

            IRoute newRoute = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            routes.AddModel(newRoute);
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

        }






        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);
            if (user.IsBlocked)
            {
                return $"{string.Format(OutputMessages.UserBlocked, drivingLicenseNumber)}";
            }
            if (vehicle.IsDamaged)
            {
                return $"{string.Format(OutputMessages.VehicleDamaged, licensePlateNumber)}";
            }
            if (route.IsLocked)
            {
                return $"{string.Format(OutputMessages.RouteLocked, routeId)}";
            }

            vehicle.Drive(route.Length);
            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            var damagedVehicles = vehicles.GetAll()
                .Where(x => x.IsDamaged)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model);

            int vehiclesCount = 0;

            if (damagedVehicles.Count() < count)
            {
                vehiclesCount = damagedVehicles.Count();
            }
            else
            {
                vehiclesCount = count;
            }

            var selectedVehicles = damagedVehicles.ToArray().Take(vehiclesCount);

            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return $"{string.Format(OutputMessages.RepairedVehicles, vehiclesCount)}";

        }

        public string UsersReport()
        {
            var orderedUsers = users.GetAll()
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.FirstName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var orderedUser in orderedUsers)
            {
                sb.AppendLine(orderedUser.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
