using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicines.Data.Models;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicinesFromCategory
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public PharmacyDto Pharmacy { get; set; }
    }
}
