using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chirper;
using Chirper.Controllers;

namespace Chirper.Tests.Controllers
{
    [TestClass]
    public class FriendsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //assert page returns ViewResult
            FriendsController controller = new FriendsController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCheepsViewResult()
        {
            //assert page returns ViewResult
            FriendsController controller = new FriendsController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCheepsRedirectWithNullUserId()
        {
            //assert Cheeps page redirects to error if userId is null
            FriendsController controller = new FriendsController();
            var result = (ViewResult)controller.Cheeps(null);
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void TestCheepsRedirectWithEmptyUserId()
        {
            //assert Cheeps page redirects to error if userId is empty
            FriendsController controller = new FriendsController();
            var result = (ViewResult)controller.Cheeps("");
            Assert.AreEqual("Error", result.ViewName);
        }
    }
}
