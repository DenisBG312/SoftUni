using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastre.Common;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Validations.DistrictNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(Validations.DistrictPostalCodeLength)]
        public string PostalCode { get; set; } = null!;
        [Required]
        [MaxLength(Validations.RegionMaxCategoryDigit)]
        public Region Region { get; set; }

        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }

    //•	Id – integer, Primary Key
    //•	Name – text with length[2, 80] (required)
    //• PostalCode – text with length 8. All postal codes must have the following structure:starting with two //                       capital letters, followed by e dash '-', followed by five digits.Example: SF-10000 (required)
    //• Region – Region enum (SouthEast = 0, SouthWest, NorthEast, NorthWest) (required)
    //•	Properties - collection of type Property

}
