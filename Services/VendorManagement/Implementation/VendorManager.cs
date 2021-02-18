using Microsoft.EntityFrameworkCore;
using Services.Models.DTOs;
using Services.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorManagement.Implementation
{
    public class VendorManager : IVendorManager
    {
        private readonly IGenericQuerier _genericQuerier;
        public VendorManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }

        public async Task<VendorDTO> GetVendor(int VendorId)
        {
            return await _genericQuerier.Load(VendorDTO.MapToDTO, v => v.VendorId == VendorId).FirstOrDefaultAsync();
        }
    }
}
