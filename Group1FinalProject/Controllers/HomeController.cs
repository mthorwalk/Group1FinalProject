using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Group1FinalProject.Controllers
{
    public class HomeController : Controller
    {
        // Commented out to make the Unit Tests work, I am unsure of how to pass logger argument to test controller in our Unit Tests
        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}