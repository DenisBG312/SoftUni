using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Cadastre.Common;
using Cadastre.Data.Enumerations;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [Required]
        [XmlAttribute]
        [EnumDataType(typeof(Region))]
        public string Region { get; set; } = null!;
        [Required]
        [XmlElement]
        [MinLength(Validations.DistrictNameMinLength)]
        [MaxLength(Validations.DistrictNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [XmlElement]
        [RegularExpression(Validations.DistrictPostalCodeRegExpression)]
        public string PostalCode { get; set; } = null!;
        [Required]
        [XmlArray]
        [XmlArrayItem("Property")]
        public PropertyDto[] Properties { get; set; }
    }
}
