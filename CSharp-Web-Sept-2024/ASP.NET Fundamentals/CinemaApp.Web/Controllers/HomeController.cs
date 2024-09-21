using CinemaApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to the Cinema Web App!";

            return View();
        }
    }
}
