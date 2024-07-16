using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicineDto
    {
        [XmlAttribute("Category")]
        public string Category { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Producer { get; set; }
        [XmlElement("BestBefore")]
        public string ExpiryDate { get; set; }
    }
}
