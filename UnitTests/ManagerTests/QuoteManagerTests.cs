using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityFramework.DbEntities;
using Services.Models.DTOs;
using Services.QuoteManagement.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class QuoteManagerTests
    {
        private QuoteManager Manager(MockContainer c)
        {
            return new QuoteManager(c.GenericQuerier.Object, c.GenericRepo.Object);
        }

        [TestMethod]
        public async Task GetQuote_Success()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);
            int quoteID = 34;

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<Quote, QuoteDTO>>>(), It.IsAny<Expression<Func<Quote, bool>>>()))
                .Returns(new List<QuoteDTO>() {
                    new QuoteDTO() { QuoteID = quoteID }
                }.GetMockQueryable());

            // Act
            var result = await manager.GetQuote(quoteID);

            // Assert
            Assert.AreEqual(result.QuoteID, quoteID);
        }

        [TestMethod]
        public async Task GetVendorQuote_Success()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);
            int quoteID = 34;

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<Quote, QuoteOverviewDTO>>>(), It.IsAny<Expression<Func<Quote, bool>>>()))
                .Returns(new List<QuoteOverviewDTO>() {
                    new QuoteOverviewDTO() { QuoteID = quoteID }
                }.GetMockQueryable());

            // Act
            var result = await manager.GetVendorQuotes(21);

            // Assert
            Assert.AreEqual(result.FirstOrDefault().QuoteID, quoteID);
        }

        [TestMethod]
        public async Task GetQuotes_Success()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);
            int quoteID = 34;

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<Quote, QuoteOverviewDTO>>>(), It.IsAny<Expression<Func<Quote, bool>>>()))
                .Returns(new List<QuoteOverviewDTO>() {
                    new QuoteOverviewDTO() { QuoteID = quoteID }
                }.GetMockQueryable());

            // Act
            var result = await manager.GetQuotes();

            // Assert
            Assert.AreEqual(result.FirstOrDefault().QuoteID, quoteID);
        }

        [TestMethod]
        public async Task RequestQuote_Success()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);

            c.GenericRepo.Setup(s => s.Add(It.IsAny<Quote>())).ReturnsAsync(1);

            // Act
            var res = await manager.RequestQuote(new VendorItemDTO() { ItemID = 21 }, 34);

            // Assert
            Assert.IsTrue(res);
        }
        
        [TestMethod]
        public async Task RequestQuote_Fail()
        {
            // Arrange
            var c = new MockContainer();
            var manager = Manager(c);

            c.GenericRepo.Setup(s => s.Add(It.IsAny<Quote>())).ReturnsAsync(0);

            // Act
            var res = await manager.RequestQuote(new VendorItemDTO() { ItemID = 21 }, 34);

            // Assert
            Assert.IsFalse(res);
        }
    }
}
