using Services.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.VendorItemManagement
{
    public interface IVendorItemManager
    {
        /// <summary>
        /// Load all vendor items that are in the abc system
        /// </summary>
        /// <returns>A list of vendro items containiing thier details such as name and description.</returns>
        Task<List<VendorItemDTO>> LoadVendorItems();
        /// <summary>
        /// Get a vendor item associated with a specific id
        /// </summary>
        /// <param name="ID">Requires a vendor items unique id.</param>
        /// <returns>Returns a vendor item specific to the give id</returns>
        Task<VendorItemDTO> LoadVendorItem(int ID);
        /// <summary>
        /// Search vendor item by seeing ifthe given string is contained within the items namn
        /// </summary>
        /// <param name="searchString">Search string</param>
        /// <returns>Can return a list of 1 - x or an empty list if nothing is found.</returns>
        Task<List<VendorItemDTO>> SearchVendorItems(string searchString);        
    }
}

