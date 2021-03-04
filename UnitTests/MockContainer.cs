using Moq;
using Services.AuthenticationManagement;
using Services.GenericRepository;
using Services.QuoteManagement;
using Services.UserManagement;

namespace UnitTests
{
    public class MockContainer
    {
        public MockContainer()
        {
            GenericQuerier = new Mock<IGenericQuerier>();
            GenericRepo = new Mock<IGenericRepo>();
            AuthenticationController = new Mock<IAuthenticationManager>();
            QuoteManager = new Mock<IQuoteManager>();
            UserManager = new Mock<IUserManager>();
        }

        public Mock<IGenericQuerier> GenericQuerier { get; set; }
        public Mock<IGenericRepo> GenericRepo { get; set; }
        public Mock<IAuthenticationManager> AuthenticationController { get; set; }
        public Mock<IQuoteManager> QuoteManager { get; set; }
        public Mock<IUserManager> UserManager { get; set; }
    }
}
