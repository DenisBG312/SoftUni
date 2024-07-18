using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientsWithInvoices
    {
        [XmlAttribute("InvoicesCount")]
        public string InvoicesCount { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string VatNumber { get; set; } = null!;
        [XmlArray("Invoices")]
        public InvoiceDto[] Invoices { get; set; } = null!;
    }
}
