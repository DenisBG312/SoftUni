using System.Text;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //01z
            //string usersPath = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, usersPath));

            //02z
            //string productPath = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productPath));

            //03z
            //string categoryPath = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoryPath));

            //04z
            //string categoryProductsPath = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductsPath));

            //05z
            //Console.WriteLine(GetProductsInRange(context));

            //06z
            //Console.WriteLine(GetSoldProducts(context));

            //07z
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //08z
            Console.WriteLine(GetUsersWithProducts(context));

        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserImportDto[]),
                new XmlRootAttribute("Users"));

            UserImportDto[] userImportDtos;
            using (var reader = new StringReader(inputXml))
            {
                userImportDtos = (UserImportDto[])xmlSerializer.Deserialize(reader);
            }

            User[] users = userImportDtos
                .Select(dto => new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                }).ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]),
                new XmlRootAttribute("Products"));

            ProductImportDto[] productDtos;
            using (var reader = new StringReader(inputXml))
            {
                productDtos = (ProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            Product[] products = productDtos
                .Select(dto => new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId
                }).ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryImportDto[]),
                new XmlRootAttribute("Categories"));

            CategoryImportDto[] categorieDtos;
            using (var reader = new StringReader(inputXml))
            {
                categorieDtos = (CategoryImportDto[])xmlSerializer.Deserialize(reader);
            }

            Category[] categories = categorieDtos
                .Select(dto => new Category()
                {
                    Name = dto.Name
                }).ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]),
                new XmlRootAttribute("CategoryProducts"));

            CategoryProductImportDto[] categoryProductDtos;
            using (var reader = new StringReader(inputXml))
            {
                categoryProductDtos = (CategoryProductImportDto[])xmlSerializer
                    .Deserialize(reader);
            }

            List<CategoryProduct> categoriesProducts = new List<CategoryProduct>();

            var categoryIds = context.Categories
                .Select(c => c.Id).ToList();

            var productsIds = context.Products
                .Select(p => p.Id);

            foreach (var dto in categoryProductDtos)
            {
                if (!categoryIds.Contains(dto.CategoryId)
                    || !productsIds.Contains(dto.ProductId))
                {
                    continue;
                }

                categoriesProducts.Add(new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                });
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductsInRangeExportDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"

                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            return SerializeXml(products, "Products");
        }

        //06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new ExportSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(s => new ProductDto()
                        {
                            Name = s.Name,
                            Price = s.Price,
                        }).ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            return SerializeXml(users, "Users");
        }

        //07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoriesByExportDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            return SerializeXml(categories, "Categories");
        }

        //08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(u => new UsersWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsCount()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToList()
                    }
                })
                .ToList();

            UserDto user = new UserDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            return SerializeXml(user, "Users");
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