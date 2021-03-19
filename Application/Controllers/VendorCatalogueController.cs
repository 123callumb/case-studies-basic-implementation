using Application.Requests.QuoteRequest;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.DTOs;
using Services.Models.Enums;
using Services.QuoteManagement;
using Services.QuoteResponseManagement;
using Services.VendorItemManagement;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class VendorCatalogueController : BaseController
    {
        private readonly IVendorItemManager _vendorItemManager;
        private readonly IQuoteManager _quoteManager;
        private readonly IQuoteResponseManager _quoteResponseManager;

        public VendorCatalogueController(IAuthenticationManager authManager, IVendorItemManager vendorItemManager, IQuoteManager quoteManager, IQuoteResponseManager quoteResponseManager) : base(authManager)
        {
            _vendorItemManager = vendorItemManager;
            _quoteManager = quoteManager;
            _quoteResponseManager = quoteResponseManager;
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<VendorItemDTO> vendorItems = await _vendorItemManager.LoadVendorItems();
                VendorCatalogueViewModel vm = new VendorCatalogueViewModel(await GetSessionUser(), vendorItems);
                return View(vm);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ErrorController", new { errorMessage = ex.Message });
            }
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorCatalogueSearch(string searchTerm)
        {
            try
            {
                ViewBag.SearchTerm = searchTerm;
                List<VendorItemDTO> vendorItems;

                if (searchTerm == null) vendorItems = await _vendorItemManager.LoadVendorItems();
                else vendorItems = await _vendorItemManager.SearchVendorItems(searchTerm);

                VendorCatalogueViewModel vm = new VendorCatalogueViewModel(await GetSessionUser(), vendorItems);
                return View("Index", vm);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { errorMessage = ex.Message });
            }
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        [HttpPost]
        public async Task<JsonResult> RequestVendorQuote([FromBody] VendorQuoteRequest request)
        {
            try
            {
                VendorItemDTO requestedItem = _vendorItemManager.LoadVendorItem(request.VendorItemID).Result;
                //upload quote 
                QuantityResult qr = new QuantityResult(false, requestedItem.ItemName, request.Quantity);
                qr.success = await _quoteManager.RequestQuote(requestedItem, request.Quantity);

                //return JSON
                string jsonString = JsonSerializer.Serialize(qr);
                return new JsonResult(new { success = true, data = jsonString });
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }
    }
}
