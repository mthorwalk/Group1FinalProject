using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Group1FinalProjectUnitTests
{
    [TestClass]
    public class CartControllerTest
    {
        [TestMethod]
        public void CartIndexView()
        {
            var controller = new CartController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
