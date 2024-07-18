using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Invoices.Common
{
    public class Validations
    {
        //Product
        public const int ProductNameMinLength = 9;
        public const int ProductNameMaxLength = 30;
        public const decimal ProductPriceMinLength = 5m;
        public const decimal ProductPriceMaxLength = 1000m;

        //Address
        public const int AddressStreetNameMinLength = 10;
        public const int AddressStreetNameMaxLength = 20;
        public const int AddressCityMinLength = 5;
        public const int AddressCityMaxLength = 15;
        public const int AddressCountryMinLength = 5;
        public const int AddressCountryMaxLength = 15;

        //Invoice
        public const int InvoiceNumberMinLength = 1000000000;
        public const int InvoiceNumberMaxLength = 1500000000;

        //Client
        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;
    }

}
