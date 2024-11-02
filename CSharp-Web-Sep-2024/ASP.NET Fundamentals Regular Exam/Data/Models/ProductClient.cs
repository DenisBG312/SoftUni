using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        [Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        [Required]
        public string ClientId { get; set; } = null!;
        [ForeignKey(nameof(ClientId))]
        public IdentityUser Client { get; set; } = null!;
    }
}
