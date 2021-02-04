using Services.EntityFramework.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorItemManagement
{
    public interface IVendorItemManager
    {
        Task<List<VendorItem>> LoadVendorItems();
    }
}
