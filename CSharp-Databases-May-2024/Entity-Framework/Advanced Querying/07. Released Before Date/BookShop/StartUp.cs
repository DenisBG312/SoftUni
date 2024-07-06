using System.Globalization;
using System.Runtime.Serialization;
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

            Console.WriteLine(GetBooksReleasedBefore(context, "30-12-1989"));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate);

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }



    }
}


