using Group1FinalProject.Models;
using System;
using System.Text.RegularExpressions;
using System.Reflection;
namespace Group1FinalProject.Helpers

{
    public class ValidationHelper
    {
        public const string PhoneFormat = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public const string EmailFormat = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string CardNumberFormat = @"[0-9]{15,16}";
        public const string ExpirationDateFormat = @"(0[1-9]|10|11|12)/20[0-9]{2}$";

        public SignInViewModel validateSignIn(SignInViewModel signInViewModel)
        {
            signInViewModel.Success = false;
            signInViewModel.ErrorMessage = "";

            if (string.IsNullOrEmpty(signInViewModel.Email))
            {
                signInViewModel.ErrorMessage += "Email is Empty";
            } else if (!Regex.IsMatch(signInViewModel.Email, EmailFormat))
            {
                signInViewModel.ErrorMessage += "Email is in wrong format,";
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
                signUpViewModel.ErrorMessage += "Last Name is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Email))
            {
                signUpViewModel.ErrorMessage += "Email is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.PhoneNumber))
            {
                signUpViewModel.ErrorMessage += "Phone Number is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Address))
            {
                signUpViewModel.ErrorMessage += "Address is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.City))
            {
                signUpViewModel.ErrorMessage += "City is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.State))
            {
                signUpViewModel.ErrorMessage += "State is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Zip))
            {
                signUpViewModel.ErrorMessage += "Zip is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Country))
            {
                signUpViewModel.ErrorMessage += "Country is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Password))
            {
                signUpViewModel.ErrorMessage += "Password is Empty,";
            }
            if (string.IsNullOrEmpty(signUpViewModel.Address2))
            {
                signUpViewModel.Address2 = "n/a";
            }

            if (!string.IsNullOrEmpty(signUpViewModel.PhoneNumber))
            {
                if (signUpViewModel.PhoneNumber.Length < 7 || (!Regex.IsMatch(signUpViewModel.PhoneNumber, PhoneFormat)))
                {
                    signUpViewModel.ErrorMessage += "Phone Number is in wrong format,";

                }
            }
            if (!string.IsNullOrEmpty(signUpViewModel.Email))
            {
                if (!Regex.IsMatch(signUpViewModel.Email,EmailFormat))
                {
                    signUpViewModel.ErrorMessage += "Email is in wrong format,";
                }
            }

            if (string.IsNullOrEmpty(signUpViewModel.ErrorMessage))
            {
                signUpViewModel.Success = true;
            }

            return signUpViewModel;
        }

        public CheckoutModel ValidatePayment(CheckoutModel checkoutModel)
        {
            checkoutModel.Success = false;
            checkoutModel.ErrorMessage = "";

            if (string.IsNullOrEmpty(checkoutModel.CardNumber))
            {
                checkoutModel.ErrorMessage += "Card number is empty. ";
            }
            else if (!Regex.IsMatch(checkoutModel.CardNumber, CardNumberFormat))
            {
                checkoutModel.ErrorMessage += "Card number is in wrong format. ";
            }

            if (string.IsNullOrEmpty(checkoutModel.NameOnCard))
            {
                checkoutModel.ErrorMessage += "Name on card is empty. ";
            }
            else if (!(checkoutModel.NameOnCard.Length <= 60))
            {
                checkoutModel.ErrorMessage += "Name on card is too long. ";
            }

            if (string.IsNullOrEmpty(checkoutModel.ExpirationDate))
            {
                checkoutModel.ErrorMessage += "Expiration date is empty. ";
            }
            else if (!Regex.IsMatch(checkoutModel.ExpirationDate, ExpirationDateFormat))
            {
                checkoutModel.ErrorMessage += "Expiration date is in wrong format. ";
            }

            if (string.IsNullOrEmpty(checkoutModel.ErrorMessage))
            {
                checkoutModel.Success = true;
            }

            return checkoutModel;
        }

    }
}

