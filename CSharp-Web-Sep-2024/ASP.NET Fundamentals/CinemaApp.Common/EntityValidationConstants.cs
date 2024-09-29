using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common
{
    public class EntityValidationConstants
    {
        public static class Movie
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 50;
            public const int GenreMinLength = 5;
            public const int GenreMaxLength = 20;
            public const int DurationMinValue = 1;
            public const int DurationMaxValue = 999;
            public const int DirectorNameMinLength = 10;
            public const int DirectorNameMaxLength = 80;
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
        }

        public static class Cinema
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int LocationMinLength = 3;
            public const int LocationMaxLength = 85;
        }
    }
}
