using System.Text;
using System.Xml.Serialization;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(CreatorDto[]),
                new XmlRootAttribute("Creators"));

            CreatorDto[] creatorDtos;
            using (var reader = new StringReader(xmlString))
            {
                creatorDtos = (CreatorDto[])xmlSerializer.Deserialize(reader);
            }

            var validCreators = new List<Creator>();

            var sb = new StringBuilder();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var boardDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame()
                    {
                        Name = boardDto.Name,
                        Rating = boardDto.Rating,
                        YearPublished = boardDto.YearPublished,
                        CategoryType = (CategoryType)boardDto.CategoryType,
                        Mechanics = boardDto.Mechanics
                    };

                    creator.Boardgames.Add(boardgame);
                }
                validCreators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellersInfo = JsonConvert.DeserializeObject<List<SellerDto>>(jsonString);

            var validSellers = new List<Seller>();

            var sb = new StringBuilder();

            foreach (var sellerDto in sellersInfo)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(s => s.Id == boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = boardgameId,
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                validSellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
