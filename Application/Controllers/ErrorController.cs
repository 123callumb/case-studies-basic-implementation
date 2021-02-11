using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class ErrorController : Controller
    {
        public JsonResult Index(string errorMessage = "unknown error")
        {
            return new JsonResult(new { success = false, message = errorMessage });
        }
    }
}
