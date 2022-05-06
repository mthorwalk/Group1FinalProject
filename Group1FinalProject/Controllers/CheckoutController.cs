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

        public IActionResult Index()
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            var userID = int.Parse(Request.Cookies["user"]);
            SignUpViewModel signUpViewModel = databaseFunctions.GetCustomerByID(userID);
            List<CartItemModel> list = databaseFunctions.GetCustomerCartItems(signUpViewModel);

            checkout.CartItems = list;
            checkout.CartId = signUpViewModel.Id;
            return View("Index", checkout);
        }

        public IActionResult Purchase()
        {
            return View("Purchase");
        }

        public void Summary(double shippingCost)
        {

            checkout.Shipping = shippingCost;
        }
    }
}
