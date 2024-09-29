using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private CinemaDbContext _context;

        public MovieController(CinemaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> allMovies = await _context
                .Movies
                .ToListAsync();

            return View(allMovies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
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

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid idValid);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context
                .Movies
                .FirstOrDefaultAsync(m => m.Id == idValid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> AddToProgram(string? id)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref movieGuid);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context
                .Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaViewModel viewModel = new AddMovieToCinemaViewModel()
            {
                Id = id!,
                MovieTitle = movie.Title,
                Cinemas = await _context
                    .Cinemas
                    .Include(c => c.CinemaMovies)
                    .ThenInclude(cm => cm.Movie)
                    .Select(c => new CinemaCheckBoxItemInputModel()
                    {
                        Id = c.Id.ToString(),
                        Name = c.Name,
                        Location = c.Location,
                        IsSelected = c.CinemaMovies
                            .Any(cm => cm.Movie.Id == movieGuid && cm.IsDeleted == false)
                    })
                    .ToArrayAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid movieGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(model.Id, ref movieGuid);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await _context
                .Movies.FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ICollection<CinemaMovie> entitiesToAdd = new HashSet<CinemaMovie>();

            foreach (var cinemaInputModel in model.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaGuidValid = IsGuidValid(cinemaInputModel.Id, ref cinemaGuid);

                if (!isCinemaGuidValid)
                {
                    ModelState.AddModelError(string.Empty, "Invalid cinema selected!");
                    return View(model);
                }

                Cinema? cinema = await _context
                    .Cinemas
                    .FirstOrDefaultAsync(c => c.Id == cinemaGuid);

                if (cinema == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid cinema selected!");
                    return View(model);
                }

                CinemaMovie cinemaMovie = await _context
                    .CinemasMovies
                    .FirstOrDefaultAsync(cm => cm.MovieId == movieGuid && cm.CinemaId == cinemaGuid);

                if (cinemaInputModel.IsSelected)
                {
                    if (cinemaMovie == null)
                    {
                        entitiesToAdd.Add(new CinemaMovie()
                        {
                            Cinema = cinema,
                            Movie = movie
                        });
                    }
                    else
                    {
                        cinemaMovie.IsDeleted = false;
                    }
                }
                else
                {

                    if (cinemaMovie != null)
                    {
                        cinemaMovie.IsDeleted = true;
                        cinemaInputModel.IsSelected = false;
                    }
                }

                await _context.SaveChangesAsync();
            }

            await _context.CinemasMovies.AddRangeAsync(entitiesToAdd);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Cinema");
        }   
    }
}
