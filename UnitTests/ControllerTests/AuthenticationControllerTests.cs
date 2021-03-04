using Application.Controllers;
using Application.Requests.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ControllerTests
{
    [TestClass]
    public class AuthenticationControllerTests
    {
        private AuthenticationController Controller(MockContainer c)
        {
            var ctr = new AuthenticationController(c.AuthenticationManager.Object);
            var httpCtx = new Mock<HttpContext>();
            var session = new Mock<ISession>();
            httpCtx.SetupGet(s => s.Session).Returns(session.Object);
            ctr.ControllerContext = new ControllerContext
            {
                HttpContext = httpCtx.Object
            };

            return ctr;
        }

        [TestMethod]
        public async Task AuthenticateInternalUser_NullRequest_Fail()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            // Act
            var res = await controller.AuthenticateInternalUser(null);

            // Assert
            Assert.IsNotNull(res);
            Assert.IsFalse(res.ExtractValue<bool>("success"));
        }

        [TestMethod]
        public async Task AuthenticateInternalUser_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            c.AuthenticationManager.Setup(s => s.AuthenticateInternalUser(It.IsAny<ISession>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            // Act
            var res = await controller.AuthenticateInternalUser(new UserLogonRequest()
            {
                Email = "cb@abc.com",
                Password = "password"
            });

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }

        [TestMethod]
        public async Task AuthenticateExternalUser_NullRequest_Fail()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            // Act
            var res = await controller.AuthenticateExternalUser(null);

            // Assert
            Assert.IsNotNull(res);
            Assert.IsFalse(res.ExtractValue<bool>("success"));
        }

        [TestMethod]
        public async Task AuthenticateExternalUser_Success()
        {
            var c = new MockContainer();
            var controller = Controller(c);

            c.AuthenticationManager.Setup(s => s.AuthenticateExternalUser(It.IsAny<ISession>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            // Act
            var res = await controller.AuthenticateExternalUser(new UserLogonRequest()
            {
                Email = "fr@pe.com",
                Password = "password"
            });

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.ExtractValue<bool>("success"));
        }
    }
}
