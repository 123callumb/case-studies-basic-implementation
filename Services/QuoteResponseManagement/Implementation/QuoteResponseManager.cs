using Services.EntityFramework.DbEntities;
using Services.GenericRepository;
using Services.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.QuoteResponseManagement.Implementation
{
    public class QuoteResponseManager : IQuoteResponseManager
    {
        private readonly IGenericRepo _genericRepo;
        private readonly IGenericQuerier _genericQuerier;
        public QuoteResponseManager(IGenericRepo genericRepo, IGenericQuerier genericQuerier)
        {
            _genericRepo = genericRepo;
            _genericQuerier = genericQuerier;
        }
        public async Task<bool> Create(QuoteResponse response)
        {
            response.QuoteStatusId = (int)QuoteStatusEnum.AWAITING_REVIEW;
            return (await _genericRepo.Add(response)) > 0;
        }
        public async Task<bool> Respond(int QuoteID, bool approved)
        {
            List<QuoteResponse> q = _genericQuerier.LoadEntity<QuoteResponse>(x => x.QuoteId == QuoteID).ToList();
            if (q != null)
            {               
                q.Where(x => x.QuoteStatusId == 1).FirstOrDefault().QuoteStatusId = approved? 3 : 2;
            }
            return (await _genericRepo.SaveChanges()) > 0;
        }
    }
}
