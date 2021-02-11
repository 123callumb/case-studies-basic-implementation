using Microsoft.EntityFrameworkCore;
using Services.GenericRepository;
using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuoteManagement.Implementation
{
    public class QuoteManager : IQuoteManager
    {
        private readonly IGenericQuerier _genericQuerier;
        public QuoteManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }
        public async Task<List<QuoteDTO>> GetVendorQuotes(int vendorID)
        {
            return await _genericQuerier.Load(QuoteDTO.MapToDTO, w => w.VendorItem.VendorId == vendorID).ToListAsync();
        }
    }
}
