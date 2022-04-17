using Microsoft.AspNetCore.Mvc;
using Group1FinalProject.Models;
using Group1FinalProject.Helpers;
namespace Group1FinalProject.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            SignInViewModel signInViewModel = new SignInViewModel();
            return View(signInViewModel);
        }



        [HttpPost]
        //[ActionName("SignIn")]

        public ActionResult Index(SignInViewModel signInViewModel)
        {
            ValidationHelper validationHelper = new ValidationHelper();
            signInViewModel = validationHelper.validateSignIn(signInViewModel);
           
            return View(signInViewModel);
        }


        public ActionResult SignUp()
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            return View(signUpViewModel);
            
        }
        
        [HttpPost]

        public ActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            ValidationHelper validationHelper = new ValidationHelper();
            signUpViewModel = validationHelper.validateSignUp(signUpViewModel);
            
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
