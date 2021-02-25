using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.EntityFramework.DbEntities;
using Services.Models.DTOs;
using Services.VendorManagement.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class VendorManagerTests
    {
        private VendorManager Manager(MockContainer c) => new VendorManager(c.GenericQuerier.Object); 

        [TestMethod]
        public async Task GetVendor_Success()
        {
            var c = new MockContainer();
            var manager = Manager(c);
            int vendorID = 1; 

            c.GenericQuerier.Setup(s => s.Load(It.IsAny<Expression<Func<Vendor, VendorDTO>>>(), It.IsAny<Expression<Func<Vendor, bool>>>())).Returns(new List<VendorDTO>() {
                new VendorDTO()
                {
                    VendorID = vendorID,
                    VendorName = "Test vendor"
                }
            }.GetMockQueryable());

            // Act
            var res = await manager.GetVendor(vendorID);

            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.VendorID, vendorID);
        }
    }
}
