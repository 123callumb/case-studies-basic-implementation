using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() { }

        public IActionResult Index()
        {
            return View();
        }

    }
}
