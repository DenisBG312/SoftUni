using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data.Models.Enums;
using static TravelAgency.Common.ValidationContext;

namespace TravelAgency.Data.Models
{
    public class Guide
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(GuideFullNameMaxLength)]
        public string FullName { get; set; } = null!;
        [Required]
        public Language Language { get; set; }

        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();
    }
}
