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
            Console.WriteLine(GetBooksNotReleasedIn(context, 1998));
            //DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue 
                            && b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.BookId
                })
                .OrderBy(b => b.BookId);

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }
    }
}


