using Group1FinalProject.Models;
using System.Reflection;
namespace Group1FinalProject.Helpers

{
    public class ValidationHelper
    {

        public SignInViewModel validateSignIn(SignInViewModel signInViewModel)
    {
        signInViewModel.Success = false;
        signInViewModel.ErrorMessage = "";
        if (string.IsNullOrEmpty(signInViewModel.Email))
        {
            signInViewModel.ErrorMessage += "Email is Empty";
        } else if (!(signInViewModel.Email.Contains ("@") && signInViewModel.Email.Contains(".com") && signInViewModel.Email.Length > 7))
            {
                signInViewModel.ErrorMessage += "Email Format is not correct";
            }
            if (string.IsNullOrEmpty(signInViewModel.Password))
            {
                signInViewModel.ErrorMessage += " and Password is Empty";
            } else if (!(signInViewModel.Password.Length >= 8))
            {
                signInViewModel.ErrorMessage += " and Password is not long enough";
            }
            
            if (string.IsNullOrEmpty(signInViewModel.ErrorMessage))
            {
                signInViewModel.Success = true;
            }
        return signInViewModel;
    }


        public SignUpViewModel validateSignUp(SignUpViewModel signUpViewModel)
        {
            signUpViewModel.Success = false;
            signUpViewModel.ErrorMessage = "";
            if (string.IsNullOrEmpty (signUpViewModel.FirstName))
            {
                signUpViewModel.ErrorMessage += "First Name is Empty";
            }

            if (string.IsNullOrEmpty(signUpViewModel.LastName))
            {
                signUpViewModel.ErrorMessage += "Last Name is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Email))
            {
                signUpViewModel.ErrorMessage += "Email is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.PhoneNumber))
            {
                signUpViewModel.ErrorMessage += "Phone Number is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Address))
            {
                signUpViewModel.ErrorMessage += "Address is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.City))
            {
                signUpViewModel.ErrorMessage += "City is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.State))
            {
                signUpViewModel.ErrorMessage += "State is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Zip))
            {
                signUpViewModel.ErrorMessage += "Zip is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Country))
            {
                signUpViewModel.ErrorMessage += "Country is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Password))
            {
                signUpViewModel.ErrorMessage += "Password is Empty";
            }
            if (string.IsNullOrEmpty(signUpViewModel.ErrorMessage))
            {
                signUpViewModel.Success = true;
            }

            return signUpViewModel;
        }   


    }
}
