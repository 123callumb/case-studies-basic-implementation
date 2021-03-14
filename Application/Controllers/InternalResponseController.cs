using Application.Requests.Vendor;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.QuoteManagement;
using Services.QuoteResponseManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class InternalResponseController : BaseController
    {
        private readonly IQuoteManager _quoteManager;
        private readonly IQuoteResponseManager _quoteResponseManager;

        public InternalResponseController(IAuthenticationManager authManager, IQuoteManager quoteManager, IQuoteResponseManager quoteResponseManager) : base(authManager)
        {
            _quoteManager = quoteManager;
            _quoteResponseManager = quoteResponseManager;
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorQuotes()
        {
            try
            {
                var sessionUser = await GetSessionUser();
                var vendorQuotes = await _quoteManager.GetQuotes();
                var viewModel = new VendorQuoteViewModel(sessionUser, vendorQuotes);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ErrorController", new { errorMessage = ex.Message });
            }
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        [HttpPost]
        public async Task<IActionResult> QuoteResponderModal([FromBody] BaseQuoteRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null.");

                var quote = await _quoteManager.GetQuote(request.QuoteID);
                string modalAsString = await this.RenderViewToString(quote);
                return new JsonResult(new { success = true, data = modalAsString });

            }
            catch (Exception ex)
            {
                return new RedirectToActionResult("Index", "Error", new { message = "Failed to load quote." });
            }
        }

        private Task<string> RenderViewToString(Services.Models.DTOs.QuoteDTO quote)
        {
            throw new NotImplementedException();
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        [HttpPost]
        public async Task<IActionResult> Respond([FromBody] BaseQuoteRequest request)
        {
            try
            {
                if (request != null)
                {
                    bool success = await _quoteResponseManager.Respond(request.QuoteID, (bool)request.IsApproved);
                }
                return new JsonResult(new { success = true, message = "Success" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Failed to load quote response modal" });
            }
        }
    }
}
