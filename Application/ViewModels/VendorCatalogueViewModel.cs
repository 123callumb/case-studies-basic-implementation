using Services.Models.Abstract;
using Services.Models.DTOs;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class VendorCatalogueViewModel : BaseViewModel
    {
        public VendorCatalogueViewModel(AbstractUser user, List<VendorItemDTO> vendorItems) : base(user)
        {
            VendorItems = vendorItems;
        }
        public List<VendorItemDTO> VendorItems { get; set; }
    }
}
