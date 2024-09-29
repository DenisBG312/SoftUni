using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.EntityValidationMessages.Movie;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieInputModel
    {
        public AddMovieInputModel()
        {
            ReleaseDate = DateTime.Now;
        }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }
        [Required(ErrorMessage = GenreRequiredMessage)]
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; }
        [Required(ErrorMessage = ReleaseDateMessage)]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = DurationRequiredMessage)]
        [Range(DurationMinValue, DurationMaxValue)]
        public int Duration { get; set; }
        [Required(ErrorMessage = DirectorRequiredMessage)]
        [MinLength(DirectorNameMinLength)]
        [MaxLength(DirectorNameMaxLength)]
        public string Director { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
