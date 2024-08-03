using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static TravelAgency.Common.ValidationContext;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [Required]
        [RegularExpression(CustomerPhoneNumberRegex)]
        [XmlAttribute("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;
    }
}
