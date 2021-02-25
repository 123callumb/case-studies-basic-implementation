using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityFramework.DbEntities;
using Services.QuoteResponseManagement.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class QuoteResponseManagerTests
    {
        private QuoteResponseManager Manager(MockContainer c)
        {
            return new QuoteResponseManager(c.GenericRepo.Object);
        }

        [TestMethod]
        public async Task Create_Success()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);

            c.GenericRepo.Setup(s => s.Add(It.IsAny<QuoteResponse>())).ReturnsAsync(1);

            // Act
            var res = await manager.Create(new QuoteResponse() { QuoteResponseId = 1 });

            // Assert
            Assert.IsTrue(res); 
        }

        [TestMethod]
        public async Task Create_Fail()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);

            c.GenericRepo.Setup(s => s.Add(It.IsAny<QuoteResponse>())).ReturnsAsync(0);

            // Act
            var res = await manager.Create(new QuoteResponse() { QuoteResponseId = 1 });

            // Assert
            Assert.IsFalse(res);
        }
    }
}
