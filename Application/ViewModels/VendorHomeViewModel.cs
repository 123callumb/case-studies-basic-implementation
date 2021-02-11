using Services.Models.Abstract;
using Services.Models.DTOs;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class VendorHomeViewModel : BaseViewModel
    {
        public VendorHomeViewModel(AbstractUser user, List<QuoteDTO> quotes) : base(user)
        {
            Quotes = quotes;
        }
        public List<QuoteDTO> Quotes { get; set; }
    }
}
