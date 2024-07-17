using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportDistrictDto[]),
                new XmlRootAttribute("Districts"));

            ImportDistrictDto[] districtDtos;
            using (var reader = new StringReader(xmlDocument))
            {
                districtDtos = (ImportDistrictDto[])xmlSerializer.Deserialize(reader);
            }

            List<District> validDistricts = new List<District>();

            var sb = new StringBuilder();

            foreach (var districtDto in districtDtos)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var district = new District()
                {
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region),
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(p
                            => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || district.Properties.Any(d => d.PropertyIdentifier == propertyDto.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(s
                            => s.Address == propertyDto.Address)
                               || district.Properties.Any(s => s.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var property = new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = DateTime
                            .ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    district.Properties.Add(property);
                }

                validDistricts.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var citizensInfo = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            List<Citizen> validCitizens = new List<Citizen>();
            
            var sb = new StringBuilder();

            foreach (var citizenDto in citizensInfo)
            {
                if (!IsValid(citizenDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var citizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = DateTime.ParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDto.MaritalStatus)
                };

                foreach (var propDto in citizenDto.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId = propDto
                    };

                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }

                validCitizens.Add(citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizenDto.FirstName, citizenDto.LastName, citizen.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

    }
}
