using Services.Models.Abstract;
using Services.Models.DTOs;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class QuantityResult
    {
        public QuantityResult() { }
        public QuantityResult(bool s, string i, int q)
        {
            success = s;
            itemName = i;
            quantity = q;
        }
        public bool success = false;
        public string itemName = null;
        public int quantity = 0;
    }

    public class VendorCatalogueViewModel : BaseViewModel
    {
        
        public VendorCatalogueViewModel(AbstractUser user, List<VendorItemDTO> vendorItems, QuantityResult quantityRes = null) : base(user)
        {
            VendorItems = vendorItems;
            QuantityResult quantiyResult = quantityRes;
        }
        public List<VendorItemDTO> VendorItems { get; set; }
    }
}
