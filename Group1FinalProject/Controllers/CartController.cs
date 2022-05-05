using Group1FinalProject.Models;
using Group1FinalProject.Helpers;
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


        private readonly IConfiguration Configuration;


        public CartController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["user"] != null)
            {
                DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
                var userID = int.Parse(Request.Cookies["user"]);
                SignUpViewModel signUpViewModel = databaseFunctions.GetCustomerByID(userID);
                List<CartItemModel> list = databaseFunctions.getCustomerCartItems(signUpViewModel);
                
                CartModel cart = new CartModel();
                cart.CartItems = list;
                cart.CartId = signUpViewModel.Id;
                return View("Index", cart);
            }

            return View("Index", cartTest);
        }

        public IActionResult DeleteProduct(int productId,int? cartItemId)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            if (Request.Cookies["user"] != null)
            {
                databaseFunctions.deleteCartItem(cartItemId);
            } 
                cartTest.CartItems.Remove(cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId));
                return RedirectToAction("Index");
            
            
        }

        public IActionResult IncreaseQuantity(int productId,int? cartItemId)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            if (Request.Cookies["user"] != null)
            {
                databaseFunctions.changeQuantity(cartItemId, "+");
                return RedirectToAction("Index");   
            }
           
                cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId).Quantity++;
                return RedirectToAction("Index");
            
        }
					
        public IActionResult DecreaseQuantity(int productId,int quantity, int cartItemId)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            if (Request.Cookies["user"] != null)
            {
                if (quantity == 1)
                {
                    databaseFunctions.deleteCartItem(cartItemId);

                } else
                {
                    databaseFunctions.changeQuantity(cartItemId, "-");
                }
                
                return RedirectToAction("Index");
            }           
                if (cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId).Quantity == 1)
                {
                    return DeleteProduct(productId,cartItemId);
                }
                else
                {
                    cartTest.CartItems.FirstOrDefault(p => p.ProductId == productId).Quantity--;
                    return RedirectToAction("Index");
                }
        }
        public IActionResult AddToCart(ProductModel product)
        {
            int? x = 0;
            CartItemModel ci = new CartItemModel() { ProductId = product.ProductId, ProductName = product.ProductName, CategoryId = product.CategoryId, Manufacturer = product.Manufacturer, 
            Description = product.Description, Dimensions = product.Dimensions, Weight = product.Weight, Rating = product.Rating, 
            Price = product.Price, SKU = product.SKU, Image = product.Image};
            if (Request.Cookies["user"] != null)
            {
                DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
                var userID = int.Parse(Request.Cookies["user"]);
                ci.cart_id = userID;
                databaseFunctions.AddCartItem(ci);
                return RedirectToAction("Index");
            }
            else {
                int contains = 0;
                foreach (CartItemModel test in cartTest.CartItems)
                {
                    if (test.ProductId == product.ProductId)
                    {
                        contains = 1;
                    }
                }
                if (contains == 1)
                {
                    IncreaseQuantity(product.ProductId,x);
                } else
                {
                    cartTest.CartItems.Add(ci);
                }
                return RedirectToAction("Index");
            }
        }
    }
}
