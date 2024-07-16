using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var patientsDto = JsonConvert.DeserializeObject<PatientImportDto[]>(jsonString);

            List<Patient> validPatients = new List<Patient>();

            var sb = new StringBuilder();

            foreach (var patientDto in patientsDto)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender,
                };

                foreach (var medicineId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(s => s.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                validPatients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportPharmacyDto[]), new XmlRootAttribute("Pharmacies"));

            ImportPharmacyDto[] pharmacyDto;
            using (var reader = new StringReader(xmlString))
            {
                pharmacyDto = (ImportPharmacyDto[])xmlSerializer.Deserialize(reader);
            }

            List<Pharmacy> pharmacies = new List<Pharmacy>();
            foreach (var phDto in pharmacyDto)
            {
                if (!IsValid(phDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = phDto.Name,
                    PhoneNumber = phDto.PhoneNumber,
                    IsNonStop = bool.Parse(phDto.IsNonStop)
                };

                foreach (var medDto in phDto.Medicines)
                {
                    if (!IsValid(medDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isProductionDateValid = DateTime.TryParseExact(
                        medDto.ProductionDate,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out medicineProductionDate);

                    if (!isProductionDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineExpiryDate;
                    bool isExpiryDateValid = DateTime.TryParseExact(
                        medDto.ExpiryDate,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out medicineExpiryDate);

                    if (!isExpiryDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(x => x.Name == medDto.Name && x.Producer == medDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Category = (Category)medDto.Category,
                        Name = medDto.Name,
                        Price = (decimal)medDto.Price,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpiryDate,
                        Producer = medDto.Producer
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                pharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
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
    }
}
