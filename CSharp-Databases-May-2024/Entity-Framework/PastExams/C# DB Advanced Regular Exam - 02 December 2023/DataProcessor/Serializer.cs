using System.Globalization;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Newtonsoft.Json.Serialization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > targetDate))
                .Select(p => new ExportPatientsWithTheirMedicinesDto()
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLowerInvariant(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate > targetDate)
                        .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new ExportMedicineDto
                        {
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("F2", CultureInfo.InvariantCulture),
                            Category = pm.Medicine.Category.ToString().ToLowerInvariant(),
                            Producer = pm.Medicine.Producer,
                            ExpiryDate = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToList()
                })
                .OrderByDescending(p => p.Medicines.Count)
                .ThenBy(p => p.Name)
                .ToList();

            return SerializeXml(patients, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context,int medicineCategory)
        {

            var categoryEnum = (Category)medicineCategory;

            var medicines = context.Medicines
                .Where(s => s.Category == categoryEnum && s.Pharmacy.IsNonStop)
                .OrderBy(s => s.Price)
                .ThenBy(s => s.Name)
                .Select(dto => new ExportMedicinesFromCategory()
                {
                    Name = dto.Name,
                    Price = dto.Price.ToString("f2"),
                    Pharmacy = new PharmacyDto()
                    {
                        Name = dto.Pharmacy.Name,
                        PhoneNumber = dto.Pharmacy.PhoneNumber
                    }
                }).ToList();

            return ConvertToJsonWithTypo(medicines);
        }


        public static string SerializeXml<T>(T obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            // Create an XmlSerializer for the type T with a specified root element name
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            // Configure namespaces for serialization
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); // Remove default namespaces

            // Use a StringWriter to serialize the object into a StringBuilder
            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, obj, namespaces);
            }

            // Return the serialized XML as a string, trimmed of any trailing whitespace
            return sb.ToString().TrimEnd();
        }

        private static string ConvertToJsonWithTypo<T>(List<T> input)
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }
    }
}
