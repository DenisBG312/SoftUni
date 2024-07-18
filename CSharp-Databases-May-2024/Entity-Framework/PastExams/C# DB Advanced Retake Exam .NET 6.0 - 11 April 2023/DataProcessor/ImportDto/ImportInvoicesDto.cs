using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Common;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoicesDto
    {
        [Required]
        [Range(Validations.InvoiceNumberMinLength, Validations.InvoiceNumberMaxLength)]
        public int Number { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Range(0, 2)]
        public CurrencyType CurrencyType { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}
