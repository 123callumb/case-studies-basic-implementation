using Services.EntityFramework.DbEntities;
using System.Threading.Tasks;

namespace Services.QuoteResponseManagement
{
    public interface IQuoteResponseManager
    {
        Task<bool> Create(QuoteResponse response);
        Task<bool> Respond(int QuoteID, bool approved);
    }
}
