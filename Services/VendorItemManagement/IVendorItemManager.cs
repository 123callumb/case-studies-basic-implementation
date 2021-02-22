using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorItemManagement
{
    public interface IVendorItemManager
    {
        Task<List<VendorItemDTO>> LoadVendorItems();
        Task<VendorItemDTO> LoadVendorItem(int ID);
        Task<List<VendorItemDTO>> SearchVendorItems(string searchString);        
    }
}
