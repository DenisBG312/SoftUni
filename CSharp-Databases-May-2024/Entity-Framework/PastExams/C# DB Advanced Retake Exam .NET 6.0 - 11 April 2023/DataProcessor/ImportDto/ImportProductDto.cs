using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Common;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [Required]
        [MinLength(Validations.ProductNameMinLength)]
        [MaxLength(Validations.ProductNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Range((double)Validations.ProductPriceMinLength, (double)Validations.ProductPriceMaxLength)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 4)]
        public CategoryType CategoryType { get; set; }
        public int[] Clients { get; set; } = null!;
    }
}
