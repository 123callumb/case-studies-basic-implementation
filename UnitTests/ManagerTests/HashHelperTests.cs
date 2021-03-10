using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.HashManagement.Implementation;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class HashHelperTests
    {
        [TestMethod]
        public void TestHashComparison_SameHash()
        {
            // Act
            string valueToHash = "This is a password";
            string hashedValue = valueToHash.Hash();
            bool comparison = HashHelper.CompareHashToValue(hashedValue, valueToHash);

            // Assert
            Assert.IsTrue(comparison);
        }

        [TestMethod]
        public void TestHashComparison_WrongHash()
        {
            // Act
            string valueToHash = "This is a password";
            string valueHashed = "This is not the same password".Hash();
            bool comparison = HashHelper.CompareHashToValue(valueHashed, valueToHash);

            // Assert
            Assert.IsFalse(comparison);
        }
    }
}
