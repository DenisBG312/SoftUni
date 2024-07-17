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
    public class Citizen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Validations.CitizenFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(Validations.CitizenLastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();

    }

        //•	Id – integer, Primary Key
        //•	FirstName – text with length[2, 30] (required)
        //•	LastName – text with length[2, 30] (required)
        //•	BirthDate – DateTime(required)
        //•	MaritalStatus - MaritalStatus enum (Unmarried = 0, Married, Divorced, Widowed) (required)
        //•	PropertiesCitizens - collection of type PropertyCitizen

}
