using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuidesWithPackages()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .OrderByDescending(t => t.TourPackage.Price)
                        .ThenBy(t => t.TourPackage.PackageName)
                        .Select(t => new PackageExportDto()
                        {
                            Name = t.TourPackage.PackageName,
                            Description = t.TourPackage.Description,
                            Price = t.TourPackage.Price
                        }).ToList()
                })
                .OrderByDescending(t => t.TourPackages.Count)
                .ThenBy(g => g.FullName)
                .ToList();

            return SerializeToXml(guides, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Customers
                .Where(c => c.Bookings.Any(s => s.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        }).ToList()
                })
                .OrderByDescending(c => c.Bookings.Count)
                .ThenBy(c => c.FullName)
                .ToList();

            return ConvertToJsonWithoutTypo(customers);
        }



        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(stringWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return stringBuilder.ToString();
        }
        private static string ConvertToJsonWithoutTypo<T>(List<T> input)
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }
    }

}
