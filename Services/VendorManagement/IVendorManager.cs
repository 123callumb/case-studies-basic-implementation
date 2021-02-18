using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorManagement
{
    public interface IVendorManager
    {
        Task<VendorDTO> GetVendor(int vendorId);        
    }
}
