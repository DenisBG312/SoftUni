using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models
{
    public class CinemaMovie
    {
        public Guid CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; } = null!;
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
