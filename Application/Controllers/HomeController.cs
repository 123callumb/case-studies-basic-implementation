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

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> Index()
        {
            try
            {
                BaseViewModel vm = new BaseViewModel(await GetSessionUser());
                return View(vm);
            }catch(Exception ex)
            {
                return new RedirectToActionResult("Index", "Error", new { errorMessage = ex.Message });
            }
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorMenu()
        {
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }
    }
}
