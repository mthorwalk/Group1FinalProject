using Microsoft.AspNetCore.Mvc;
using Group1FinalProject.Models;
using Group1FinalProject.Helpers;


namespace Group1FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration Configuration;

        public AccountController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public ActionResult Index()
        {
            SignInViewModel signInViewModel = new SignInViewModel();
            return View("Index", signInViewModel);
        }

        [HttpPost]
        //[ActionName("SignIn")]
        public ActionResult Index(SignInViewModel signInViewModel)
        {
            ValidationHelper validationHelper = new ValidationHelper();
            signInViewModel = validationHelper.validateSignIn(signInViewModel);

            if (signInViewModel.Success == true)
            {
                DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
                SignUpViewModel signUpViewModel = databaseFunctions.GetCustomer(signInViewModel);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Append("user",signUpViewModel.Id.ToString(),options);
                
            }

            return View(signInViewModel);
        }

        public IActionResult SignOut()
        {
            if (Request.Cookies["user"] != null)
            {
                Response.Cookies.Delete("user");
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult SignUp()
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            return View("SignUp", signUpViewModel);
        }
        
        [HttpPost]

        public ActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            ValidationHelper validationHelper = new ValidationHelper();
            signUpViewModel = validationHelper.validateSignUp(signUpViewModel);
            if (signUpViewModel.Success == true)
            {
                DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
                signUpViewModel = databaseFunctions.AddCustomer(signUpViewModel);
                if (signUpViewModel.Success == true)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Append("user", signUpViewModel.Id.ToString(), options);
                }
                
            }
            return View(signUpViewModel);
        }


        [HttpPost]
        [ActionName("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(SignInViewModel signInViewModel)
        {

            return View(signInViewModel);
        }


    }
}
