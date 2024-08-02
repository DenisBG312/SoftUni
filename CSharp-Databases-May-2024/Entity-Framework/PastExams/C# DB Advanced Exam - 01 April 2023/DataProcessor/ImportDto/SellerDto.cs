using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Boardgames.Common.ValidationContext;

namespace Boardgames.DataProcessor.ImportDto
{
    public class SellerDto
    {
        [Required]
        [MinLength(SellerNameMinLength)]
        [MaxLength(SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(SellerAddressMinLength)]
        [MaxLength(SellerAddressMaxLength)]
        public string Address { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(SellerWebsiteRegex)]
        public string Website { get; set; } = null!;
        public int[] Boardgames { get; set; }
    }
}
