using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuoteManagement
{
    public interface IQuoteManager
    {
        Task<bool> RequestQuote(VendorItemDTO item, int quantity); 
        Task<List<QuoteOverviewDTO>> GetVendorQuotes(int vendorID);
        Task<QuoteDTO> GetQuote(int quoteID);
    }
}
