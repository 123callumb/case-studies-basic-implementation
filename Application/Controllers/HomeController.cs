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
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public async Task<IActionResult> VendorMenu()
        {
            BaseViewModel vm = new BaseViewModel(await GetSessionUser());
            return View(vm);
        }
    }
}
