using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.AuthenticationManagement.Implementation;
using Services.AuthenticationManagement.Models;
using Services.EntityFramework.DbEntities;
using Services.Models.Abstract;
using Services.Models.DTOs;
using Services.SessionManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class AuthenticationManagerTests
    {
        private AuthenticationManager Manager(MockContainer c) => new AuthenticationManager(c.GenericQuerier.Object);

        [TestMethod]
        public async Task AuthenticateInternalUser_UserNotFound_ThrowsException()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<User, InternalUserDTO>>>(), It.IsAny <Expression<Func<User, bool>>>())).Returns(new List<InternalUserDTO>().GetMockQueryable());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => manager.AuthenticateInternalUser(session.Object, "test@abc.com"));
        }

        [TestMethod]
        public async Task AuthenticateInternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);
            string userEmail = "cb@abc.com";

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<User, InternalUserDTO>>>(), It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<InternalUserDTO>() { 
                new InternalUserDTO(){ Email = userEmail }
            }.GetMockQueryable());

            // Act 
            await manager.AuthenticateInternalUser(session.Object, userEmail);
        }

        [TestMethod]
        public async Task AuthenticateExternalUser_UserNotFound_ThrowsException()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorUser, ExternalUserDTO>>>(), It.IsAny<Expression<Func<VendorUser, bool>>>())).Returns(new List<ExternalUserDTO>().GetMockQueryable());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => manager.AuthenticateExternalUser(session.Object, "test@abc.com"));
        }

        [TestMethod]
        public async Task AuthenticateExternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);
            string userEmail = "cb@abc.com";

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorUser, ExternalUserDTO>>>(), It.IsAny<Expression<Func<VendorUser, bool>>>())).Returns(new List<ExternalUserDTO>() { 
                new ExternalUserDTO(){ Email = userEmail }
            }.GetMockQueryable());

            // Act 
            await manager.AuthenticateExternalUser(session.Object, userEmail);
        }

        [TestMethod]
        public async Task GetSessionUser_SessionNull_ReturnsNull()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);

            session.Setup(s => s.GetUserSession()).Returns(null as AuthenticatedSession);

            // Act
            var res = await manager.GetSessionUser(session.Object);

            // Assert
            Assert.IsNull(res);
        }
    }
}
