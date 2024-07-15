using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class CarsWithDistanceDto
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("traveled-distance")]
        public long TraveledDistance { get; set; }
    }

    [XmlType("car")]
    public class CarsArrayLikeDto
    {
        [XmlAttribute("id")]
        public int CarId { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }
    }

    [XmlType("sale")]
    public class CarsWithDiscountDto
    {
        [XmlElement("car")]
        public CarDto Car { get; set; }
        [XmlElement("discount")]
        public int Discount { get; set; }
        [XmlElement("customer-name")]
        public string CustomerName { get; set; } = null!;
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("price-with-discount")]
        public double PriceWithDiscount { get; set; }
    }

    [XmlType("car")]
    public class CarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;
        [XmlAttribute("model")]
        public string Model { get; set; } = null!;
        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }
    }

}
