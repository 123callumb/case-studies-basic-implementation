using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuoteManagement
{
    public interface IQuoteManager
    {
        /// <summary>
        /// Used to request a quote from a vendor 
        /// </summary>
        /// <param name="item">The item in question</param>
        /// <param name="quantity">The amount of the item in question requested</param>
        /// <returns>Returns a bool, true if the request is created.</returns>
        Task<bool> RequestQuote(VendorItemDTO item, int quantity);
        /// <summary>
        /// Load all quotes that are currently on the system 
        /// </summary>
        /// <returns>A List of quotes</returns>
        Task<List<QuoteOverviewDTO>> GetQuotes();
        /// <summary>
        /// Get a list of all quotes associated with a specific vendor
        /// </summary>
        /// <param name="vendorID">Unique vendor id</param>
        /// <returns>Returns a list of quote overviews, the quote overview object is a small summaty of the quote without its quote responses attatched.</returns>
        Task<List<QuoteOverviewDTO>> GetVendorQuotes(int vendorID);
        /// <summary>
        /// A full quote with its summary and quote responses if it has any
        /// </summary>
        /// <param name="quoteID">Unique identifier for the quote</param>
        /// <returns>Returns a quote</returns>
        Task<QuoteDTO> GetQuote(int quoteID);
    }
}
