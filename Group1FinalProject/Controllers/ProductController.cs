using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private static IList<Product> products = new List<Product>
        {
            new Product() {ProductId = 1, ProductName = "Test1"},
            new Product() {ProductId = 2, ProductName = "Test2"}
        };

        public IActionResult Index()
        {
            return View(products);
        }
    }
}
