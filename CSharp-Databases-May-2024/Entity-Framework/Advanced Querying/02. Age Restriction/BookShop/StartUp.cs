using System.Text;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));
            //DbInitializer.ResetDatabase(db);
        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .ToArray()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(t => t.Title);

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }
    }
}


