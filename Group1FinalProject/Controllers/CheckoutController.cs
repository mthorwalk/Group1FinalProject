using Microsoft.AspNetCore.Mvc;
using Group1FinalProject.Models;

namespace Group1FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
        // test data: to be deleted
        private static IList<CartItemModel> itemsTest = new List<CartItemModel>
        {
            //new CartItem() {ProductId = 87924, ProductName = "Slime Maker Kit for Kids", Price = 12.9, Image = "/images/Picture24.jpeg"},
            //new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "/images/Picture6.jpeg"},
            //new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "/images/Picture6.jpeg"},
            //new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "/images/Picture6.jpeg"},
            //new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "/images/Picture6.jpeg"}
        };

        // test data: to be deleted
        private static CheckoutModel cartTest = new CheckoutModel{ CheckoutId = 1, CheckoutItems = itemsTest };

        public IActionResult Index(IList<CartItemModel> cartItems)
        {
            cartTest.CheckoutItems = cartItems;
            return View("Index", cartTest);

        }

        public IActionResult Purchase()
        {
            return View("Purchase", cartTest);
        }
    }
}
