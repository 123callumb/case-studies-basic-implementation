using Application.Requests.Vendor;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.EntityFramework.DbEntities;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.MVCManagement;
using Services.QuoteManagement;
using Services.QuoteResponseManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class QuoteResponseController : BaseController
    {
        private readonly IQuoteManager _quoteManager;
        private readonly IQuoteResponseManager _quoteResponseManager;
        private readonly IMVCManager _mvcManager;
        public QuoteResponseController(IAuthenticationManager authManager,
                                       IQuoteManager quoteManager,
                                       IQuoteResponseManager quoteResponseManager,
                                       IMVCManager mvcManager) : base(authManager)
        {
            _quoteManager = quoteManager;
            _quoteResponseManager = quoteResponseManager;
            _mvcManager = mvcManager;
        }

        /// <summary>
        /// Loads up the html for the modal that allows for external vendor users
        /// to respond to a specific quote
        /// </summary>
        /// <param name="request">Requests a quote id fot the associated quote</param>
        /// <returns>Returns a html string for the javascript to render in a modal</returns>
        [RequireUser(UserTypeEnum.EXTERNAL)]
        [HttpPost]
        public async Task<IActionResult> QuoteResponseModal([FromBody] BaseQuoteRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null");

                var quote = await _quoteManager.GetQuote(request.QuoteID);
                string modalAsString = await _mvcManager.RenderViewToString(this, quote);
                return new JsonResult(new { success = true, data = modalAsString });
            }
            catch (Exception e)
            {
                return new RedirectToActionResult("Index", "Error", new { message = "Failed to load quote response modal" });
            }
        }
        /// <summary>
        /// For creating a new quote response for a given quote. Used by external vendor users
        /// </summary>
        /// <param name="newResponse">Wull respond with a json object for the javascript to determine if the request has been completed</param>
        /// <returns>Quote response object asks for a price and a text response.</returns>
        [RequireUser(UserTypeEnum.EXTERNAL)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuoteResponse newResponse)
        {
            try
            {
                if (newResponse == null || (newResponse.ReponseText?.Length ?? 0) == 0 || newResponse.Quote == 0)
                    throw new Exception("Request sent was not valid");

                bool didCreate = await _quoteResponseManager.Create(newResponse);
                return new JsonResult(new { success = didCreate, message = didCreate ? "Response Created" : "Failed to create response" });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to load quote response modal" });
            }
        }
    }
}
