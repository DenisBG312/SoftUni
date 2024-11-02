using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DeskMarket.Data.Models
{
    using static Constants.EntityConstants.Product;
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string ProductName { get; set; } = null!;
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [Range(PriceMinRange, PriceMaxRange)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public string SellerId { get; set; } = null!;
        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;
        [Required]
        public DateTime AddedOn { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
    }
}
