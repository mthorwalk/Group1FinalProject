using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Group1FinalProjectUnitTests
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void AccountIndexView()
        {
            var controller = new AccountController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void AccountSignUpView()
        {
            var controller = new AccountController();

            var result = controller.SignUp() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("SignUp", result.ViewName);
        }
    }
}
