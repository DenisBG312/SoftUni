using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Data.Models
{
    using static Constants.EntityConstants.Category;
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
