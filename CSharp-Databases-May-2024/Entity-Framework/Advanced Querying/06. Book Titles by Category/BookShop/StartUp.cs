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

            Console.WriteLine(GetBooksByCategory(context, "horror mystery drama"));

            //DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categoriesList = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var books = context.BooksCategories
                .Where(c => categoriesList.Contains(c.Category.Name.ToLower()))
                .Select(b => new
                {
                    b.Book.Title
                })
                .OrderBy(b => b.Title);

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }
    }
}


