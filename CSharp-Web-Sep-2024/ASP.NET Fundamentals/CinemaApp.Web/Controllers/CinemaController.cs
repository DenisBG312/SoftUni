using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly CinemaDbContext context;
        public CinemaController(CinemaDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await context
                .Cinemas
                .Select(c => new CinemaIndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location
                })
                .OrderBy(c => c.Location)
                .ToArrayAsync();

            return View(cinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Cinema cinema = new Cinema()
            {
                Name = model.Name,
                Location = model.Location
            };

            await context.Cinemas.AddAsync(cinema);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid cinemaGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref cinemaGuid);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Cinema? cinema = await context
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(c => c.Id == cinemaGuid);

            if (cinema == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel viewModel = new CinemaDetailsViewModel()
            {
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies
                    .Where(cm => cm.IsDeleted == false) 
                    .Select(cm => new CinemaMovieViewModel()
                    {
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration
                    })
                    .ToArray()
            };

            return View(viewModel);
        }
    }
}
