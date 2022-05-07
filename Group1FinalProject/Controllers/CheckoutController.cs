using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Group1FinalProject.Models;
using Group1FinalProject.Helpers;

namespace Group1FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
        private CheckoutModel checkout = new CheckoutModel();

        private readonly IConfiguration Configuration;

        public CheckoutController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index(double shipping)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            var userID = int.Parse(Request.Cookies["user"]);
            SignUpViewModel signUpViewModel = databaseFunctions.GetCustomerByID(userID);
            List<CartItemModel> list = databaseFunctions.GetCustomerCartItems(signUpViewModel);

            checkout.CartItems = list;
            checkout.CartId = signUpViewModel.Id;
            checkout.Shipping = shipping;
            return View("Index", checkout);
        }

        public IActionResult PurchaseInfo()
        {
            return View("PurchaseInfo");
        }

        public IActionResult Purchase(double shipping)
        {
            var userID = int.Parse(Request.Cookies["user"]);
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            SignUpViewModel user = databaseFunctions.GetCustomerByID(userID);
            SignUpViewModel signUpViewModel = databaseFunctions.GetCustomerByID(userID);
            List<CartItemModel> list = databaseFunctions.GetCustomerCartItems(signUpViewModel);
            checkout.CartItems = list;
            checkout.CartId = signUpViewModel.Id;
            checkout.Shipping = shipping;
            databaseFunctions.emailConfirmation(user, checkout);
            return View("Purchase");
        }
    }
}
