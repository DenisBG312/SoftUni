using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class ExportPatientsWithTheirMedicinesDto
    {
        [XmlAttribute("Gender")]
        public string Gender { get; set; }
        public string Name { get; set; }
        public string AgeGroup { get; set; }
        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public List<ExportMedicineDto> Medicines { get; set; }
    }

}
