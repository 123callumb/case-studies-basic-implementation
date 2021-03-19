using Application.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Models.DTOs;
using Services.Models.Enums;
using System.Threading.Tasks;

namespace UnitTests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController Controller(MockContainer c) => new HomeController(c.AuthenticationManager.Object);

        [TestMethod]
        public async Task Index_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            c.AuthenticationManager.Setup(s => s.GetSessionUser(It.IsAny<ISession>())).ReturnsAsync(new InternalUserDTO() { UserID = 290, UserType = UserTypeEnum.INTERNAL});
            
            //Act
            var res = await controller.Index();

            //Assert
            Assert.IsNotNull(res);
        }
    }
}
