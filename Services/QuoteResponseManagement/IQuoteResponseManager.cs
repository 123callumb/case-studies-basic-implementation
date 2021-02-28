using Services.EntityFramework.DbEntities;
using System.Threading.Tasks;

namespace Services.QuoteResponseManagement
{
    public interface IQuoteResponseManager
    {
        /// <summary>
        /// Create a quote response
        /// </summary>
        /// <param name="response">Takes in a quoete response object which asks for a quote id associated with the response, a response text and a price.</param>
        /// <returns>Returns a boolean, will be true of the response is successfully created.</returns>
        Task<bool> Create(QuoteResponse response);
    }
}
