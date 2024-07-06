using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            Console.WriteLine(GetBooksByPrice(context));
            //DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(t => t.Price > 40)
                .Select(t => new
                {
                    t.Title,
                    t.Price
                })
                .OrderByDescending(t => t.Price);

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}


