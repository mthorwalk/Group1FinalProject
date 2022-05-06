using Group1FinalProject.Models;
using Group1FinalProject.Helpers;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Group1FinalProject.Controllers
{
    public class CartController : Controller
    {
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
                List<CartItemModel> list = databaseFunctions.GetCustomerCartItems(signUpViewModel);
                
                CartModel cart = new CartModel();
                cart.CartItems = list;
                cart.CartId = signUpViewModel.Id;
                return View("Index", cart);
            }

            return View("Guest");
        }

        public IActionResult DeleteProduct(int productId,int? cartItemId)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            databaseFunctions.DeleteCartItem(cartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int productId,int? cartItemId)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            databaseFunctions.ChangeQuantity(cartItemId, "+");
            return RedirectToAction("Index");
        }
					
        public IActionResult DecreaseQuantity(int productId,int quantity, int cartItemId)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            if (quantity == 1)
            {
                databaseFunctions.DeleteCartItem(cartItemId);

            }
            else {
                databaseFunctions.ChangeQuantity(cartItemId, "-");
            }
                
            return RedirectToAction("Index");
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
                return View("Guest");
            }
        }
    }
}
