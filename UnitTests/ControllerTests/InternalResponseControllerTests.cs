using Application.Controllers;
using Application.Requests.Vendor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ControllerTests
{
    [TestClass]
    public class InternalResponseControllerTests
    {
        private InternalResponseController Controller(MockContainer c) => new InternalResponseController(c.AuthenticationManager.Object, c.QuoteManager.Object, c.QuoteResponseManager.Object, c.MVCManager.Object);

        [TestMethod]
        public async Task VendorQuotes_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            c.AuthenticationManager.Setup(s => s.GetSessionUser(It.IsAny<ISession>())).ReturnsAsync(new InternalUserDTO() { UserID = 290 });
            c.QuoteManager.Setup(s => s.GetVendorQuotes(It.IsAny<int>())).ReturnsAsync(new List<QuoteOverviewDTO>());

            var res = await controller.VendorQuotes();

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public async Task QuoteResponderModal_NullRequest()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            //Act
            RedirectToActionResult res = await controller.QuoteResponderModal(null) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.ActionName, "Index");
            Assert.AreEqual(res.ControllerName, "Error");
        }
        
        [TestMethod]
        public async Task QuoteResponderModal_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);
            int quoteID = 1;

            //Act
            JsonResult res = await controller.QuoteResponderModal(new BaseQuoteRequest() { QuoteID = quoteID }) as JsonResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }

        [TestMethod]
        public async Task Respond_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);
            var quoteID = 1;

            //Act
            JsonResult res = await controller.QuoteResponderModal(new BaseQuoteRequest() { QuoteID = quoteID }) as JsonResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }
    }
}
