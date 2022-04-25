using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Group1FinalProject.Models;
using System.Diagnostics;
using Microsoft.Build.Framework;

namespace Group1FinalProjectUnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeIndexView()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void HomePrivacyView()
        {
            var controller = new HomeController();

            var result = controller.Privacy() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Privacy", result.ViewName);
        }
        // [TestMethod]
        // public void HomeErrorView()
        // {
            // var controller = new HomeController();

            // var result = controller.Error() as ViewResult;
            // Assert.IsNotNull(result);
            //Assert.AreEqual("Error", result.ViewName);
        // }
    }
}
