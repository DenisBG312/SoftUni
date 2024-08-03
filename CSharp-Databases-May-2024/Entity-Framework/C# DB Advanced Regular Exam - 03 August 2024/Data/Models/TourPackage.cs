using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static TravelAgency.Common.ValidationContext;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(TourPackagePackageNameMaxLength)]
        public string PackageName { get; set; } = null!;
        [MaxLength(TourPackageDescriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        [Range(typeof(decimal), TourPackagePriceMinValue, TourPackagePriceMaxValue)]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();
    }
}
