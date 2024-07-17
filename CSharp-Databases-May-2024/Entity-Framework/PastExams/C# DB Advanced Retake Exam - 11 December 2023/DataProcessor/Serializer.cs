using Cadastre.Data;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            string dateToCheck = "01/01/2000";
            var properties = dbContext.Properties
                .Where(s => s.DateOfAcquisition >= DateTime.ParseExact(dateToCheck, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(s => s.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new ExportPropertiesWithOwners()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                        .Select(x => new OwnersExport()
                        {
                            LastName = x.Citizen.LastName,
                            MaritalStatus = x.Citizen.MaritalStatus.ToString(),
                        })
                        .OrderBy(s => s.LastName)
                        .ToArray()
                }).ToList();

            return ConvertToJsonWithoutTypo(properties);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(s => s.Area >= 100)
                .OrderByDescending(s => s.Area)
                .ThenBy(s => s.DateOfAcquisition)
                .Select(dto => new ExportPropertiesWithDistrict()
                {
                    PostalCode = dto.District.PostalCode,
                    PropertyIdentifier = dto.PropertyIdentifier,
                    Area = dto.Area,
                    DateOfAcquisition = dto.DateOfAcquisition.ToString("dd/MM/yyyy")
                }).ToList();

            return SerializeToXml(properties, "Properties");
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
