﻿using Application.Requests.QuoteRequest;
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

        /// <summary>
        /// Loads the view for the vendor catalogue. The vendor catalogue loads all vendor items and displays them in a list.
        /// Users can request quotes for vendor items from this page.
        /// </summary>
        /// <returns>Returns a View</returns>
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

        /// <summary>
        /// Searches the vendor items using the search term. 
        /// Called when an item is searched for in the Vendor Catalogue.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns>Returns the Vendor Catalogue View with a filtered list of items</returns>
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

        /// <summary>
        /// Called when a user requests a quote for an item in the Vendor Catalogue.
        /// The quote is created and can be seen on the 'Vendor Quotes' page.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns a JsonResult with success data</returns>
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
