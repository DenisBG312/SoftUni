using System.Globalization;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //01z
            //var suppliersInfo = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersInfo));

            //02z
            //var partsInfo = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, partsInfo));

            //03z
            //var carsInfo = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, carsInfo));

            //04z
            //var customersInfo = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, carsInfo));

            //05z
            //var salesInfo = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, salesInfo));

            //06z
            //Console.WriteLine(GetOrderedCustomers(context));

            //07z
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //08z
            //Console.WriteLine(GetLocalSuppliers(context));

            //09z
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //010z
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //011z
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var suppliersIds = context.Suppliers.Select(s => s.Id).ToList();

            var validParts = new List<Part>();
            foreach (var part in parts)
            {
                if (suppliersIds.Contains(part.SupplierId))
                {
                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        //03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(newCar);
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar()
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }
            }
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                }).ToList();

            return ConvertToJsonNotTypo(customers);
        }


        //07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToList();

            return ConvertToJsonNotTypo(cars);
        }

        //08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return ConvertToJsonNotTypo(suppliers);
        }

        //09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = p.Part.Price.ToString("f2")
                        })
                })
                .ToList();

            return ConvertToJsonNotTypo(carsAndParts);
        }

        //010
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any()) // Filter customers who have bought at least 1 car
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            return ConvertToJsonWithTypo(customers);
        }

        //011
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },

                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars
                        .Sum(pc => pc.Part.Price) * (1 - s.Discount / 100))
                        .ToString("f2")
                })
                .Take(10)
                .ToList();

            return ConvertToJsonNotTypo(sales);
        }

        private static string ConvertToJsonNotTypo<T>(List<T> input)
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(input, settings);
        }
        private static string ConvertToJsonWithTypo<T>(List<T> input)
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(input, settings);
        }
    }
}