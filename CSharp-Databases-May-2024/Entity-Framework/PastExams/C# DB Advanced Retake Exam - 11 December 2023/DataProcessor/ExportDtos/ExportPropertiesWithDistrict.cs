using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlType("Property")]
    public class ExportPropertiesWithDistrict
    {
        [XmlAttribute("postal-code")]
        public string PostalCode { get; set; }
        public string PropertyIdentifier { get; set; }
        public int Area { get; set; }
        public string DateOfAcquisition { get; set; }
    }
}