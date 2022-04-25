using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class CartController : Controller
    {
        // test data: to be deleted
        private static IList<CartItem> itemsTest = new List<CartItem>
        {
            new CartItem() {ProductId = 3, ProductName = "Fidget Spinner", Price = 2.50},
            new CartItem() {ProductId = 4, ProductName = "Slime", Price = 3.50}
        };

        // test data: to be deleted
        private static Cart cartTest = new Cart { CartId = 1, CartItems = itemsTest };

        public IActionResult Index()
        {
            return View("Index", cartTest);
        }

        public IActionResult DeleteProduct(int productId)
        {
            cartTest.CartItems.Remove(cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId));
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int productId)
        {
            cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId).Quantity++;
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseQuantity(int productId)
        {
            if (cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId).Quantity == 1)
            {
                return DeleteProduct(productId);
            }
            else
            {
                cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId).Quantity--;
                return RedirectToAction("Index");
            }
        }
    }
}
