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
    public class CheepsControllerTest
    {
        [TestMethod]
        public void TestCreateViewResult()
        {
            //assert page returns ViewResult
            CheepsController controller = new CheepsController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
