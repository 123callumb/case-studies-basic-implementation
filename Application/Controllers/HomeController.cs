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
using Application.Requests.Vendor;
using Services.MVCManagement.Helpers;
using Services.QuoteResponseManagement;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IVendorItemManager _vendorItemManager;
        private readonly IQuoteManager _quoteManager;
        private readonly IQuoteResponseManager _quoteResponseManager;
        private readonly IUserManager _userManager;
        public HomeController(IAuthenticationManager authManager, IVendorItemManager vendorItemManager, IQuoteManager quoteManager, IQuoteResponseManager _quoteResponseManager) : base(authManager) {
            _vendorItemManager = vendorItemManager;
            _quoteManager = quoteManager;
            _quoteResponseManager = quoteResponseManager;
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
                qr.success = await _quoteManager.RequestQuote(requestedItem, quantity);

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
                var vendorQuotes = await _quoteManager.GetQuotes();
                var viewModel = new VendorQuoteViewModel(sessionUser, vendorQuotes);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ErrorController", new { errorMessage = ex.Message });
            }
        }

        //temp location        
        [RequireUser(UserTypeEnum.INTERNAL)]
        [HttpPost]
        public async Task<IActionResult> QuoteResponderModal([FromBody] BaseQuoteRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null.");

                var quote = await _quoteManager.GetQuote(request.QuoteID);
                if(quote.Responses.Find(x=>x.Status.AsEnum == QuoteStatusEnum.AWAITING_REVIEW) != null)
                {                   
                    //can filter this modal to only pop up when there is a quote awaiting review.
                }
                string modalAsString = await this.RenderViewToString(quote);
                return new JsonResult(new { success = true, data = modalAsString });

            }catch(Exception ex)
            {
                return new RedirectToActionResult("Index", "Error", new { message = "Failed to load quote." });
            }
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
                else
                {

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
