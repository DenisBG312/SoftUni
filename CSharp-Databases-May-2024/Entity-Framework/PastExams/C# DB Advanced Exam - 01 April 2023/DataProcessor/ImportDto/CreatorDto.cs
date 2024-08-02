using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static Boardgames.Common.ValidationContext;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class CreatorDto
    {
        [Required]
        [MinLength(CreatorFirstNameMinLength)]
        [MaxLength(CreatorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MinLength(CreatorLastNameMinLength)]
        [MaxLength(CreatorLastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [XmlArray]
        [XmlArrayItem("Boardgame")]
        public BoardgameDto[] Boardgames { get; set; }
    }
}
