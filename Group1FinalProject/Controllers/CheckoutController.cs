using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Group1FinalProject.Models;
using Group1FinalProject.Helpers;

namespace Group1FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IConfiguration Configuration;

        public CheckoutController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index(CheckoutModel checkoutModel)
        {
            return View(checkoutModel);
        }

        public ActionResult PurchaseInfo()
        {
            return View("PurchaseInfo");
        }

        [HttpPost]
        public ActionResult PurchaseInfo(CheckoutModel checkoutModel)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            var userID = int.Parse(Request.Cookies["user"]);
            SignUpViewModel signUpViewModel = databaseFunctions.GetCustomerByID(userID);
            List<CartItemModel> list = databaseFunctions.GetCustomerCartItems(signUpViewModel);

            checkoutModel.CartItems = list;
            checkoutModel.CartId = signUpViewModel.Id;

            ValidationHelper validationHelper = new ValidationHelper();
            checkoutModel = validationHelper.ValidatePayment(checkoutModel);

            if (checkoutModel.Success == true)
            {
                return View("~/Views/Checkout/Index.cshtml", checkoutModel);
            }

            return View(checkoutModel);
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
