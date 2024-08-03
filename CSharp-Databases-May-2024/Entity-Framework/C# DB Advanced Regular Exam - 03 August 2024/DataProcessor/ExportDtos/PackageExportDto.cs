using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("TourPackage")]
    public class PackageExportDto
    {
        public string Name { get; set; } = null!;
        [XmlElement("Description")]
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
