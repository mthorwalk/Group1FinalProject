using Group1FinalProject.Models;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class CartController : Controller
    {
        // test data: to be deleted
        private static IList<CartItem> itemsTest = new List<CartItem>
        {
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
        public IActionResult AddToCart(Product product)
        {
            CartItem ci = new CartItem() { ProductId = product.ProductId, ProductName = product.ProductName, CategoryId = product.CategoryId, Manufacturer = product.Manufacturer, 
            Description = product.Description, Dimensions = product.Dimensions, Weight = product.Weight, Rating = product.Rating, 
            Price = product.Price, SKU = product.SKU, Image = product.Image};
            int contains = 0;
            foreach(CartItem test in cartTest.CartItems)
            {
                if(test.ProductId == product.ProductId)
                {
                    contains = 1;
                }
            }
            if (contains == 1) 
            {
                IncreaseQuantity(product.ProductId);
            } else
            {
                cartTest.CartItems.Add(ci);
            }
            return RedirectToAction("Index");
        }
    }
}
