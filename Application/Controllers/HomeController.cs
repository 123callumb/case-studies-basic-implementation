using System;
using System.Threading.Tasks;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IAuthenticationManager authManager) : base(authManager) {}

        /// <summary>
        /// The homescreen for the internal users. It is loaded straight after logging in and displays
        /// a grid of possible further menus.
        /// </summary>
        /// <returns>Returns a View</returns>
        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> Index()
        { 
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }

        /// <summary>
        /// The internal vendor management menu, it is accessed from the homescreen.
        /// This menu splits into 3 vendor related menus: Vendor Catalogue, Vendor List and Vendor Quotes.
        /// </summary>
        /// <returns>Returns a View</returns>
        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorMenu()
        {
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }
    }
}
