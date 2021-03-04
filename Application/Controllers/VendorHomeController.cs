using Application.Requests.Vendor;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.QuoteManagement;
using Services.UserManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class VendorHomeController : BaseController
    {
        private readonly IQuoteManager _quoteManager;
        private readonly IUserManager _userManager;
        public VendorHomeController(
            IAuthenticationManager authenticationManager,
            IQuoteManager quoteManager,
            IUserManager userManager) : base(authenticationManager)
        {
            _quoteManager = quoteManager;
            _userManager = userManager;
        }
        /// <summary>
        /// This is for the home screen of external users, it will load up a list of thier current
        /// quotes that are active for the vendor that they work for.
        /// </summary>
        /// <returns>Returns a View</returns>
        [RequireUser(UserTypeEnum.EXTERNAL)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var sessionUser = await GetSessionUser();
                var externalUser = await _userManager.GetExternalUser(sessionUser.UserID);
                var vendorQuotes = await _quoteManager.GetVendorQuotes(externalUser.VendorID);
                var viewModel = new VendorHomeViewModel(externalUser, vendorQuotes);

                return View(viewModel);
            }
            catch(Exception e)
            {
                // not really safe to pass the exception to the error page but its fine for now for debugging
                return new RedirectToActionResult("Index", "Error", new { errorMessage = e.Message });
            }
        }
    }
}
