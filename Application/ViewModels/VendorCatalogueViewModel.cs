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
        public bool success { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
    }

    public class VendorCatalogueViewModel : BaseViewModel
    {
        
        public VendorCatalogueViewModel(AbstractUser user, List<VendorItemDTO> vendorItems, QuantityResult quantityRes = null) : base(user)
        {
            VendorItems = vendorItems;
            if (quantityRes == null) quantiyResult = new QuantityResult();
            else quantiyResult = quantityRes;
        }
        public QuantityResult quantiyResult;
        public List<VendorItemDTO> VendorItems { get; set; }
    }
}
