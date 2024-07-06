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

            Console.WriteLine(GetAuthorNamesEndingIn(context, "e"));
        }


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                   a.FirstName,
                   a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().Trim();
        }
    }
}


