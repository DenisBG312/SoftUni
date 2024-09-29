using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaDetailsViewModel
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public IEnumerable<CinemaMovieViewModel> Movies { get; set; } =
            new HashSet<CinemaMovieViewModel>();
    }
}
