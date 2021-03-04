using Application.Controllers;
using Application.Requests.Vendor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityFramework.DbEntities;
using Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ControllerTests
{
    [TestClass]
    public class QuoteResponseControllerTests
    {
        private QuoteResponseController Controller(MockContainer c) => new QuoteResponseController(c.AuthenticationManager.Object, c.QuoteManager.Object, c.QuoteResponseManager.Object, c.MVCManager.Object);

        [TestMethod]
        public async Task QuoteResponseModal_NullRequest_Fail()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            // Act
            RedirectToActionResult res = await controller.QuoteResponseModal(null) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.ActionName, "Index");
            Assert.AreEqual(res.ControllerName, "Error");
        }

        [TestMethod]
        public async Task QuoteResponseModal_NullRequest_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);
            int quoteID = 32;

            c.QuoteManager.Setup(s => s.GetQuote(It.IsAny<int>())).ReturnsAsync(new QuoteDTO() { QuoteID = quoteID });
            c.MVCManager.Setup(s => s.RenderViewToString(It.IsAny<Controller>(), It.IsAny<QuoteDTO>(), null, true)).ReturnsAsync("This is a partial response");

            // Act
            JsonResult res = await controller.QuoteResponseModal(new BaseQuoteRequest() { QuoteID = quoteID }) as JsonResult;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }

        [TestMethod]
        public async Task Create_NullRequest_Fail()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            // Act
            JsonResult res = await controller.Create(null) as JsonResult;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsFalse(res.ExtractValue<bool>("success"));
        }

        [TestMethod]
        public async Task Create_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);
            c.QuoteResponseManager.Setup(s => s.Create(It.IsAny<QuoteResponse>())).ReturnsAsync(true);

            // Act
            JsonResult res = await controller.Create(new QuoteResponse() { 
                ReponseText = "resposne text",
                Quote = 24
            }) as JsonResult;

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }
    }
}
