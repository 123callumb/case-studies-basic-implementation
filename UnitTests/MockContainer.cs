using Moq;
using Services.AuthenticationManagement;
using Services.GenericRepository;
using Services.MVCManagement;
using Services.QuoteManagement;
using Services.QuoteResponseManagement;
using Services.UserManagement;
using Services.VendorItemManagement;

namespace UnitTests
{
    public class MockContainer
    {
        public MockContainer()
        {
            GenericQuerier = new Mock<IGenericQuerier>();
            GenericRepo = new Mock<IGenericRepo>();
            AuthenticationManager = new Mock<IAuthenticationManager>();
            QuoteManager = new Mock<IQuoteManager>();
            UserManager = new Mock<IUserManager>();
            QuoteResponseManager = new Mock<IQuoteResponseManager>();
            VendorItemManager = new Mock<IVendorItemManager>();
            MVCManager = new Mock<IMVCManager>();
        }

        public Mock<IGenericQuerier> GenericQuerier { get; set; }
        public Mock<IGenericRepo> GenericRepo { get; set; }
        public Mock<IAuthenticationManager> AuthenticationManager { get; set; }
        public Mock<IQuoteManager> QuoteManager { get; set; }
        public Mock<IQuoteResponseManager> QuoteResponseManager { get; set; }
        public Mock<IUserManager> UserManager { get; set; }
        public Mock<IMVCManager> MVCManager { get; set; }
        public Mock<IVendorItemManager> VendorItemManager { get; set; }
    }
}
