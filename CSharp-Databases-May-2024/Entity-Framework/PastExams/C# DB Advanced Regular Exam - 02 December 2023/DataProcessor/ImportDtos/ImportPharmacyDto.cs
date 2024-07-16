using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [Required]
        [XmlAttribute("non-stop")]
        [RegularExpression(@"^(true|false)$")]
        public string IsNonStop { get; set; } = null!;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}")]
        public string PhoneNumber { get; set; } = null!;
        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]

        public MedicineImportDto[] Medicines { get; set; }
    }


    //•	Id – integer, Primary Key
    //•	Name – text with length[2, 50] (required)
    //  PhoneNumber – text with length 14. (required)
    //      All phone numbers must have the following structure: three digits enclosed in parentheses, followed by a        space, three more digits, a hyphen, and four final digits: 
    //          	Example -> (123) 456-7890 
    //•IsNonStop – bool (required)
    //•Medicines - collection of type Medicine
}
