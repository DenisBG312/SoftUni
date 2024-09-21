using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieInputModel
    {
        [MaxLength(TitleMaxLength)]
        public required string Title { get; set; }
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public required string Genre { get; set; }
        public required DateTime ReleaseDate { get; set; }
        [Range(DurationMinValue, DurationMaxValue)]
        public int Duration { get; set; }

        [MinLength(DirectorNameMinLength)]
        [MaxLength(DirectorNameMaxLength)]
        public required string Director { get; set; }

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public required string Description { get; set; }
    }
}
