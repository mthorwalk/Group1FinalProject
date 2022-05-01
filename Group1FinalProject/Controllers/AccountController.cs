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
                DatabaseFunctions databaseFunctions = new DatabaseFunctions(Configuration);
                SignUpViewModel signUpViewModel = databaseFunctions.GetCustomer(signInViewModel);
            }

            return View(signInViewModel);
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
                DatabaseFunctions databaseFunctions = new DatabaseFunctions(Configuration);
                databaseFunctions.AddCustomer(signUpViewModel);
                
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
