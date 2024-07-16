using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Medicines.Data.Models.Enums;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class MedicineImportDto
    {
        [Required]
        [Range(0, 4)]
        [XmlAttribute("category")]
        public int Category { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0.01, 1000.00)]
        public double Price { get; set; }
        [Required]
        public string ProductionDate { get; set; } = null!;
        [Required]
        public string ExpiryDate { get; set; } = null!;
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; } = null!;
    }

    //•	Name – text with length[3, 150] (required)
    //•	Price – decimal in range[0.01…1000.00] (required)
    //•	Category – Category enum (Analgesic = 0, Antibiotic, Antiseptic, Sedative, Vaccine) (required)
    //•	ProductionDate – DateTime(required)
    //•	ExpiryDate – DateTime(required)
    //•	Producer – text with length[3, 100] (required)
}
