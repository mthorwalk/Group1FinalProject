using Group1FinalProject.Models;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class CartController : Controller
    {
        // DELETE
        private static IList<CartItemModel> itemsTest = new List<CartItemModel>
        {
            new CartItemModel() {ProductId = 87924, ProductName = "Slime Maker Kit for Kids", Price = 12.9, Image = "/images/Picture24.jpg"}
        };

        // DELETE
        private static CartModel cartTest = new CartModel { CartId = 1, CartItems = itemsTest };

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
        public IActionResult AddToCart(ProductModel product)
        {
            CartItemModel ci = new CartItemModel() { ProductId = product.ProductId, ProductName = product.ProductName, CategoryId = product.CategoryId, Manufacturer = product.Manufacturer, 
            Description = product.Description, Dimensions = product.Dimensions, Weight = product.Weight, Rating = product.Rating, 
            Price = product.Price, SKU = product.SKU, Image = product.Image};
            int contains = 0;
            foreach(CartItemModel test in cartTest.CartItems)
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
