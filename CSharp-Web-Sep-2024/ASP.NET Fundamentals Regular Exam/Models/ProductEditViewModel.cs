namespace DeskMarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Constants.EntityConstants.Product;
    using static Constants.EntityMessages.Product;
    public class ProductEditViewModel
    {
        [Required(ErrorMessage = ProductNameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = ProductNameLength)]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = PriceRequired)]
        [Range(PriceMinRange, PriceMaxRange, ErrorMessage = PriceRange)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = DateTimeFormat)]
        public string AddedOn { get; set; } = DateTime.Now.ToString(DateTimeFormat);
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public string SellerId { get; set; }
    }
}
