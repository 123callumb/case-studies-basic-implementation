using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.AuthenticationManagement.Implementation;
using Services.AuthenticationManagement.Models;
using Services.EntityFramework.DbEntities;
using Services.HashManagement.Implementation;
using Services.Models.Abstract;
using Services.Models.DTOs;
using Services.Models.Enums;
using Services.SessionManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
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
            string password = "password";

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<User, InternalUserDTO>>>(), It.IsAny <Expression<Func<User, bool>>>())).Returns(new List<InternalUserDTO>().GetMockQueryable());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => manager.AuthenticateInternalUser(session.Object, "test@abc.com", password));
        }

        [TestMethod]
        public async Task AuthenticateInternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);
            string userEmail = "cb@abc.com";
            string password = "password";
            string hashedPAssword = password.Hash();

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<User, InternalUserDTO>>>(), It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<InternalUserDTO>() { 
                new InternalUserDTO(){ 
                    Email = userEmail,
                    PasswordHash = hashedPAssword
                }
            }.GetMockQueryable());

            // Act 
            await manager.AuthenticateInternalUser(session.Object, userEmail, password);
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
            await Assert.ThrowsExceptionAsync<Exception>(() => manager.AuthenticateExternalUser(session.Object, "test@abc.com", "password"));
        }

        [TestMethod]
        public async Task AuthenticateExternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);
            string userEmail = "cb@abc.com";
            string password = "password";
            string hashedPAssword = password.Hash();

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorUser, ExternalUserDTO>>>(), It.IsAny<Expression<Func<VendorUser, bool>>>())).Returns(new List<ExternalUserDTO>() { 
                new ExternalUserDTO(){ 
                    Email = userEmail,
                    PasswordHash = hashedPAssword
                }
            }.GetMockQueryable());

            // Act 
            await manager.AuthenticateExternalUser(session.Object, userEmail, password);
        }

        [TestMethod]
        public async Task GetSessionUser_SessionNull_ReturnsNull()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var manager = Manager(c);
            byte[] userSession = { };
            session.Setup(s => s.TryGetValue(SessionHelper.UserSessionKey, out userSession)).Returns(false);

            // Act
            var res = await manager.GetSessionUser(session.Object);

            // Assert
            Assert.IsNull(res);
        }

        [TestMethod]
        public async Task GetSessionUser_AnyUserType_ReturnsNull()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var sessionObj = session.Object;
            var manager = Manager(c);
            int userID = 290;
            byte[] userSession = JsonSerializer.SerializeToUtf8Bytes(new AuthenticatedSession(userID, UserTypeEnum.ANY));
            session.Setup(s => s.TryGetValue(SessionHelper.UserSessionKey, out userSession)).Returns(true);
            
            // Act
            var res = await manager.GetSessionUser(sessionObj);

            // Assert
            Assert.IsNull(res);
        }

        [TestMethod]
        public async Task GetSessionUser_InternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var sessionObj = session.Object;
            var manager = Manager(c);
            int userID = 290;
            byte[] userSession = JsonSerializer.SerializeToUtf8Bytes(new AuthenticatedSession(userID, UserTypeEnum.INTERNAL));
            session.Setup(s => s.TryGetValue(SessionHelper.UserSessionKey, out userSession)).Returns(true);
            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<User, InternalUserDTO>>>(), It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<InternalUserDTO>()
            {
                new InternalUserDTO()
                {
                    UserType = UserTypeEnum.INTERNAL,
                    UserID = userID
                }
            }.GetMockQueryable());
            // Act
            var res = await manager.GetSessionUser(sessionObj);

            // Assert
            Assert.AreEqual(res.UserType, UserTypeEnum.INTERNAL);
        }

        [TestMethod]
        public async Task GetSessionUser_ExternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var session = new Mock<ISession>();
            var sessionObj = session.Object;
            var manager = Manager(c);
            int userID = 290;
            byte[] userSession = JsonSerializer.SerializeToUtf8Bytes(new AuthenticatedSession(userID, UserTypeEnum.EXTERNAL));
            session.Setup(s => s.TryGetValue(SessionHelper.UserSessionKey, out userSession)).Returns(true);
            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorUser, ExternalUserDTO>>>(), It.IsAny<Expression<Func<VendorUser, bool>>>())).Returns(new List<ExternalUserDTO>()
            {
                new ExternalUserDTO()
                {
                    UserType = UserTypeEnum.EXTERNAL,
                    UserID = userID
                }
            }.GetMockQueryable());

            // Act
            var res = await manager.GetSessionUser(sessionObj);

            // Assert
            Assert.AreEqual(res.UserType, UserTypeEnum.EXTERNAL);
        }
    }
}
