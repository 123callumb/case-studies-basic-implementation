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
        /// <summary>
        /// Used as a shared mthod across all controllers to quickly access the 
        /// current user session. 
        /// </summary>
        /// <returns>Returns the active user session, will reutrn null if there is no user session</returns>
        protected async Task<AbstractUser> GetSessionUser()
        {
            if (_instanceUser == null)
                _instanceUser = await _authManager.GetSessionUser(HttpContext.Session);
            return _instanceUser;
        }
    }
}
