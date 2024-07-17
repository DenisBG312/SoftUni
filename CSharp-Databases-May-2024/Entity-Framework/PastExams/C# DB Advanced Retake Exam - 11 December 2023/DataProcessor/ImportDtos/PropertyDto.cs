using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Cadastre.Common;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class PropertyDto
    {
        [Required]
        [XmlElement]
        [MinLength(Validations.PropertyIdentifierMinLength)]
        [MaxLength(Validations.PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;
        [Required]
        [XmlElement]
        [Range(1, int.MaxValue)]
        public int Area { get; set; }
        [XmlElement]
        [MinLength(Validations.PropertyDetailsMinLength)]
        [MaxLength(Validations.PropertyDetailsMaxLength)]
        public string? Details { get; set; }
        [Required]
        [XmlElement]
        [MinLength(Validations.PropertyAddressMinLength)]
        [MaxLength(Validations.PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;
        [Required]
        [XmlElement]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
