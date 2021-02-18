using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuoteManagement
{
    public interface IQuoteManager
    {
        Task<List<QuoteOverviewDTO>> GetVendorQuotes(int vendorID);
        Task<QuoteDTO> GetQuote(int quoteID);
    }
}
