using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Group1FinalProjectUnitTests
{
    [TestClass]
    public class CheckoutControllerTest
    {
        [TestMethod]
        public void CheckoutIndexView()
        {
            var controller = new CheckoutController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void CheckoutPurchaseView()
        {
            var controller = new CheckoutController();

            var result = controller.Purchase() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Purchase", result.ViewName);
        }
    }
}
