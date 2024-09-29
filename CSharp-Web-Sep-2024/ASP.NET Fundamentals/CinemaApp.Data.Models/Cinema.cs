using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models
{
    public class Cinema
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; } = 
            new HashSet<CinemaMovie>();

    }
}
