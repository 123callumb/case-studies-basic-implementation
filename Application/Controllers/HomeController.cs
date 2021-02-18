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

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IVendorItemManager _vendorItemManager;
        public HomeController(IAuthenticationManager authManager, IVendorItemManager vendorItemManager) : base(authManager) {
            _vendorItemManager = vendorItemManager;
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
        public async Task<IActionResult> VendorCatalogueSearch(string searchTerm) {

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
    }
}
