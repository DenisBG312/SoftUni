using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Data.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage;
using static Boardgames.Common.ValidationContext;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(BoardgameRatingMinLength, BoardgameRatingMaxLength)]
        public double Rating { get; set; }
        [Required]
        [Range(BoargameYearPublishedMinLength, BoargameYearPublishedMaxLength)]
        public int YearPublished { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }
        [Required]
        public string Mechanics { get; set; } = null!;
        [Required]
        public int CreatorId { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public Creator Creator { get; set; }

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } 
            = new HashSet<BoardgameSeller>();
    }
}
