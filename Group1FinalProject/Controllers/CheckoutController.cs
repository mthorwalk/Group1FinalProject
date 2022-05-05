using Microsoft.AspNetCore.Mvc;
using Group1FinalProject.Models;

namespace Group1FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
        //DELETE
        private static IList<CartItemModel> itemsTest = new List<CartItemModel>
        {
            new CartItemModel() {ProductId = 87924, ProductName = "Slime Maker Kit for Kids", Price = 12.9, Image = "/images/Picture24.jpg", Quantity = 1}
        };

        // DELETE
        private static CheckoutModel cartTest = new CheckoutModel{ CheckoutId = 1, CheckoutItems = itemsTest };

        public IActionResult Index()
        {
            return View(cartTest);
        }

        public IActionResult Purchase()
        {
            return View(cartTest);
        }

        public void Summary(double shippingCost)
        {
            cartTest.Shipping = shippingCost;
        }
    }
}
