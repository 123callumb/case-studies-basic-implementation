using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.QuoteManagement.Implementation

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class QuoteManagerTests
    {
        private QuoteManager Manager()
        {
            return new QuoteManager();
        }

        [TestMethod]
        public async Task GetQuote_Success()
        {
            QuoteManager quoteManager = new QuoteManager();
        }
    }
}
