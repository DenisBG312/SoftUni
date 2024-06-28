using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.PerformerNamesMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(ValidationConstants.PerformerNamesMaxLength)]

        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public decimal NetWorth { get; set; }
        public virtual ICollection<SongPerformer> PerformerSongs { get; set; } = new List<SongPerformer>();
    }
}
