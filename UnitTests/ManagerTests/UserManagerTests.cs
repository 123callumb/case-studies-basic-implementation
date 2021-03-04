using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityFramework.DbEntities;
using Services.Models.DTOs;
using Services.UserManagement.Implementation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class UserManagerTests
    {
        private UserManager Manager(MockContainer c) => new UserManager(c.GenericQuerier.Object);

        [TestMethod]
        public async Task GetExternalUser_UserDoesntExist_ThrowsException()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);
            int userID = 2;

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorUser, ExternalUserDTO>>>(), It.IsAny<Expression<Func<VendorUser, bool>>>())).Returns(new List<ExternalUserDTO>().GetMockQueryable());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => manager.GetExternalUser(userID));
        }

        [TestMethod]
        public async Task GetExternalUser_Success()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);
            int userID = 2;

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorUser, ExternalUserDTO>>>(), It.IsAny<Expression<Func<VendorUser, bool>>>())).Returns(new List<ExternalUserDTO>()
            {
                new ExternalUserDTO()
                {
                    UserID = userID
                }
            }.GetMockQueryable());

            // Act
            var res = await manager.GetExternalUser(userID);

            // Assert
            Assert.AreEqual(res.UserID, userID);
        }
    }
}
