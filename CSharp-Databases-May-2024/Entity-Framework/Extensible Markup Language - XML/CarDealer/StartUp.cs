using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //09z
            //string suppliersPath = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersPath));

            //10z
            //string partsPath = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsPath));

            //11z
            //string carsPath = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsPath));

            //12z
            //string customerPath = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customerPath));

            //13z
            //string salesPath = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesPath));

            //14z
            //Console.WriteLine(GetCarsWithDistance(context));

            //15z
            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //16z
            //Console.WriteLine(GetLocalSuppliers(context));

            //17z
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //18z
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //19z
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]),
                new XmlRootAttribute("Suppliers"));


            SupplierImportDto[] supplierDtos;
            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = supplierDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        //10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartImportDto[]),
                new XmlRootAttribute("Parts"));

            PartImportDto[] parts;
            using (var reader = new StringReader(inputXml))
            {
                parts = (PartImportDto[])xmlSerializer.Deserialize(reader);
            }

            var supplierIds = context.Suppliers
                .Select(s => s.Id).ToList();

            var validParts = new List<Part>();

            foreach (var dto in parts)
            {
                if (!supplierIds.Contains(dto.SupplierId))
                {
                    continue;
                }

                validParts.Add(new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                });
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        //11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarWithPartsIdsDto[]),
                new XmlRootAttribute("Cars"));

            CarWithPartsIdsDto[] carDtos;
            using (var reader = new StringReader(inputXml))
            {
                carDtos = (CarWithPartsIdsDto[])xmlSerializer.Deserialize(reader);
            }

            var partIds = context.Parts.Select(p => p.Id).ToList();

            var cars = new List<Car>();

            foreach (var dto in carDtos)
            {
                var uniquePartIds = dto.Parts
                    .Select(p => p.Id)
                    .Distinct()
                    .Where(id => partIds.Contains(id))
                    .ToList();

                var car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,
                    PartsCars = uniquePartIds.Select(id => new PartCar() { PartId = id }).ToList()
                };

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomerImportDto[]),
                new XmlRootAttribute("Customers"));

            CustomerImportDto[] customerDtos;
            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (CustomerImportDto[])xmlSerializer.Deserialize(reader);
            }

            Customer[] customers = customerDtos
                .Select(dto => new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                }).ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SaleImportDto[]),
                new XmlRootAttribute("Sales"));

            SaleImportDto[] saleDtos;
            using (var reader = new StringReader(inputXml))
            {
                saleDtos = (SaleImportDto[])xmlSerializer.Deserialize(reader);
            }

            var validCarIds = context.Cars.Select(c => c.Id).ToList();
            List<Sale> sales = new List<Sale>();

            foreach (var dto in saleDtos)
            {
                if (!validCarIds.Contains(dto.CarId))
                {
                    continue;
                }

                var sale = new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(dto => new CarsWithDistanceDto()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList(); 
            
            return SerializeXml(cars, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(dto => new CarsArrayLikeDto()
                {
                    CarId = dto.Id,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToList();

            return SerializeXml(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(dto => new SuppliersDto()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    PartsCount = dto.Parts.Count
                }).ToList();

            return SerializeXml(suppliers, "suppliers");

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(dto => new CarsWithPartsDto()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,
                    Parts = dto.PartsCars
                        .Select(partDto => new PartForCarsDto()
                        {
                            Name = partDto.Part.Name,
                            Price = partDto.Part.Price
                        })
                        .OrderByDescending(partDto => partDto.Price)
                        .ToList()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            return SerializeXml(cars, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var dto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            CustomersExportDto[] totalSalesDtos = dto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new CustomersExportDto()
                {
                    FullName = t.FullName,
                    BoughtCars = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return SerializeXml(totalSalesDtos, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(dto => new CarsWithDiscountDto()
                {
                    Car = new CarDto()
                    {
                        Make = dto.Car.Make,
                        Model = dto.Car.Model,
                        TraveledDistance = dto.Car.TraveledDistance,
                    },
                    Discount = (int)dto.Discount,
                    CustomerName = dto.Customer.Name,
                    Price = dto.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(dto.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (dto.Discount / 100))), 4)
                }).ToList();


            return SerializeXml(sales, "sales");
        }




        public static string SerializeXml<T>(T obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            // Create an XmlSerializer for the type T with a specified root element name
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            // Configure namespaces for serialization
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); // Remove default namespaces

            // Use a StringWriter to serialize the object into a StringBuilder
            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, obj, namespaces);
            }

            // Return the serialized XML as a string, trimmed of any trailing whitespace
            return sb.ToString().TrimEnd();
        }
        public static string SerializeXml<T>(T[] obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]),
                new XmlRootAttribute(rootName));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}