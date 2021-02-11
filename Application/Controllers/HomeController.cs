using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IAuthenticationManager authManager) : base(authManager) { }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public IActionResult Index()
        {
            BaseViewModel vm = new BaseViewModel(GetSessionUser().Result);
            return View(vm);
        }

        public IActionResult VendorMenu()
        {
            BaseViewModel vm = new BaseViewModel(GetSessionUser().Result);
            return View(vm);
        }

    }
}
