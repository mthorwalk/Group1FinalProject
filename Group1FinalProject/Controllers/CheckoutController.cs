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

        [HttpPost]
        public IActionResult Index(double shipping, string cardNumber, string nameOnCard, string expirationDate)
        {
            DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
            var userID = int.Parse(Request.Cookies["user"]);
            SignUpViewModel signUpViewModel = databaseFunctions.GetCustomerByID(userID);
            List<CartItemModel> list = databaseFunctions.GetCustomerCartItems(signUpViewModel);

            checkout.CartItems = list;
            checkout.CartId = signUpViewModel.Id;
            checkout.Shipping = shipping;
            checkout.CardNumber = cardNumber;
            checkout.NameOnCard = nameOnCard;
            checkout.ExpirationDate = expirationDate;

            ValidationHelper validationHelper = new ValidationHelper();
            checkout = validationHelper.ValidatePayment(checkout);
            if (checkout.Success == true)
            {
                return View("Index", checkout);
            }

            return View("PurchaseInfo");
        }

        public IActionResult PurchaseInfo()
        {
            return View("PurchaseInfo");
        }

        public IActionResult Purchase()
        {
            return View("Purchase");
        }
    }
}
