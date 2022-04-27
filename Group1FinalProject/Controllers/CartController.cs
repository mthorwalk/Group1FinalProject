using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class CartController : Controller
    {
        // test data: to be deleted
        private static IList<CartItem> itemsTest = new List<CartItem>
        {
            new CartItem() {ProductId = 87924, ProductName = "Slime Maker Kit for Kids", Price = 12.9, Image = "~/images/Picture24.jpg"},
            new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "~/images/Picture6.jpg"},
            new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "~/images/Picture6.jpg"},
            new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "~/images/Picture6.jpg"},
            new CartItem() {ProductId = 51120, ProductName = "Squishville Mini Squishmallows 6-Pack Rainbow Dream Squad", Price = 14.97, Image = "~/images/Picture6.jpg"}
        };

        // test data: to be deleted
        private static Cart cartTest = new Cart { CartId = 1, CartItems = itemsTest };

        public IActionResult Index()
        {
            return View(cartTest);
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
