using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group1FinalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Group1FinalProjectUnitTests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new ProductController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}