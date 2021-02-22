using Services.EntityFramework.DbEntities;
using Services.GenericRepository;
using Services.Models.Enums;
using System.Threading.Tasks;

namespace Services.QuoteResponseManagement.Implementation
{
    public class QuoteResponseManager : IQuoteResponseManager
    {
        private readonly IGenericRepo _genericRepo;
        public QuoteResponseManager(IGenericRepo genericRepo)
        {
            _genericRepo = genericRepo;
        }
        public async Task<bool> Create(QuoteResponse response)
        {
            response.QuoteStatusId = (int)QuoteStatusEnum.AWAITING_REVIEW;
            return (await _genericRepo.Add(response)) > 0;
        }
    }
}
