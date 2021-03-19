using Application.Controllers;
using Application.Requests.QuoteRequest;
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
    public class VendorCatalogueControllerTests
    {
        private VendorCatalogueController Controller(MockContainer c) => new VendorCatalogueController(c.AuthenticationManager.Object, c.VendorItemManager.Object, c.QuoteManager.Object, c.QuoteResponseManager.Object);

        [TestMethod]
        public async Task Index_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            //Act
            var res = await controller.Index();

            //Assert
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public async Task VendorCatalogueSearch_Null()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            //Act
            RedirectToActionResult res = await controller.VendorCatalogueSearch(null) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.ActionName, "Index");
            Assert.AreEqual(res.ControllerName, "Error");
        }

        [TestMethod]
        public async Task VendorCatalogueSearch_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            //Act
            ActionResult res = await controller.VendorCatalogueSearch("test") as ActionResult;

            //Assert
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public async Task RequestVendorQuote_Null()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            //Act
            JsonResult res = await controller.RequestVendorQuote(null) as JsonResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Value, "error");
        }

        [TestMethod]
        public async Task RequestVendorQuote_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            c.VendorItemManager.Setup(s => s.LoadVendorItem(It.IsAny<int>())).ReturnsAsync(new VendorItemDTO() { ItemID = 1, ItemName = "test" });

            //Act
            JsonResult res = await controller.RequestVendorQuote(new VendorQuoteRequest() { VendorItemID = 2, Quantity = 1 }) as JsonResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }
    }
}
