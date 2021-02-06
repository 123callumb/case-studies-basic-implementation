using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using Services.Models.Abstract;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class BaseController : Controller
    {
        private AbstractUser _instanceUser;
        protected readonly IAuthenticationManager _authManager;
        public BaseController(IAuthenticationManager authManager)
        {
            _authManager = authManager;
        }
        protected async Task<AbstractUser> GetSessionUser()
        {
            if (_instanceUser == null)
                _instanceUser = await _authManager.GetSessionUser(HttpContext.Session);
            return _instanceUser;
        }
    }
}
