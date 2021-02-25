using Services.Models.DTOs;
using System.Collections.Generic;
using Services.Models.Abstract;

namespace Application.ViewModels
{
    public class VendorQuoteViewModel : BaseViewModel
    {
        public VendorQuoteViewModel(AbstractUser user, List<QuoteOverviewDTO> quotes) : base(user)
        {
            Quotes = quotes;
        }
        public List<QuoteOverviewDTO> Quotes { get; set; }
    }
}