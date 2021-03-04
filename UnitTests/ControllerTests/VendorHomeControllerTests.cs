using Application.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.ControllerTests
{
    [TestClass]
    public class VendorHomeControllerTests
    {
        private VendorHomeController Controller(MockContainer c) => new VendorHomeController(c.AuthenticationManager.Object, c.QuoteManager.Object, c.UserManager.Object);

        [TestMethod]
        public async Task Index_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            c.AuthenticationManager.Setup(s => s.GetSessionUser(It.IsAny<ISession>())).ReturnsAsync(new ExternalUserDTO() { UserID = 290 });
            c.UserManager.Setup(s => s.GetExternalUser(It.IsAny<int>())).ReturnsAsync(new ExternalUserDTO() { VendorID = 1 });
            c.QuoteManager.Setup(s => s.GetVendorQuotes(It.IsAny<int>())).ReturnsAsync(new List<QuoteOverviewDTO>());

            // Act
            var res = await controller.Index();

            // Assert
            Assert.IsNotNull(res);
        }
    }
}
