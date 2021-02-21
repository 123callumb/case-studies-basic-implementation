using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuoteManagement
{
    public interface IQuoteManager
    {
        Task<List<QuoteDTO>> GetVendorQuotes(int vendorID);
        Task<bool> RequestQuote(VendorItemDTO item, int quantity); 
    }
}
