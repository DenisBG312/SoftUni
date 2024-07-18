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
    [XmlType("Client")]
    public class ImportClientDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(Validations.ClientNameMinLength)]
        [MaxLength(Validations.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("NumberVat")]
        [MinLength(Validations.ClientNumberVatMinLength)]
        [MaxLength(Validations.ClientNumberVatMaxLength)]
        public string NumberVat { get; set; } = null!;
        [XmlArray("Addresses")]
        public AddressDto[] Addresses { get; set; }
    }
}
