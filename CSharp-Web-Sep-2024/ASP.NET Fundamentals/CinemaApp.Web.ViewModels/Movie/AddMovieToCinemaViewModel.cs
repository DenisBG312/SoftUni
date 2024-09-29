using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Web.ViewModels.Movie
{
    using static Common.EntityValidationConstants.Movie;
    public class AddMovieToCinemaViewModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string MovieTitle { get; set; } = null!;

        public IList<CinemaCheckBoxItemInputModel> Cinemas { get; set; }
            = new List<CinemaCheckBoxItemInputModel>();
    }
}
