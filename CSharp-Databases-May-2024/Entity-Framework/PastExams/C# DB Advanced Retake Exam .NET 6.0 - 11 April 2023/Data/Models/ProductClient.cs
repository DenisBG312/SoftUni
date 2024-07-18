using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class ProductClient
    {
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
    }
}
