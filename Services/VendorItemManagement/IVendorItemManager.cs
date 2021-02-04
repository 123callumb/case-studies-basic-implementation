using Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorItemManagement
{
    public interface IVendorItemManager
    {
        Task<List<VendorItemDTO>> LoadVendorItems();
    }
}
