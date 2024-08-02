using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Boardgames.Common.ValidationContext;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(SellerAddressMaxLength)]
        public string Address { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
        [Required]
        [RegularExpression(SellerWebsiteRegex)]
        public string Website { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
            = new HashSet<BoardgameSeller>();
    }
}
