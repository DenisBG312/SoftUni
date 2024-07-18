using Invoices.DataProcessor.ExportDto;

namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                .Where(c => c.Invoices.Any(s => s.IssueDate > date))
                .Select(c => new ExportClientsWithInvoices()
                {
                    InvoicesCount = c.Invoices.Count.ToString(),
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(s => s.IssueDate)
                        .ThenByDescending(s => s.DueDate)
                        .Select(s => new InvoiceDto()
                        {
                            InvoiceNumber = s.Number,
                            InvoiceAmount = decimal.Parse(s.Amount.ToString().TrimEnd('0')),
                            DueDate = s.DueDate.ToString("MM/dd/yyyy"),
                            Currency = s.CurrencyType.ToString()
                        }).ToArray()
                })
                .OrderByDescending(s => s.InvoicesCount)
                .ThenBy(s => s.ClientName)
                .ToList();

            return SerializeToXml(clients, "Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var clients = context.Products
                .Where(p => p.ProductsClients
                    .Any(s => s.Client.Name.Length >= nameLength))
                .Select(dto => new ExportProductWithClientDto()
                {
                    Name = dto.Name,
                    Price = decimal.Parse(dto.Price.ToString().TrimEnd('0')),
                    Category = dto.CategoryType.ToString(),
                    Clients = dto.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(s => new ClientDto()
                        {
                            Name = s.Client.Name,
                            NumberVat = s.Client.NumberVat
                        })
                        .OrderBy(s => s.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Clients.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToList();

            return ConvertToJsonWithoutTypo(clients);
        }


        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(stringWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return stringBuilder.ToString();
        }
        private static string ConvertToJsonWithoutTypo<T>(List<T> input)
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }
    }
}