using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Boardgames.Data.Models.Enums;
using static Boardgames.Common.ValidationContext;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class BoardgameDto
    {
        [Required]
        [MinLength(BoardgameNameMinLength)]
        [MaxLength(BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(BoardgameRatingMinLength, BoardgameRatingMaxLength)]
        public double Rating { get; set; }
        [Required]
        [Range(BoargameYearPublishedMinLength, BoargameYearPublishedMaxLength)]
        public int YearPublished { get; set; }
        [Required]
        [EnumDataType(typeof(CategoryType))]
        public int CategoryType { get; set; }
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
