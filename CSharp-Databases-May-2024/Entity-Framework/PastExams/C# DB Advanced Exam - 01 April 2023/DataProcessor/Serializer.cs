using Boardgames.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Include(c => c.Boardgames)
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new CreatorWithBoardGames()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames
                        .OrderBy(b => b.Name)
                        .Select(b => new BoardgameCreator()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        }).ToList()
                })
                .OrderByDescending(b => b.BoardgamesCount)
                .ThenBy(b => b.CreatorName)
                .ToList();

            return SerializeToXml(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {

            var sellers = context
                .Sellers
                .Where(s => s.BoardgamesSellers.Any(b => 
                    b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
                .Select(s => new SellersWithBoardgames()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(b => b.Boardgame.YearPublished >= year
                        && b.Boardgame.Rating <= rating)
                        .OrderByDescending(b => b.Boardgame.Rating)
                        .ThenBy(b => b.Boardgame.Name)
                        .Select(b => new BoardgameExportDto()
                        {
                            Name = b.Boardgame.Name,
                            Rating = b.Boardgame.Rating,
                            Mechanics = b.Boardgame.Mechanics,
                            Category = b.Boardgame.CategoryType.ToString()
                        }).ToList()
                })
                .OrderByDescending(b => b.Boardgames.Count)
                .ThenBy(b => b.Name)
                .Take(5)
                .ToList();

            return ConvertToJsonWithoutTypo(sellers);
        }


        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(stringWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return stringBuilder.ToString();
        }
        private static string ConvertToJsonWithoutTypo<T>(List<T> input)
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }
    }
}