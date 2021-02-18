using Services.Models.DTOs;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class VendorHomeViewModel : ExternalBaseViewModel
    {
        public VendorHomeViewModel(ExternalUserDTO user, List<QuoteOverviewDTO> quotes) : base(user)
        {
            Quotes = quotes;
        }
        public List<QuoteOverviewDTO> Quotes { get; set; }
    }
}
