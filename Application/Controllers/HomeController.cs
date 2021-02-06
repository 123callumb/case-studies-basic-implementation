using Microsoft.AspNetCore.Mvc;
using Services.Filters.Attributes;
using Services.Models.Enums;

namespace Application.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() { }

        [RequireUser(UserTypeEnum.INTERNAL)]
        public IActionResult Index()
        {
            return View();
        }

    }
}
