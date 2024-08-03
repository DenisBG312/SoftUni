using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuidesWithPackages
    {
        public string FullName { get; set; } = null!;
        [XmlArray]
        [XmlArrayItem("TourPackage")]
        public List<PackageExportDto> TourPackages { get; set; }
    }
}
