using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class UsersWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlElement("age")]
        public int? Age { get; set; }
        [XmlArray("SoldProducts")]
        public SoldProductsCount SoldProducts { get; set; } = null!;
    }

    [XmlType("SoldProducts")]
    public class SoldProductsCount
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ProductDto> Products { get; set; }
    }

    public class UserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        [XmlArrayItem("user")]
        public List<UsersWithProductsDto> Users { get; set; }
    }
}
