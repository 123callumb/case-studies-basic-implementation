using Application.Requests.Vendor;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.MVCManagement;
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
        private readonly IMVCManager _MVCManager;

        public InternalResponseController(IAuthenticationManager authManager, IQuoteManager quoteManager, IQuoteResponseManager quoteResponseManager, IMVCManager MVCManager) : base(authManager)
        {
            _quoteManager = quoteManager;
            _quoteResponseManager = quoteResponseManager;
            _MVCManager = MVCManager;
        }

        /// <summary>
        /// Loads the internal Vendor Quotes page. 
        /// A list of all vendor quotes and their statuses are displayed here.
        /// </summary>
        /// <returns>Returns a View</returns>
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

        /// <summary>
        /// Loads the Quote Responder modal when 'Open Quote' button is pressed on a quote.
        /// The modal contains all previous responses for the loaded quote and an ability to approve/reject 
        /// the quote if it is awaiting a response.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns a JsonResult</returns>
        [RequireUser(UserTypeEnum.INTERNAL)]
        [HttpPost]
        public async Task<IActionResult> QuoteResponderModal([FromBody] BaseQuoteRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null.");

                var quote = await _quoteManager.GetQuote(request.QuoteID);
                string modalAsString = await _MVCManager.RenderViewToString(this, quote);
                return new JsonResult(new { success = true, data = modalAsString });

            }
            catch (Exception ex)
            {
                return new RedirectToActionResult("Index", "Error", new { message = "Failed to load quote." });
            }
        }

        /// <summary>
        /// Is called when an internal user on the Vendor Quotes page responds to quote from within a Quote Responder Modal.
        /// The quote is updated when the user either approves or rejects it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns a JsonResult</returns>
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
