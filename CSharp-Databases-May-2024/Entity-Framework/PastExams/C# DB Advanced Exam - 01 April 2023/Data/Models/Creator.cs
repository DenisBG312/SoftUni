using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Boardgames.Common.ValidationContext;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(CreatorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(CreatorLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public ICollection<Boardgame> Boardgames { get; set; } = new HashSet<Boardgame>();

    }
}
