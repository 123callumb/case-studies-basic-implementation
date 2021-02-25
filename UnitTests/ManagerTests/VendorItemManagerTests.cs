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
            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<VendorItem, VendorItemDTO>>>(), It.IsAny<Expression<Func<VendorItem, bool>>>())).Returns(new List<VendorItemDTO>() {
                new VendorItemDTO()
                {
                    ItemID = 69
                }
            }.GetMockQueryable());

        }
    }
}
