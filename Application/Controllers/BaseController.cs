using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.SessionManagement.Helpers;

namespace Application.Controllers
{
    public class BaseController : Controller
    {
        private IUserDTO _instanceUser;
        public BaseController()
        {

        }
        protected IUserDTO GetSessionUser()
        {
            if (_instanceUser == null)
                _instanceUser = HttpContext.Session.GetUserSession();
            return _instanceUser;
        }
    }
}
