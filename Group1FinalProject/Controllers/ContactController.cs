using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }
    }
}
