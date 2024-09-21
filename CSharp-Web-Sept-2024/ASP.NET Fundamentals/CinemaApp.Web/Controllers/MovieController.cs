using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private CinemaDbContext _context;
        public MovieController(CinemaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Movie> allMovies = _context
                .Movies
                .ToList();

            return View(allMovies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddMovieInputModel inputModel)
        {

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = inputModel.ReleaseDate,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                Description = inputModel.Description
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid idValid);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = _context
                .Movies
                .FirstOrDefault(m => m.Id == idValid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
    }
}
