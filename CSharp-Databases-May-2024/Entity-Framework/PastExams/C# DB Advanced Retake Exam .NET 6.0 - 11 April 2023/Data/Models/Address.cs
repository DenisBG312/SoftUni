using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Common;

namespace Invoices.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Validations.AddressStreetNameMaxLength)]
        public string StreetName { get; set; } = null!;
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string PostCode { get; set; } = null!;
        [Required]
        [MaxLength(Validations.AddressCityMaxLength)]
        public string City { get; set; } = null!;
        [Required]
        [MaxLength(Validations.AddressCountryMaxLength)]
        public string Country { get; set; } = null!;
        [Required]
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
    }
}
