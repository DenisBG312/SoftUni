using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarWithPartsIdsDto
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;
        [XmlElement("model")]
        public string Model { get; set; } = null!;
        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        [XmlArrayItem("partId")]
        public List<PartIdDto> Parts { get; set; }
    }

    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
