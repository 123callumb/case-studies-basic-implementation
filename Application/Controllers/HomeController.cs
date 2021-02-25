using System;
using System.Threading.Tasks;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.VendorItemManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.Models.DTOs;
using System.Collections.Generic;
using Services.QuoteManagement;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.UserManagement;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IVendorItemManager _vendorItemManager;
        private readonly IQuoteManager _quoteManager;
        private readonly IUserManager _userManager;
        public HomeController(IAuthenticationManager authManager, IVendorItemManager vendorItemManager, IQuoteManager quoteManager) : base(authManager) {
            _vendorItemManager = vendorItemManager;
            _quoteManager = quoteManager;
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> Index()
        { 
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorMenu()
        {
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorCatalogue()
        {
            try
            {
                List<VendorItemDTO> vendorItems = await _vendorItemManager.LoadVendorItems();
                VendorCatalogueViewModel vm = new VendorCatalogueViewModel(await GetSessionUser(), vendorItems);
                return View(vm);
            }catch(Exception ex)
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
                return View("VendorCatalogue", vm);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ErrorController", new { errorMessage = ex.Message });
            }
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        [HttpPost]
        public async Task<JsonResult> RequestVendorQuote(int vendorItemID, int quantity, string searchTerm = null)
        {
            try
            {
                VendorItemDTO requestedItem = _vendorItemManager.LoadVendorItem(vendorItemID).Result;
                //upload quote 
                QuantityResult qr = new QuantityResult(false, requestedItem.ItemName, quantity);
                qr.success = _quoteManager.RequestQuote(requestedItem, quantity).Result;

                //return JSON
                string jsonString = JsonSerializer.Serialize(qr);
                return Json(jsonString);                

            }catch(Exception ex)
            {
                return Json("error");                
            }
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorQuotes()
        {
            try
            {
                var sessionUser = await GetSessionUser();
                var vendorQuotes = await _quoteManager.GetVendorQuotes();
                var viewModel = new VendorQuoteViewModel(sessionUser, vendorQuotes);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ErrorController", new { errorMessage = ex.Message });
            }
        }
    }
}
