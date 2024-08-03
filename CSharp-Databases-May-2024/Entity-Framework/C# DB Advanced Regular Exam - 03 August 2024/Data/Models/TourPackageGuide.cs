using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        public int TourPackageId { get; set; }
        [ForeignKey(nameof(TourPackageId))]
        public TourPackage TourPackage { get; set; }
        public int GuideId { get; set; }
        [ForeignKey(nameof(GuideId))]
        public Guide Guide { get; set; }
    }
}
