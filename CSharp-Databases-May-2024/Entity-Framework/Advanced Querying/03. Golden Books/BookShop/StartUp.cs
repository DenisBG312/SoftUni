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

            Console.WriteLine(GetGoldenBooks(context));
            //DbInitializer.ResetDatabase(db);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(t => t.Copies < 5000 && t.EditionType == EditionType.Gold)
                .Select(t => new
                {
                    t.Title,
                    t.BookId,
                    t.Copies
                })
                .OrderBy(t => t.BookId);

            var sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }
    }
}


