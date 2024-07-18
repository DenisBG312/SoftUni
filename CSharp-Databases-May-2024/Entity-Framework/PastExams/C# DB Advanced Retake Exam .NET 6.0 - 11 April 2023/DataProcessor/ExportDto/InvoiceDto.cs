using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class InvoiceDto
    {
        public int InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string DueDate { get; set; } = null!;
        public string Currency { get; set; } = null!;
    }
}
