using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorItemManagement
{
    public interface IVendorItemManager
    {
        Task<List<VendorItemDTO>> LoadVendorItems();

        Task<List<VendorItemDTO>> SearchVendorItems(string searchString);
    }
}
