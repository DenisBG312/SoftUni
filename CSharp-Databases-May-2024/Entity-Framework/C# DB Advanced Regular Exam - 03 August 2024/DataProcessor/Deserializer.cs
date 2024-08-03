using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customerDtos;
            using (var reader = new StringReader(xmlString))
            {
                customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            List<Customer> validCustomers = new List<Customer>();

            var sb = new StringBuilder();

            foreach (var custDto in customerDtos)
            {
                if (!IsValid(custDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validCustomers.Any(s => s.FullName == custDto.FullName
                                            || s.Email == custDto.Email
                                            || s.PhoneNumber == custDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var customer = new Customer()
                {
                    PhoneNumber = custDto.PhoneNumber,
                    FullName = custDto.FullName,
                    Email = custDto.Email
                };

                validCustomers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var bookingsInfo = JsonConvert.DeserializeObject<List<ImportBookingDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var bookDto in bookingsInfo)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(bookDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var bookingDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(c => c.FullName == bookDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(tp => tp.PackageName == bookDto.TourPackageName);

                var booking = new Booking()
                {
                    BookingDate = bookingDate,
                    CustomerId = customer.Id,
                    TourPackageId = tourPackage.Id
                };

                context.Bookings.Add(booking);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported booking. TourPackage: {tourPackage.PackageName}, Date: {bookingDate:yyyy-MM-dd}");

            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
