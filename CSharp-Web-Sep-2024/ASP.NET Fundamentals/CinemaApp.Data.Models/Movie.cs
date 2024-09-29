namespace CinemaApp.Data.Models
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CinemaMovie> MovieCinemas { get; set; } =
            new HashSet<CinemaMovie>();

    }
}
