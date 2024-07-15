using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class CarsWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;
        [XmlAttribute("model")]
        public string Model { get; set; } = null!;
        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }
        [XmlArray("parts")]
        [XmlArrayItem("part")]

        public List<PartForCarsDto> Parts { get; set; } = null!;
    }

    [XmlType("parts")]
    public class PartForCarsDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
