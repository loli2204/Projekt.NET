using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhotographyApp.Models;

namespace PhotographyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Konstruktor för HomeController
        // Tar en ILogger<HomeController> som parameter för att logga information
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: /Home/Index
        // Visar startsidan
        public IActionResult Index()
        {
            return View(); // Returnerar vyn för startsidan
        }

        // GET: /Home/Privacy
        // Visar sekretesspolicyn
        public IActionResult Privacy()
        {
            return View(); // Returnerar vyn för sekretesspolicyn
        }

        // GET: /Home/Error
        // Visar felmeddelandesidan
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Skapar en ny ErrorViewModel med begäran ID och returnerar vyn för felmeddelande
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
