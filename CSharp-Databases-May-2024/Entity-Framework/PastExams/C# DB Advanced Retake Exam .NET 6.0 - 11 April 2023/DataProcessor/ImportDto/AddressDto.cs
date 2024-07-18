using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Invoices.Common;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class AddressDto
    {
        [Required]
        [XmlElement("StreetName")]
        [MaxLength(Validations.AddressStreetNameMaxLength)]
        [MinLength(Validations.AddressStreetNameMinLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")] public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(Validations.AddressCityMaxLength)]
        [MinLength(Validations.AddressCityMinLength)]
        [XmlElement("City")]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(Validations.AddressCountryMaxLength)]
        [MinLength(Validations.AddressCityMinLength)]
        [XmlElement("Country")]
        public string Country { get; set; } = null!;
    }
}
