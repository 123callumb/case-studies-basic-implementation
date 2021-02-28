using Services.Models.DTOs;
using System.Threading.Tasks;

namespace Services.VendorManagement
{
    public interface IVendorManager
    {
        /// <summary>
        /// Loading vendor entity, for vendors associateed with abc
        /// </summary>
        /// <param name="vendorId">Use a vendors unique id to get.</param>
        /// <returns>Returns a vendor dto</returns>
        Task<VendorDTO> GetVendor(int vendorId);        
    }
}
