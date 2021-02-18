using Application.Requests.Vendor;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.EntityFramework.DbEntities;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.MVCManagement.Helpers;
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
        public QuoteResponseController(IAuthenticationManager authManager,
                                       IQuoteManager quoteManager,
                                       IQuoteResponseManager quoteResponseManager) : base(authManager)
        {
            _quoteManager = quoteManager;
            _quoteResponseManager = quoteResponseManager;
        }


        [RequireUser(UserTypeEnum.EXTERNAL)]
        [HttpPost]
        public async Task<IActionResult> QuoteResponseModal([FromBody] BaseQuoteRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null");

                var quote = await _quoteManager.GetQuote(request.QuoteID);
                string modalAsString = await this.RenderViewToString(quote);
                return new JsonResult(new { success = true, data = modalAsString });
            }
            catch (Exception e)
            {
                return new RedirectToActionResult("Index", "Error", new { message = "Failed to load quote response modal" });
            }
        }

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
