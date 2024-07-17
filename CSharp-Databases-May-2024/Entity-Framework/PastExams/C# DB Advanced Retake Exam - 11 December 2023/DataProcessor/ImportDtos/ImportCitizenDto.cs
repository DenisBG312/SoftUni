using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastre.Common;
using Cadastre.Data.Enumerations;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [Required]
        [MinLength(Validations.CitizenFirstNameMinLength)]
        [MaxLength(Validations.CitizenFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MinLength(Validations.CitizenLastNameMinLength)]
        [MaxLength(Validations.CitizenLastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        public string BirthDate { get; set; } = null!;
        [Required]
        [EnumDataType(typeof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;
        [Required]
        public int[] Properties { get; set; }
    }
}
