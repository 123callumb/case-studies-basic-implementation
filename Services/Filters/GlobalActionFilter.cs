using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.AuthenticationManagement;
using Services.Filters.Attributes;
using Services.Models.Enums;
using Services.SessionManagement.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Filters
{
    public class GlobalActionFilter : IAsyncActionFilter
    {
        private readonly IAuthenticationManager _authManager;
        //private RedirectToActionResult permissionError = new RedirectToActionResult("Index", "Error", new { errorMessage = "Access denied." });
        private RedirectToActionResult noSesssionResult = new RedirectToActionResult("Login", "Authentication", null);
        public GlobalActionFilter(IAuthenticationManager authManager) 
        {
            _authManager = authManager;
        }
        /// <summary>
        /// This method is called everytime a controller action is called. It ensures that the user in the current session has access to the action. 
        /// </summary>
        /// <param name="context">Current HttpContext</param>
        /// <param name="next">The intended action method.</param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userFilter = context.Filters.FirstOrDefault(f => f.GetType() == typeof(RequireUser)) as RequireUser;
            // No filter then let them access the action - not usuall safe but it'll be fine ;)
            if(userFilter == null)
            {
                await next();
                return;
            }

            var session = context.HttpContext.Session;
            if (!session.HasUserSession())
            {
                context.Result = noSesssionResult; // redirect them to login if they have no session.
                return;
            }
            
            var user = await _authManager.GetSessionUser(context.HttpContext.Session);
            if(userFilter.Get() != UserTypeEnum.ANY && user.UserType != userFilter.Get())
            {
                context.Result = noSesssionResult;
                return;
            }

            await next();
        }
    }
}
