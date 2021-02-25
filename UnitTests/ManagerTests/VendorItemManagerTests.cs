using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityFramework.DbEntities;
using Services.Models.DTOs;
using Services.VendorItemManagement.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class VendorItemManagerTests
    {
        private VendorItemManager Manager(MockContainer c) => new VendorItemManager(c.GenericQuerier.Object);

        [TestMethod]
        public async Task LoadVendorItems_Success()
        {
            var c = new MockContainer();
            var manager = Manager(c);
            int vendorItemID = 69;
            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorItem, VendorItemDTO>>>(), It.IsAny<Expression<Func<VendorItem, bool>>>())).Returns(new List<VendorItemDTO>() {
                new VendorItemDTO()
                {
                    ItemID = vendorItemID
                }
            }.GetMockQueryable());


            // Act
            var res = await manager.LoadVendorItems();

            // Assert
            Assert.AreEqual(res.FirstOrDefault().ItemID, vendorItemID);
        }

        [TestMethod]
        public async Task LoadVendorItem_Success()
        {
            var c = new MockContainer();
            var manager = Manager(c);
            int vendorItemID = 69;
            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorItem, VendorItemDTO>>>(), It.IsAny<Expression<Func<VendorItem, bool>>>())).Returns(new List<VendorItemDTO>() {
                new VendorItemDTO()
                {
                    ItemID = vendorItemID
                }
            }.GetMockQueryable());


            // Act
            var res = await manager.LoadVendorItem(vendorItemID);

            // Assert
            Assert.AreEqual(res.ItemID, vendorItemID);
        }

        [TestMethod]
        public async Task SearchVendorItems_Success()
        {
            var c = new MockContainer();
            var manager = Manager(c);
            int vendorItemID = 69;
            string searchVal = "test";

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorItem, VendorItemDTO>>>(), It.IsAny<Expression<Func<VendorItem, bool>>>())).Returns(new List<VendorItemDTO>() {
                new VendorItemDTO()
                {
                    ItemID = vendorItemID,
                    ItemName = searchVal
                }
            }.GetMockQueryable());


            // Act
            var res = await manager.SearchVendorItems(searchVal);

            // Assert
            Assert.AreEqual(res.FirstOrDefault().ItemID, vendorItemID);
            Assert.AreEqual(res.FirstOrDefault().ItemName, searchVal);
        }
    }
}
