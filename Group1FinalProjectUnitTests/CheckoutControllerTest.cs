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
            CheckoutController controller = new CheckoutController();

            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void CheckoutPurchaseView()
        {
            CheckoutController controller = new CheckoutController();

            ViewResult result = controller.Purchase() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Purchase", result.ViewName);
        }
    }
}
