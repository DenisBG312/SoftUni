using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using Invoices.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportClientDto[]),
                new XmlRootAttribute("Clients"));

            ImportClientDto[] clientDtos;
            using (var reader = new StringReader(xmlString))
            {
                clientDtos = (ImportClientDto[])xmlSerializer.Deserialize(reader);
            }

            List<Client> clients = new List<Client>();

            var sb = new StringBuilder();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client c = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address a = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };

                    c.Addresses.Add(a);
                }
                clients.Add(c);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, c.Name));
            }
            context.Clients.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var invoicesInfo = JsonConvert.DeserializeObject<List<ImportInvoicesDto>>(jsonString);

            var validInvoices = new List<Invoice>();

            var sb = new StringBuilder();

            foreach (var invoiceDto in invoicesInfo)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoiceDto.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) || invoiceDto.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var invoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };

                if (invoice.IssueDate > invoice.DueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validInvoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var productsInfo = JsonConvert.DeserializeObject<List<ImportProductDto>>(jsonString);

            List<Product> products = new List<Product>();

            var validClientIds = context.Clients.Select(s => s.Id).ToList();

            var sb = new StringBuilder();

            foreach (var productDto in productsInfo)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = productDto.CategoryType
                };

                foreach (var clientDto in productDto.Clients.Distinct())
                {
                    if (!IsValid(clientDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!validClientIds.Contains(clientDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var productClient = new ProductClient()
                    {
                        Product = product,
                        ClientId = clientDto
                    };

                    product.ProductsClients.Add(productClient);
                }

                products.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
